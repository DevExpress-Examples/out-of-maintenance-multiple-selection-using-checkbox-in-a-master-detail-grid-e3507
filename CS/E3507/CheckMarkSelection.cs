using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Data;
using E1271;
using System.Collections.Generic;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using System.Linq;

namespace DevExpress.XtraGrid.Selection {

    public class GridCheckMarksSelection {
        public const string CHECKMARK_FIELDNAME = "CheckMarkSelection";
        GridView _view;
        GridView _parentView;
        ArrayList selection;
        GridColumn column;
        RepositoryItemCheckEdit edit;
        Dictionary<DetailKey, GridCheckMarksSelection> detailSelections = new Dictionary<DetailKey, GridCheckMarksSelection>();
        GridCheckMarksSelection parentSelection = null;
        const int CheckboxIndent = 4;
        public GridCheckMarksSelection() {
            selection = new ArrayList();
        }
        public GridCheckMarksSelection(GridView view, GridCheckMarksSelection parentCheckMarkSelection) : this() {
            View = view;
            parentSelection = parentCheckMarkSelection;
            _parentView = parentSelection.View;
        }
        public GridCheckMarksSelection(GridView view) : this() {
            View = view;
        }
        public GridView View {
            get { return _view; }
            set {
                if (_view != value) {
                    Detach(value);
                    Attach(value);
                }
            }
        }
        public GridColumn CheckMarkColumn { get { return column; } }
        public int SelectedCount { get { return selection.Count; } }
        public bool IsMasterView {
            get { return _parentView == null; }
        }

        #region Attach / Detach
        void AddCheckColumn() {
            edit = View.GridControl.RepositoryItems["CheckMark"] as RepositoryItemCheckEdit;
            if (edit == null) {
                edit = View.GridControl.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
                edit.Name = "CheckMark";
            }
            column = View.Columns.Add();
            column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            column.Visible = true;
            column.VisibleIndex = 0;
            column.FieldName = CHECKMARK_FIELDNAME;
            column.Caption = "Mark";
            column.OptionsColumn.ShowCaption = false;
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowSize = false;
            column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            column.Width = GetCheckBoxWidth();
            column.ColumnEdit = edit;
        }
        void SubscribeViewToEvents() {
            View.Click += new EventHandler(View_Click);
            View.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
            View.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
            View.CustomUnboundColumnData += new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
            View.KeyDown += new KeyEventHandler(view_KeyDown);
            View.RowStyle += new RowStyleEventHandler(view_RowStyle);
            View.MasterRowExpanded += view_MasterRowExpanded;
        }
        void UnsubscribeViewFromEvents() {
            View.Click -= View_Click;
            View.CustomDrawColumnHeader -= View_CustomDrawColumnHeader;
            View.CustomDrawGroupRow -= View_CustomDrawGroupRow;
            View.CustomUnboundColumnData -= view_CustomUnboundColumnData;
            View.KeyDown -= view_KeyDown;
            View.RowStyle -= view_RowStyle;
            View.MasterRowExpanded -= view_MasterRowExpanded;
        }
        protected virtual void Attach(GridView view) {
            if (view == null) return;
            _view = view;
            AddCheckColumn();
            SubscribeViewToEvents();
        }
        protected virtual void Detach(GridView newView) {
            newView.Columns.Remove(newView.Columns[CHECKMARK_FIELDNAME]);
            if (_view == null) return;
            UnsubscribeViewFromEvents();
            _view = null;
        }
        #endregion

        public object GetSelectedRow(int index) {
            return selection[index];
        }
        public int GetSelectedIndex(object row) {
            foreach (object record in selection)
                if ((record as DataRowView).Row == (row as DataRowView).Row)
                    return selection.IndexOf(record);
            return selection.IndexOf(row);
        }

        #region Selection Methods
        
