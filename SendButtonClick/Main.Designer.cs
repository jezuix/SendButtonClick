namespace ProcessSendButtonClick
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartStop = new System.Windows.Forms.Button();
            this.ddlProcessNameId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtButton = new System.Windows.Forms.TextBox();
            this.chkCtrl = new System.Windows.Forms.CheckBox();
            this.chkShift = new System.Windows.Forms.CheckBox();
            this.chkAlt = new System.Windows.Forms.CheckBox();
            this.btnAddButton = new System.Windows.Forms.Button();
            this.txtPause = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddPause = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUniversalPause = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbPreSetButtonClick = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddPreSetButton = new System.Windows.Forms.Button();
            this.chkRandomVariation = new System.Windows.Forms.CheckBox();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.dgvButtonSequence = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoop = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddLoop = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvButtonSequence)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 619);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(647, 34);
            this.btnStartStop.TabIndex = 13;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // ddlProcessNameId
            // 
            this.ddlProcessNameId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProcessNameId.FormattingEnabled = true;
            this.ddlProcessNameId.Location = new System.Drawing.Point(175, 5);
            this.ddlProcessNameId.Name = "ddlProcessNameId";
            this.ddlProcessNameId.Size = new System.Drawing.Size(366, 33);
            this.ddlProcessNameId.TabIndex = 0;
            this.ddlProcessNameId.Click += new System.EventHandler(this.ddlProcessNameId_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Process Name - Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Button Click";
            // 
            // txtButton
            // 
            this.txtButton.Location = new System.Drawing.Point(124, 51);
            this.txtButton.MaxLength = 1;
            this.txtButton.Name = "txtButton";
            this.txtButton.Size = new System.Drawing.Size(106, 31);
            this.txtButton.TabIndex = 2;
            this.txtButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkCtrl
            // 
            this.chkCtrl.AutoSize = true;
            this.chkCtrl.Location = new System.Drawing.Point(236, 52);
            this.chkCtrl.Name = "chkCtrl";
            this.chkCtrl.Size = new System.Drawing.Size(97, 29);
            this.chkCtrl.TabIndex = 3;
            this.chkCtrl.Text = "Control";
            this.chkCtrl.UseVisualStyleBackColor = true;
            // 
            // chkShift
            // 
            this.chkShift.AutoSize = true;
            this.chkShift.Location = new System.Drawing.Point(339, 52);
            this.chkShift.Name = "chkShift";
            this.chkShift.Size = new System.Drawing.Size(74, 29);
            this.chkShift.TabIndex = 4;
            this.chkShift.Text = "Shift";
            this.chkShift.UseVisualStyleBackColor = true;
            // 
            // chkAlt
            // 
            this.chkAlt.AutoSize = true;
            this.chkAlt.Location = new System.Drawing.Point(419, 52);
            this.chkAlt.Name = "chkAlt";
            this.chkAlt.Size = new System.Drawing.Size(60, 29);
            this.chkAlt.TabIndex = 5;
            this.chkAlt.Text = "Alt";
            this.chkAlt.UseVisualStyleBackColor = true;
            // 
            // btnAddButton
            // 
            this.btnAddButton.Location = new System.Drawing.Point(547, 49);
            this.btnAddButton.Name = "btnAddButton";
            this.btnAddButton.Size = new System.Drawing.Size(112, 34);
            this.btnAddButton.TabIndex = 6;
            this.btnAddButton.Text = "Add";
            this.btnAddButton.UseVisualStyleBackColor = true;
            this.btnAddButton.Click += new System.EventHandler(this.btnAddButton_Click);
            // 
            // txtPause
            // 
            this.txtPause.Location = new System.Drawing.Point(187, 140);
            this.txtPause.MaxLength = 5;
            this.txtPause.Name = "txtPause";
            this.txtPause.Size = new System.Drawing.Size(106, 31);
            this.txtPause.TabIndex = 9;
            this.txtPause.Text = "1000";
            this.txtPause.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPause_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Pause (milliseconds)";
            // 
            // btnAddPause
            // 
            this.btnAddPause.Location = new System.Drawing.Point(547, 138);
            this.btnAddPause.Name = "btnAddPause";
            this.btnAddPause.Size = new System.Drawing.Size(112, 34);
            this.btnAddPause.TabIndex = 10;
            this.btnAddPause.Text = "Add";
            this.btnAddPause.UseVisualStyleBackColor = true;
            this.btnAddPause.Click += new System.EventHandler(this.btnAddPause_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Universal Pause (milliseconds)";
            // 
            // txtUniversalPause
            // 
            this.txtUniversalPause.Location = new System.Drawing.Point(263, 245);
            this.txtUniversalPause.MaxLength = 5;
            this.txtUniversalPause.Name = "txtUniversalPause";
            this.txtUniversalPause.Size = new System.Drawing.Size(106, 31);
            this.txtUniversalPause.TabIndex = 11;
            this.txtUniversalPause.Text = "50";
            this.txtUniversalPause.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUniversalPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUniversalPause_KeyPress);
            this.txtUniversalPause.Leave += new System.EventHandler(this.txtUniversalPause_Leave);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(299, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 2);
            this.label5.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Pre Setted Button Click";
            // 
            // cbPreSetButtonClick
            // 
            this.cbPreSetButtonClick.FormattingEnabled = true;
            this.cbPreSetButtonClick.Location = new System.Drawing.Point(210, 95);
            this.cbPreSetButtonClick.Name = "cbPreSetButtonClick";
            this.cbPreSetButtonClick.Size = new System.Drawing.Size(269, 33);
            this.cbPreSetButtonClick.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(485, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 2);
            this.label6.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(485, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 2);
            this.label8.TabIndex = 19;
            // 
            // btnAddPreSetButton
            // 
            this.btnAddPreSetButton.Location = new System.Drawing.Point(547, 94);
            this.btnAddPreSetButton.Name = "btnAddPreSetButton";
            this.btnAddPreSetButton.Size = new System.Drawing.Size(112, 34);
            this.btnAddPreSetButton.TabIndex = 8;
            this.btnAddPreSetButton.Text = "Add";
            this.btnAddPreSetButton.UseVisualStyleBackColor = true;
            this.btnAddPreSetButton.Click += new System.EventHandler(this.btnAddPreSetButton_Click);
            // 
            // chkRandomVariation
            // 
            this.chkRandomVariation.AutoSize = true;
            this.chkRandomVariation.Checked = true;
            this.chkRandomVariation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRandomVariation.Location = new System.Drawing.Point(375, 247);
            this.chkRandomVariation.Name = "chkRandomVariation";
            this.chkRandomVariation.Size = new System.Drawing.Size(213, 29);
            this.chkRandomVariation.TabIndex = 12;
            this.chkRandomVariation.Text = "Add random variation";
            this.chkRandomVariation.UseVisualStyleBackColor = true;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Location = new System.Drawing.Point(547, 4);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(112, 34);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.Text = "Maxmize";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximizeProcess_Click);
            // 
            // dgvButtonSequence
            // 
            this.dgvButtonSequence.AllowDrop = true;
            this.dgvButtonSequence.AllowUserToResizeColumns = false;
            this.dgvButtonSequence.AllowUserToResizeRows = false;
            this.dgvButtonSequence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvButtonSequence.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvButtonSequence.Location = new System.Drawing.Point(12, 282);
            this.dgvButtonSequence.MultiSelect = false;
            this.dgvButtonSequence.Name = "dgvButtonSequence";
            this.dgvButtonSequence.ReadOnly = true;
            this.dgvButtonSequence.RowHeadersWidth = 62;
            this.dgvButtonSequence.RowTemplate.Height = 33;
            this.dgvButtonSequence.Size = new System.Drawing.Size(647, 331);
            this.dgvButtonSequence.TabIndex = 14;
            this.dgvButtonSequence.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvButtonSequence_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Action loop";
            // 
            // txtLoop
            // 
            this.txtLoop.Location = new System.Drawing.Point(123, 185);
            this.txtLoop.MaxLength = 3;
            this.txtLoop.Name = "txtLoop";
            this.txtLoop.Size = new System.Drawing.Size(106, 31);
            this.txtLoop.TabIndex = 21;
            this.txtLoop.Text = "10";
            this.txtLoop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLoop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoop_KeyPress);
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(235, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(306, 1);
            this.label10.TabIndex = 22;
            // 
            // btnAddLoop
            // 
            this.btnAddLoop.Location = new System.Drawing.Point(547, 184);
            this.btnAddLoop.Name = "btnAddLoop";
            this.btnAddLoop.Size = new System.Drawing.Size(112, 34);
            this.btnAddLoop.TabIndex = 23;
            this.btnAddLoop.Text = "Add";
            this.btnAddLoop.UseVisualStyleBackColor = true;
            this.btnAddLoop.Click += new System.EventHandler(this.btnAddLoop_Click);
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(12, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(647, 1);
            this.label11.TabIndex = 24;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 662);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAddLoop);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtLoop);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvButtonSequence);
            this.Controls.Add(this.btnMaximize);
            this.Controls.Add(this.chkRandomVariation);
            this.Controls.Add(this.btnAddPreSetButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbPreSetButtonClick);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUniversalPause);
            this.Controls.Add(this.btnAddPause);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPause);
            this.Controls.Add(this.btnAddButton);
            this.Controls.Add(this.chkAlt);
            this.Controls.Add(this.chkShift);
            this.Controls.Add(this.chkCtrl);
            this.Controls.Add(this.txtButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlProcessNameId);
            this.Controls.Add(this.btnStartStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Proccess Send Button Click";
            ((System.ComponentModel.ISupportInitialize)(this.dgvButtonSequence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStartStop;
        private ComboBox ddlProcessNameId;
        private Label label1;
        private Label label2;
        private TextBox txtButton;
        private CheckBox chkCtrl;
        private CheckBox chkShift;
        private CheckBox chkAlt;
        private Button btnAddButton;
        private TextBox txtPause;
        private Label label3;
        private Button btnAddPause;
        private Label label4;
        private TextBox txtUniversalPause;
        private Label label5;
        private Label label7;
        private ComboBox cbPreSetButtonClick;
        private Label label6;
        private Label label8;
        private Button btnAddPreSetButton;
        private CheckBox chkRandomVariation;
        private Button btnMaximize;
        private DataGridView dgvButtonSequence;
        private Label label9;
        private TextBox txtLoop;
        private Label label10;
        private Button btnAddLoop;
        private Label label11;
    }
}