/*************************************************************************
* Title:    I2C master library using hardware TWI interface
* Author:   Peter Fleury <pfleury@gmx.ch>  http://jump.to/fleury
* File:     $Id: twimaster.c,v 1.3 2005/07/02 11:14:21 Peter Exp $
* Software: AVR-GCC 3.4.3 / avr-libc 1.2.3
* Target:   any AVR device with hardware TWI 
* Usage:    API compatible with I2C Software Library i2cmaster.h
**************************************************************************/
#include <inttypes.h>
#include <compat/twi.h>
#include "I2Cmaster.h"

/* define CPU frequency in Mhz here if not defined in Makefile */
#ifndef F_CPU
#define F_CPU 8000000UL
#endif

/* I2C clock in Hz */
#define SCL_CLOCK  100000L

/****** Master ******/
// TW_START					0x08, start condition transmitted
// TW_REP_START				0x10, repeated start condition transmitted
/****** Master Transmitter ******/
// TW_MT_SLA_ACK 			0x18, SLA+W transmitted, ACK received 
// TW_MT_SLA_NACK			0x20, SLA+W transmitted, NACK received 
// TW_MT_DATA_ACK			0x28, data transmitted, ACK received
// TW_MT_DATA_NACK			0x30, data transmitted, NACK received
// TW_MT_ARB_LOST			0x38, arbitration lost in SLA+W or data
/****** Master Receiver ******/
// TW_MR_ARB_LOST			0x38, arbitration lost in SLA+R or NACK
// TW_MR_SLA_ACK			0x40, SLA+R transmitted, ACK received
// TW_MR_SLA_NACK			0x48, SLA+R transmitted, NACK received 
// TW_MR_DATA_ACK			0x50, data received, ACK returned
// TW_MR_DATA_NACK			0x58, data received, NACK returned
/****** Slave Transmitter ******/
// TW_ST_SLA_ACK			0xA8, SLA+R received, ACK returned 
// TW_ST_ARB_LOST_SLA_ACK	0xB0, arbitration lost in SLA+RW, SLA+R received, ACK returned
// TW_ST_DATA_ACK			0xB8, data transmitted, ACK received
// TW_ST_DATA_NACK			0xC0, data transmitted, NACK received
// TW_ST_LAST_DATA			0xC8, last data byte transmitted, ACK received
/****** Slave Receiver ******/
// TW_SR_SLA_ACK			0x60, SLA+W received, ACK returned
// TW_SR_ARB_LOST_SLA_ACK	0x68, arbitration lost in SLA+RW, SLA+W received, ACK returned
// TW_SR_GCALL_ACK			0x70, general call received, ACK returned
// TW_SR_ARB_LOST_GCALL_ACK 0x78, arbitration lost in SLA+RW, general call received, ACK returned
// TW_SR_DATA_ACK			0x80, data received, ACK returned
// TW_SR_DATA_NACK			0x88, data received, NACK returned
// TW_SR_GCALL_DATA_ACK		0x90, general call data received, ACK returned
// TW_SR_GCALL_DATA_NACK	0x98, general call data received, NACK returned
// TW_SR_STOP				0xA0, stop or repeated start condition received while selected 
/****** Misc ******/
// TW_NO_INFO				0xF8, no state information available
// TW_BUS_ERROR				0x00, illegal start or stop condition


/*************************************************************************
 Initialization of the I2C bus interface. Need to be called only once
*************************************************************************/
void i2c_init(void)
{
  /* initialize TWI clock: 100 kHz clock, TWPS = 0 => prescaler = 1 */
  
  TWSR = 0;                         /* no prescaler */
  TWBR = ((F_CPU/SCL_CLOCK)-16)/2;  /* must be > 10 for stable operation */

}/* i2c_init */


