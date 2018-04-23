Imports Microsoft.VisualBasic
Imports System
Namespace CustomLink_ListView
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim listViewItem1 As New System.Windows.Forms.ListViewItem("Item1")
			Dim listViewItem2 As New System.Windows.Forms.ListViewItem("Item2")
			Me.printingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
			Me.button1 = New System.Windows.Forms.Button()
			Me.listView1 = New System.Windows.Forms.ListView()
			CType(Me.printingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(8, 8)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(128, 32)
			Me.button1.TabIndex = 0
			Me.button1.Text = "Preview"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' listView1
			' 
			Me.listView1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.listView1.Items.AddRange(New System.Windows.Forms.ListViewItem() { listViewItem1, listViewItem2})
			Me.listView1.Location = New System.Drawing.Point(8, 48)
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New System.Drawing.Size(264, 209)
			Me.listView1.TabIndex = 1
			Me.listView1.UseCompatibleStateImageBehavior = False
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 264)
			Me.Controls.Add(Me.listView1)
			Me.Controls.Add(Me.button1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.printingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private printingSystem1 As DevExpress.XtraPrinting.PrintingSystem
		Private WithEvents button1 As System.Windows.Forms.Button
		Private listView1 As System.Windows.Forms.ListView
	End Class
End Namespace

