#Workflows and explanation of Code

This Document shall define How different Variables are named, How different element, objects shall be manipulated  and explains the basic flow of code within the Software. It also describes several processes for the Dev's of this Software - it's basically a Wiki of our practices.


#Creating a Release
The following things have to be done when creating a Release => 

1. Add Changes to the Changelog.txt File in the Github Source.
2. Make Sure the Assembly Information is updated with correct Version. 
3. Make Sure to only copy the needed Files into a Directory, and use the newest builds!

  |Needed Files|
  |-----|
  |Winbackupper.exe|
  |THC_Updater.exe|
  |autorun.inf*|
  |Startup_Silent.bat*|
  |Settings\|
  |Logs\Changelog.txt|
  |Logs\NewVersion.txt|
  |* File contents below in a seperate chapter|

4. IF the Software is tested in this directory, make sure all created Logs are deleted again.

5. Create an Self extracting Archive (exe) using 7zip or similar software.
6. Upload this exe as "Winbackupper_v0.0.1.0"  to Github as a "Release" (https://github.com/SnipeLike/WinBackupper/releases)
7. Make sure to replace the "V_0.0.1.0" with the Release Version number.
8. Create a Tag which equals the VersionNR (In Github Release page - if no tag is specified this is the default tag)
9. When the Release is public, change the "NewVersion.txt" File in the Github source, this will enebale Clients to Update. (And signal to them that a new Version is available)

10. Have a beer and test the Update function =)

#Common Words:

| Expression  | Explanation: |
| ------------- | -------------     |
| Folderpair | A combination of Source/Destination folder and all Startimes for them.    |
| Save   | "Save" in this case refers to "Save what ever I changed since the last startup. ONLY happening by clicking the "save" button in the Settings Form!    |

#Naming Convention
| Object        | Naming Convetion  | Description | 
| ------------- | -------------     | ------------- | 
| Rich Text Box  | rtb_    | | 
| Button   | b_      | | 
| CheckBox   | cb_      | | 
| Label   | l_      | | 
| BackgroundWorker   | bw_      | | 
| Textbox   | tb_      | | 
| DateTimePicker   | dtp_      | | 
| ListView   | lv_      | | 
| ColumnHeader (listview)   | ch_      | | 
| ComboBox (DropDown)   | dd_      | | 
| TreeView   | tv_      | | 
| LoadingCircle   | lc_      | the discussed loading circle from http://www.codeproject.com/Articles/14841/How-to-write-a-loading-circle-animation-in-NET. VERY easy to implement, I'll show you in school. It s a  thing for the toolbox. (To drag and drop) That dude who made that is awesome =) | 

#autorun.inf
An autorun.inf File is used on USB Sticks. 
Let's assume someone wants to build a "Backup stick". 
He can copy this Software into the main dir, and if autorun isn't disabled, windows will immediatly ask to start the winbackupper exe. (not tested yet, but that s the theory of autorun.inf files)
Contents of the file : 

```
[autorun] 
open=WinBackupper.exe 
icon=WinBackupper.exe,0
label=WinBackupper
```

#Startup_Silent.bat
Used to start the Software silently.
Contents of the file : 

```
@echo off
REM This script runs Winbackupper silently in the background.
cmd.exe /c "%~dp0WinBackupper.exe -s"

REM Alternative commands: -s /s /silent and -silent
exit
```

#Saving Data
The only way how Data permanently get's saved - is with the "default.xml"file.
Within the settings.vb class this xml is written with all the important settings when the user presses "Save".
If f.E Timesettings for a certain folderpair are edited - they will NOT be saved unless the user clicks "save" in the settings form!

If there is any Manipulation like editing/adding etc. it always has to be changed within the globals variables WITHIN THE HOME class!
(This Variables will be used to write the xml) Also - the Chagnes will not be saved if the user does not click onto "save" in the settings class!

#"Flow"
The Software will start up and read settings from the xml file.
A Timer will tick every Minute to check if a Backup needs to run.
If any Settings are changed within the home global Var's the timed Backup will consider them. (not reading from file but from memory!)
((furhter expl. home.sourcepatharray/home.backuppatharray and home.timesettingsarray are the variables to edit - the only ones. All other Variables are only used locally!))
The Backupper will execute the backup and log it accordingly. (at a later poit into a file)

#Adding Text to Richtextbox
If Text is added to a Richtextbox, it ALWAYS ends with " &VBNewLine" like in the example below:
```
examplertb_.AppendText("The super important String to add." &VBNewLine)
```
If that isn't in place the next Text added to the Richtextbox will likely be on the same line as the just added text.
(Since the VBNewLine would be missing. If VBNewLine is written in the begging it could be that either 2 Lines are on 1,
or that there is 1 empty Line. By sticking to this "agreement" that VBNewLine is always at the end, trouble is avoided.)