/*************************************************************************	
  Issues a start condition and sends address and transfer direction.
  (7 bits for address and 1 bit for read/write)
  return 0 = device accessible, 1= failed to access device
*************************************************************************/
unsigned char i2c_start(unsigned char address)
{
    uint8_t   twst;

	// send START condition
	TWCR = (1<<TWINT) | (1<<TWSTA) | (1<<TWEN);

	// wait until transmission completed
	while(!(TWCR & (1<<TWINT)));

	// check value of TWI Status Register. Mask prescaler bits.
	twst = TW_STATUS & 0xF8;
	if ( (twst != TW_START) && (twst != TW_REP_START)) return 1;

	// send device address (load address, and start transmission of address)
	TWDR = address; 
	TWCR = (1<<TWINT) | (1<<TWEN);

	// wail until transmission completed (when TWINT is set) and ACK/NACK has been received
	while(!(TWCR & (1<<TWINT)));

	// check value of TWI Status Register. Mask prescaler bits.
	twst = TW_STATUS & 0xF8;
	if ( (twst != TW_MT_SLA_ACK) && (twst != TW_MR_SLA_ACK) ) return 1;

	return 0;

}/* i2c_start */


/*************************************************************************
 Issues a start condition and sends address and transfer direction.
 If device is busy, use ack polling to wait until device is ready
 
 Input:   address and transfer direction of I2C device
*************************************************************************/
void i2c_start_wait(unsigned char address)
{
    uint8_t   twst;


    while ( 1 )
    {
	    // send START condition
	    TWCR = (1<<TWINT) | (1<<TWSTA) | (1<<TWEN);
    
    	// wait until transmission completed
    	while(!(TWCR & (1<<TWINT)));
    
    	// check value of TWI Status Register. Mask prescaler bits.
    	twst = TW_STATUS & 0xF8;
    	if ( (twst != TW_START) && (twst != TW_REP_START)) continue;
    
    	// send device address
    	TWDR = address;
    	TWCR = (1<<TWINT) | (1<<TWEN);
    
    	// wail until transmission completed
    	while(!(TWCR & (1<<TWINT)));
    
    	// check value of TWI Status Register. Mask prescaler bits.
    	twst = TW_STATUS & 0xF8;
    	if ( (twst == TW_MT_SLA_NACK )||(twst ==TW_MR_DATA_NACK) ) 
    	{    	    
    	    /* device busy, send stop condition to terminate write operation */
	        TWCR = (1<<TWINT) | (1<<TWEN) | (1<<TWSTO);
	        
	        // wait until stop condition is executed and bus released
	        while(TWCR & (1<<TWSTO));
	        
    	    continue;
    	}
    	//if( twst != TW_MT_SLA_ACK) return 1;
    	break;
     }

}/* i2c_start_wait */


/*************************************************************************
 Issues a repeated start condition and sends address and transfer direction 

 Input:   address and transfer direction of I2C device
 
 Return:  0 device accessible
          1 failed to access device
*************************************************************************/
unsigned char i2c_rep_start(unsigned char address)
{
    return i2c_start( address );

}/* i2c_rep_start */


/*************************************************************************
 Terminates the data transfer and releases the I2C bus
*************************************************************************/
void i2c_stop(void)
{
    /* send stop condition */
	TWCR = (1<<TWINT) | (1<<TWEN) | (1<<TWSTO);
	
	// wait until stop condition is executed and bus released
	while(TWCR & (1<<TWSTO));

}/* i2c_stop */


/*************************************************************************
  Send one byte to I2C device
  
  Input:    byte to be transfered
  Return:   0 write successful 
            1 write failed
*************************************************************************/
unsigned char i2c_write( unsigned char data )
{	
    uint8_t   twst;
    
	// send data to the previously addressed device
	TWDR = data;
	TWCR = (1<<TWINT) | (1<<TWEN);

	// wait until transmission completed
	while(!(TWCR & (1<<TWINT)));

	// check value of TWI Status Register. Mask prescaler bits
	twst = TW_STATUS & 0xF8;
	if( twst != TW_MT_DATA_ACK) return 1;
	return 0;

}/* i2c_write */


/*************************************************************************
 Read one byte from the I2C device, request more data from device 
 
 Return:  byte read from I2C device
*************************************************************************/
unsigned char i2c_readAck(void)
{
	TWCR = (1<<TWINT) | (1<<TWEN) | (1<<TWEA);
	while(!(TWCR & (1<<TWINT)));    

    return TWDR;

}/* i2c_readAck */


/*************************************************************************
 Read one byte from the I2C device, read is followed by a stop condition 
 
 Return:  byte read from I2C device
*************************************************************************/
unsigned char i2c_readNak(void)
{
	TWCR = (1<<TWINT) | (1<<TWEN);
	while(!(TWCR & (1<<TWINT)));
	
    return TWDR;

}/* i2c_readNak */
