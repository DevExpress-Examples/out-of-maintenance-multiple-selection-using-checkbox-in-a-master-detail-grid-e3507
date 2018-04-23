using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Selection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using E1271;

namespace E3507 {
    public partial class Form1 : Form {
        Dictionary<int, GridCheckMarksSelection> detailCache;
        public Form1() {
            InitializeComponent();
            ds = InitData();
            gridControl1.DataSource = ds.MasterTable;
            new GridCheckMarksSelection(gridView1);

        }
        DataSet1 InitData()
        {
            DataSet1 dataSet = new DataSet1();
            for (int i = 0; i < 5; i++)
            {

                dataSet.MasterTable.Rows.Add(i, "Master " + i);
                for (int j = 0; j < 5; j++)
                {
                    dataSet.Child2.Rows.Add(i * 100 + j, i, "Child2:" + j);
                }
            }
            return dataSet;

        }
        DataSet1 ds;
        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Orders' table. You can move, or remove it, as needed.
            this.gridView1.ExpandAllGroups();

        }
        private void gridView1_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            int SourceIndex = gridView1.GetDataSourceRowIndex(e.RowHandle);
            if (detailCache == null)
                detailCache = new Dictionary<int, GridCheckMarksSelection>();
            if (!detailCache.ContainsKey(SourceIndex))
            {
                GridCheckMarksSelection detailHelper = new GridCheckMarksSelection();
                detailHelper.DetailViewAttach(detailView);
                detailCache.Add(SourceIndex, detailHelper);
            }
            else
                detailCache[SourceIndex].DetailViewAttach(detailView);
        
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_MasterRowCollapsed(object sender, CustomMasterRowEventArgs e)
        {
        }

        private void gridView1_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {

        }

        private void gridView1_MasterRowCollapsing(object sender, MasterRowCanExpandEventArgs e)
        {
            GridView view = sender as GridView;
            GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            int SourceIndex = gridView1.GetDataSourceRowIndex(e.RowHandle);
            if (detailCache == null)
                return;
            if (detailCache.ContainsKey(SourceIndex))
                detailCache[SourceIndex].DetailViewDetach();


        }
    }
}