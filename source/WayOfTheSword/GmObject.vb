Public Class GmObject

    Public Enum ObjectIndex
        ObjCharacter
        ObjMonster
    End Enum

    Private GUIBox As Panel = New Panel
    Private GUI As Graphics
    Private GUIBuffer As Bitmap = New Bitmap(frmMain.Width, frmMain.Height)
    Private ReDraw As Timer
    Public ObjectList(255) As ArrayList
    Public Score As Integer

    Public Sub New()
        GUIBox.Parent = frmMain.panGame
        GUIBox.BackColor = Color.Transparent
        GUIBox.Width = frmMain.Width
        GUIBox.Height = frmMain.Height
        GUI = GUIBox.CreateGraphics()
        AddHandler GUIBox.MouseUp, AddressOf MouseUp
        ReDraw = New Timer
        AddHandler ReDraw.Tick, AddressOf GUIDraw
        ReDraw.Interval = 17
        ReDraw.Enabled = True
    End Sub

    Public Sub GUIDraw(sender As Object, e As EventArgs)
        Dim drawing As Graphics = Graphics.FromImage(GUIBuffer)
        Dim j As Integer
        drawing.DrawImage(frmMain.panGame.BackgroundImage, New Point(0, 0))
        drawing.DrawImage(frmMain.panGame.BackgroundImage, New Point(351, 0))
        drawing.DrawString("Score: " & Score, frmMain.FntGame, Brushes.Black, New Point(frmMain.panGame.Width, 0), frmMain.FntStyle)
        For i = 0 To ObjectList.GetUpperBound(0)
            If (Not IsNothing(ObjectList(i))) Then
                j = 0
                While (j < ObjectList(i).Count)
                    Dim Instance As InstanceBase = ObjectList(i).Item(j)
                    If (Instance.ImageXSize = -1 Or Instance.ImageYSize = -1) Then
                        Dim ImgClone As Image = Instance.Image.Images(Instance.ImageIndex).Clone()
                        If (Instance.ImageXSize = -1) Then ImgClone.RotateFlip(RotateFlipType.RotateNoneFlipX)
                        If (Instance.ImageYSize = -1) Then ImgClone.RotateFlip(RotateFlipType.RotateNoneFlipY)
                        drawing.DrawImage(ImgClone, Instance.Position)
                    Else
                        drawing.DrawImage(Instance.Image.Images(Instance.ImageIndex), Instance.Position)
                    End If
                    j += 1
                End While
            End If
        Next
        GUI.DrawImage(GUIBuffer, New Point(0, 0))
    End Sub

    Public Sub InstanceCreate(ByVal ObjIndex As ObjectIndex, ByVal Position As Point, ByVal Depth As Byte)
        Dim Instance As InstanceBase
        Select Case ObjIndex
            Case ObjectIndex.ObjMonster
                If (IsNothing(ObjectList(Depth))) Then ObjectList(Depth) = New ArrayList
                Instance = New ObjMonster(ObjectIndex.ObjMonster, ObjectList(Depth).Count, Position, Depth)
            Case Else
                If (IsNothing(ObjectList(Depth))) Then ObjectList(Depth) = New ArrayList
                Instance = New ObjCharacter(ObjectIndex.ObjCharacter, ObjectList(Depth).Count, Position, Depth)
        End Select
        ObjectList(Depth).Add(Instance)
    End Sub

    Public Sub InstanceDestroy(ByVal Index As Integer, ByVal Depth As Byte)
        Dim Instance As InstanceBase = ObjectList(Depth).Item(Index)
        Dim i As Integer
        Instance.GmStep.Dispose()
        Instance.ImgStep.Dispose()
        ObjectList(Depth).RemoveAt(Index)
        i = Index
        While (i < ObjectList(Depth).Count)
            Instance = ObjectList(Depth).Item(i)
            Instance.Index -= 1
            i += 1
        End While
    End Sub

    Public Sub MouseUp(sender As Object, e As MouseEventArgs)
        Dim j As Integer
        For i = 0 To ObjectList.GetUpperBound(0)
            If (Not IsNothing(ObjectList(i))) Then
                j = 0
                While (j < ObjectList(i).Count)
                    Dim Instance As InstanceBase = ObjectList(i).Item(j)
                    Instance.MouseGlobalPressedEvent(e)
                    j += 1
                End While
            End If
        Next
    End Sub
