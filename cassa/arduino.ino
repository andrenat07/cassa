/*
  LiquidCrystal Library - Serial Input

 Demonstrates the use a 16x2 LCD display.  The LiquidCrystal
 library works with all LCD displays that are compatible with the
 Hitachi HD44780 driver. There are many of them out there, and you
 can usually tell them by the 16-pin interface.

 This sketch displays text sent over the serial port
 (e.g. from the Serial Monitor) on an attached LCD.

 The circuit:
 * LCD RS pin to digital pin 12
 * LCD Enable pin to digital pin 11
 * LCD D4 pin to digital pin 5
 * LCD D5 pin to digital pin 4
 * LCD D6 pin to digital pin 3
 * LCD D7 pin to digital pin 2
 * LCD R/W pin to ground
 * 10K resistor:
 * ends to +5V and ground
 * wiper to LCD VO pin (pin 3)

 Library originally added 18 Apr 2008
 by David A. Mellis
 library modified 5 Jul 2009
 by Limor Fried (http://www.ladyada.net)
 example added 9 Jul 2009
 by Tom Igoe
 modified 22 Nov 2010
 by Tom Igoe

 This example code is in the public domain.

 http://www.arduino.cc/en/Tutorial/LiquidCrystalSerial
 */

// include the library code:
#include <LiquidCrystal.h>

// initialize the library with the numbers of the interface pins
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

byte euroSymbol[8] = {
  0b00110,
  0b01001,
  0b11100,
  0b01000,
  0b11100,
  0b01001,
  0b00110,
  0b00000
};

byte moneySymbol[8] = {
  0b00100,
  0b01111,
  0b10100,
  0b01110,
  0b00101,
  0b11110,
  0b00100,
  0b00000
};

void setup() {
  // set up the LCD's number of columns and rows:
  lcd.begin(16, 2);
  lcd.createChar(0, euroSymbol);
  lcd.createChar(1, moneySymbol);
  // initialize the serial communications:
  Serial.begin(9600);
}

void loop() {
  String message = "";

  // Attendi il messaggio completo con entrambi i testi separati da '\n'
  while (Serial.available() == 0) {}
  message = Serial.readString();
  message.trim();

  // Trova la posizione della divisione tra le due righe
  int separatorIndex = message.indexOf("!");

  if (separatorIndex != -1) 
  {
    String message1 = message.substring(0, separatorIndex);
    String message2 = message.substring(separatorIndex + 1);

    // Scrivi il primo messaggio sulla prima riga
    lcd.clear();

    lcd.setCursor(0, 0);
    lcd.print(message1);
      

    // Scrivi il secondo messaggio alla fine della seconda riga
    lcd.setCursor(15 - message2.length(), 1);
    lcd.print(message2);
    lcd.write(byte(0));
  }
  delay(1000);
}
