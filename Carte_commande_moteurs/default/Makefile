###############################################################################
# Makefile for the project pwm
###############################################################################

## General Flags
PROJECT = pwm
MCU = atmega88
TARGET = pwm.elf
CC = avr-gcc

CPP = avr-g++

## Options common to compile, link and assembly rules
COMMON = -mmcu=$(MCU)

## Compile options common for all C compilation units.
CFLAGS = $(COMMON)
CFLAGS += -Wall -gdwarf-2 -std=gnu99    -DF_CPU=8000000UL -Os -funsigned-char -funsigned-bitfields -fpack-struct -fshort-enums
CFLAGS += -MD -MP -MT $(*F).o -MF dep/$(@F).d 

## Assembly specific flags
ASMFLAGS = $(COMMON)
ASMFLAGS += $(CFLAGS)
ASMFLAGS += -x assembler-with-cpp -Wa,-gdwarf2

## Linker flags
LDFLAGS = $(COMMON)
LDFLAGS +=  -Wl,-Map=pwm.map


## Intel Hex file production flags
HEX_FLASH_FLAGS = -R .eeprom -R .fuse -R .lock -R .signature

HEX_EEPROM_FLAGS = -j .eeprom
HEX_EEPROM_FLAGS += --set-section-flags=.eeprom="alloc,load"
HEX_EEPROM_FLAGS += --change-section-lma .eeprom=0 --no-change-warnings


## Objects that must be built in order to link
OBJECTS = main.o adc.o usart.o ballast_position.o motor_driver.o timer0.o 3964r.o external_interrupt.o timer1.o watchdog.o 

## Objects explicitly added by the user
LINKONLYOBJECTS = 

## Build
all: $(TARGET) pwm.hex pwm.eep pwm.lss size

## Compile
main.o: ../main.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

adc.o: ../adc.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

usart.o: ../usart.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

ballast_position.o: ../ballast_position.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

motor_driver.o: ../motor_driver.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

timer0.o: ../timer0.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

3964r.o: ../3964r.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

external_interrupt.o: ../external_interrupt.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

timer1.o: ../timer1.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

watchdog.o: ../watchdog.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

##Link
$(TARGET): $(OBJECTS)
	 $(CC) $(LDFLAGS) $(OBJECTS) $(LINKONLYOBJECTS) $(LIBDIRS) $(LIBS) -o $(TARGET)

%.hex: $(TARGET)
	avr-objcopy -O ihex $(HEX_FLASH_FLAGS)  $< $@

%.eep: $(TARGET)
	-avr-objcopy $(HEX_EEPROM_FLAGS) -O ihex $< $@ || exit 0

%.lss: $(TARGET)
	avr-objdump -h -S $< > $@

size: ${TARGET}
	@echo
	@avr-size -C --mcu=${MCU} ${TARGET}

## Clean target
.PHONY: clean
clean:
	-rm -rf $(OBJECTS) pwm.elf dep/* pwm.hex pwm.eep pwm.lss pwm.map


## Other dependencies
-include $(shell mkdir dep 2>/dev/null) $(wildcard dep/*)

