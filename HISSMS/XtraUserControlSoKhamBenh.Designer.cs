using DevExpress.XtraGrid.Views.Grid;
namespace HISSMS
{
    partial class XtraUserControlSoKhamBenh
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cb_solieu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.simpleButtonXem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.stiViewerControl = new Stimulsoft.Report.Viewer.StiViewerControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_solieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1008, 63);
            this.panelControl1.TabIndex = 1;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cb_solieu);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.dateEditDenNgay);
            this.groupControl1.Controls.Add(this.simpleButtonXem);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dateEditTuNgay);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(567, 55);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Ngày thống kê";
            // 
            // cb_solieu
            // 
            this.cb_solieu.Location = new System.Drawing.Point(357, 27);
            this.cb_solieu.Name = "cb_solieu";
            this.cb_solieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb_solieu.Properties.Items.AddRange(new object[] {
            "Nội trú",
            "Ngoại trú"});
            this.cb_solieu.Size = new System.Drawing.Size(100, 20);
            this.cb_solieu.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(316, 30);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Số liệu:";
            // 
            // dateEditDenNgay
            // 
            this.dateEditDenNgay.EditValue = null;
            this.dateEditDenNgay.Location = new System.Drawing.Point(207, 27);
            this.dateEditDenNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.dateEditDenNgay.Size = new System.Drawing.Size(89, 20);
            this.dateEditDenNgay.TabIndex = 2;
            // 
            // simpleButtonXem
            // 
            this.simpleButtonXem.Location = new System.Drawing.Point(483, 27);
            this.simpleButtonXem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButtonXem.Name = "simpleButtonXem";
            this.simpleButtonXem.Size = new System.Drawing.Size(64, 19);
            this.simpleButtonXem.TabIndex = 0;
            this.simpleButtonXem.Text = "Xem";
            this.simpleButtonXem.Click += new System.EventHandler(this.simpleButtonXem_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(154, 30);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Đến ngày";
            // 
            // dateEditTuNgay
            // 
            this.dateEditTuNgay.EditValue = null;
            this.dateEditTuNgay.Location = new System.Drawing.Point(55, 27);
            this.dateEditTuNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.dateEditTuNgay.Size = new System.Drawing.Size(89, 20);
            this.dateEditTuNgay.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 30);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.stiViewerControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 63);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1008, 373);
            this.panelControl2.TabIndex = 2;
            // 
            // stiViewerControl
            // 
            this.stiViewerControl.AllowDrop = true;
            this.stiViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stiViewerControl.Location = new System.Drawing.Point(2, 2);
            this.stiViewerControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stiViewerControl.Name = "stiViewerControl";
            this.stiViewerControl.Report = null;
            this.stiViewerControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiViewerControl.ShowBookmarksPanel = false;
            this.stiViewerControl.ShowOpen = false;
            this.stiViewerControl.ShowSendEMail = false;
            this.stiViewerControl.ShowSendEMailDocumentFile = false;
            this.stiViewerControl.ShowZoom = true;
            this.stiViewerControl.Size = new System.Drawing.Size(1004, 369);
            this.stiViewerControl.TabIndex = 0;
            // 
            // Mau_79_80
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Mau_79_80";
            this.Size = new System.Drawing.Size(1008, 436);
            this.Load += new System.EventHandler(this.Mau_79_80_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_solieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private Stimulsoft.Report.Viewer.StiViewerControl stiViewerControl;
        private DevExpress.XtraEditors.SimpleButton simpleButtonXem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dateEditDenNgay;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEditTuNgay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cb_solieu;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
