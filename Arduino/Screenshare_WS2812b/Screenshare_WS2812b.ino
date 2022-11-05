#include <WiFi.h>
#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>



//This Program is used in Combination with a Windows Forms Application to Screenshare your PC Screen to an WS2812b Matrix
//It is recomendet to use a ESP32
//Created by fabe1999
//last updated: 05.11.2022



//Things you have to change:
//Put your WiFi Credentials here:
const char* ssid = "WIFINAME";
const char* password = "WIFIPASSWORD";

//Set the Pin and the *total* Dimensions of Your Matrix here:
const int pin = 13;
const int width = 16;
const int height = 16;

//If you have a special kind of Matrix ore use more than one Tile you should change the settings here,
//For mor Information Visit the Adafruit NeoMatrix Guide: https://learn.adafruit.com/adafruit-neopixel-uberguide/neomatrix-library
Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(width, height, pin,
                            NEO_MATRIX_BOTTOM     + NEO_MATRIX_LEFT +
                            NEO_MATRIX_ROWS  + NEO_MATRIX_ZIGZAG,
                            NEO_GRB            + NEO_KHZ800);


//Example of a Tiled Matrix
//If you use a tiled matrix you have to set the individual matrix sizes here manually
//Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(16, 16, 2, 2, pin,
//                            NEO_MATRIX_TOP      + NEO_MATRIX_LEFT +
//                            NEO_MATRIX_COLUMNS  + NEO_MATRIX_ZIGZAG +
//                            NEO_TILE_BOTTOM     + NEO_TILE_LEFT +
//                            NEO_TILE_ROWS       + NEO_TILE_ZIGZAG);





//No need to change anything after this Point.
//+++++++++++++++++++++++++++++++++++++++++++

const int iDelay = 30;
byte byReceive [(width * height) * 2 + 1];
//Configure the TCP Server to listen on this Port
//If you want to change the Port please cange it in the Settings of the Windows software aswell
WiFiServer server(4210);



void setup()
{
  //Initialise the Matrix
  matrix.begin();
  matrix.clear();
  matrix.show();

  //The Max Brightness is limited until the Windows program is connected
  matrix.setBrightness(100);

  //Try to connect to the WiFi
  WiFi.setHostname("ledMatrix");
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);
  }

  //Start TCP Server
  server.begin();


  //Create a Pink square on the Matrix as a signal that the Setup is finished and the ESP is ready to Connect to the PC Software.
  //If you cant see the Pink Square check your WiFi credentials, Probably the ESP couldnt connect to the WiFi.
  for (int i = 0; i <= width; i++)
  {
    matrix.drawRect(0, 0, i, i, matrix.Color(255, 0, 255));
    matrix.show();
    delay(iDelay);
  }
  for (int i = 0; i <= width; i++)
  {
    matrix.drawRect(0, 0, i, i, matrix.Color(0, 0, 0));
    matrix.show();
    delay(iDelay);
  }
  matrix.clear();
  matrix.show();
}



void loop()
{
  WiFiClient client = server.available();

  if (client)
  {
    while (client.connected())
    {
      //Reset Index to override the char Array
      int iIndex = 0;
      byReceive[0] = 0;
      while (client.available() > 0)
      {
        //recive Data from the Windows Client
        byReceive[iIndex] = client.read();
        iIndex++;
      }

      //If the Send String starts with a C the Windows programm wants to know the Matrix dimensions
      if (byReceive[0] == 'C')
      {
        //Set the maximum Brightness of the Matrix
        matrix.setBrightness(byReceive[1]);

        //Send back the Dimensions of the Matrix to configure the Windows application.
        char  replyPacket[7];
        sprintf(replyPacket, "%d;%d", width, height);
        client.write(replyPacket);
        client.stop();

        //Show a Green Circle on the Matrix to show the User a successfull connection
        for (int i = 0; i < width; i++)
        {
          matrix.drawCircle((width / 2), (height / 2), i, matrix.Color(0, 255, 0));
          matrix.show();
          delay(iDelay);
        }
        for (int i = 0; i < width; i++)
        {
          matrix.drawCircle((width / 2), (height / 2), i, matrix.Color(0, 0, 0));
          matrix.show();
          delay(iDelay);
        }
        matrix.clear();
        matrix.show();
      }
      
      //If the Send String starts with a X the Windows program is closing, Clear the Matrix so the last Picture wont stay on there
      else if (byReceive[0] == 'X')
      {
        matrix.clear();
        matrix.show();
      }

      //If the Packet starts with a P its a Picture Packet to display on the Matrix.
      else if (byReceive[0] == 'P')
      {
        //Set Index to 1, Byte 0 is the Indecator what type of Package is being sendt
        int iIndex = 1;
        for (int y = 0; y < height; y++)
        {
          for (int x = 0; x < width; x++)
          {
            //Combine two bytes to recive the Color of the current LED
            word wColor = 0;
            wColor = (byReceive[iIndex++] << 8) | (byReceive[iIndex++]);
            matrix.drawPixel(x, y, wColor);
          }
        }
      }
      client.stop();
      //If the Whole Package is recived and calculated Show the Picture on the matrix
      //Wait for the next Package, Every Package is a whole Picture
      matrix.show();
    }
  }
}