End Class

Public Class InstanceBase

    Public ObjIndex As GmObject.ObjectIndex
    Public Index As Integer
    Public Position As Point
    Public CenterPosition As Point
    Public Depth As Byte
    Public Image As ImageList
    Public ImageIndex As Integer
    Public ImageSpeed As Double = 1
    Public ImageXSize As Integer = 1
    Public ImageYSize As Integer = 1
    Public Speed As Integer
    Public Direction As Integer
    Public Attack As Boolean
    Public GmStep As Timer
    Public ImgStep As Timer

    Public Sub New(ByVal ObjIndex As GmObject.ObjectIndex, ByVal Index As Integer, ByVal Position As Point, ByVal Depth As Byte)
        Me.ObjIndex = ObjIndex
        Me.Index = Index
        Me.Position = Position
        Me.Depth = Depth
        GmStep = New Timer
        AddHandler GmStep.Tick, AddressOf GMStepEvent
        GmStep.Interval = 17
        GmStep.Enabled = True
        ImgStep = New Timer
        AddHandler ImgStep.Tick, AddressOf ImgEvent
        ImgStep.Interval = 17 / (ImageSpeed)
        ImgStep.Enabled = True
    End Sub

    Public Sub GMStepEvent(sender As Object, e As EventArgs)
        Position = New Point(Position.X + LengthdirX(Speed, Direction), Position.Y + LengthdirY(Speed, Direction))
        StepEvent()
    End Sub

    Public Sub ImgEvent(sender As Object, e As EventArgs)
        If (Image.Images.Count = ImageIndex + 1) Then
            ImageIndex = 0
            AnimationEndEvent()
        Else
            ImageIndex += 1
        End If
        CenterPosition = New Point(Position.X + Fix(Image.Images(ImageIndex).Width / 2), Position.Y + Fix(Image.Images(ImageIndex).Height / 2))
        ImgStep.Interval = 17 / (ImageSpeed)
    End Sub

    Public Overridable Sub StepEvent()
    End Sub

    Public Overridable Sub AnimationEndEvent()
    End Sub

    Public Overridable Sub MouseGlobalPressedEvent(e As MouseEventArgs)
    End Sub

    Public Function LengthdirX(ByVal Len As Integer, ByVal Dir As Integer) As Integer
        Return Len * Math.Cos(Dir * Math.PI / 180)
    End Function

    Public Function LengthdirY(ByVal Len As Integer, ByVal Dir As Integer) As Integer
        Return -Len * Math.Sin(Dir * Math.PI / 180)
    End Function

    Public Function IntersectLine(X As Integer, W As Integer, X2 As Integer, W2 As Integer) As Boolean
        If ((W > X2) And (X < W2)) Then Return True
        Return False
    End Function
End Class

