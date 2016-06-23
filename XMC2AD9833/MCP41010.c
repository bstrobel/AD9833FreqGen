/*
 * MCP41010.c
 *
 *  Created on: May 15, 2016
 *      Author: Bernd
 */
#include <DAVE.h>
#include "MCP41010.h"

void MCP41010_StartSPI(void)
{
	XMC_SPI_CH_DisableSlaveSelect(SPI_CONFIG_0.channel);
	XMC_SPI_CH_EnableSlaveSelect(SPI_CONFIG_0.channel, XMC_SPI_CH_SLAVE_SELECT_1);
	DIGITAL_IO_SetOutputLow(&DIGITAL_IO_SSL2);
	while (DIGITAL_IO_GetInput(&DIGITAL_IO_SSL2))
	{

	}
}

static void MCP41010_WaitEndSPI(void)
{
	while((XMC_SPI_CH_GetStatusFlag(SPI_CONFIG_0.channel) &	XMC_SPI_CH_STATUS_FLAG_TRANSMIT_SHIFT_INDICATION) ==0U)
	{
		/* wait for ACK */
	}
	//XMC_SPI_CH_DisableSlaveSelect(SPI_CONFIG_0.channel);
	DIGITAL_IO_SetOutputHigh(&DIGITAL_IO_SSL2);
}

void MCP41010_set(uint8_t value)
{
	uint16_t word = (1U << MCP41010_BIT_C0) | (1U << MCP41010_BIT_P0) | value;
	XMC_SPI_CH_ClearStatusFlag(SPI_CONFIG_0.channel,XMC_SPI_CH_STATUS_FLAG_TRANSMIT_SHIFT_INDICATION);
	XMC_SPI_CH_Transmit(SPI_CONFIG_0.channel, word, XMC_SPI_CH_MODE_STANDARD);
	MCP41010_WaitEndSPI();
}


