# Neurosky Mindwave EEG Headset 

### Background

The neurosky mindwave offers...

### Setting up Device

1. Turn on Headset. 
2. If you need to pair it to your computer via Bluetooth 
   a. Turn on the Mindwave Headset and push and hold the on switch in the on position until 
   the blue light flashes twice in rapid succession and continues to do that after you let go of the switch. 
   b. Open the Windows Settings app from the Start menu.  
   c. Go to the Devices pane and choose Bluetooth in the left-hand nav bar. 
   d. When the computer has detected the headset, it will show up as a MindWave Mobile device. 
   Click on the Pair button to make it connect to the computer. 
3. Test the headset.  
   a. Make sure the headset is on. 
   b. Put the headset on your head.  
   c. Connect the earpiece to your left earlobe.  
   d. Place the electrode on the left side of your forehead so it makes a flush contact. 
   e. Open the NeuroView application.  
   f. Click on the headset icon at the left end of the icon command bar. 
      Choose OK in the dialog box and wait for it to connect to your headset. 
   g. When connected, you will get a dialog box that says 
      ```
      Successfully connected to 
      \\.\COM4  (or another COM port on the computer). This is a Bluetooth Serial connection. 
      ```
   h. Click OK to dismiss the dialog.  

### Testing signal

1. To see the incoming signal, click on one of the graph buttons in the icon command bar. The red button displays the raw signal. 
      The blue button displays a filtered signal. The histogram button displays the power spectrum of the signal being received.  
2. The A button and M button display a proprietary computed signal from the Mindwave called Attention and Meditation. 
      Play with your mind to see if you can make these metrics (0-100) change.  
3. To record, 
   a. First change the timestamp format to Unix timestamps in the Record menu. 
   b. Hit the red Record button to start recording data from the Mindwave at 1000 Hz. 

### Recording data and data format.

When you have finished gathering data, click the disk icon in the icon command bar to save it to disk. 
It will save into up to 7 CSV files. If you want to record more data, click the red Record button again. 
Every file will have a time column first with Unix time (seconds since Jan 1, 1970) and a decimal millisecond value. 

* Signal quality file (Columns: Time, Value (0-100)) 1 Hz 
* Attention data (Columns: Time, Value (0-100)) 1 Hz 
* Meditation data (Columns: Time, Value (0-100)) 1 Hz 
* Combined data (Columns: Time, Signal quality, Attention, Meditation) 1 Hz 
* Raw data (Columns: Time, Value (-2048--2048)), 1000 MHz 
* Filtered wave data (Columns: Time, Value (-2048-–2048)), 1000 MHz 
* Power spectrum (Columns: Time, Value for each 0.25 width frequency band from 0 to 128 Hz)
