Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils.Drawing
Imports System.Data
Imports E1271
Imports System.Collections.Generic
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports System.Linq

Namespace DevExpress.XtraGrid.Selection

	Public Class GridCheckMarksSelection
		Public Const CHECKMARK_FIELDNAME As String = "CheckMarkSelection"
		Private _view As GridView
		Private _parentView As GridView
		Private selection As ArrayList
		Private column As GridColumn
		Private edit As RepositoryItemCheckEdit
		Private detailSelections As New Dictionary(Of DetailKey, GridCheckMarksSelection)()
		Private parentSelection As GridCheckMarksSelection = Nothing
		Private Const CheckboxIndent As Integer = 4
		Public Sub New()
			selection = New ArrayList()
		End Sub
		Public Sub New(ByVal view As GridView, ByVal parentCheckMarkSelection As GridCheckMarksSelection)
			Me.New()
			Me.View = view
			parentSelection = parentCheckMarkSelection
			_parentView = parentSelection.View
		End Sub
		Public Sub New(ByVal view As GridView)
			Me.New()
			Me.View = view
		End Sub
		Public Property View() As GridView
			Get
				Return _view
			End Get
			Set(ByVal value As GridView)
				If _view IsNot value Then
					Detach(value)
					Attach(value)
				End If
			End Set
		End Property
		Public ReadOnly Property CheckMarkColumn() As GridColumn
			Get
				Return column
			End Get
		End Property
		Public ReadOnly Property SelectedCount() As Integer
			Get
				Return selection.Count
			End Get
		End Property
		Public ReadOnly Property IsMasterView() As Boolean
			Get
				Return _parentView Is Nothing
			End Get
		End Property

		#Region "Attach / Detach"
		Private Sub AddCheckColumn()
			edit = TryCast(View.GridControl.RepositoryItems("CheckMark"), RepositoryItemCheckEdit)
			If edit Is Nothing Then
				edit = TryCast(View.GridControl.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
				edit.Name = "CheckMark"
			End If
			column = View.Columns.Add()
			column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
			column.Visible = True
			column.VisibleIndex = 0
			column.FieldName = CHECKMARK_FIELDNAME
			column.Caption = "Mark"
			column.OptionsColumn.ShowCaption = False
			column.OptionsColumn.AllowEdit = False
			column.OptionsColumn.AllowSize = False
			column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
			column.Width = GetCheckBoxWidth()
			column.ColumnEdit = edit
		End Sub
		Private Sub SubscribeViewToEvents()
			AddHandler View.Click, AddressOf View_Click
			AddHandler View.CustomDrawColumnHeader, AddressOf View_CustomDrawColumnHeader
			AddHandler View.CustomDrawGroupRow, AddressOf View_CustomDrawGroupRow
			AddHandler View.CustomUnboundColumnData, AddressOf view_CustomUnboundColumnData
			AddHandler View.KeyDown, AddressOf view_KeyDown
			AddHandler View.RowStyle, AddressOf view_RowStyle
			AddHandler View.MasterRowExpanded, AddressOf view_MasterRowExpanded
		End Sub
		Private Sub UnsubscribeViewFromEvents()
			RemoveHandler View.Click, AddressOf View_Click
			RemoveHandler View.CustomDrawColumnHeader, AddressOf View_CustomDrawColumnHeader
			RemoveHandler View.CustomDrawGroupRow, AddressOf View_CustomDrawGroupRow
			RemoveHandler View.CustomUnboundColumnData, AddressOf view_CustomUnboundColumnData
			RemoveHandler View.KeyDown, AddressOf view_KeyDown
			RemoveHandler View.RowStyle, AddressOf view_RowStyle
			RemoveHandler View.MasterRowExpanded, AddressOf view_MasterRowExpanded
		End Sub
		Protected Overridable Sub Attach(ByVal view As GridView)
			If view Is Nothing Then
				Return
			End If
			_view = view
			AddCheckColumn()
			SubscribeViewToEvents()
		End Sub
		Protected Overridable Sub Detach(ByVal newView As GridView)
			newView.Columns.Remove(newView.Columns(CHECKMARK_FIELDNAME))
			If _view Is Nothing Then
				Return
			End If
			UnsubscribeViewFromEvents()
			_view = Nothing
		End Sub
		#End Region

		Public Function GetSelectedRow(ByVal index As Integer) As Object
			Return selection(index)
		End Function
		Public Function GetSelectedIndex(ByVal row As Object) As Integer
			For Each record As Object In selection
				If (TryCast(record, DataRowView)).Row Is (TryCast(row, DataRowView)).Row Then
					Return selection.IndexOf(record)
				End If
			Next record
			Return selection.IndexOf(row)
		End Function

		#Region "Selection Methods"

		Public Sub SelectRow(ByVal rowHandle As Integer, ByVal [select] As Boolean)
			If View.IsGroupRow(rowHandle) Then
				SelectGroup(rowHandle, [select])
				Return
			End If
			SelectRow(rowHandle, [select], True)
		End Sub
		Public Sub SelectRowObject(ByVal row As Object, ByVal [select] As Boolean)
			Dim rowHandle As Integer = View.GetRowHandle((CType(View.DataSource, IList)).IndexOf(row))
			SelectRow(rowHandle, [select], True)
		End Sub
		Public Sub ClearSelection()
			selection.Clear()
			UpdateParentAndDetailSelection(False)
			InvalidateView()
		End Sub
		Public Sub SelectAll()
			selection.Clear()
			selection.AddRange(CType(View.DataSource, IList))
			UpdateParentAndDetailSelection(True)
			InvalidateView()
		End Sub
		Public Sub InvertDetailRowsSelection(ByVal masterRowHandle As Integer)
			GetDetailSelectionHelper(masterRowHandle, 0).SetAllDetailsSelected(masterRowHandle, IsRowSelected(masterRowHandle))
		End Sub
		Public Sub InvertRowSelection(ByVal rowHandle As Integer)
			If View.IsDataRow(rowHandle) Then
				SelectRow(rowHandle, (Not IsRowSelected(rowHandle)))
			End If
			If View.IsGroupRow(rowHandle) Then
				SelectGroup(rowHandle, (Not IsGroupRowSelected(rowHandle)))
			End If
		End Sub
		Private Sub SelectRow(ByVal rowHandle As Integer, ByVal [select] As Boolean, ByVal invalidate As Boolean)
			If IsRowSelected(rowHandle) = [select] Then
				Return
			End If
			Dim row As Object = View.GetRow(rowHandle)
			If [select] Then
				selection.Add(row)
			Else
				selection.RemoveAt(GetSelectedIndex(row))
			End If
			If IsMasterView Then
				SetAllDetailsSelected(rowHandle, [select])
			Else
				SetParentRowSelected(AreAllDetailsSelected())
			End If
			If invalidate Then
				InvalidateView()
			End If
		End Sub
		Private Sub SelectGroup(ByVal rowHandle As Integer, ByVal [select] As Boolean)
			If IsGroupRowSelected(rowHandle) AndAlso [select] Then
				Return
			End If
			For i As Integer = 0 To View.GetChildRowCount(rowHandle) - 1
				Dim childRowHandle As Integer = View.GetChildRowHandle(rowHandle, i)
				If View.IsGroupRow(childRowHandle) Then
					SelectGroup(childRowHandle, [select])
				Else
					SelectRow(childRowHandle, [select], False)
				End If
			Next i
			InvalidateView()
		End Sub
		Private Sub SetParentRowSelected(ByVal selected As Boolean)
			If selected Then
				parentSelection.selection.Add(View.SourceRow)
			Else
				parentSelection.selection.Remove(View.SourceRow)
			End If
			_parentView.LayoutChanged()
		End Sub
		Private Sub UpdateParentAndDetailSelection(ByVal [select] As Boolean)
			If IsMasterView Then
				For i As Integer = 0 To View.DataRowCount - 1
					SetAllDetailsSelected(i, [select])
				Next i
			Else
				SetParentRowSelected(AreAllDetailsSelected())
			End If
		End Sub
		Private Sub SetAllDetailsSelected(ByVal masterRowHandle As Integer, ByVal [select] As Boolean)
			Dim relationCount As Integer = View.GetRelationCount(masterRowHandle)
			For i As Integer = 0 To relationCount - 1
				SetAllDetailRowsSelected(masterRowHandle, i, [select])
			Next i
		End Sub
		Private Sub SetAllDetailRowsSelected(ByVal masterRowHandle As Integer, ByVal relationIndex As Integer, ByVal [select] As Boolean)
			Dim detailSelectionHelper As GridCheckMarksSelection = GetDetailSelectionHelper(masterRowHandle, relationIndex)
			detailSelectionHelper.selection.Clear()
			If [select] Then
				detailSelectionHelper.selection.AddRange(View.DataController.GetDetailList(masterRowHandle, relationIndex))
			End If
			If detailSelectionHelper.View IsNot Nothing Then
				detailSelectionHelper.View.LayoutChanged()
			End If
		End Sub
		#End Region

		Private Function GetDetailSelectionHelper(ByVal masterRowHandle As Integer, ByVal relationIndex As Integer) As GridCheckMarksSelection
			Dim key As New DetailKey(masterRowHandle, relationIndex)
			If (Not detailSelections.ContainsKey(key)) Then
				detailSelections.Add(key, New GridCheckMarksSelection(Nothing, Me))
			End If
			Return detailSelections(key)
		End Function
		Private Function AreAllRowsSelected() As Boolean
			If View IsNot Nothing Then
				Return SelectedCount = View.DataRowCount
			Else
				Dim key As DetailKey = parentSelection.detailSelections.FirstOrDefault(Function(x) x.Value Is Me).Key
				Return SelectedCount = _parentView.DataController.GetDetailList(key.MasterRowHandle, key.RelationIndex).Count
			End If
		End Function
		Private Function AreAllDetailsSelected() As Boolean ' call it for a detail helper
			Dim relationCount As Integer = _parentView.GetRelationCount(View.SourceRowHandle)
			For i As Integer = 0 To relationCount - 1
				If (Not parentSelection.GetDetailSelectionHelper(View.SourceRowHandle, i).AreAllRowsSelected()) Then
					Return False
				End If
			Next i
			Return True
		End Function
		Private Function IsGroupRowSelected(ByVal rowHandle As Integer) As Boolean
			For i As Integer = 0 To View.GetChildRowCount(rowHandle) - 1
				Dim childRowHandle As Integer = View.GetChildRowHandle(rowHandle, i)
				If View.IsGroupRow(childRowHandle) Then
					If (Not IsGroupRowSelected(childRowHandle)) Then
						Return False
					End If
				Else
					If (Not IsRowSelected(childRowHandle)) Then
						Return False
					End If
				End If
			Next i
			Return True
		End Function
		Public Function IsRowSelected(ByVal rowHandle As Integer) As Boolean
			If View.IsGroupRow(rowHandle) Then
				Return IsGroupRowSelected(rowHandle)
			End If
			Dim row As Object = View.GetRow(rowHandle)
			Return IsObjectSelected(row)
		End Function
		Public Function IsObjectSelected(ByVal row As Object) As Boolean
			Return GetSelectedIndex(row) <> -1
		End Function
		Protected Function GetCheckBoxWidth() As Integer
			Dim info As CheckEditViewInfo = TryCast(edit.CreateViewInfo(), CheckEditViewInfo)
			Dim width As Integer = 0
			GraphicsInfo.Default.AddGraphics(Nothing)
			Try
				width = info.CalcBestFit(GraphicsInfo.Default.Graphics).Width
			Finally
				GraphicsInfo.Default.ReleaseGraphics()
			End Try
			Return width + CheckboxIndent * 2
		End Function
		Private Sub InvalidateView()
			View.CloseEditor()
			View.BeginUpdate()
			View.EndUpdate()
		End Sub

		#Region "Events"
		Private Sub view_MasterRowExpanded(ByVal sender As Object, ByVal e As CustomMasterRowEventArgs)
			Dim detailView As GridView = TryCast(View.GetDetailView(e.RowHandle, e.RelationIndex), GridView)
			Dim detailHelper As GridCheckMarksSelection = GetDetailSelectionHelper(e.RowHandle, e.RelationIndex)
			detailHelper.View = detailView
			detailHelper.View.LayoutChanged()
		End Sub
		Private Sub view_CustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs)
			If e.Column Is CheckMarkColumn Then
				If e.IsGetData Then
					e.Value = IsObjectSelected(e.Row)
				Else
					SelectRowObject(e.Row, CBool(e.Value))
				End If
			End If
		End Sub
		Private Sub view_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.KeyCode = Keys.Space AndAlso (View.FocusedColumn Is CheckMarkColumn OrElse View.IsGroupRow(View.FocusedRowHandle)) Then
                InvertRowSelection(View.FocusedRowHandle)
            End If
		End Sub
		Private Sub View_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim pt As Point = View.GridControl.PointToClient(Control.MousePosition)
			Dim info As GridHitInfo = View.CalcHitInfo(pt)
			If info.InColumn Then
				If AreAllRowsSelected() Then
					ClearSelection()
				Else
					SelectAll()
				End If
			End If
			If info.InRow AndAlso info.HitTest <> GridHitTest.RowGroupButton AndAlso info.HitTest <> GridHitTest.CellButton Then
				InvertRowSelection(info.RowHandle)
			End If
		End Sub
		#End Region

		#Region "Painting"

		Protected Sub DrawCheckBox(ByVal g As Graphics, ByVal r As Rectangle, ByVal _checked As Boolean)
			Dim info As CheckEditViewInfo = TryCast(edit.CreateViewInfo(), CheckEditViewInfo)
			Dim painter As CheckEditPainter = TryCast(edit.CreatePainter(), CheckEditPainter)
			info.EditValue = _checked
			info.Bounds = r
			info.CalcViewInfo(g)
			Dim args As New ControlGraphicsInfoArgs(info, New GraphicsCache(g), r)
			painter.Draw(args)
			args.Cache.Dispose()
		End Sub
		Private Sub View_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As ColumnHeaderCustomDrawEventArgs)
			If e.Column IsNot Nothing AndAlso e.Column Is column Then
				e.Info.InnerElements.Clear()
				e.Painter.DrawObject(e.Info)
                DrawCheckBox(e.Cache.Graphics, e.Bounds, AreAllRowsSelected())
                e.Handled = True
			End If
		End Sub
		Private Sub View_CustomDrawGroupRow(ByVal sender As Object, ByVal e As RowObjectCustomDrawEventArgs)
			Dim info As GridGroupRowInfo = TryCast(e.Info, GridGroupRowInfo)
			info.GroupText = "         " & info.GroupText.TrimStart()
            e.Info.Paint.FillRectangle(e.Cache.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds)
            e.Painter.DrawObject(e.Info)
			Dim r As Rectangle = info.ButtonBounds
			r.Offset(r.Width + CheckboxIndent * 2 - 1, 0)
            DrawCheckBox(e.Cache.Graphics, r, IsGroupRowSelected(e.RowHandle))
            e.Handled = True
		End Sub
		Private Sub view_RowStyle(ByVal sender As Object, ByVal e As RowStyleEventArgs)
			If IsRowSelected(e.RowHandle) Then
				e.Appearance.BackColor = SystemColors.Highlight
				e.Appearance.ForeColor = SystemColors.HighlightText
			End If
		End Sub
		#End Region
	End Class
End Namespace
