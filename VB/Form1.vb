Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
' ...

Namespace CustomLink_ListView
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim myLink As New ListLink(printingSystem1)

			myLink.ListViewControl = listView1
			myLink.ShowPreviewDialog()

			myLink.Dispose()
		End Sub
	End Class
End Namespace