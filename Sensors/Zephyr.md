# Zephyr HxM Heart Rate Monitor

### Setup Instructions

1. Put chest strap on underneath your shirt. The black plastic “electrodes” should be on your ribs just below your pectoral muscles.
2. Attach Zephyr device to the two snaps on the chest strap.
3. If you need to pair it to your computer via Bluetooth
    * a. Attach the Zephyr HxM Monitor to the chest strap.
    * b. Open the Windows Settings app from the Start menu. 
    * c. Go to the Devices pane and choose Bluetooth in the left-hand nav bar.
    * d. When the computer has detected the heart rate monitor, it will show up as an HXM033918 device. Click on the Pair button to make it connect to the computer.

### Get Signal

1. Make sure the Zephyr monitor is on.
2. Open Visual Studio 2015.
3. Open up the HeartToSkin.sln in the folder C:\SEmotion\Zephyr\HeartToSkin.
4. Run the application from Visual Studio by pressing F5. 
5. When the window comes up, check that COM7 is in the Zephyr COM Port text box.
6. Click on Collect from Zephyr to connect the application to the Zephyr monitor. 
7. Once the connection has been established, you will see data from the sensor appear in the window, updated once per second. The heart icon will start to beat. 
8. To stop collecting data, quit the application or press the Stop Collecting Zephyr button in the window.

### Data

1. As long as the connection is maintained, data is being saved to two files in the `%TEMP%` directory: HeartActivity_datetime.csv and RRIntervals_datetime.csv.
2. Every file will have a SensorDateTime column first with Unix time (seconds since Jan 1, 1970) and a decimal millisecond value.
3. HeartActivity file stores one row every 4 seconds.
   * Heart Beat Number (1 – infinity)
   * Heart Rate (20-200), beats per minute
   * Strides (0-100), how many steps you’ve taken
   * Distance (0-1000), how far you’ve traveled
