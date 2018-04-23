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
			Me.gridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
			CType(Me.gridView2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridView2
			' 
			Me.gridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.gridColumn3, Me.gridColumn4, Me.gridColumn5})
			Me.gridView2.GridControl = Me.gridControl1
			Me.gridView2.Name = "gridView2"
			' 
			' gridColumn3
			' 
			Me.gridColumn3.Caption = "ParentID"
			Me.gridColumn3.FieldName = "ParentID"
			Me.gridColumn3.Name = "gridColumn3"
			Me.gridColumn3.Visible = True
			Me.gridColumn3.VisibleIndex = 0
			' 
			' gridColumn4
			' 
			Me.gridColumn4.Caption = "ID"
			Me.gridColumn4.FieldName = "ID"
			Me.gridColumn4.Name = "gridColumn4"
			Me.gridColumn4.Visible = True
			Me.gridColumn4.VisibleIndex = 1
			' 
			' gridColumn5
			' 
			Me.gridColumn5.Caption = "Value"
			Me.gridColumn5.FieldName = "Value"
			Me.gridColumn5.Name = "gridColumn5"
			Me.gridColumn5.Visible = True
			Me.gridColumn5.VisibleIndex = 2
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			gridLevelNode1.LevelTemplate = Me.gridView2
			gridLevelNode2.LevelTemplate = Me.gridView3
			gridLevelNode2.RelationName = "Child2_Child3"
			gridLevelNode1.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() { gridLevelNode2})
			gridLevelNode1.RelationName = "MasterTable_Child2"
			Me.gridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() { gridLevelNode1})
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.ShowOnlyPredefinedDetails = True
			Me.gridControl1.Size = New System.Drawing.Size(840, 541)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1, Me.gridView3, Me.gridView2})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.gridColumn1, Me.gridColumn2})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
'			Me.gridView1.MasterRowExpanding += New DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(Me.gridView1_MasterRowExpanding);
'			Me.gridView1.Click += New System.EventHandler(Me.gridView1_Click);
'			Me.gridView1.MasterRowCollapsing += New DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(Me.gridView1_MasterRowCollapsing);
'			Me.gridView1.MasterRowExpanded += New DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(Me.gridView1_MasterRowExpanded);
'			Me.gridView1.MasterRowCollapsed += New DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(Me.gridView1_MasterRowCollapsed);
			' 
			' gridColumn1
			' 
			Me.gridColumn1.Caption = "ID"
			Me.gridColumn1.FieldName = "ID"
			Me.gridColumn1.Name = "gridColumn1"
			Me.gridColumn1.Visible = True
			Me.gridColumn1.VisibleIndex = 0
			' 
			' gridColumn2
			' 
			Me.gridColumn2.Caption = "Value"
			Me.gridColumn2.FieldName = "Value"
			Me.gridColumn2.Name = "gridColumn2"
			Me.gridColumn2.Visible = True
			Me.gridColumn2.VisibleIndex = 1
			' 
			' gridView3
			' 
			Me.gridView3.GridControl = Me.gridControl1
			Me.gridView3.Name = "gridView3"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(840, 541)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridView2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
		Private gridView2 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridView3 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace