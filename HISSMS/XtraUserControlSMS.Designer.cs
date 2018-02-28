using DevExpress.XtraGrid.Views.Grid;
namespace HISSMS
{
    partial class XtraUserControlSMS
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonGuiSMS = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEditHinhThuc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlSMS = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NamSinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoThe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayHen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoLanGui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.simpleButtonXem = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHinhThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1062, 94);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.simpleButtonExport);
            this.groupControl2.Controls.Add(this.simpleButtonGuiSMS);
            this.groupControl2.Controls.Add(this.comboBoxEditHinhThuc);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Location = new System.Drawing.Point(534, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(523, 83);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Gửi tin nhắn";
            // 
            // simpleButtonGuiSMS
            // 
            this.simpleButtonGuiSMS.Location = new System.Drawing.Point(349, 43);
            this.simpleButtonGuiSMS.Name = "simpleButtonGuiSMS";
            this.simpleButtonGuiSMS.Size = new System.Drawing.Size(68, 23);
            this.simpleButtonGuiSMS.TabIndex = 5;
            this.simpleButtonGuiSMS.Text = "Gửi SMS";
            this.simpleButtonGuiSMS.Click += new System.EventHandler(this.simpleButtonGuiSMS_Click);
            // 
            // comboBoxEditHinhThuc
            // 
            this.comboBoxEditHinhThuc.EditValue = "";
            this.comboBoxEditHinhThuc.Location = new System.Drawing.Point(95, 44);
            this.comboBoxEditHinhThuc.Name = "comboBoxEditHinhThuc";
            this.comboBoxEditHinhThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditHinhThuc.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditHinhThuc.Size = new System.Drawing.Size(248, 22);
            this.comboBoxEditHinhThuc.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 46);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(83, 17);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Hình thức gừi";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButtonXem);
            this.groupControl1.Controls.Add(this.simpleButtonCapNhat);
            this.groupControl1.Controls.Add(this.dateEditDenNgay);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dateEditTuNgay);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(523, 83);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Ngày hẹn";
            // 
            // simpleButtonCapNhat
            // 
            this.simpleButtonCapNhat.Location = new System.Drawing.Point(352, 42);
            this.simpleButtonCapNhat.Name = "simpleButtonCapNhat";
            this.simpleButtonCapNhat.Size = new System.Drawing.Size(80, 23);
            this.simpleButtonCapNhat.TabIndex = 3;
            this.simpleButtonCapNhat.Text = "Cập nhật";
            this.simpleButtonCapNhat.Click += new System.EventHandler(this.simpleButtonXem_Click);
            // 
            // dateEditDenNgay
            // 
            this.dateEditDenNgay.EditValue = null;
            this.dateEditDenNgay.Location = new System.Drawing.Point(242, 42);
            this.dateEditDenNgay.Name = "dateEditDenNgay";
            this.dateEditDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEditDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEditDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditDenNgay.Size = new System.Drawing.Size(104, 22);
            this.dateEditDenNgay.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(176, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 17);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Đến ngày";
            // 
            // dateEditTuNgay
            // 
            this.dateEditTuNgay.EditValue = null;
            this.dateEditTuNgay.Location = new System.Drawing.Point(64, 42);
            this.dateEditTuNgay.Name = "dateEditTuNgay";
            this.dateEditTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEditTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEditTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEditTuNgay.Size = new System.Drawing.Size(104, 22);
            this.dateEditTuNgay.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
            // 
            // gridControlSMS
            // 
            this.gridControlSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSMS.Location = new System.Drawing.Point(0, 94);
            this.gridControlSMS.MainView = this.gridView;
            this.gridControlSMS.Name = "gridControlSMS";
            this.gridControlSMS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridControlSMS.Size = new System.Drawing.Size(1062, 421);
            this.gridControlSMS.TabIndex = 1;
            this.gridControlSMS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.MaBN,
            this.HoTen,
            this.NamSinh,
            this.SoThe,
            this.DiaChi,
            this.SoDienThoai,
            this.NgayHen,
            this.NoiDung,
            this.TrangThai,
            this.SoLanGui});
            this.gridView.CustomizationFormBounds = new System.Drawing.Rectangle(898, 453, 218, 212);
            this.gridView.GridControl = this.gridControlSMS;
            this.gridView.Name = "gridView1";
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 58;
            // 
            // MaBN
            // 
            this.MaBN.Caption = "Mã BN";
            this.MaBN.Name = "MaBN";
            this.MaBN.OptionsColumn.AllowEdit = false;
            this.MaBN.OptionsColumn.AllowFocus = false;
            this.MaBN.Visible = true;
            this.MaBN.VisibleIndex = 1;
            this.MaBN.Width = 58;
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Họ tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.OptionsColumn.AllowEdit = false;
            this.HoTen.OptionsColumn.AllowFocus = false;
            this.HoTen.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 2;
            this.HoTen.Width = 114;
            // 
            // NamSinh
            // 
            this.NamSinh.Caption = "Năm sinh";
            this.NamSinh.Name = "NamSinh";
            this.NamSinh.OptionsColumn.AllowEdit = false;
            this.NamSinh.OptionsColumn.AllowFocus = false;
            this.NamSinh.Visible = true;
            this.NamSinh.VisibleIndex = 3;
            this.NamSinh.Width = 59;
            // 
            // SoThe
            // 
            this.SoThe.Caption = "Số thẻ";
            this.SoThe.Name = "SoThe";
            this.SoThe.OptionsColumn.AllowEdit = false;
            this.SoThe.OptionsColumn.AllowFocus = false;
            this.SoThe.Visible = true;
            this.SoThe.VisibleIndex = 4;
            this.SoThe.Width = 127;
            // 
            // DiaChi
            // 
            this.DiaChi.Caption = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.OptionsColumn.AllowEdit = false;
            this.DiaChi.OptionsColumn.AllowFocus = false;
            this.DiaChi.Visible = true;
            this.DiaChi.VisibleIndex = 5;
            this.DiaChi.Width = 255;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.Caption = "Số điện thoại";
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.Visible = true;
            this.SoDienThoai.VisibleIndex = 6;
            this.SoDienThoai.Width = 88;
            // 
            // NgayHen
            // 
            this.NgayHen.Caption = "Ngày hẹn";
            this.NgayHen.Name = "NgayHen";
            this.NgayHen.OptionsColumn.AllowEdit = false;
            this.NgayHen.OptionsColumn.AllowFocus = false;
            this.NgayHen.Visible = true;
            this.NgayHen.VisibleIndex = 7;
            this.NgayHen.Width = 69;
            // 
            // NoiDung
            // 
            this.NoiDung.Caption = "Nội dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.OptionsColumn.AllowEdit = false;
            this.NoiDung.OptionsColumn.AllowFocus = false;
            this.NoiDung.Visible = true;
            this.NoiDung.VisibleIndex = 8;
            this.NoiDung.Width = 255;
            // 
            // TrangThai
            // 
            this.TrangThai.Caption = "Trạng Thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.OptionsColumn.AllowEdit = false;
            this.TrangThai.OptionsColumn.AllowFocus = false;
            this.TrangThai.Visible = true;
            this.TrangThai.VisibleIndex = 10;
            this.TrangThai.Width = 70;
            // 
            // SoLanGui
            // 
            this.SoLanGui.Caption = "Số lần gửi";
            this.SoLanGui.Name = "SoLanGui";
            this.SoLanGui.OptionsColumn.AllowEdit = false;
            this.SoLanGui.OptionsColumn.AllowFocus = false;
            this.SoLanGui.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.SoLanGui.Visible = true;
            this.SoLanGui.VisibleIndex = 9;
            this.SoLanGui.Width = 70;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControlSMS;
            this.gridView2.Name = "gridView2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // simpleButtonXem
            // 
            this.simpleButtonXem.Location = new System.Drawing.Point(438, 42);
            this.simpleButtonXem.Name = "simpleButtonXem";
            this.simpleButtonXem.Size = new System.Drawing.Size(80, 23);
            this.simpleButtonXem.TabIndex = 4;
            this.simpleButtonXem.Text = "Xem";
            this.simpleButtonXem.Click += new System.EventHandler(this.simpleButtonXem_Click_1);
            // 
            // simpleButtonExport
            // 
            this.simpleButtonExport.Location = new System.Drawing.Point(423, 43);
            this.simpleButtonExport.Name = "simpleButtonExport";
            this.simpleButtonExport.Size = new System.Drawing.Size(68, 23);
            this.simpleButtonExport.TabIndex = 7;
            this.simpleButtonExport.Text = "Export";
            this.simpleButtonExport.Click += new System.EventHandler(this.simpleButtonExport_Click);
            // 
            // XtraUserControlSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlSMS);
            this.Controls.Add(this.panelControl1);
            this.Name = "XtraUserControlSMS";
            this.Size = new System.Drawing.Size(1062, 515);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHinhThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCapNhat;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dateEditDenNgay;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEditTuNgay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControlSMS;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn MaBN;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn SoDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn SoLanGui;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn NamSinh;
        private DevExpress.XtraGrid.Columns.GridColumn NoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn SoThe;
        private DevExpress.XtraGrid.Columns.GridColumn NgayHen;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonGuiSMS;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditHinhThuc;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonXem;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExport;
    }
}
