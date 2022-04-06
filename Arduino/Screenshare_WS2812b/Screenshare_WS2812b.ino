#include <WiFi.h>
#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>



//This Program is used in Combination with a Windows Forms Application to Screenshare your PC Screen to an WS2812b Matrix
//It is recomendet to use a ESP32
//Created by fabe1999
//last updated: 04.04.2022



//Things you have to change:
//Put your WiFi Credentials here:
const char* ssid = "********";
const char* password = "********";

//Set the Pin and the Dimensions of Your Matrix here:
const int pin = 13;
const int width = 16;
const int height = 16;

//If you have a special kind of Matrix ore use more than one Tile you should change the settings here,
//For mor Information Visit the Adafruit NeoMatrix Guide: https://learn.adafruit.com/adafruit-neopixel-uberguide/neomatrix-library
Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(width, height, pin,
                            NEO_MATRIX_BOTTOM     + NEO_MATRIX_LEFT +
                            NEO_MATRIX_ROWS + NEO_MATRIX_ZIGZAG,
                            NEO_GRB            + NEO_KHZ800);





//No need to change anything after this Point.
WiFiUDP Udp;
unsigned int localUdpPort = 4210;
char incomingPacket[255];



void setup()
{
  //Initialise the Matrix
  matrix.begin();
  matrix.clear();
  matrix.show();

  //Try to connect to the WiFi
  WiFi.setHostname("ledMatrix");
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);
  }

  //Start to Listen to UDP Packages send to the specified Port
  Udp.begin(localUdpPort);


  //Create a Pink square on the Matrix as a signal that the Setup is finished and the ESP is ready to Connect to the PC Software.
  //If you cant see the Pink Square check your WiFi credentials, Probably the ESP couldnt connect to the WiFi.
  for (int i = 0; i <= width; i++)
  {
    matrix.drawRect(0, 0, i, i, matrix.Color(255, 0, 255));
    matrix.show();
    delay(30);
  }
  for (int i = 0; i <= width; i++)
  {
    matrix.drawRect(0, 0, i, i, matrix.Color(0, 0, 0));
    matrix.show();
    delay(30);
  }
  matrix.clear();
  matrix.show();
}



void loop()
{
  //If a Package is recived
  int packetSize = Udp.parsePacket();
  if (packetSize)
  {
    int len = Udp.read(incomingPacket, 255);
    if (len > 0)
    {
      incomingPacket[len] = 0;
    }

    //Translate the UDP Pachage to a String so it can be processed.
    String udpIn = incomingPacket;

    //If the send String starts with a V its a Connection request.
    if (udpIn[0] == 'V')
    {
      //Send back the Dimensions of the Matrix to configure the Windows application.
      char  replyPacket[7];
      sprintf(replyPacket, "%d;%d", width, height);
      Udp.beginPacket(Udp.remoteIP(), (udpIn.substring(2)).toInt());
      Udp.print(replyPacket);
      Udp.endPacket();
      
      //Show a Green Circle on the Matrix to show the User a successfull connection
      for (int i = 0; i < width; i++)
      {
        matrix.drawCircle((width / 2), (height / 2), i, matrix.Color(0, 255, 0));
        matrix.show();
        delay(30);
      }
      for (int i = 0; i < width; i++)
      {
        matrix.drawCircle((width / 2), (height / 2), i, matrix.Color(0, 0, 0));
        matrix.show();
        delay(30);
      }
      matrix.clear();
      matrix.show();
    }
    //If the Send String starts with a X the Windows program is closing, Clear the Matrix so the last Picture wont stay on there
    else if(udpIn[0] == 'X')
    {
      matrix.clear();
      matrix.show();
    }
    else
    {
      //If the Packet starts with a number these are Packages to convert and show on the Matrix
      //Create temporary Variables as Buffer for the Conversion
      String strTemp = "";
      byte bytR = 0;
      byte bytG = 0;
      byte bytB = 0;
      int intLEDx = 0;
      int intLEDy = 0;
      byte bytCol = 4; //Start with something else so the first Number which is the Line Number can be Seperated from the Color Values

      //Umwandlung von Hex in int (Stringumwandlung funktioniert mit einzelnem Char nicht)

      //Umwandlung des Strings in LED Matrix anzeige
      for (int i = 0; i < udpIn.length(); i++)
      {
        if ( udpIn[i] == ';')
        {
          //Set the Pixel which was converted to show on the matrix
          matrix.drawPixel(intLEDx, intLEDy, matrix.Color(bytR, bytG, bytB));

          //Jump to the next Pixel
          intLEDx++;

          //Reset the Color Variables
          bytR = 0;
          bytG = 0;
          bytB = 0;
          strTemp = "";
          bytCol = 0;
        }
        else if ( udpIn[i] == '-')
        {
          //after the Line Number is read the Color Informations can be processed
          //Reset the Variables
          strTemp = "";
          bytCol = 0;
        }
        else if ( udpIn[i] == ':')
        {
          //The Seperator : is used to diferentiate the R G and B Color values
          bytCol++;
          strTemp = "";
        }
        else
        {
          //Save the Numbers in the coresponding Variables
          switch (bytCol)
          {
            case 0:
              strTemp += udpIn[i];
              bytR = strTemp.toInt();
              break;
            case 1:
              strTemp += udpIn[i];
              bytG = strTemp.toInt();
              break;
            case 2:
              strTemp += udpIn[i];
              bytB = strTemp.toInt();
              break;
            default:
              strTemp += udpIn[i];
              intLEDy = strTemp.toInt();
              break;
          }
        }
      }
      //If the Whole Package is recived and calculated Show the Row on the matrix
      //Wait for the next udp Package, Every Line is a Package
      matrix.show();
    }
  }
}
