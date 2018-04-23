Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Selection
Imports E1271

Namespace E3507
	Partial Public Class Form1
		Inherits Form
		Private dataSet As DataSet1
		Public Sub New()
			InitializeComponent()
			InitData()
			gridControl1.DataSource = dataSet.MasterTable
			Dim TempGridCheckMarksSelection As GridCheckMarksSelection = New GridCheckMarksSelection(gridView1)
		End Sub
		Private Sub InitData()
			dataSet = New DataSet1()
			Const masterCount As Integer = 7
			Const detailCount1 As Integer = 5
			Const detailCount2 As Integer = 5
			For i As Integer = 0 To masterCount - 1
				dataSet.MasterTable.Rows.Add(i, "Master " & i, i Mod 3)
				For j As Integer = 0 To detailCount1 - 1
					dataSet.Child1.Rows.Add(i * masterCount + j, i, "Child1: " & j)
				Next j
				For j As Integer = 0 To detailCount2 - 1
					dataSet.Child2.Rows.Add(i * masterCount + j, i, "Child2: " & j, j Mod 2)
				Next j
			Next i
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			gridView1.ExpandAllGroups()
		End Sub
	End Class
End Namespace