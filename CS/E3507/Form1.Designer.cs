namespace E3507
{
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID_Child1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInformation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID_Child2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID_main = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup_main = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup_Child2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID_Child1,
            this.colInformation});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // colID_Child1
            // 
            this.colID_Child1.Caption = "ID";
            this.colID_Child1.FieldName = "ID";
            this.colID_Child1.Name = "colID_Child1";
            this.colID_Child1.Visible = true;
            this.colID_Child1.VisibleIndex = 0;
            // 
            // colInformation
            // 
            this.colInformation.Caption = "Information";
            this.colInformation.FieldName = "Information";
            this.colInformation.Name = "colInformation";
            this.colInformation.Visible = true;
            this.colInformation.VisibleIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "MasterTable_Child1";
            gridLevelNode2.LevelTemplate = this.gridView3;
            gridLevelNode2.RelationName = "MasterTable_Child2";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(840, 672);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3,
            this.gridView1,
            this.gridView2});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID_Child2,
            this.colDescription,
            this.colGroup_Child2});
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.GroupCount = 1;
            this.gridView3.Name = "gridView3";
            this.gridView3.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGroup_Child2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID_Child2
            // 
            this.colID_Child2.Caption = "ID";
            this.colID_Child2.FieldName = "ID";
            this.colID_Child2.Name = "colID_Child2";
            this.colID_Child2.Visible = true;
            this.colID_Child2.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID_main,
            this.colName,
            this.colGroup_main});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGroup_main, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID_main
            // 
            this.colID_main.Caption = "ID";
            this.colID_main.FieldName = "ID";
            this.colID_main.Name = "colID_main";
            this.colID_main.Visible = true;
            this.colID_main.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colGroup_main
            // 
            this.colGroup_main.Caption = "Group";
            this.colGroup_main.FieldName = "Group";
            this.colGroup_main.Name = "colGroup_main";
            this.colGroup_main.Visible = true;
            this.colGroup_main.VisibleIndex = 2;
            // 
            // colGroup_Child2
            // 
            this.colGroup_Child2.Caption = "Group";
            this.colGroup_Child2.FieldName = "Group";
            this.colGroup_Child2.Name = "colGroup_Child2";
            this.colGroup_Child2.Visible = true;
            this.colGroup_Child2.VisibleIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 672);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colID_Child1;
        private DevExpress.XtraGrid.Columns.GridColumn colInformation;
        private DevExpress.XtraGrid.Columns.GridColumn colID_main;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colID_Child2;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup_Child2;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup_main;
    }
}