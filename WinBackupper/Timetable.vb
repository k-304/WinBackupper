Imports System.Threading
Imports System.Reflection

Public Class Timetable



#Region "Variables"
    '*------------------------*'
    '*----Global Variables----*'
    '*------------------------*'
    Public selectedday As Integer
    Public ToplevelSeperator As String = "::" 'has to be 2 chars (should be)  if changed code needs to change too!
    Public seperator As String = ";"
    Public lvc_Mon As New ArrayList
    Public lvc_Tue As New ArrayList
    Public lvc_Wed As New ArrayList
    Public lvc_Thu As New ArrayList
    Public lvc_Fri As New ArrayList
    Public lvc_Sat As New ArrayList
    Public lvc_Sun As New ArrayList
    Dim lastcomboboxindex As Integer
    Dim finalstring As String = ""
    Public selectedtimesarray As New ArrayList

#End Region

#Region "MainCode"
    Private Sub ComboBox_Day_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_Day.SelectedIndexChanged

        'this code gets executed when the Selection of the "Daypickbox" (dropdown) changes
        'use this to reread all settings when user changes to another Day

        'define Lines for lastly selected day (before changing index)
        'when it changes again, reload the data for the selected day
        selectedday = dd_Day.SelectedIndex


        Select Case lastcomboboxindex
            Case 0
                'build an array out of all items in listview and save them accoridngly in var as string
                Dim temparray As New ArrayList
                For Each item As ListViewItem In lv_timetable.Items
                    'gett al entry of a line in lv and save them as 1 entry in array
                    'later get it back by serializing the string and get data for each line
                    Dim tempitemtext As String
                    tempitemtext = item.Text
                    tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                    temparray.Add(tempitemtext)
                Next
                If Not lv_timetable.Items.Count = 0 Then ' check if there are no elemts, if so leave old array
                    lvc_Mon = temparray
                End If

            Case 1
                Dim temparray As New ArrayList
                For Each item As ListViewItem In lv_timetable.Items
                    'gett al entry of a line in lv and save them as 1 entry in array
                    'later get it back by serializing the string and get data for each line
                    Dim tempitemtext As String
                    tempitemtext = item.Text
                    tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                    temparray.Add(tempitemtext)
                Next
                If Not lv_timetable.Items.Count = 0 Then ' check if there are no elemts, if so leave old array
                    lvc_Tue = temparray
                End If
                temparray = Nothing
            Case 2
                Dim temparray As New ArrayList
                For Each item As ListViewItem In lv_timetable.Items
                    'gett al entry of a line in lv and save them as 1 entry in array
                    'later get it back by serializing the string and get data for each line
                    Dim tempitemtext As String
                    tempitemtext = item.Text
                    tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                    temparray.Add(tempitemtext)
                Next
                If Not lv_timetable.Items.Count = 0 Then ' check if there are no elemts, if so leave old array
                    lvc_Wed = temparray
                End If
                temparray = Nothing
            Case 3
                Dim temparray As New ArrayList
                For Each item As ListViewItem In lv_timetable.Items
                    'gett al entry of a line in lv and save them as 1 entry in array
                    'later get it back by serializing the string and get data for each line
                    Dim tempitemtext As String
                    tempitemtext = item.Text
                    tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                    temparray.Add(tempitemtext)
                Next
                If Not lv_timetable.Items.Count = 0 Then ' check if there are no elemts, if so leave old array
                    lvc_Thu = temparray
                End If
                temparray = Nothing
            Case 4
                Dim temparray As New ArrayList
                For Each item As ListViewItem In lv_timetable.Items
                    'gett al entry of a line in lv and save them as 1 entry in array
                    'later get it back by serializing the string and get data for each line
                    Dim tempitemtext As String
                    tempitemtext = item.Text
                    tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                    temparray.Add(tempitemtext)
                Next
                If Not lv_timetable.Items.Count = 0 Then ' check if there are no elemts, if so leave old array
                    lvc_Fri = temparray
                End If
                temparray = Nothing
            Case 5
                Dim temparray As New ArrayList
                For Each item As ListViewItem In lv_timetable.Items
                    'gett al entry of a line in lv and save them as 1 entry in array
                    'later get it back by serializing the string and get data for each line
                    Dim tempitemtext As String
                    tempitemtext = item.Text
                    tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                    temparray.Add(tempitemtext)
                Next
                If Not lv_timetable.Items.Count = 0 Then ' check if there are no elemts, if so leave old array
                    lvc_Sat = temparray
                End If
                temparray = Nothing
            Case 6
                Dim temparray As New ArrayList
                For Each item As ListViewItem In lv_timetable.Items
                    'gett al entry of a line in lv and save them as 1 entry in array
                    'later get it back by serializing the string and get data for each line
                    Dim tempitemtext As String
                    tempitemtext = item.Text
                    tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                    temparray.Add(tempitemtext)
                Next
                If Not lv_timetable.Items.Count = 0 Then ' check if there are no elemts, if so leave old array
                    lvc_Sun = temparray
                End If
                temparray = Nothing
        End Select

        'clear old data in RTB
        lv_timetable.Items.Clear()
        'reread data for new day  and repupulate RTB
        'this is for the currently selected index
        Select Case selectedday
            Case 0
                For Each item As String In lvc_Mon
                    Dim timepart As String = item.Substring(0, 5) 'get first 5 chars (the time like HH:MM)
                    Dim backuptype As String = item.Substring(5, item.Length - (5 + 1)) '(don t write last character , so 5+1 is used. last character is ";" leads to nasty bugs)
                    Dim tempitem As ListViewItem = lv_timetable.Items.Add(timepart)
                    tempitem.SubItems.Add(backuptype)
                Next
            Case 1
                For Each item As String In lvc_Tue
                    Dim timepart As String = item.Substring(0, 5) 'get first 5 chars (the time like HH:MM)
                    Dim backuptype As String = item.Substring(5, item.Length - (5 + 1))
                    Dim tempitem As ListViewItem = lv_timetable.Items.Add(timepart)
                    tempitem.SubItems.Add(backuptype)
                Next
            Case 2
                For Each item As String In lvc_Wed
                    Dim timepart As String = item.Substring(0, 5) 'get first 5 chars (the time like HH:MM)
                    Dim backuptype As String = item.Substring(5, item.Length - (5 + 1))
                    Dim tempitem As ListViewItem = lv_timetable.Items.Add(timepart)
                    tempitem.SubItems.Add(backuptype)
                Next
            Case 3
                For Each item As String In lvc_Thu
                    Dim timepart As String = item.Substring(0, 5) 'get first 5 chars (the time like HH:MM)
                    Dim backuptype As String = item.Substring(5, item.Length - (5 + 1))
                    Dim tempitem As ListViewItem = lv_timetable.Items.Add(timepart)
                    tempitem.SubItems.Add(backuptype)
                Next
            Case 4
                For Each item As String In lvc_Fri
                    Dim timepart As String = item.Substring(0, 5) 'get first 5 chars (the time like HH:MM)
                    Dim backuptype As String = item.Substring(5, item.Length - (5 + 1))
                    Dim tempitem As ListViewItem = lv_timetable.Items.Add(timepart)
                    tempitem.SubItems.Add(backuptype)
                Next
            Case 5
                For Each item As String In lvc_Sat
                    Dim timepart As String = item.Substring(0, 5) 'get first 5 chars (the time like HH:MM)
                    Dim backuptype As String = item.Substring(5, item.Length - (5 + 1))
                    Dim tempitem As ListViewItem = lv_timetable.Items.Add(timepart)
                    tempitem.SubItems.Add(backuptype)
                Next
            Case 6
                For Each item As String In lvc_Sun
                    Dim timepart As String = item.Substring(0, 5) 'get first 5 chars (the time like HH:MM)
                    Dim backuptype As String = item.Substring(5, item.Length - (5 + 1))
                    Dim tempitem As ListViewItem = lv_timetable.Items.Add(timepart)
                    tempitem.SubItems.Add(backuptype)
                Next
        End Select


        'define old index -  needed to keep old settings (and store them correctly in vars)
        lastcomboboxindex = dd_Day.SelectedIndex

    End Sub

    'executed when user wants toc hagne backuptype
    Private Sub b_changebackuptype_Click(sender As Object, e As EventArgs) Handles b_changebackuptype.Click
        Try
            'check if user has marked any specific time entry
            'if not, assume he wants to change everything of that day
        Catch ex As Exception

        End Try
    End Sub

    Public Function settings_of_dayn(day As Integer, settingsstringserialized As String) As String
        'get a settings string - and deserialize it and return settings for a specific day.
        'built like => MON::%time%;%time%TUE::%time%;%Time%WED::  etc
        Dim lastchar As Char
        Dim alreadyread As String = ""
        Dim daystring(7) As String
        Dim startpoints(7) As String
        Dim endpoints(7) As String
        Dim charssincelasttoplevelseperator As Long = -1 'first time :: signs are reached only the day description is before it 
        Dim Daysalreadyscanned As Integer = 0
        'there are always 3 Chars describing the day before the :: => Exmaple => MON::%data%;%data%TUE::%data%;%data%;....
        Dim contentextracted As Integer
        'loop nthorugh all chars in the string
        For i = 0 To settingsstringserialized.Length - 1 Step 1
            Dim currchar = settingsstringserialized(i)
            alreadyread = alreadyread & settingsstringserialized(i)

            'check if last and current char are ":" => this is the seperator
            If currchar = ":" And lastchar = ":" Then
                'remeber start point in loop for segment. (the index of first char after seperator!)
                startpoints(Daysalreadyscanned) = i + 1
                If (Daysalreadyscanned >= 1) Then
                    'notice the endpoint too (startpoint already found)
                    endpoints(Daysalreadyscanned - 1) = i - 5 'the startpoint may also be an endpoint except the first one! minus 5 because "MON::" does not count!
                    'set 1 "lower"(-1) in array because it s in the next loop
                End If


                'check if there is any data left to extract? (maybe only 1 day is filled)
                If Not contentextracted + 35 = settingsstringserialized.Length Then 'if this nr is reached, all characters are understood (only MON:: etc left - no real data)
                    '35 is the nr of chars needed for all Day seperators (MON:: = 5 chars * 7 days = 35 chars)
                    If Not Daysalreadyscanned = 0 Then 'fires when i is not 0 => the first loop (i=0) will contain "MON::"
                        Dim currstartpoint = startpoints(Daysalreadyscanned - 1) 'to access the last segment (seperator comes first hen the segment MON::%DATA%
                        Dim currendpoint = endpoints(Daysalreadyscanned - 1)
                        daystring(Daysalreadyscanned - 1) = settingsstringserialized.Substring(currstartpoint, currendpoint - currstartpoint + 1)
                        contentextracted = contentextracted + daystring(Daysalreadyscanned - 1).ToString.Length
                        ''msgboxes only for debugging...
                        '  MsgBox(daystring(Daysalreadyscanned - 1)) => returns the string from the array (daystring array)
                        ' MsgBox("Real Day : " & Daysalreadyscanned - 1) '-1because the seperator comes first (MON::%DATA%) => returns ht eactual day (0 = monday)

                    End If

                End If


                'reset charssincelasttoplevelseparator variable
                charssincelasttoplevelseperator = 0

                'next day is reached - put in the end that the first "MON::" is not counted - otherwise it would produce errors
                Daysalreadyscanned += 1

            End If
            'no sperator found - increase counter
            charssincelasttoplevelseperator += 1

            'set the last char variable for next loop
            lastchar = currchar
        Next
        If daystring(day) Is Nothing Then
            Return "Nothing Configured"
        End If
        Select Case day
            Case 0 'monday
                Return daystring(0)
            Case 1 'tuesday
                Return daystring(1)
            Case 2 'wed etc...
                Return daystring(2)
            Case 3
                Return daystring(3)
            Case 4
                Return daystring(4)
            Case 5
                Return daystring(5)
            Case 6
                Return daystring(6)
        End Select
        Return -1
    End Function

    Private Sub b_add_Click(sender As Object, e As EventArgs) Handles b_add.Click
        'define target array
        Dim finalarray As New ArrayList
        'get selected time
        Dim seltimehours As Integer = dtp.ToString.Substring(dtp.ToString.Length - 8, 2)
        Dim seltimeminutes As String = dtp.ToString.Substring(dtp.ToString.Length - 5, 2)
        Dim intervall As Integer = Me.tb_intervall.Text

        'if checkbox is checked calculate others and add them (and check if intervall makes sense, if not just add currently selected time)
        If cb_intervall.Checked = True And Not (intervall = 24 Or intervall = 0) Then
            'loop through all times from selected 
            For i As Integer = seltimehours To 0 Step -intervall
                Dim resulthour As String = i.ToString
                'i is an hour which should be added according to the intervall specified
                'add it to target raray (it will be reversed, so on end revers all of it so it s sorted correctly to add it later
                'check if hour is below 10 if so ad a 0 in front
                If i < 10 Then
                    resulthour = "0" & i.ToString
                End If
                finalarray.Add(resulthour)
            Next
            'reverse the orger of the array
            finalarray.Reverse()
            'loop thorugh all hours from the selcted hour to 24
            For i As Integer = seltimehours + intervall To 24 Step intervall '+intervall in the i= declaration to prevent add the selected time 2 times. (prevents a "bug")
                If i = 24 Then
                    'exclude the 24 hour since it doesnt exist =)
                    Exit For
                End If
                finalarray.Add(i)
            Next

            'add all members 
            For Each hourentry As String In finalarray
                'recreating time structure ( HH:MM )
                Dim finalentry = hourentry & ":" & seltimeminutes
                Dim tempitem As ListViewItem = lv_timetable.Items.Add(finalentry)
                'assume the backuptype is full - make another dropdowm in gui for that?
                tempitem.SubItems.Add("Full")
            Next
        Else
            'just add selected value
            'gt entered text and add to richtextbox (later also array)
            Dim tempitem As ListViewItem = lv_timetable.Items.Add(dtp.ToString.Substring(dtp.ToString.Length - 8, 5))
            tempitem.SubItems.Add("Full")
        End If

    End Sub

    Private Sub b_stopediting_Click(sender As Object, e As EventArgs) Handles b_stopediting.Click

        'first create timesettings string to save to xml
        'reset finalstring if executed before (var is public)
        finalstring = ""

        Select Case dd_Day.SelectedIndex
            Case 0
                'build an array out of all items in listview and save them accoridngly in var as string
                If Not lv_timetable.Items.Count = 0 Then 'check if there are no items , otherwise it would add unnessecery ";" chars which kills the settings file
                    Dim temparray As New ArrayList
                    For Each item As ListViewItem In lv_timetable.Items


                        'gett al entry of a line in lv and save them as 1 entry in array
                        'later get it back by serializing the string and get data for each line
                        Dim tempitemtext As String
                        tempitemtext = item.Text
                        tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                        temparray.Add(tempitemtext)
                    Next
                    lvc_Mon = temparray
                End If
            Case 1
                If Not lv_timetable.Items.Count = 0 Then 'check if there are no items , otherwise it would add unnessecery ";" chars which kills the settings file
                    Dim temparray As New ArrayList
                    For Each item As ListViewItem In lv_timetable.Items
                        'gett al entry of a line in lv and save them as 1 entry in array
                        'later get it back by serializing the string and get data for each line
                        Dim tempitemtext As String
                        tempitemtext = item.Text
                        tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                        temparray.Add(tempitemtext)
                    Next
                    lvc_Tue = temparray
                End If
            Case 2
                If Not lv_timetable.Items.Count = 0 Then 'check if there are no items , otherwise it would add unnessecery ";" chars which kills the settings file
                    Dim temparray As New ArrayList
                    For Each item As ListViewItem In lv_timetable.Items
                        'gett al entry of a line in lv and save them as 1 entry in array
                        'later get it back by serializing the string and get data for each line
                        Dim tempitemtext As String
                        tempitemtext = item.Text
                        tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                        temparray.Add(tempitemtext)
                    Next
                    lvc_Wed = temparray
                End If
            Case 3
                If Not lv_timetable.Items.Count = 0 Then 'check if there are no items , otherwise it would add unnessecery ";" chars which kills the settings file
                    Dim temparray As New ArrayList
                    For Each item As ListViewItem In lv_timetable.Items
                        'gett al entry of a line in lv and save them as 1 entry in array
                        'later get it back by serializing the string and get data for each line
                        Dim tempitemtext As String
                        tempitemtext = item.Text
                        tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                        temparray.Add(tempitemtext)
                    Next
                    lvc_Thu = temparray
                End If
            Case 4
                If Not lv_timetable.Items.Count = 0 Then 'check if there are no items , otherwise it would add unnessecery ";" chars which kills the settings file
                    Dim temparray As New ArrayList
                    For Each item As ListViewItem In lv_timetable.Items
                        'gett al entry of a line in lv and save them as 1 entry in array
                        'later get it back by serializing the string and get data for each line
                        Dim tempitemtext As String
                        tempitemtext = item.Text
                        tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                        temparray.Add(tempitemtext)
                    Next
                    lvc_Fri = temparray
                End If
            Case 5
                If Not lv_timetable.Items.Count = 0 Then 'check if there are no items , otherwise it would add unnessecery ";" chars which kills the settings fil
                    Dim temparray As New ArrayList
                    For Each item As ListViewItem In lv_timetable.Items
                        'gett al entry of a line in lv and save them as 1 entry in array
                        'later get it back by serializing the string and get data for each line
                        Dim tempitemtext As String
                        tempitemtext = item.Text
                        tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                        temparray.Add(tempitemtext)
                    Next
                    lvc_Sat = temparray
                End If
            Case 6
                If Not lv_timetable.Items.Count = 0 Then 'check if there are no items , otherwise it would add unnessecery ";" chars which kills the settings file
                    Dim temparray As New ArrayList
                    For Each item As ListViewItem In lv_timetable.Items
                        'gett al entry of a line in lv and save them as 1 entry in array
                        'later get it back by serializing the string and get data for each line
                        Dim tempitemtext As String
                        tempitemtext = item.Text
                        tempitemtext = tempitemtext & item.SubItems(1).Text & seperator
                        temparray.Add(tempitemtext)
                    Next
                    lvc_Sun = temparray
                End If
        End Select

        'Process Monday Times 
        'write top lvl speerator =>
        finalstring = finalstring & "MON" & ToplevelSeperator
        'check if there are values to write
        If Not lvc_Mon Is Nothing Then
            'now loop through timearray and write all time and backuptype values into variable (later stored in array)

            For Each item As String In lvc_Mon
                finalstring = finalstring & item
            Next
        End If

        'set Tuesday
        'write top lvl speerator =>
        finalstring = finalstring & "TUE" & ToplevelSeperator
        'check if there are values to write
        If Not lvc_Tue Is Nothing Then
            'now loop through timearray and write all time and backuptype values into variable (later stored in array)
            For Each item As String In lvc_Tue
                finalstring = finalstring & item
            Next
        End If
        'set Wednesday
        'write top lvl speerator =>
        finalstring = finalstring & "WED" & ToplevelSeperator
        'check if there are values to write
        If Not lvc_Wed Is Nothing Then
            'now loop through timearray and write all time and backuptype values into variable (later stored in array)
            For Each item As String In lvc_Wed
                finalstring = finalstring & item
            Next
        End If

        'set thusday 
        'write top lvl speerator =>
        finalstring = finalstring & "THU" & ToplevelSeperator
        'check if there are values to write
        If Not lvc_Thu Is Nothing Then
            'now loop through timearray and write all time and backuptype values into variable (later stored in array)
            For Each item As String In lvc_Thu
                finalstring = finalstring & item
            Next
        End If

        'set friday
        'write top lvl speerator =>
        finalstring = finalstring & "FRI" & ToplevelSeperator
        'check if there are values to write
        If Not lvc_Fri Is Nothing Then
            'now loop through timearray and write all time and backuptype values into variable (later stored in array)
            For Each item As String In lvc_Fri
                finalstring = finalstring & item
            Next
        End If

        'set Saturday
        'write top lvl speerator =>
        finalstring = finalstring & "SAT" & ToplevelSeperator
        'check if there are values to write
        If Not lvc_Sat Is Nothing Then
            'now loop through timearray and write all time and backuptype values into variable (later stored in array)
            For Each item As String In lvc_Sun
                finalstring = finalstring & item
            Next
        End If

        'set Sunday
        '  ComboBox_Day.SelectedIndex = 6
        'write top lvl speerator =>
        finalstring = finalstring & "SUN" & ToplevelSeperator
        'check if there are values to write
        If Not lvc_Sun Is Nothing Then
            'now loop through timearray and write all time and backuptype values into variable (later stored in array)
            For Each item As String In lvc_Sat
                finalstring = finalstring & item
            Next
        End If


        'check if there is a entry to edit or not - set index accordingly (Folder arrays are updated by settings form via add button)
        'if an entry in settings form was selected  - assume user wants to edit it
        If Not Settings.lv_settings.SelectedItems.Count = 0 Then
            'user wants to edit entry
            'loop trhough the lines (all selected)
            For Each item As ListViewItem In Settings.lv_settings.SelectedItems
                'loop through all selected entries to set time
                home.timesettingsarray(item.Index) = finalstring
            Next
        Else
            'user wants to add entry (form is called when adding new entry)
            home.timesettingsarray.Add(finalstring)
        End If

        ' MsgBox(lvc_Mon.Count.ToString & " | " & lvc_Tue.Count.ToString & " | " & lvc_Wed.Count.ToString & " | " & lvc_Thu.Count.ToString & " | " & lvc_Fri.Count.ToString & " | " & lvc_Sat.Count.ToString & " | " & lvc_Sun.Count.ToString & " | ")
        'close form when finished
        Me.Close()
    End Sub

    Private Sub Timetable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'check if there are any settings to prevent errors
        If System.IO.File.Exists(home.getexedir() & "\default.xml") Then
            Settings_Reload()
        End If
    End Sub


    'function to reload all settings displayed in the form. Only use this one!
    Public Function Settings_Reload()
        '''''''''''''' Try
        'reset text before reloading settings (for each day)
        lv_timetable.Items.Clear()
        If Not Settings.lv_settings.SelectedItems.Count = 0 Then
            'get values of home class
            Dim timesettingsforcurrentfolderpair As String = home.timesettingsarray(Settings.linecurrentlyedited)
            'call settings for dayn with 0 argument to get values for monday and load them appropriately.
            'Go through all indexes (days) and fill them accordingly (the rtb will save it into the according variables when the index is changed)


            'TESTIGN

            Dim mondaytimes = settings_of_dayn(0, timesettingsforcurrentfolderpair)
            Dim mondaytimesarray As New ArrayList
            mondaytimesarray = home.StringtoArray(mondaytimes, seperator)
            'fill the current times into RTB_Time
            Dim tempmontimesettingsarray As New ArrayList
            For Each time As String In mondaytimesarray

                'gett all entry of a line in lv and save them as 1 entry in array
                'later get it back by serializing the string and get data for each line
                tempmontimesettingsarray.Add(time & seperator)
            Next
            lvc_Mon = tempmontimesettingsarray



            'TESTIGN

            'reset text before reloading settings (for each day)
            lv_timetable.Items.Clear()
            'select index to fill
            dd_Day.SelectedIndex = 1
            'next day (tue)
            Dim tuedaytimes = settings_of_dayn(1, timesettingsforcurrentfolderpair)
            Dim tuedaytimesarray As New ArrayList
            tuedaytimesarray = home.StringtoArray(tuedaytimes, seperator)
            'fill the current times into RTB_Time
            Dim temptuetimesettingsarray As New ArrayList
            For Each time As String In tuedaytimesarray

                'gett all entry of a line in lv and save them as 1 entry in array
                'later get it back by serializing the string and get data for each line
                temptuetimesettingsarray.Add(time & seperator)
            Next
            lvc_Tue = temptuetimesettingsarray

            'reset text before reloading settings (for each day)
            lv_timetable.Items.Clear()
            'select index to fill
            dd_Day.SelectedIndex = 2
            'next day (wed)
            Dim weddaytimes = settings_of_dayn(2, timesettingsforcurrentfolderpair)
            Dim weddaytimesarray As New ArrayList
            weddaytimesarray = home.StringtoArray(weddaytimes, seperator)
            'fill the current times into RTB_Time
            Dim tempwedtimesettingsarray As New ArrayList
            For Each time As String In weddaytimesarray

                'gett all entry of a line in lv and save them as 1 entry in array
                'later get it back by serializing the string and get data for each line
                tempwedtimesettingsarray.Add(time & seperator)
            Next
            lvc_Wed = tempwedtimesettingsarray

            'reset text before reloading settings (for each day)
            lv_timetable.Items.Clear()
            'select index to fill
            dd_Day.SelectedIndex = 3
            'next day (thu)
            Dim thudaytimes = settings_of_dayn(3, timesettingsforcurrentfolderpair)
            Dim thudaytimesarray As New ArrayList
            thudaytimesarray = home.StringtoArray(thudaytimes, seperator)
            'fill the current times into RTB_Time
            Dim tempthutimesettingsarray As New ArrayList
            For Each time As String In thudaytimesarray

                'gett all entry of a line in lv and save them as 1 entry in array
                'later get it back by serializing the string and get data for each line
                tempthutimesettingsarray.Add(time & seperator)
            Next
            lvc_Thu = tempthutimesettingsarray
            'reset text before reloading settings (for each day)
            lv_timetable.Items.Clear()
            'select index to fill
            dd_Day.SelectedIndex = 4
            'next day (fri)
            Dim fridaytimes = settings_of_dayn(4, timesettingsforcurrentfolderpair)
            Dim fridaytimesarray As New ArrayList
            fridaytimesarray = home.StringtoArray(fridaytimes, seperator)
            'fill the current times into RTB_Time
            Dim tempfritimesettingsarray As New ArrayList
            For Each time As String In fridaytimesarray

                'gett all entry of a line in lv and save them as 1 entry in array
                'later get it back by serializing the string and get data for each line
                tempfritimesettingsarray.Add(time & seperator)
            Next
            lvc_Fri = tempfritimesettingsarray
            'reset text before reloading settings (for each day)
            lv_timetable.Items.Clear()
            'select index to fill
            dd_Day.SelectedIndex = 5
            'next day (sat)
            Dim satdaytimes = settings_of_dayn(5, timesettingsforcurrentfolderpair)
            Dim satdaytimesarray As New ArrayList
            satdaytimesarray = home.StringtoArray(satdaytimes, seperator)
            'fill the current times into RTB_Time
            Dim tempsattimesettingsarray As New ArrayList
            For Each time As String In satdaytimesarray

                'gett all entry of a line in lv and save them as 1 entry in array
                'later get it back by serializing the string and get data for each line
                tempsattimesettingsarray.Add(time & seperator)
            Next
            lvc_Sat = tempsattimesettingsarray
            'reset text before reloading settings (for each day)
            lv_timetable.Items.Clear()
            'select index to fill
            dd_Day.SelectedIndex = 6
            'next day (sun)
            Dim sundaytimes = settings_of_dayn(6, timesettingsforcurrentfolderpair)
            Dim sundaytimesarray As New ArrayList
            sundaytimesarray = home.StringtoArray(sundaytimes, seperator)
            'fill the current times into RTB_Time
            Dim tempsuntimesettingsarray As New ArrayList
            For Each time As String In sundaytimesarray

                'gett all entry of a line in lv and save them as 1 entry in array
                'later get it back by serializing the string and get data for each line
                tempsuntimesettingsarray.Add(time & seperator)
            Next
            lvc_Sun = tempsuntimesettingsarray
            'select index 0 again (monday = 0) / or current day?
            dd_Day.SelectedIndex = 0
        Else
            'is nothing - dont  load settings => a new entry is created)
        End If
        ''''''  Catch ex As Exception
        ''''MessageBox.Show(ex.Message & vbNewLine & "Above Error occured in Settings_Reload Function", "Error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ''''   Return -1
        ''''   End Try
        Return 0
    End Function

    'sub executed when form is closed
    Private Sub Timetable_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        'asume the user aborted => Fill timesettgins var with normal value 
        'write the timesetting values into "home.vb" to store the data (currently all ar's are there - should be in settings though)
        Dim tsa = home.timesettingsarray 'define TimeSettingsArray (tsa)
        If tsa.Count = 0 Then 'if 0 cant use %var%.count -1 (it would result in -1)
            home.timesettingsarray.Add(finalstring) 'first one so use the add function
        Else
            home.timesettingsarray(tsa.Count - 1) = finalstring 'settings timesettingsarray over direct call cause I think it otherwise won't change the home.timesettingsarray variable (dim creates a new var I guess -so it would change the local one?)
        End If
    End Sub

    Private Sub b_reset_Click(sender As Object, e As EventArgs) Handles b_reset.Click
        Dim resetchoice = MessageBox.Show("Do you really want to reset ALL your configurations?", "Reset EVERYTHING?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resetchoice = vbYes Then
            'cycle through all time data and reset it
            For i = 0 To 6 Step 1
                dd_Day.SelectedIndex = i
                lv_timetable.Items.Clear()
            Next
            'select first day again
            dd_Day.SelectedIndex = 0
        Else
            'user aborted - maybe misclicked 
            MessageBox.Show("Reseting Configuration Aborted!", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'executed when remocve button is clicked
    Private Sub b_remove_Click(sender As Object, e As EventArgs) Handles b_remove.Click
        'loop through selected lines
        For Each item As ListViewItem In lv_timetable.SelectedItems
            'remove the selected line
            lv_timetable.Items.Remove(item)
        Next

    End Sub

    'sub called when mouse button is clicked (rtb refers to the clicked richtextbox!)
    Private Sub RTB_Time_MouseDown(sender As Object, e As MouseEventArgs)
        Try
            If home.sourcepatharray.Count = 0 Then
                Exit Sub
            End If
            'get mouseposition
            Dim rtb = DirectCast(sender, RichTextBox)
            'then get the char where the mouse is
            Dim index = rtb.GetCharIndexFromPosition(e.Location)
            'get the line where this char is (with it's index in the char array of the rtb)
            Dim line = rtb.GetLineFromCharIndex(index)
            'define the first char of line
            Dim lineStart = rtb.GetFirstCharIndexFromLine(line)
            'define the last one
            Dim lineEnd = rtb.GetFirstCharIndexFromLine(line + 1) - 1
            'start selection
            rtb.SelectionStart = lineStart
            'define the length of it
            rtb.SelectionLength = lineEnd - lineStart
            'define color to set
            Dim tempselectionfont
            If (rtb.SelectionFont.Style = FontStyle.Regular) Then
                'set the font type to bold to mark that it s selcted
                tempselectionfont = New Font(rtb.SelectionFont, FontStyle.Bold)
                'add to selcted line var
                selectedtimesarray.Add(line)
            Else
                'set font normal again
                tempselectionfont = New Font(rtb.SelectionFont, FontStyle.Regular)
                'remove the entry of selected lines again
                selectedtimesarray.Remove(line)
            End If
            rtb.SelectionFont = tempselectionfont
            'after setting bold font in both boxes, select "nothing" so no text is blue.
            rtb.SelectionStart = 0
            rtb.SelectionLength = 0
        Catch ex As Exception

        End Try

    End Sub

#End Region



End Class