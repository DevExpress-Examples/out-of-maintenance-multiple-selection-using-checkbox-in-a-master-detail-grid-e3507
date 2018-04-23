Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Selection
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports E1271

Namespace E3507
	Partial Public Class Form1
		Inherits Form
		Private detailCache As Dictionary(Of Integer, GridCheckMarksSelection)
		Public Sub New()
			InitializeComponent()
			ds = InitData()
			gridControl1.DataSource = ds.MasterTable
			Dim TempGridCheckMarksSelection As GridCheckMarksSelection = New GridCheckMarksSelection(gridView1)

		End Sub
		Private Function InitData() As DataSet1
			Dim dataSet As New DataSet1()
			For i As Integer = 0 To 4

				dataSet.MasterTable.Rows.Add(i, "Master " & i)
				For j As Integer = 0 To 4
					dataSet.Child2.Rows.Add(i * 100 + j, i, "Child2:" & j)
				Next j
			Next i
			Return dataSet

		End Function
		Private ds As DataSet1
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Orders' table. You can move, or remove it, as needed.
			Me.gridView1.ExpandAllGroups()

		End Sub
		Private Sub gridView1_MasterRowExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles gridView1.MasterRowExpanded
			Dim view As GridView = TryCast(sender, GridView)
			Dim detailView As GridView = TryCast(view.GetDetailView(e.RowHandle, e.RelationIndex), GridView)
			Dim SourceIndex As Integer = gridView1.GetDataSourceRowIndex(e.RowHandle)
			If detailCache Is Nothing Then
				detailCache = New Dictionary(Of Integer, GridCheckMarksSelection)()
			End If
			If (Not detailCache.ContainsKey(SourceIndex)) Then
				Dim detailHelper As New GridCheckMarksSelection()
				detailHelper.DetailViewAttach(detailView)
				detailCache.Add(SourceIndex, detailHelper)
			Else
				detailCache(SourceIndex).DetailViewAttach(detailView)
			End If

		End Sub

		Private Sub gridView1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles gridView1.Click

		End Sub

		Private Sub gridView1_MasterRowCollapsed(ByVal sender As Object, ByVal e As CustomMasterRowEventArgs) Handles gridView1.MasterRowCollapsed
		End Sub

		Private Sub gridView1_MasterRowExpanding(ByVal sender As Object, ByVal e As MasterRowCanExpandEventArgs) Handles gridView1.MasterRowExpanding

		End Sub

		Private Sub gridView1_MasterRowCollapsing(ByVal sender As Object, ByVal e As MasterRowCanExpandEventArgs) Handles gridView1.MasterRowCollapsing
			Dim view As GridView = TryCast(sender, GridView)
			Dim detailView As GridView = TryCast(view.GetDetailView(e.RowHandle, e.RelationIndex), GridView)
			Dim SourceIndex As Integer = gridView1.GetDataSourceRowIndex(e.RowHandle)
			If detailCache Is Nothing Then
				Return
			End If
			If detailCache.ContainsKey(SourceIndex) Then
				detailCache(SourceIndex).DetailViewDetach()
			End If


		End Sub
	End Class
End Namespace