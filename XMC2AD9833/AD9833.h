/*
 * AD9833.h
 *
 *  Created on: May 8, 2016
 *      Author: Bernd
 */

#ifndef AD9833_H_
#define AD9833_H_

#define AD9833_MCLK_FREQ 25000000

#define AD9833_B_CTRL_BIT_H 15
#define AD9833_B_CTRL_BIT_L 14
#define AD9833_B_B28 13
#define AD9833_B_HLB 12
#define AD9833_B_FSELECT 11
#define AD9833_B_PSELECT 10
#define AD9833_B_RESERVED_D9 9
#define AD9833_B_RESET 8
#define AD9833_B_SLEEP1 7
#define AD9833_B_SLEEP12 6
#define AD9833_B_OPBITEN 5
#define AD9833_B_RESERVED_D4 4
#define AD9833_B_DIV2 3
#define AD9833_B_RESERVED_D2 2
#define AD9833_B_MODE 1
#define AD9833_B_RESERVED_D0 0

#define AD9833_CTRL_CONF 0U
#define AD9833_CTRL_SET_FREQ_0 (1 << AD9833_B_CTRL_BIT_L)
#define AD9833_CTRL_SET_FREQ_1 (1 << AD9833_B_CTRL_BIT_H)
#define AD9833_CTRL_SET_PHASE_0 ( \
		1 << AD9833_B_CTRL_BIT_L | \
		1 << AD9833_B_CTRL_BIT_H)
#define AD9833_CTRL_SET_PHASE_1 ( \
		1 << AD9833_B_CTRL_BIT_L |\
		1 << AD9833_B_CTRL_BIT_H)
#define AD9833_RESET (1 << AD9833_B_RESET)
#define AD9833_LSB_MSB_CONSECUTIVE (1 << AD9833_B_B28)
#define AD9833_SLEEP_DAC (1 << AD9833_B_SLEEP1)
#define AD9833_SLEEP_INTERNAL_CLOCK (1 << AD9833_B_SLEEP12)
#define AD9833_OUT_SINUS 0
#define AD9833_OUT_TRIANGLE (1 << AD9833_B_MODE)
#define AD9833_OUT_DAC_MSB_DIV2 ( \
		1 << AD9833_B_OPBITEN)
#define AD9833_OUT_DAC_MSB ( \
		1 << AD9833_B_OPBITEN |\
		1 << AD9833_B_DIV2)

enum AD9833_OUT_TYPE {
	RESET,
	SINUS,
	TRIANGLE,
	SQUARE
};


void AD9833_StartSPI(void);
void AD9833_Reset(void);
void AD9833_SetFreq(int which_freq, uint32_t freq_value);
void AD9833_SetPhase(int which_phase, uint16_t phase_value);
void AD9833_SelFreqPhase(int which_freq, int which_phase, int waveform);

#endif /* AD9833_H_ */
