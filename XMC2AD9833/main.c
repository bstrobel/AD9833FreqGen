/*
 * main.c
 *
 *  Created on: 2016 May 14 17:14:44
 *  Author: Bernd
 */

#include <DAVE.h>                 //Declarations from DAVE Code Generation (includes SFR declaration)
#include <string.h>
#include <stdlib.h>
#include "AD9833.h"
#include "MCP41010.h"

#define BUFF_SIZE 25
char welcome_str[] = "XMC2GO/AD9833 WaveGen\r\n";
char err_msg_buff_ovflw[] = "ERROR: Input Buffer Overflow\r\n";
char separators[] = { ',', ';' };
char rec_data[BUFF_SIZE];
uint8_t rec_data_idx = 0;

/**

 * @brief main() - Application entry point
 *
 * <b>Details of function</b><br>
 * This routine is the application entry point. It is invoked by the device startup code. It is responsible for
 * invoking the APP initialization dispatcher routine - DAVE_Init() and hosting the place-holder for user application
 * code.
 */

int main(void) {
	DAVE_STATUS_t status;

	status = DAVE_Init(); /* Initialization of DAVE APPs  */
	XMC_SPI_CH_Start(SPI_CONFIG_0.channel);	// SPI Initialization
	XMC_SPI_CH_EnableEvent(SPI_CONFIG_0.channel, XMC_SPI_CH_EVENT_TRANSMIT_SHIFT);
	DIGITAL_IO_SetOutputHigh(&DIGITAL_IO_SSL2); // MCP41010 has a /CS (inverted)
	DIGITAL_IO_SetOutputLow(&DIGITAL_IO_LED1);
	DIGITAL_IO_SetOutputLow(&DIGITAL_IO_LED2);

	if (status == DAVE_STATUS_FAILURE) {
		/* Placeholder for error handler code. The while loop below can be replaced with an user error handler. */
		XMC_DEBUG("DAVE APPs initialization failed\n");

		while (1U) {

		}
	}
	AD9833_StartSPI();
	AD9833_Reset();

	UART_Transmit(&UART_0, (uint8_t*) welcome_str, sizeof(welcome_str) - 1);

	uint8_t inchar = 0;

	/* Placeholder for user application code. The while loop below can be replaced with user application code. */
	while (1U) {
		//Check if receive FIFO event is generated
		if (UART_Receive(&UART_0, &inchar, 1) == UART_STATUS_SUCCESS) {
			//Read received data
			if (inchar == '\n')
				continue;
			rec_data[rec_data_idx] = inchar;
			UART_TransmitWord(&UART_0, inchar);
			if (rec_data[rec_data_idx] == '\r' || rec_data[rec_data_idx] == 0) {
				if (rec_data[0] == 0)
					continue;
				//We received a command or the buffer was full. Start parsing it!
				rec_data[rec_data_idx] = 0; // terminate the string with a 0x0
				//UART_Transmit(&UART_0, (uint8_t*) rec_data, rec_data_idx + 1);
				UART_TransmitWord(&UART_0, '\r');
				UART_TransmitWord(&UART_0, '\n');
				rec_data_idx = 0;
				char* ptr = strtok(rec_data, separators);
				uint8_t idx = 0;
				char* tk[4];
				while (idx < 4 && ptr != NULL) {
					tk[idx++] = ptr;
					ptr = strtok(NULL, separators);
				}

				AD9833_StartSPI();
				if (idx > 0)
				{
					AD9833_SetFreq(0, atoi(tk[1]));
				}
				if (idx > 1)
				{
					AD9833_SetPhase(0, atoi(tk[2]));
				}

				if (tk[0] != NULL) {
					switch (tk[0][0]) {
					case 's':
						AD9833_SelFreqPhase(0, 0, SINUS);
						break;
					case 't':
						AD9833_SelFreqPhase(0, 0, TRIANGLE);
						break;
					case 'q':
						AD9833_SelFreqPhase(0, 0, SQUARE);
						break;
					default:
					case 'r':
						AD9833_Reset();
						memset(rec_data, 0, BUFF_SIZE);
						DIGITAL_IO_SetOutputLow(&DIGITAL_IO_LED1);
						continue;
					}
					DIGITAL_IO_SetOutputHigh(&DIGITAL_IO_LED1);
				}
				uint8_t output = 127;
				if (idx>2)
				{
					output = atoi(tk[3]);
				}
				MCP41010_StartSPI();
				MCP41010_set(output);
				memset(rec_data, 0, BUFF_SIZE);
			} else {
				rec_data_idx++;
				if (rec_data_idx >= BUFF_SIZE) {
					UART_Transmit(&UART_0, (uint8_t*) err_msg_buff_ovflw,
							sizeof(err_msg_buff_ovflw) - 1);
					rec_data_idx = 0;
				}
			}
		}

	}
}