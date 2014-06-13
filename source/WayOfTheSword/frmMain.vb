Imports WMPLib

Public Class frmMain

    Public GmSystem As GmObject
    Public BGM As New WindowsMediaPlayer
    Public FntGame As Font = New Font("Courier New", 16, FontStyle.Bold)
    Public FntStyle As StringFormat = New StringFormat

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GmSystem = New GmObject
        btnStart.Focus()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        BGM.URL = "bgm.mp3"
        BGM.controls.play()
        FntStyle.Alignment = StringAlignment.Far
        GmSystem.Score = 0
        GmSystem.InstanceCreate(GmObject.ObjectIndex.ObjCharacter, New Point(194, 138), 1)
        If (rdoLevel1.Checked = True) Then
            timCreate.Interval = 2000
        ElseIf (rdoLevel2.Checked = True) Then
            timCreate.Interval = 1000
        Else
            timCreate.Interval = 500
        End If
        timCreate.Enabled = True
        groLevel.Enabled = False
        btnStart.Enabled = False
    End Sub

    Private Sub timCreate_Tick(sender As Object, e As EventArgs) Handles timCreate.Tick
        Randomize()
        Dim dir As New Random
        If (dir.Next(0, 2) = 0) Then
            GmSystem.InstanceCreate(GmObject.ObjectIndex.ObjMonster, New Point(0, 200), 1)
        Else
            GmSystem.InstanceCreate(GmObject.ObjectIndex.ObjMonster, New Point(Me.Width, 200), 1)
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        End
    End Sub
End Class