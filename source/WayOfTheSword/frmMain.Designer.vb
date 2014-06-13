<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.imgMonster1 = New System.Windows.Forms.ImageList(Me.components)
        Me.imglstCharBasic = New System.Windows.Forms.ImageList(Me.components)
        Me.imglstCharAttack = New System.Windows.Forms.ImageList(Me.components)
        Me.timCreate = New System.Windows.Forms.Timer(Me.components)
        Me.imgMonster2 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgMonster3 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgMonster4 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgMonster5 = New System.Windows.Forms.ImageList(Me.components)
        Me.groLevel = New System.Windows.Forms.GroupBox()
        Me.rdoLevel3 = New System.Windows.Forms.RadioButton()
        Me.rdoLevel2 = New System.Windows.Forms.RadioButton()
        Me.rdoLevel1 = New System.Windows.Forms.RadioButton()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.panGame = New System.Windows.Forms.Panel()
        Me.groLevel.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgMonster1
        '
        Me.imgMonster1.ImageStream = CType(resources.GetObject("imgMonster1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMonster1.TransparentColor = System.Drawing.Color.Transparent
        Me.imgMonster1.Images.SetKeyName(0, "apple.png")
        '
        'imglstCharBasic
        '
        Me.imglstCharBasic.ImageStream = CType(resources.GetObject("imglstCharBasic.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstCharBasic.TransparentColor = System.Drawing.Color.Transparent
        Me.imglstCharBasic.Images.SetKeyName(0, "Character_0_0.png")
        Me.imglstCharBasic.Images.SetKeyName(1, "Character_0_1.png")
        Me.imglstCharBasic.Images.SetKeyName(2, "Character_0_2.png")
        Me.imglstCharBasic.Images.SetKeyName(3, "Character_0_3.png")
        '
        'imglstCharAttack
        '
        Me.imglstCharAttack.ImageStream = CType(resources.GetObject("imglstCharAttack.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstCharAttack.TransparentColor = System.Drawing.Color.Transparent
        Me.imglstCharAttack.Images.SetKeyName(0, "Character_1_0.png")
        Me.imglstCharAttack.Images.SetKeyName(1, "Character_1_1.png")
        Me.imglstCharAttack.Images.SetKeyName(2, "Character_1_2.png")
        Me.imglstCharAttack.Images.SetKeyName(3, "Character_1_3.png")
        Me.imglstCharAttack.Images.SetKeyName(4, "Character_1_4.png")
        Me.imglstCharAttack.Images.SetKeyName(5, "Character_1_5.png")
        Me.imglstCharAttack.Images.SetKeyName(6, "Character_1_6.png")
        Me.imglstCharAttack.Images.SetKeyName(7, "Character_1_7.png")
        '
        'timCreate
        '
        Me.timCreate.Interval = 1000
        '
        'imgMonster2
        '
        Me.imgMonster2.ImageStream = CType(resources.GetObject("imgMonster2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMonster2.TransparentColor = System.Drawing.Color.Transparent
        Me.imgMonster2.Images.SetKeyName(0, "banana.png")
        '
        'imgMonster3
        '
        Me.imgMonster3.ImageStream = CType(resources.GetObject("imgMonster3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMonster3.TransparentColor = System.Drawing.Color.Transparent
        Me.imgMonster3.Images.SetKeyName(0, "ghost.png")
        '
        'imgMonster4
        '
        Me.imgMonster4.ImageStream = CType(resources.GetObject("imgMonster4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMonster4.TransparentColor = System.Drawing.Color.Transparent
        Me.imgMonster4.Images.SetKeyName(0, "rock.png")
        '
        'imgMonster5
        '
        Me.imgMonster5.ImageStream = CType(resources.GetObject("imgMonster5.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMonster5.TransparentColor = System.Drawing.Color.Transparent
        Me.imgMonster5.Images.SetKeyName(0, "bomb.png")
        '
        'groLevel
        '
        Me.groLevel.Controls.Add(Me.rdoLevel3)
        Me.groLevel.Controls.Add(Me.rdoLevel2)
        Me.groLevel.Controls.Add(Me.rdoLevel1)
        Me.groLevel.Location = New System.Drawing.Point(12, 264)
        Me.groLevel.Name = "groLevel"
        Me.groLevel.Size = New System.Drawing.Size(200, 86)
        Me.groLevel.TabIndex = 0
        Me.groLevel.TabStop = False
        Me.groLevel.Text = "난이도"
        '
        'rdoLevel3
        '
        Me.rdoLevel3.AutoSize = True
        Me.rdoLevel3.Location = New System.Drawing.Point(6, 64)
        Me.rdoLevel3.Name = "rdoLevel3"
        Me.rdoLevel3.Size = New System.Drawing.Size(59, 16)
        Me.rdoLevel3.TabIndex = 2
        Me.rdoLevel3.Text = "어려움"
        Me.rdoLevel3.UseVisualStyleBackColor = True
        '
        'rdoLevel2
        '
        Me.rdoLevel2.AutoSize = True
        Me.rdoLevel2.Checked = True
        Me.rdoLevel2.Location = New System.Drawing.Point(6, 42)
        Me.rdoLevel2.Name = "rdoLevel2"
        Me.rdoLevel2.Size = New System.Drawing.Size(47, 16)
        Me.rdoLevel2.TabIndex = 0
        Me.rdoLevel2.TabStop = True
        Me.rdoLevel2.Text = "보통"
        Me.rdoLevel2.UseVisualStyleBackColor = True
        '
        'rdoLevel1
        '
        Me.rdoLevel1.AutoSize = True
        Me.rdoLevel1.Location = New System.Drawing.Point(6, 20)
        Me.rdoLevel1.Name = "rdoLevel1"
        Me.rdoLevel1.Size = New System.Drawing.Size(47, 16)
        Me.rdoLevel1.TabIndex = 1
        Me.rdoLevel1.Text = "쉬움"
        Me.rdoLevel1.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(243, 277)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 67)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "시작하기"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnEnd
        '
        Me.btnEnd.Location = New System.Drawing.Point(367, 277)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(75, 67)
        Me.btnEnd.TabIndex = 4
        Me.btnEnd.Text = "게임 종료"
        Me.btnEnd.UseVisualStyleBackColor = True
        '
        'panGame
        '
        Me.panGame.BackgroundImage = Global.WayOfTheSword.My.Resources.Resources.bgr
        Me.panGame.Location = New System.Drawing.Point(18, 12)
        Me.panGame.Name = "panGame"
        Me.panGame.Size = New System.Drawing.Size(424, 234)
        Me.panGame.TabIndex = 5
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 362)
        Me.Controls.Add(Me.panGame)
        Me.Controls.Add(Me.btnEnd)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.groLevel)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(480, 400)
        Me.MinimumSize = New System.Drawing.Size(480, 400)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Way Of The Sword"
        Me.groLevel.ResumeLayout(False)
        Me.groLevel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imgMonster1 As System.Windows.Forms.ImageList
    Friend WithEvents imglstCharBasic As System.Windows.Forms.ImageList
    Friend WithEvents imglstCharAttack As System.Windows.Forms.ImageList
    Friend WithEvents timCreate As System.Windows.Forms.Timer
    Friend WithEvents imgMonster2 As System.Windows.Forms.ImageList
    Friend WithEvents imgMonster3 As System.Windows.Forms.ImageList
    Friend WithEvents imgMonster4 As System.Windows.Forms.ImageList
    Friend WithEvents imgMonster5 As System.Windows.Forms.ImageList
    Friend WithEvents groLevel As System.Windows.Forms.GroupBox
    Friend WithEvents rdoLevel3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLevel2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLevel1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnEnd As System.Windows.Forms.Button
    Friend WithEvents panGame As System.Windows.Forms.Panel

End Class
