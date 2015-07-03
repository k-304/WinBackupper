#Workflows ad explanation of Code

This Document shall define How different Variables are named, How different element,objects shall be amnipulated  and explains the basic flow of code within the Software.
At a later point it might link to some fancy Charts - for now text has to be enough

#Naming Convention
| Object        | Naming Convetion  |
| ------------- | -------------     |
| Rich Text Box  | rtb_    |
| Button   | b_      |
| CheckBox   | cb_      |
| Label   | l_      |
| BackgroundWorker   | bw_      |
| Textbox   | tb_      |
| DateTimePicker   | dtp_      |
| ListView   | lv_      |
| ColumnHeader (listview)   | ch_      | 
| ComboBox (DropDown)   | dd_      | 

(Not sure about the ComboBox (Dropdown) one but cb is already taken)

#Saving Data
The only way how Data permanently get's saved - is with the "default.xml"file.
Within the settings.vb class this xml is written with all the important settings when the user presses "Save".
If f.E Timesettings for a certain folderpair are edited - they will NOT be saved unless the user clicks "save" in the settings form!

If there is any Manipulation like editing/adding etc. it always has to be changed within the globals variables WITHIN THE HOME class!
(This Variables will be used to write the xml) Also - the Cahgnes will not be saved if the user does not click onto "save" in the settings class!

#"Flow"
The Software will start up and read settings from the xml file.
A Timer will tick every Minute to check if a Backup needs to run.
If any Settings are changed within the home global Var's the timed Backup will consider them. (not reading from file but from memory!)
((furhter expl. home.sourcepatharray/home.backuppatharray and home.timesettingsarray are the variables to edit - the only ones. All other Variables are only used locally!))
The Backupper will execute the backup and log it accordingly. (at a later poit into a file)
