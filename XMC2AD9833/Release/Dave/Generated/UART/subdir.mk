################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../Dave/Generated/UART/uart.c \
../Dave/Generated/UART/uart_conf.c 

OBJS += \
./Dave/Generated/UART/uart.o \
./Dave/Generated/UART/uart_conf.o 

C_DEPS += \
./Dave/Generated/UART/uart.d \
./Dave/Generated/UART/uart_conf.d 


# Each subdirectory must supply rules for building sources it contributes
Dave/Generated/UART/%.o: ../Dave/Generated/UART/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: ARM-GCC C Compiler'
	"C:\Programs\Dave4\eclipse\ARM-GCC-49/bin/arm-none-eabi-gcc" -MMD -MT "$@" -DXMC1100_Q024x0064 -I"C:\Users\Bernd\Documents\AD9833DDS\AD9833FreqGen\XMC2AD9833\Libraries\XMCLib\inc" -I"C:\Users\Bernd\Documents\AD9833DDS\AD9833FreqGen\XMC2AD9833/Libraries/CMSIS/Include" -I"C:\Users\Bernd\Documents\AD9833DDS\AD9833FreqGen\XMC2AD9833/Libraries/CMSIS/Infineon/XMC1100_series/Include" -I"C:\Users\Bernd\Documents\AD9833DDS\AD9833FreqGen\XMC2AD9833" -I"C:\Users\Bernd\Documents\AD9833DDS\AD9833FreqGen\XMC2AD9833\Dave\Generated" -I"C:\Users\Bernd\Documents\AD9833DDS\AD9833FreqGen\XMC2AD9833\Libraries" -Os -ffunction-sections -fdata-sections -Wall -std=gnu99 -Wa,-adhlns="$@.lst" -pipe -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d) $@" -mcpu=cortex-m0 -mthumb -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo.