Public Class ObjCharacter

    Inherits InstanceBase

    Public Sub New(ByVal ObjIndex As GmObject.ObjectIndex, ByVal Index As Integer, ByVal Position As Point, ByVal Depth As Byte)
        MyBase.New(ObjIndex, Index, Position, Depth)
        Image = frmMain.imglstCharBasic
        ImageSpeed = 0.3
        CenterPosition = New Point(Position.X + Fix(Image.Images(ImageIndex).Width / 2), Position.Y + Fix(Image.Images(ImageIndex).Height / 2))
    End Sub

    Public Overrides Sub AnimationEndEvent()
        Image = frmMain.imglstCharBasic
        Attack = False
    End Sub

    Public Overrides Sub MouseGlobalPressedEvent(e As MouseEventArgs)
        If (e.Button = MouseButtons.Left) Then
            If (e.X > Position.X) Then
                ImageXSize = 1
                Image = frmMain.imglstCharAttack
                ImageIndex = 0
                Attack = True
            Else
                ImageXSize = -1
                Image = frmMain.imglstCharAttack
                ImageIndex = 0
                Attack = True
            End If
        End If
    End Sub

    Public Overrides Sub StepEvent()
        Dim j As Integer
        For i = 0 To frmMain.GmSystem.ObjectList.GetUpperBound(0)
            If (Not IsNothing(frmMain.GmSystem.ObjectList(i))) Then
                j = 0
                While (j < frmMain.GmSystem.ObjectList(i).Count)
                    Dim Instance As InstanceBase = frmMain.GmSystem.ObjectList(i).Item(j)
                    If (Instance.ObjIndex = GmObject.ObjectIndex.ObjMonster) Then
                        Dim MeX, MeX2, YoX, YoX2 As Integer
                        MeX = Position.X + 10
                        MeX2 = Position.X + Image.Images(ImageIndex).Width - 20
                        YoX = Instance.Position.X
                        YoX2 = Instance.Position.X + Instance.Image.Images(Instance.ImageIndex).Width
                        If (IntersectLine(MeX, MeX2, YoX, YoX2)) Then
                            frmMain.GmSystem.InstanceDestroy(Index, Depth)
                            frmMain.BGM.controls.stop()
                            frmMain.timCreate.Enabled = False
                            frmMain.groLevel.Enabled = True
                            frmMain.btnStart.Enabled = True
                        End If
                    End If
                    j += 1
                End While
            End If
        Next
    End Sub
End Class

Public Class ObjMonster

    Inherits InstanceBase

    Public Sub New(ByVal ObjIndex As GmObject.ObjectIndex, ByVal Index As Integer, ByVal Position As Point, ByVal Depth As Byte)
        MyBase.New(ObjIndex, Index, Position, Depth)
        Randomize()
        Speed = Rnd() * 10 + 1
        Dim img As New Random
        Select Case img.Next(0, 5)
            Case 0 : Image = frmMain.imgMonster1
            Case 1 : Image = frmMain.imgMonster2
            Case 2 : Image = frmMain.imgMonster3
            Case Else
                Image = frmMain.imgMonster4
        End Select
        CenterPosition = New Point(Position.X + Fix(Image.Images(ImageIndex).Width / 2), Position.Y + Fix(Image.Images(ImageIndex).Height / 2))
        If (Position.X <> 0) Then
            Direction = 180
        End If
    End Sub

    Public Overrides Sub StepEvent()
        Dim j As Integer
        For i = 0 To frmMain.GmSystem.ObjectList.GetUpperBound(0)
            If (Not IsNothing(frmMain.GmSystem.ObjectList(i))) Then
                j = 0
                While (j < frmMain.GmSystem.ObjectList(i).Count)
                    Dim Instance As InstanceBase = frmMain.GmSystem.ObjectList(i).Item(j)
                    If (Instance.ObjIndex = GmObject.ObjectIndex.ObjCharacter) Then
                        Dim MeX, MeX2, YoX, YoX2 As Integer
                        MeX = Position.X
                        MeX2 = Position.X + Image.Images(ImageIndex).Width
                        If (Instance.ImageXSize = 1) Then
                            YoX = Instance.CenterPosition.X
                            YoX2 = Instance.CenterPosition.X + Instance.Image.Images(Instance.ImageIndex).Width / 2
                        Else
                            YoX = Instance.CenterPosition.X - Instance.Image.Images(Instance.ImageIndex).Width / 2
                            YoX2 = Instance.CenterPosition.X
                        End If
                        If (Instance.Attack = True AndAlso IntersectLine(MeX, MeX2, YoX, YoX2)) Then
                            frmMain.GmSystem.InstanceDestroy(Index, Depth)
                            Instance.Attack = False
                            frmMain.GmSystem.Score += 1
                        End If
                    End If
                    j += 1
                End While
            End If
        Next
        If (Position.X > frmMain.Width Or Position.X + Image.Images(ImageIndex).Width < 0) Then
            frmMain.GmSystem.InstanceDestroy(Index, Depth)
        End If
    End Sub
End Class