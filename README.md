# ScreenShare-WS2812b
Display your Screen on a WS2812b LED Matrix<br />
With this application you can Screenshare your desktop to an ESP-Connected WS2812b LED Matrix.

## How to use

Please download the Arduino Code and configure the Size of your Matrix.<br />
The Program should be able to handle every Size as well as a Matrix with more than one Tile.<br />
For information about the Matrix configuration visit the [Adafruit Website](https://learn.adafruit.com/adafruit-neopixel-uberguide/neomatrix-library))

After changing the settings in the Code upload the sketch to your controller.<br />
it is recommended to use a ESP32.<br />
If the Upload is finished the ESP starts to connect to your WiFi,<br />
if the connection was successful the Matrix should light up in pink.<br />
Now you can install the Windows application.

Download the Files from the Windows-Setup folder and run through the setup.<br />
At the first startup you need to specify which IP-Address you want to connect to,<br />
you probably have to look up the IP in the settings of your WiFi router.<br />
Click on save and the application should start.<br />
Now you can resize the Window to fit the Screen Capture area to whatever you want<br />
Click on Connect to start the communication with the ESP.<br />
If it is successful the Matrix should light up green and you should see the Dimensions of the Matrix under the Connect Button.

After you established a connection you can Start sharing your screen by hitting the "Play-Button".
