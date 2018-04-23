using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Selection;
using E1271;

namespace E3507 {
    public partial class Form1 : Form {
        DataSet1 dataSet;
        public Form1() {
            InitializeComponent();
            InitData();
            gridControl1.DataSource = dataSet.MasterTable;
            new GridCheckMarksSelection(gridView1);
        }
        void InitData() {
            dataSet = new DataSet1();
            const int masterCount = 7;
            const int detailCount1 = 5;
            const int detailCount2 = 5;
            for (int i = 0; i < masterCount; i++) {
                dataSet.MasterTable.Rows.Add(i, "Master " + i, i % 3);
                for (int j = 0; j < detailCount1; j++)
                    dataSet.Child1.Rows.Add(i * masterCount + j, i, "Child1: " + j);
                for (int j = 0; j < detailCount2; j++)
                    dataSet.Child2.Rows.Add(i * masterCount + j, i, "Child2: " + j, j % 2);
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            gridView1.ExpandAllGroups();
        }
    }
}