﻿namespace CaptIt.SettingPanels
{
    partial class SET_HotKey
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.KS_Handle = new CaptIt.SettingPanels.KeySet();
            this.KS_HandleGet = new CaptIt.SettingPanels.KeySet();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.KS_H1 = new CaptIt.SettingPanels.KeySet();
            this.KS_HD1 = new CaptIt.SettingPanels.KeySet();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.KS_DSS = new CaptIt.SettingPanels.KeySet();
            this.KS_FSS = new CaptIt.SettingPanels.KeySet();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.KS_BS = new CaptIt.SettingPanels.KeySet();
            this.KS_BSD = new CaptIt.SettingPanels.KeySet();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "핫키";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.KS_Handle);
            this.groupBox4.Controls.Add(this.KS_HandleGet);
            this.groupBox4.Location = new System.Drawing.Point(6, 207);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(484, 92);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "윈도우 추적 캡쳐";
            // 
            // KS_Handle
            // 
            this.KS_Handle.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.KS_Handle.Key = System.Windows.Forms.Keys.None;
            this.KS_Handle.LabelText = "윈도우 추적 캡쳐 : ";
            this.KS_Handle.Location = new System.Drawing.Point(6, 56);
            this.KS_Handle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KS_Handle.Name = "KS_Handle";
            this.KS_Handle.Size = new System.Drawing.Size(467, 25);
            this.KS_Handle.TabIndex = 27;
            // 
            // KS_HandleGet
            // 
            this.KS_HandleGet.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.KS_HandleGet.Key = System.Windows.Forms.Keys.None;
            this.KS_HandleGet.LabelText = "윈도우 지정 : ";
            this.KS_HandleGet.Location = new System.Drawing.Point(6, 23);
            this.KS_HandleGet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KS_HandleGet.Name = "KS_HandleGet";
            this.KS_HandleGet.Size = new System.Drawing.Size(467, 25);
            this.KS_HandleGet.TabIndex = 26;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.KS_H1);
            this.groupBox3.Controls.Add(this.KS_HD1);
            this.groupBox3.Location = new System.Drawing.Point(6, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(484, 92);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "핫키 캡쳐";
            // 
            // KS_H1
            // 
            this.KS_H1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.KS_H1.Key = System.Windows.Forms.Keys.None;
            this.KS_H1.LabelText = "1번 핫키 캡쳐 : ";
            this.KS_H1.Location = new System.Drawing.Point(6, 56);
            this.KS_H1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KS_H1.Name = "KS_H1";
            this.KS_H1.Size = new System.Drawing.Size(467, 25);
            this.KS_H1.TabIndex = 27;
            // 
            // KS_HD1
            // 
            this.KS_HD1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.KS_HD1.Key = System.Windows.Forms.Keys.None;
            this.KS_HD1.LabelText = "1번 핫키 영역 지정 : ";
            this.KS_HD1.Location = new System.Drawing.Point(6, 23);
            this.KS_HD1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KS_HD1.Name = "KS_HD1";
            this.KS_HD1.Size = new System.Drawing.Size(467, 25);
            this.KS_HD1.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.KS_DSS);
            this.groupBox2.Controls.Add(this.KS_FSS);
            this.groupBox2.Location = new System.Drawing.Point(6, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 81);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "일반 캡쳐";
            // 
            // KS_DSS
            // 
            this.KS_DSS.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.KS_DSS.Key = System.Windows.Forms.Keys.None;
            this.KS_DSS.LabelText = "영역 지정 캡쳐 : ";
            this.KS_DSS.Location = new System.Drawing.Point(6, 47);
            this.KS_DSS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KS_DSS.Name = "KS_DSS";
            this.KS_DSS.Size = new System.Drawing.Size(467, 25);
            this.KS_DSS.TabIndex = 25;
            // 
            // KS_FSS
            // 
            this.KS_FSS.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.KS_FSS.Key = System.Windows.Forms.Keys.None;
            this.KS_FSS.LabelText = "전체 화면 캡쳐 : ";
            this.KS_FSS.Location = new System.Drawing.Point(6, 14);
            this.KS_FSS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KS_FSS.Name = "KS_FSS";
            this.KS_FSS.Size = new System.Drawing.Size(467, 25);
            this.KS_FSS.TabIndex = 24;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.KS_BS);
            this.groupBox5.Controls.Add(this.KS_BSD);
            this.groupBox5.Location = new System.Drawing.Point(6, 305);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(484, 90);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "연속 캡쳐";
            // 
            // KS_BS
            // 
            this.KS_BS.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.KS_BS.Key = System.Windows.Forms.Keys.None;
            this.KS_BS.LabelText = "연속 캡쳐 : ";
            this.KS_BS.Location = new System.Drawing.Point(6, 56);
            this.KS_BS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KS_BS.Name = "KS_BS";
            this.KS_BS.Size = new System.Drawing.Size(467, 25);
            this.KS_BS.TabIndex = 27;
            // 
            // KS_BSD
            // 
            this.KS_BSD.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.KS_BSD.Key = System.Windows.Forms.Keys.None;
            this.KS_BSD.LabelText = "연속 캡쳐 영역 지정 : ";
            this.KS_BSD.Location = new System.Drawing.Point(6, 23);
            this.KS_BSD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KS_BSD.Name = "KS_BSD";
            this.KS_BSD.Size = new System.Drawing.Size(467, 25);
            this.KS_BSD.TabIndex = 26;
            // 
            // SET_HotKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 493);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SET_HotKey";
            this.Text = "SET_HotKey";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private KeySet KS_FSS;
        private KeySet KS_H1;
        private KeySet KS_HD1;
        private KeySet KS_DSS;
        private System.Windows.Forms.GroupBox groupBox4;
        private KeySet KS_Handle;
        private KeySet KS_HandleGet;
        private System.Windows.Forms.GroupBox groupBox5;
        private KeySet KS_BS;
        private KeySet KS_BSD;
    }
}