        public void SelectRow(int rowHandle, bool select) {
            if (View.IsGroupRow(rowHandle)) {
                SelectGroup(rowHandle, select);
                return;
            }
            SelectRow(rowHandle, select, true);
        }
        public void SelectRowObject(object row, bool select) {
            int rowHandle = View.GetRowHandle(((IList)View.DataSource).IndexOf(row));
            SelectRow(rowHandle, select, true);
        }
        public void ClearSelection() {
            selection.Clear();
            UpdateParentAndDetailSelection(false);
            InvalidateView();
        }
        public void SelectAll() {
            selection.Clear();
            selection.AddRange((IList)View.DataSource);
            UpdateParentAndDetailSelection(true);
            InvalidateView();
        }
        public void InvertDetailRowsSelection(int masterRowHandle) {
            GetDetailSelectionHelper(masterRowHandle, 0).SetAllDetailsSelected(masterRowHandle, IsRowSelected(masterRowHandle));
        }
        public void InvertRowSelection(int rowHandle) {
            if (View.IsDataRow(rowHandle))
                SelectRow(rowHandle, !IsRowSelected(rowHandle));
            if (View.IsGroupRow(rowHandle))
                SelectGroup(rowHandle, !IsGroupRowSelected(rowHandle));
        }
        void SelectRow(int rowHandle, bool select, bool invalidate) {
            if (IsRowSelected(rowHandle) == select) return;
            object row = View.GetRow(rowHandle);
            if (select)
                selection.Add(row);
            else
                selection.RemoveAt(GetSelectedIndex(row));
            if (IsMasterView)
                SetAllDetailsSelected(rowHandle, select);
            else
                SetParentRowSelected(AreAllDetailsSelected());
            if (invalidate)
                InvalidateView();
        }
        void SelectGroup(int rowHandle, bool select) {
            if (IsGroupRowSelected(rowHandle) && select) return;
            for (int i = 0; i < View.GetChildRowCount(rowHandle); i++) {
                int childRowHandle = View.GetChildRowHandle(rowHandle, i);
                if (View.IsGroupRow(childRowHandle))
                    SelectGroup(childRowHandle, select);
                else
                    SelectRow(childRowHandle, select, false);
            }
            InvalidateView();
        }
        void SetParentRowSelected(bool selected) {
            if (selected)
                parentSelection.selection.Add(View.SourceRow);
            else
                parentSelection.selection.Remove(View.SourceRow);
            _parentView.LayoutChanged();
        }
        void UpdateParentAndDetailSelection(bool select) {
            if (IsMasterView)
                for (int i = 0; i < View.DataRowCount; i++)
                    SetAllDetailsSelected(i, select);
            else
                SetParentRowSelected(AreAllDetailsSelected());
        }
        void SetAllDetailsSelected(int masterRowHandle, bool select) {
            int relationCount = View.GetRelationCount(masterRowHandle);
            for (int i = 0; i < relationCount; i++)
                SetAllDetailRowsSelected(masterRowHandle, i, select);    
        }
        void SetAllDetailRowsSelected(int masterRowHandle, int relationIndex, bool select) {
            GridCheckMarksSelection detailSelectionHelper = GetDetailSelectionHelper(masterRowHandle, relationIndex);
            detailSelectionHelper.selection.Clear();
            if (select)
                detailSelectionHelper.selection.AddRange(View.DataController.GetDetailList(masterRowHandle, relationIndex));
            if (detailSelectionHelper.View != null) detailSelectionHelper.View.LayoutChanged();
        }
        #endregion

