# ScreenShare-WS2812b
Display your screen on a WS2812b LED matrix<br />
With this application you can screenshare your desktop to an ESP-connected WS2812b LED matrix.

## How to use

Please download the Arduino code and configure your WiFi credentials as well as the size of your matrix.<br />
The program should be able to handle every size as well as a matrix with more than one tile.<br />
For information about the matrix configuration visit the [Adafruit website](https://learn.adafruit.com/adafruit-neopixel-uberguide/neomatrix-library)

After changing the settings in the code upload the sketch to your controller.<br />
It is recommended to use a ESP32.<br />
If the Upload is finished the ESP starts to connect to your WiFi,<br />
if the connection was successful the matrix should light up in pink.<br />
Now you can install the Windows application.

Download the files from the Windows-Setup folder and run through the setup.<br />
At the first startup you need to specify which IP-Address you want to connect to,<br />
you probably have to look up the IP in the settings of your WiFi router.<br />
Click on save and the application should start.<br />
Now you can resize the Window to fit the Screen Capture area to whatever you want<br />
Click on connect to start the communication with the ESP.<br />
If it is successful the matrix should light up green and you should see the dimensions of the matrix under the connect button.

After you established a connection you can start sharing your screen by hitting the "Play-button".
