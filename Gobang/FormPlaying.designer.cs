namespace Gobang
{
    partial class FormPlaying
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
            this.painter = new System.Windows.Forms.Panel();
            this.leftBox = new System.Windows.Forms.Panel();
            this.infoBox = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.PlayerColor = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelPlayStatus = new System.Windows.Forms.Label();
            this.labelSide0 = new System.Windows.Forms.Label();
            this.labelGrade0 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSide1 = new System.Windows.Forms.Label();
            this.labelGrade1 = new System.Windows.Forms.Label();
            this.panelTalk = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.leftBox.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.panelTalk.SuspendLayout();
            this.SuspendLayout();
            // 
            // painter
            // 
            this.painter.Location = new System.Drawing.Point(65, 3);
            this.painter.Name = "painter";
            this.painter.Size = new System.Drawing.Size(525, 546);
            this.painter.TabIndex = 12;
            this.painter.SizeChanged += new System.EventHandler(this.painter_Resize);
            this.painter.Paint += new System.Windows.Forms.PaintEventHandler(this.painter_Paint);
            this.painter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.painter_MouseDown);
            this.painter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.painter_MouseMove);
            this.painter.Resize += new System.EventHandler(this.painter_Resize);
            // 
            // leftBox
            // 
            this.leftBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftBox.BackgroundImage = global::Gobang.Properties.Resources.gobang;
            this.leftBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftBox.Controls.Add(this.painter);
            this.leftBox.Location = new System.Drawing.Point(0, 0);
            this.leftBox.Margin = new System.Windows.Forms.Padding(0);
            this.leftBox.Name = "leftBox";
            this.leftBox.Size = new System.Drawing.Size(660, 552);
            this.leftBox.TabIndex = 15;
            // 
            // infoBox
            // 
            this.infoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoBox.BackgroundImage = global::Gobang.Properties.Resources.rightBox;
            this.infoBox.Controls.Add(this.buttonExit);
            this.infoBox.Controls.Add(this.buttonHelp);
            this.infoBox.Controls.Add(this.listBox1);
            this.infoBox.Controls.Add(this.PlayerColor);
            this.infoBox.Controls.Add(this.buttonStart);
            this.infoBox.Controls.Add(this.label2);
            this.infoBox.Controls.Add(this.label6);
            this.infoBox.Controls.Add(this.LabelPlayStatus);
            this.infoBox.Controls.Add(this.labelSide0);
            this.infoBox.Controls.Add(this.labelGrade0);
            this.infoBox.Controls.Add(this.label5);
            this.infoBox.Controls.Add(this.labelSide1);
            this.infoBox.Controls.Add(this.labelGrade1);
            this.infoBox.Location = new System.Drawing.Point(660, 0);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(204, 600);
            this.infoBox.TabIndex = 14;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(117, 567);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(83, 29);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHelp.Location = new System.Drawing.Point(4, 567);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(89, 29);
            this.buttonHelp.TabIndex = 2;
            this.buttonHelp.Text = "帮助";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(4, 465);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 94);
            this.listBox1.TabIndex = 3;
            // 
            // PlayerColor
            // 
            this.PlayerColor.AutoSize = true;
            this.PlayerColor.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerColor.Location = new System.Drawing.Point(65, 17);
            this.PlayerColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PlayerColor.Name = "PlayerColor";
            this.PlayerColor.Size = new System.Drawing.Size(97, 40);
            this.PlayerColor.TabIndex = 11;
            this.PlayerColor.Text = "颜色";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(62, 428);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(89, 29);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(12, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "游戏状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 295);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "成绩：";
            // 
            // LabelPlayStatus
            // 
            this.LabelPlayStatus.AutoSize = true;
            this.LabelPlayStatus.ForeColor = System.Drawing.Color.Blue;
            this.LabelPlayStatus.Location = new System.Drawing.Point(41, 182);
            this.LabelPlayStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelPlayStatus.Name = "LabelPlayStatus";
            this.LabelPlayStatus.Size = new System.Drawing.Size(67, 15);
            this.LabelPlayStatus.TabIndex = 9;
            this.LabelPlayStatus.Text = "等待开始";
            // 
            // labelSide0
            // 
            this.labelSide0.AutoSize = true;
            this.labelSide0.Location = new System.Drawing.Point(42, 68);
            this.labelSide0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSide0.Name = "labelSide0";
            this.labelSide0.Size = new System.Drawing.Size(87, 15);
            this.labelSide0.TabIndex = 4;
            this.labelSide0.Text = "labelSide1";
            // 
            // labelGrade0
            // 
            this.labelGrade0.AutoSize = true;
            this.labelGrade0.Location = new System.Drawing.Point(101, 102);
            this.labelGrade0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGrade0.Name = "labelGrade0";
            this.labelGrade0.Size = new System.Drawing.Size(15, 15);
            this.labelGrade0.TabIndex = 4;
            this.labelGrade0.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "成绩：";
            // 
            // labelSide1
            // 
            this.labelSide1.AutoSize = true;
            this.labelSide1.Location = new System.Drawing.Point(42, 252);
            this.labelSide1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSide1.Name = "labelSide1";
            this.labelSide1.Size = new System.Drawing.Size(87, 15);
            this.labelSide1.TabIndex = 4;
            this.labelSide1.Text = "labelSide2";
            // 
            // labelGrade1
            // 
            this.labelGrade1.AutoSize = true;
            this.labelGrade1.Location = new System.Drawing.Point(101, 295);
            this.labelGrade1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGrade1.Name = "labelGrade1";
            this.labelGrade1.Size = new System.Drawing.Size(15, 15);
            this.labelGrade1.TabIndex = 4;
            this.labelGrade1.Text = "0";
            // 
            // panelTalk
            // 
            this.panelTalk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTalk.BackColor = System.Drawing.SystemColors.Control;
            this.panelTalk.BackgroundImage = global::Gobang.Properties.Resources.rightBox;
            this.panelTalk.Controls.Add(this.textBox1);
            this.panelTalk.Controls.Add(this.buttonSend);
            this.panelTalk.Location = new System.Drawing.Point(0, 555);
            this.panelTalk.Name = "panelTalk";
            this.panelTalk.Size = new System.Drawing.Size(660, 45);
            this.panelTalk.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(5, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(577, 25);
            this.textBox1.TabIndex = 5;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(591, 8);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(62, 29);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "聊天";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // FormPlaying
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 600);
            this.Controls.Add(this.leftBox);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.panelTalk);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormPlaying";
            this.Text = "五子棋游戏";
            this.MaximumSizeChanged += new System.EventHandler(this.FormPlaying_Resize);
            this.MinimumSizeChanged += new System.EventHandler(this.FormPlaying_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPlaying_FormClosing);
            this.Load += new System.EventHandler(this.FormPlaying_Load);
            this.Resize += new System.EventHandler(this.FormPlaying_Resize);
            this.leftBox.ResumeLayout(false);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.panelTalk.ResumeLayout(false);
            this.panelTalk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelSide0;
        private System.Windows.Forms.Label labelSide1;
        private System.Windows.Forms.Label labelGrade0;
        private System.Windows.Forms.Label labelGrade1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LabelPlayStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PlayerColor;
        private System.Windows.Forms.Panel panelTalk;
        private System.Windows.Forms.Panel infoBox;
        private System.Windows.Forms.Panel painter;
        private System.Windows.Forms.Panel leftBox;
    }
}