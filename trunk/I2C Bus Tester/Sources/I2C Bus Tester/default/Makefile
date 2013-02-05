###############################################################################
# Makefile for the project Sous-Marin
###############################################################################

## General Flags
PROJECT = Sous-Marin
MCU = atmega88
TARGET = Sous-Marin.elf
CC = avr-gcc

CPP = avr-g++

## Options common to compile, link and assembly rules
COMMON = -mmcu=$(MCU)

## Compile options common for all C compilation units.
CFLAGS = $(COMMON)
CFLAGS += -Wall -gdwarf-2 -std=gnu99 -DF_CPU=8000000UL -Os -funsigned-char -funsigned-bitfields -fpack-struct -fshort-enums
CFLAGS += -MD -MP -MT $(*F).o -MF dep/$(@F).d 

## Assembly specific flags
ASMFLAGS = $(COMMON)
ASMFLAGS += $(CFLAGS)
ASMFLAGS += -x assembler-with-cpp -Wa,-gdwarf2

## Linker flags
LDFLAGS = $(COMMON)
LDFLAGS +=  -Wl,-Map=Sous-Marin.map


## Intel Hex file production flags
HEX_FLASH_FLAGS = -R .eeprom -R .fuse -R .lock -R .signature

HEX_EEPROM_FLAGS = -j .eeprom
HEX_EEPROM_FLAGS += --set-section-flags=.eeprom="alloc,load"
HEX_EEPROM_FLAGS += --change-section-lma .eeprom=0 --no-change-warnings


## Objects that must be built in order to link
OBJECTS = I2Cmaster.o main.o uart.o DS7505.o SHT21.o gestion_H.o DS1621.o gestion_T.o 

## Objects explicitly added by the user
LINKONLYOBJECTS = 

## Build
all: $(TARGET) Sous-Marin.hex Sous-Marin.eep Sous-Marin.lss size

## Compile
I2Cmaster.o: ../I2Cmaster.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

main.o: ../main.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

uart.o: ../uart.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

DS7505.o: ../DS7505.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

SHT21.o: ../SHT21.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

gestion_H.o: ../gestion_H.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

DS1621.o: ../DS1621.c
	$(CC) $(INCLUDES) $(CFLAGS) -c  $<

gestion_T.o: ../gestion_T.c
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
	-rm -rf $(OBJECTS) Sous-Marin.elf dep/* Sous-Marin.hex Sous-Marin.eep Sous-Marin.lss Sous-Marin.map


## Other dependencies
-include $(shell mkdir dep 2>NUL) $(wildcard dep/*)

