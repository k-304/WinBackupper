# WinBackupper

# Table of content
- [Features](#Features)
- [How to use](#How to use)
- [Bugs](#Bugs)
- [Next Update](#Next Update)

A simple and automated Backup-Tool for Windows.

<div id='Features'/>
## Features
- Multiple Source & Destination Folders
- Source & Destination default Folders
- Set multuiple start Times for every Folder for every Day, Hour and Minute

<div id='How to use'/>
## How to use?
(Will be fully complete for next release, currently only testing!)

After Startup of the Software, Click on "Configuration" to configure your Folderpairs which should be backed-up.
(This Screenshot Illustrates the first Form showing after starting this Software. Later Reffered to as "home"  or "Main" Form!)

![alt tag](https://raw.github.com/T0mH4rr1s0n/WinBackupper/master/Documentation/V0.0.1.0/Home.png)

After clicking on "Configuration" you are presented with the following form, which gives you an overview about all currently configured Folderpairs, and gives you the ability to delete them, or add new ones.
Later reffered to as the "Settings" Form

![alt tag](https://raw.github.com/T0mH4rr1s0n/WinBackupper/master/Documentation/V0.0.1.0/settings.png)

If you want to add a Foldeprair simply click on "Add Directory" and you will get prompted to enter the source path, then the destination path and finaly to choose a Time schedule for the Folderpair, If you don't want to Backup the Folder automatically, simply leave the times empty! 
The following Screenshot illustrates the as called "Timetable" Form, which allows you to specify the backup times mentioned above.
![alt tag](https://raw.github.com/T0mH4rr1s0n/WinBackupper/master/Documentation/V0.0.1.0/timetable.png)
Choose the Day you want to configure the backuptimes by choosing the right one in the Dropdown menu.
Then enter the correct time in the "Time" field. If you want to add multiple times for a Day, you can use the "add intervall" checkbox and make sure to edit the "Intervall" value to the number of hours you want it to repeat at. 
When you are sure that the time, and day is correc,t click on "add" and repeat the process until you have configured your schedule. (There will be a process to set a time for each day withtout repeatingly enter the same time 7 times for each day.)
When sure your schedule is correct, click an "Apply Times" which will apply the changes temporarly.
If you however want to save the changes done (INCLUDIGN the addition of a new Folderpair!) make sure to click on "Save Folderpair" to make sure your Changes get written into a File to apply permanently!

That's it, you configured the Sourcefolder to be backed up into the backupfolder at specified starttimes. (Or manually if times left empty)

<div id='Bugs'/>
## Bugs
https://github.com/SnipeLike/WinBackupper/issues

<div id='Next Update'/>
## Next Update
Restore will be automated.

# Credits
- T0mH4rr1s0n
- SnipeLike
