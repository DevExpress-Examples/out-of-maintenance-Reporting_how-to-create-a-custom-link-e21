Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
' ...

Namespace CustomLink_ListView

	Public Class ListLink
		Inherits Link
		Private listView As ListView = Nothing


		Public Property ListViewControl() As ListView
			Get
				Return listView
			End Get
			Set(ByVal value As ListView)
				listView = value
			End Set
		End Property

		Public Sub New(ByVal container As System.ComponentModel.IContainer)
			MyBase.New(container)
		End Sub

		Public Sub New()
			MyBase.New()
		End Sub

		Public Sub New(ByVal ps As PrintingSystem)
			MyBase.New(ps)
		End Sub

		Public Overrides Overloads Sub CreateDocument(ByVal ps As PrintingSystem)
			If listView Is Nothing Then
				Return
			End If
			If listView.Items.Count = 0 Then
				Return
			End If
			Dim gr As BrickGraphics = ps.Graph
			MyBase.CreateDocument(ps)
		End Sub


		Protected Overrides Sub CreateMarginalHeader(ByVal gr As BrickGraphics)
			gr.Modifier = BrickModifier.MarginalHeader
			Dim format As String = "Printed on {0:MMMM, dd}"
			Dim brick As PageInfoBrick = gr.DrawPageInfo(PageInfo.DateTime, format, Color.Black, New RectangleF(0, 0, 0, 20), BorderSide.None)
			brick.Alignment = BrickAlignment.Far
			brick.AutoWidth = True
		End Sub


		Protected Overrides Sub CreateReportHeader(ByVal gr As BrickGraphics)
			gr.Modifier = BrickModifier.ReportHeader
			Dim textBrick As TextBrick
			gr.BackColor = Color.White
			gr.StringFormat = New BrickStringFormat(StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit)
			gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Center)
			Dim r As New Rectangle(0, 0, 200, 30)
			gr.Font = New Font("Arial", 16)
			textBrick = gr.DrawString("ListView Report", Color.Red, r, BorderSide.None)
			textBrick.StringFormat.ChangeAlignment(StringAlignment.Center)
		End Sub


		Protected Overrides Sub CreateDetailHeader(ByVal gr As BrickGraphics)
			If listView.View <> View.Details Then
				Return
			End If
			gr.Modifier = BrickModifier.DetailHeader
			gr.Font = listView.Font
			gr.BackColor = SystemColors.Control
			gr.ForeColor = SystemColors.ControlText
			gr.StringFormat = New BrickStringFormat(StringFormatFlags.NoWrap)
			gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Near)
			gr.DrawString("Name", gr.ForeColor, listView.Items(0).Bounds, BorderSide.All)
		End Sub

		Protected Overrides Sub CreateDetail(ByVal gr As BrickGraphics)
			gr.StringFormat = New BrickStringFormat(StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit)
			gr.StringFormat = gr.StringFormat.ChangeLineAlignment(StringAlignment.Near)
			For i As Integer = 0 To listView.Items.Count - 1
				gr.Font = listView.Items(i).Font
				gr.BackColor = listView.Items(i).BackColor
				gr.ForeColor = listView.Items(i).ForeColor
				gr.DrawString(listView.Items(i).Text, gr.ForeColor, listView.Items(i).Bounds, BorderSide.None)
			Next i
		End Sub

		Protected Overrides Sub CreateDetailFooter(ByVal gr As BrickGraphics)
			gr.Modifier = BrickModifier.DetailFooter
			gr.Font = listView.Font
			gr.BackColor = SystemColors.Control
			gr.ForeColor = SystemColors.ControlText
			gr.StringFormat = New BrickStringFormat(StringFormatFlags.NoWrap)
			gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Far)
			gr.DrawString("Total Items: " & Convert.ToString(listView.Items.Count), gr.ForeColor, New Rectangle(0, 0, 60 + listView.Items(0).Bounds.Width, listView.Items(0).Bounds.Height), BorderSide.All)
		End Sub

		Protected Overrides Sub CreateMarginalFooter(ByVal gr As BrickGraphics)
			gr.Modifier = BrickModifier.MarginalFooter
			Dim format As String = "Page {0} of {1}"
			Dim brick As PageInfoBrick = gr.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black, New RectangleF(0, 0, 0, 20), BorderSide.None)
			brick.Alignment = BrickAlignment.Far
			brick.AutoWidth = True
		End Sub

		Protected Overrides Sub CreateReportFooter(ByVal gr As BrickGraphics)
			gr.Modifier = BrickModifier.ReportFooter
			gr.StringFormat = New BrickStringFormat(StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit)
			gr.StringFormat = gr.StringFormat.ChangeLineAlignment(StringAlignment.Far)
			gr.Font = listView.Font
			gr.DrawString("Created by John Smith", gr.ForeColor, New Rectangle(0, 0, 200, 30), BorderSide.None)
		End Sub
	End Class
End Namespace
