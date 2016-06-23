#include <DAVE.h>
#include "AD9833.h"

void AD9833_StartSPI(void)
{
	XMC_SPI_CH_DisableSlaveSelect(SPI_CONFIG_0.channel);
	XMC_SPI_CH_EnableSlaveSelect(SPI_CONFIG_0.channel, XMC_SPI_CH_SLAVE_SELECT_0);
}

static void AD9833_WaitEndSPI(void)
{
	while((XMC_SPI_CH_GetStatusFlag(SPI_CONFIG_0.channel) &	XMC_SPI_CH_STATUS_FLAG_TRANSMIT_SHIFT_INDICATION) ==0U)
	{
		/* wait for ACK */
	}
}

void AD9833_Reset(void)
{
	uint16_t cword = AD9833_RESET | AD9833_LSB_MSB_CONSECUTIVE;
	XMC_SPI_CH_ClearStatusFlag(SPI_CONFIG_0.channel,XMC_SPI_CH_STATUS_FLAG_TRANSMIT_SHIFT_INDICATION);
	XMC_SPI_CH_Transmit(SPI_CONFIG_0.channel, cword, XMC_SPI_CH_MODE_STANDARD);
}

void AD9833_SetFreq(int which_freq, uint32_t freq_value)
{
	uint16_t freqsel;
	if (!which_freq)
	{
		freqsel = AD9833_CTRL_SET_FREQ_0;
	}
	else
	{
		freqsel = AD9833_CTRL_SET_FREQ_1;
	}
	uint64_t temp = (1ULL << 28) * freq_value;
	temp /= AD9833_MCLK_FREQ;
	uint16_t lsb = (temp & ~(1 << AD9833_B_CTRL_BIT_H | 1 << AD9833_B_CTRL_BIT_L)) | freqsel;
	uint16_t msb = (temp >> 14) | freqsel;
	XMC_SPI_CH_ClearStatusFlag(SPI_CONFIG_0.channel,XMC_SPI_CH_STATUS_FLAG_TRANSMIT_SHIFT_INDICATION);
	XMC_SPI_CH_Transmit(SPI_CONFIG_0.channel, lsb, XMC_SPI_CH_MODE_STANDARD);
	AD9833_WaitEndSPI();
	XMC_SPI_CH_ClearStatusFlag(SPI_CONFIG_0.channel,XMC_SPI_CH_STATUS_FLAG_TRANSMIT_SHIFT_INDICATION);
	XMC_SPI_CH_Transmit(SPI_CONFIG_0.channel, msb, XMC_SPI_CH_MODE_STANDARD);
	AD9833_WaitEndSPI();
}

void AD9833_SetPhase(int which_phase, uint16_t phase_value)
{
	uint16_t phasesel;
	if (!which_phase)
	{
		phasesel = AD9833_CTRL_SET_PHASE_0;
	}
	else
	{
		phasesel = AD9833_CTRL_SET_PHASE_1;
	}
	uint16_t phase = phase_value*((1 << 11)/180U);
	phase |= phasesel;
	XMC_SPI_CH_ClearStatusFlag(SPI_CONFIG_0.channel,XMC_SPI_CH_STATUS_FLAG_TRANSMIT_SHIFT_INDICATION);
	XMC_SPI_CH_Transmit(SPI_CONFIG_0.channel, phase, XMC_SPI_CH_MODE_STANDARD);
	AD9833_WaitEndSPI();
}

void AD9833_SelFreqPhase(int which_freq, int which_phase, int waveform)
{
	uint16_t word = AD9833_LSB_MSB_CONSECUTIVE;
	switch (which_freq)
	{
	case 0:
		word &= ~(1 << AD9833_B_FSELECT);
		break;
	case 1:
		word |= (1 << AD9833_B_FSELECT);
	}
	switch (which_phase)
	{
	case 0:
		word &= ~(1 << AD9833_B_PSELECT);
		break;
	case 1:
		word |= (1 << AD9833_B_PSELECT);
	}
	switch (waveform)
	{
	case SINUS:
		word |= AD9833_OUT_SINUS;
		break;
	case TRIANGLE:
		word |= AD9833_OUT_TRIANGLE;
		break;
	case SQUARE:
		word |= AD9833_OUT_DAC_MSB;
	}
	XMC_SPI_CH_ClearStatusFlag(SPI_CONFIG_0.channel,XMC_SPI_CH_STATUS_FLAG_TRANSMIT_SHIFT_INDICATION);
	XMC_SPI_CH_Transmit(SPI_CONFIG_0.channel, word, XMC_SPI_CH_MODE_STANDARD);
	AD9833_WaitEndSPI();
}
