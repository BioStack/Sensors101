# Microsoft Band2

The Microsoft Band2 contains many interesting sensors. 

# Connector Setup

### Requirements

1. You need Windows 10.
2. Have Visual Studio 2015 installed.
3. Enable Developer Mode.

### Connector Project

A sample C# project for connecting to a Band 2 is provided: URL

Some other considerations:

* Package.appxmanifest needs to have Bluetooth and Proxmity app permissions enabled (in Capabilities tab).
* You need to have the Microsoft.Band nuget package installed. Either restore packages or manually run `install-package Microsoft.Band` in nuget package manager console.

### Pairing

You need to pair your Microsoft Band 2 to your computer in order to stream data collection.

To pair, 

1. Click the big side button to turn on the screen.
2. If you see the clock screen, make a big swipe through the icons until you see the gear.
3. Scroll until you see the Bluetooth icon.
4. Tap the icon then tap the "On" option, then scroll until you see "Pairing".
5. If it asks you to pair with a phone, select No. It is now waiting to pair with computer.
6. On Windows Desktop, go to Bluetooth settings, have it search for Band.
7. Click the Band device when it appears, then click Pair.
8. One your Microsoft Band, click Accept.
9. One your PC, click Yes to accept.
10. You're paired!

### Collecting Data.

1. Run the solution.
2. If this is the first time, it will ask you for permission to access HeartRate and other health measures.
3. You will see debug output printed to screen!
