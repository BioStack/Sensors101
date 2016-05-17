# Microsoft Touch Mouse

### Setup Instructions

1. Take wireless transceiver out of the bottom of the mouse and plug it into a USB port.
2. Turn on the mouse using the On/Off switch on the bottom.
3. Test the mouse movement and scrolling on any application on the computer.
4. The mouse has a 13x15 grid of capacitive cells sensitive to human touch on its surface. As your fingers touch the mouse, each cell will get charged to a value between 0 and 255 which can be read by the computer.

### Recording

1. Open up Visual Studio 2015. 
2. Load the TouchMouse.sln file from the C:\SEmotion\Touch Mouse folder.
3. Run the application to see a visualization of your fingers on the mouse. The application is also saving touch data to %TEMP%\TouchMouseData-<datetime>.csv.
4. When you have finished gathering data, close the application.

### Touch Data
The touch data file will have this format:

* Time column with Unix time (seconds since Jan 1, 1970) and a decimal millisecond value.
* Left Mouse Button: “down” or “up”
* Right Mouse Button: “down” or “up”
* Touch Mouse Count: Number of capacitive cells touched with threshold > 5 (Value: 0-195).
* Touch Mouse Sum: The sum of the values of every capacitive cell on the mouse (Value 0-49725).
* Touch Mouse Value 1 through Touch Mouse Value 195: The value of the particular capacitive cell on the mouse (Value: 0-255).
