Public Class Timetable

    Public selectedday As Integer
    Public ToplevelSeperator As String = "::" 'has to be 2 chars (should be)  if changed code needs to change too!
    Public seperator As String = ";"
    Public RTB_Lines_Mon() As String
    Public RTB_Lines_Tue() As String
    Public RTB_Lines_Wed() As String
    Public RTB_Lines_Thu() As String
    Public RTB_Lines_Fri() As String
    Public RTB_Lines_Sat() As String
    Public RTB_Lines_Sun() As String
    Dim lastcomboboxindex As Integer

    Private Sub ComboBox_Day_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Day.SelectedIndexChanged

        'this code gets executed when the Selection of the "Daypickbox" (dropdown) changes
        'use this to reread all settings when user changes to another Day
        selectedday = ComboBox_Day.SelectedIndex


        'define Lines for lastly selected day (before changing index)
        'when it changes again, reload the data for the selected day
        Select Case lastcomboboxindex
            Case 0
                RTB_Lines_Mon = RTB_Time.Lines
            Case 1
                RTB_Lines_Tue = RTB_Time.Lines
            Case 2
                RTB_Lines_Wed = RTB_Time.Lines
            Case 3
                RTB_Lines_Thu = RTB_Time.Lines
            Case 4
                RTB_Lines_Fri = RTB_Time.Lines
            Case 5
                RTB_Lines_Sat = RTB_Time.Lines
            Case 6
                RTB_Lines_Sun = RTB_Time.Lines
        End Select

        'clear old data in RTB
        RTB_Time.Clear()
        'reread data for new day  and repupulate RTB
        'this is for the currently selected index
        Select Case selectedday
            Case 0
                RTB_Time.Lines = RTB_Lines_Mon
            Case 1
                RTB_Time.Lines = RTB_Lines_Tue
            Case 2
                RTB_Time.Lines = RTB_Lines_Wed
            Case 3
                RTB_Time.Lines = RTB_Lines_Thu
            Case 4
                RTB_Time.Lines = RTB_Lines_Fri
            Case 5
                RTB_Time.Lines = RTB_Lines_Sat
            Case 6
                RTB_Time.Lines = RTB_Lines_Sun
        End Select


        'define old index -  needed to keep old settings (and store them correctly in vars)
        lastcomboboxindex = ComboBox_Day.SelectedIndex

    End Sub

    Public Function settings_of_dayn(day As Integer, settingsstringserialized As String)
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
                    If Not Daysalreadyscanned = 0 Then 'fires when i is not 0 => the first loop (i=0) will contain "MON::"
                        Dim currstartpoint = startpoints(Daysalreadyscanned - 1) 'to access the last segment (seperator comes first hen the segment MON::%DATA%
                        Dim currendpoint = endpoints(Daysalreadyscanned - 1)
                        daystring(Daysalreadyscanned - 1) = settingsstringserialized.Substring(currstartpoint, currendpoint - currstartpoint + 1)
                        contentextracted = contentextracted + daystring(Daysalreadyscanned - 1).ToString.Length
                        ' MsgBox(settingsstringserialized.Substring(currstartpoint, currendpoint - currstartpoint + 1))
                        MsgBox(daystring(Daysalreadyscanned - 1))
                        ' MsgBox("days scanned : " & Daysalreadyscanned)
                        MsgBox("Real Day : " & Daysalreadyscanned - 1) '-1because the seperator comes first (MON::%DATA%)
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

        Select Case daystring(Daysalreadyscanned - 1)
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

    End Function

    Private Sub b_add_Click(sender As Object, e As EventArgs) Handles b_add.Click
        'gt entered text and add to richtextbox (later also array)
        RTB_Time.AppendText(DTP.ToString.Substring(DTP.ToString.Length - 8, 5) & vbNewLine)

    End Sub

    Private Sub b_stopediting_Click(sender As Object, e As EventArgs) Handles b_stopediting.Click
    
        Dim finalstring As String = ""

        ' save the current field too - if edited it will be saved in the Variable, since it only saves when the combox (day) is changed . 
        'this might not happen the last time, so save it here (too) 

        Select Case ComboBox_Day.SelectedIndex
            Case 0
                RTB_Lines_Mon = RTB_Time.Lines
            Case 1
                RTB_Lines_Tue = RTB_Time.Lines
            Case 2
                RTB_Lines_Wed = RTB_Time.Lines
            Case 3
                RTB_Lines_Thu = RTB_Time.Lines
            Case 4
                RTB_Lines_Fri = RTB_Time.Lines
            Case 5
                RTB_Lines_Sat = RTB_Time.Lines
            Case 6
                RTB_Lines_Sun = RTB_Time.Lines
        End Select

        'Process Monday Times 
        'write top lvl speerator =>
        finalstring = finalstring & "MON" & ToplevelSeperator
        'check if there are values to write
        If Not RTB_Lines_Mon Is Nothing Then
            'now write monday the values seperated by ";"
            For ii = 0 To RTB_Lines_Mon.LongCount - 2 'this is minus 2 because: -1 is needed anyway . -2 is needed because a vbnewline is written - if there is only 1 time in the RTP thereare still 2 Lines. 
                'If this would not be 2 there would be 2 ";;" written after the last value.
                ' wrtie current line =>
                finalstring = finalstring & RTB_Lines_Mon(ii).ToString & seperator
            Next

        End If

        'set Tuesday
        'write top lvl speerator =>
        finalstring = finalstring & "TUE" & ToplevelSeperator
        'check if there are values to write
        If Not RTB_Lines_Tue Is Nothing Then
            For ii = 0 To RTB_Lines_Tue.LongCount - 2
                ' wrtie current line =>
                finalstring = finalstring & RTB_Lines_Tue(ii) & seperator
            Next
        End If
        'set Wednesday
        'write top lvl speerator =>
        finalstring = finalstring & "WED" & ToplevelSeperator
        'check if there are values to write
        If Not RTB_Lines_Wed Is Nothing Then
            For ii = 0 To RTB_Lines_Wed.LongCount - 2
                ' wrtie current line =>
                finalstring = finalstring & RTB_Lines_Wed(ii) & seperator
            Next
        End If

        'set thusday 
        'write top lvl speerator =>
        finalstring = finalstring & "THU" & ToplevelSeperator
        'check if there are values to write
        If Not RTB_Lines_Thu Is Nothing Then
            For ii = 0 To RTB_Lines_Thu.LongCount - 2
                ' wrtie current line =>
                finalstring = finalstring & RTB_Lines_Thu(ii) & seperator
            Next
        End If

        'set friday
        'write top lvl speerator =>
        finalstring = finalstring & "FRI" & ToplevelSeperator
        'check if there are values to write
        If Not RTB_Lines_Fri Is Nothing Then
            For ii = 0 To RTB_Lines_Fri.LongCount - 2
                ' wrtie current line =>
                finalstring = finalstring & RTB_Lines_Fri(ii) & seperator
            Next
        End If

        'set Saturday
        'write top lvl speerator =>
        finalstring = finalstring & "SAT" & ToplevelSeperator
        'check if there are values to write
        If Not RTB_Lines_Sat Is Nothing Then
            For ii = 0 To RTB_Lines_Sat.LongCount - 2
                ' wrtie current line =>
                finalstring = finalstring & RTB_Lines_Sat(ii) & seperator
            Next
        End If

        'set Sunday
        '  ComboBox_Day.SelectedIndex = 6
        'write top lvl speerator =>
        finalstring = finalstring & "SUN" & ToplevelSeperator
        'check if there are values to write
        If Not RTB_Lines_Sun Is Nothing Then
            For ii = 0 To RTB_Lines_Sun.LongCount - 2
                ' wrtie current line =>
                finalstring = finalstring & RTB_Lines_Sun(ii) & seperator
            Next
        End If


        ''''  Next

        'debug => print the string to check the values => 
        'MsgBox(finalstring)
        settings_of_dayn(0, finalstring)
    End Sub

    Private Sub Timetable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      'call function settings_of_dayn() with argument for current day to get the part of data 
        ''''''''''''''''''''''''' settings_of_dayn(selectedday, "Timesettings part read out from XML")
    End Sub

    Private Sub b_reset_Click(sender As Object, e As EventArgs) Handles b_reset.Click
        'cycle through all time data and reset it
        For i = 0 To 6 Step 1
            ComboBox_Day.SelectedIndex = i
            RTB_Time.Clear()
        Next
        ComboBox_Day.SelectedIndex = 0
    End Sub
End Class