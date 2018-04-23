Imports Microsoft.VisualBasic
Imports System
Namespace E3507
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
			Dim gridLevelNode1 As New DevExpress.XtraGrid.GridLevelNode()
			Dim gridLevelNode2 As New DevExpress.XtraGrid.GridLevelNode()
			Me.gridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colID_Child1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colInformation = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colID_Child2 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colID_main = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colGroup_main = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colGroup_Child2 = New DevExpress.XtraGrid.Columns.GridColumn()
			CType(Me.gridView2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridView2
			' 
			Me.gridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colID_Child1, Me.colInformation})
			Me.gridView2.GridControl = Me.gridControl1
			Me.gridView2.Name = "gridView2"
			' 
			' colID_Child1
			' 
			Me.colID_Child1.Caption = "ID"
			Me.colID_Child1.FieldName = "ID"
			Me.colID_Child1.Name = "colID_Child1"
			Me.colID_Child1.Visible = True
			Me.colID_Child1.VisibleIndex = 0
			' 
			' colInformation
			' 
			Me.colInformation.Caption = "Information"
			Me.colInformation.FieldName = "Information"
			Me.colInformation.Name = "colInformation"
			Me.colInformation.Visible = True
			Me.colInformation.VisibleIndex = 1
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			gridLevelNode1.LevelTemplate = Me.gridView2
			gridLevelNode1.RelationName = "MasterTable_Child1"
			gridLevelNode2.LevelTemplate = Me.gridView3
			gridLevelNode2.RelationName = "MasterTable_Child2"
			Me.gridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() { gridLevelNode1, gridLevelNode2})
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.ShowOnlyPredefinedDetails = True
			Me.gridControl1.Size = New System.Drawing.Size(840, 672)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView3, Me.gridView1, Me.gridView2})
			' 
			' gridView3
			' 
			Me.gridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colID_Child2, Me.colDescription, Me.colGroup_Child2})
			Me.gridView3.GridControl = Me.gridControl1
			Me.gridView3.GroupCount = 1
			Me.gridView3.Name = "gridView3"
			Me.gridView3.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() { New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colGroup_Child2, DevExpress.Data.ColumnSortOrder.Ascending)})
			' 
			' colID_Child2
			' 
			Me.colID_Child2.Caption = "ID"
			Me.colID_Child2.FieldName = "ID"
			Me.colID_Child2.Name = "colID_Child2"
			Me.colID_Child2.Visible = True
			Me.colID_Child2.VisibleIndex = 0
			' 
			' colDescription
			' 
			Me.colDescription.Caption = "Description"
			Me.colDescription.FieldName = "Description"
			Me.colDescription.Name = "colDescription"
			Me.colDescription.Visible = True
			Me.colDescription.VisibleIndex = 1
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colID_main, Me.colName, Me.colGroup_main})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.GroupCount = 1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() { New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colGroup_main, DevExpress.Data.ColumnSortOrder.Ascending)})
			' 
			' colID_main
			' 
			Me.colID_main.Caption = "ID"
			Me.colID_main.FieldName = "ID"
			Me.colID_main.Name = "colID_main"
			Me.colID_main.Visible = True
			Me.colID_main.VisibleIndex = 0
			' 
			' colName
			' 
			Me.colName.Caption = "Name"
			Me.colName.FieldName = "Name"
			Me.colName.Name = "colName"
			Me.colName.Visible = True
			Me.colName.VisibleIndex = 1
			' 
			' colGroup_main
			' 
			Me.colGroup_main.Caption = "Group"
			Me.colGroup_main.FieldName = "Group"
			Me.colGroup_main.Name = "colGroup_main"
			Me.colGroup_main.Visible = True
			Me.colGroup_main.VisibleIndex = 2
			' 
			' colGroup_Child2
			' 
			Me.colGroup_Child2.Caption = "Group"
			Me.colGroup_Child2.FieldName = "Group"
			Me.colGroup_Child2.Name = "colGroup_Child2"
			Me.colGroup_Child2.Visible = True
			Me.colGroup_Child2.VisibleIndex = 2
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(840, 672)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridView2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridView2 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridView3 As DevExpress.XtraGrid.Views.Grid.GridView
		Private colID_Child1 As DevExpress.XtraGrid.Columns.GridColumn
		Private colInformation As DevExpress.XtraGrid.Columns.GridColumn
		Private colID_main As DevExpress.XtraGrid.Columns.GridColumn
		Private colName As DevExpress.XtraGrid.Columns.GridColumn
		Private colID_Child2 As DevExpress.XtraGrid.Columns.GridColumn
		Private colDescription As DevExpress.XtraGrid.Columns.GridColumn
		Private colGroup_Child2 As DevExpress.XtraGrid.Columns.GridColumn
		Private colGroup_main As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace