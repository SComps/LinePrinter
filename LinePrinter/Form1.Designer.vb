<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.checkautofont = New System.Windows.Forms.CheckBox()
        Me.fontsize = New System.Windows.Forms.TextBox()
        Me.fontname = New System.Windows.Forms.ComboBox()
        Me.checklandscape = New System.Windows.Forms.CheckBox()
        Me.destination = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.checkstart = New System.Windows.Forms.CheckBox()
        Me.checkignore = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.inputstream = New System.Windows.Forms.TextBox()
        Me.printertype = New System.Windows.Forms.ComboBox()
        Me.printername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.monitor = New System.Windows.Forms.RichTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fileChooser = New System.Windows.Forms.OpenFileDialog()
        Me.page_Setup = New System.Windows.Forms.PageSetupDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplicationToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ApplicationToolStripMenuItem
        '
        Me.ApplicationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.ApplicationToolStripMenuItem.Name = "ApplicationToolStripMenuItem"
        Me.ApplicationToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.ApplicationToolStripMenuItem.Text = "Application"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 411)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.ListBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(768, 385)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dashboard"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(183, 341)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 38)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Pause Selected"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(102, 341)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 38)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Pause All"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Line Printer 132", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(6, 6)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(371, 334)
        Me.ListBox1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button8)
        Me.TabPage2.Controls.Add(Me.Button7)
        Me.TabPage2.Controls.Add(Me.Button6)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.checkautofont)
        Me.TabPage2.Controls.Add(Me.fontsize)
        Me.TabPage2.Controls.Add(Me.fontname)
        Me.TabPage2.Controls.Add(Me.checklandscape)
        Me.TabPage2.Controls.Add(Me.destination)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.checkstart)
        Me.TabPage2.Controls.Add(Me.checkignore)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.inputstream)
        Me.TabPage2.Controls.Add(Me.printertype)
        Me.TabPage2.Controls.Add(Me.printername)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.ListBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(768, 385)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Printers"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(581, 187)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 23
        Me.Button8.Text = "Page Setup"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(394, 266)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 22
        Me.Button7.Text = "Cancel"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(313, 266)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Save"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(87, 354)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 20
        Me.Button5.Text = "Delete"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 354)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 19
        Me.Button4.Text = "New"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(661, 117)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "Choose"
        Me.ToolTip1.SetToolTip(Me.Button3, "Browse to choose the input file source")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(226, 245)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Font:"
        '
        'checkautofont
        '
        Me.checkautofont.AutoSize = True
        Me.checkautofont.Location = New System.Drawing.Point(581, 241)
        Me.checkautofont.Name = "checkautofont"
        Me.checkautofont.Size = New System.Drawing.Size(95, 17)
        Me.checkautofont.TabIndex = 16
        Me.checkautofont.Text = "Auto Font Size"
        Me.ToolTip1.SetToolTip(Me.checkautofont, "Automatically adjust the font size (in points) for a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "standard 66 line page, at 1" &
        "32 columns.")
        Me.checkautofont.UseVisualStyleBackColor = True
        '
        'fontsize
        '
        Me.fontsize.Location = New System.Drawing.Point(498, 239)
        Me.fontsize.Name = "fontsize"
        Me.fontsize.Size = New System.Drawing.Size(61, 20)
        Me.fontsize.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.fontsize, "Font size in points")
        '
        'fontname
        '
        Me.fontname.FormattingEnabled = True
        Me.fontname.Location = New System.Drawing.Point(315, 239)
        Me.fontname.Name = "fontname"
        Me.fontname.Size = New System.Drawing.Size(177, 21)
        Me.fontname.TabIndex = 14
        '
        'checklandscape
        '
        Me.checklandscape.AutoSize = True
        Me.checklandscape.Location = New System.Drawing.Point(315, 216)
        Me.checklandscape.Name = "checklandscape"
        Me.checklandscape.Size = New System.Drawing.Size(79, 17)
        Me.checklandscape.TabIndex = 13
        Me.checklandscape.Text = "Landscape"
        Me.checklandscape.UseVisualStyleBackColor = True
        '
        'destination
        '
        Me.destination.FormattingEnabled = True
        Me.destination.Location = New System.Drawing.Point(315, 189)
        Me.destination.Name = "destination"
        Me.destination.Size = New System.Drawing.Size(264, 21)
        Me.destination.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(226, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Destination:"
        '
        'checkstart
        '
        Me.checkstart.AutoSize = True
        Me.checkstart.Location = New System.Drawing.Point(315, 166)
        Me.checkstart.Name = "checkstart"
        Me.checkstart.Size = New System.Drawing.Size(73, 17)
        Me.checkstart.TabIndex = 10
        Me.checkstart.Text = "Auto Start"
        Me.checkstart.UseVisualStyleBackColor = True
        '
        'checkignore
        '
        Me.checkignore.AutoSize = True
        Me.checkignore.Location = New System.Drawing.Point(315, 143)
        Me.checkignore.Name = "checkignore"
        Me.checkignore.Size = New System.Drawing.Size(118, 17)
        Me.checkignore.TabIndex = 9
        Me.checkignore.Text = "Ignore existing data"
        Me.ToolTip1.SetToolTip(Me.checkignore, resources.GetString("checkignore.ToolTip"))
        Me.checkignore.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(226, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Input Stream:"
        '
        'inputstream
        '
        Me.inputstream.Location = New System.Drawing.Point(315, 117)
        Me.inputstream.Name = "inputstream"
        Me.inputstream.Size = New System.Drawing.Size(340, 20)
        Me.inputstream.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.inputstream, "Input filename, or port number if Telnet")
        '
        'printertype
        '
        Me.printertype.FormattingEnabled = True
        Me.printertype.Items.AddRange(New Object() {"Stream File", "TCP/IP Telnet "})
        Me.printertype.Location = New System.Drawing.Point(315, 90)
        Me.printertype.Name = "printertype"
        Me.printertype.Size = New System.Drawing.Size(121, 21)
        Me.printertype.TabIndex = 5
        '
        'printername
        '
        Me.printername.Location = New System.Drawing.Point(315, 66)
        Me.printername.Name = "printername"
        Me.printername.Size = New System.Drawing.Size(147, 20)
        Me.printername.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(226, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Type:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(226, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Printer Name:"
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(6, 6)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(197, 342)
        Me.ListBox2.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.monitor)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(768, 385)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Monitor"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'monitor
        '
        Me.monitor.Font = New System.Drawing.Font("Lucida Console", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.monitor.Location = New System.Drawing.Point(3, 3)
        Me.monitor.Name = "monitor"
        Me.monitor.Size = New System.Drawing.Size(762, 379)
        Me.monitor.TabIndex = 0
        Me.monitor.Text = ""
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'fileChooser
        '
        Me.fileChooser.SupportMultiDottedExtensions = True
        Me.fileChooser.Title = "Choose your systems output file"
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Line Printers"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ApplicationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents checkautofont As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents fontsize As TextBox
    Friend WithEvents fontname As ComboBox
    Friend WithEvents checklandscape As CheckBox
    Friend WithEvents destination As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents checkstart As CheckBox
    Friend WithEvents checkignore As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents inputstream As TextBox
    Friend WithEvents printertype As ComboBox
    Friend WithEvents printername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button3 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents monitor As RichTextBox
    Friend WithEvents fileChooser As OpenFileDialog
    Friend WithEvents Button8 As Button
    Friend WithEvents page_Setup As PageSetupDialog
    Friend WithEvents Timer1 As Timer
End Class