        GridCheckMarksSelection GetDetailSelectionHelper(int masterRowHandle, int relationIndex) {
            DetailKey key = new DetailKey(masterRowHandle, relationIndex);
            if (!detailSelections.ContainsKey(key))
                detailSelections.Add(key, new GridCheckMarksSelection(null, this));
            return detailSelections[key];
        }
        bool AreAllRowsSelected() {
            if (View != null)
                return SelectedCount == View.DataRowCount;
            else {
                DetailKey key = parentSelection.detailSelections.FirstOrDefault(x => x.Value == this).Key;
                return SelectedCount == _parentView.DataController.GetDetailList(key.MasterRowHandle, key.RelationIndex).Count;
            }
        }
        bool AreAllDetailsSelected() { // call it for a detail helper
            int relationCount = _parentView.GetRelationCount(View.SourceRowHandle);
            for (int i = 0; i < relationCount; i++){
                if (!parentSelection.GetDetailSelectionHelper(View.SourceRowHandle, i).AreAllRowsSelected())
                    return false;
            }
            return true;
        }
        bool IsGroupRowSelected(int rowHandle) {
            for (int i = 0; i < View.GetChildRowCount(rowHandle); i++) {
                int childRowHandle = View.GetChildRowHandle(rowHandle, i);
                if (View.IsGroupRow(childRowHandle)) {
                    if (!IsGroupRowSelected(childRowHandle)) return false;
                } else
                    if (!IsRowSelected(childRowHandle)) return false;
            }
            return true;
        }
        public bool IsRowSelected(int rowHandle) {
            if (View.IsGroupRow(rowHandle))
                return IsGroupRowSelected(rowHandle);
            object row = View.GetRow(rowHandle);
            return IsObjectSelected(row);
        }
        public bool IsObjectSelected(object row) {
            return GetSelectedIndex(row) != -1;
        }
        protected int GetCheckBoxWidth() {
            CheckEditViewInfo info = edit.CreateViewInfo() as CheckEditViewInfo;
            int width = 0;
            GraphicsInfo.Default.AddGraphics(null);
            try {
                width = info.CalcBestFit(GraphicsInfo.Default.Graphics).Width;
            }
            finally {
                GraphicsInfo.Default.ReleaseGraphics();
            }
            return width + CheckboxIndent * 2;
        }
        void InvalidateView() {
            View.CloseEditor();
            View.BeginUpdate();
            View.EndUpdate();
        }

        #region Events
        void view_MasterRowExpanded(object sender, CustomMasterRowEventArgs e) {
            GridView detailView = View.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            GridCheckMarksSelection detailHelper = GetDetailSelectionHelper(e.RowHandle, e.RelationIndex);
            detailHelper.View = detailView;
            detailHelper.View.LayoutChanged();
        }
        void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
            if (e.Column == CheckMarkColumn) {
                if (e.IsGetData)
                    e.Value = IsObjectSelected(e.Row);
                else
                    SelectRowObject(e.Row, (bool)e.Value);
            }
        }
        void view_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space && (View.FocusedColumn == CheckMarkColumn || View.IsGroupRow(View.FocusedRowHandle)))
                InvertRowSelection(View.FocusedRowHandle);
        }
        void View_Click(object sender, EventArgs e) {
            Point pt = View.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = View.CalcHitInfo(pt);
            if (info.InColumn)
                if (AreAllRowsSelected())
                    ClearSelection();
                else
                    SelectAll();
            if (info.InRow && info.HitTest != GridHitTest.RowGroupButton && info.HitTest !=  GridHitTest.CellButton)
                InvertRowSelection(info.RowHandle);
        }
        #endregion

        #region Painting

        protected void DrawCheckBox(Graphics g, Rectangle r, bool _checked) {
            CheckEditViewInfo info = edit.CreateViewInfo() as CheckEditViewInfo;
            CheckEditPainter painter = edit.CreatePainter() as CheckEditPainter;
            info.EditValue = _checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            ControlGraphicsInfoArgs args = new ControlGraphicsInfoArgs(info, new GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }
        void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e) {
            if (e.Column != null && e.Column == column) {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Cache.Graphics, e.Bounds, AreAllRowsSelected());
                e.Handled = true;
            }
        }
        void View_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e) {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            info.GroupText = "         " + info.GroupText.TrimStart();
            e.Info.Paint.FillRectangle(e.Cache.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
            e.Painter.DrawObject(e.Info);
            Rectangle r = info.ButtonBounds;
            r.Offset(r.Width + CheckboxIndent * 2 - 1, 0);
            DrawCheckBox(e.Cache.Graphics, r, IsGroupRowSelected(e.RowHandle));
            e.Handled = true;
        }
        void view_RowStyle(object sender, RowStyleEventArgs e) {
            if (IsRowSelected(e.RowHandle))
            {
                e.Appearance.BackColor = SystemColors.Highlight;
                e.Appearance.ForeColor = SystemColors.HighlightText;
            }
        }
        #endregion
    }
}
