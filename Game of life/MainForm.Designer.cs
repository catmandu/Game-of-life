using Microsoft.VisualBasic.PowerPacks;

namespace Game_of_life
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.frame = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.barSpeed = new System.Windows.Forms.TrackBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblGenerations = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.clrBorders = new System.Windows.Forms.ColorDialog();
            this.btn_BorderColor = new System.Windows.Forms.Button();
            this.btn_FillColor = new System.Windows.Forms.Button();
            this.btn_BackgroundColor = new System.Windows.Forms.Button();
            this.clrBackground = new System.Windows.Forms.ColorDialog();
            this.clrFill = new System.Windows.Forms.ColorDialog();
            this.picBorder = new System.Windows.Forms.PictureBox();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.picFill = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.frame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFill)).BeginInit();
            this.SuspendLayout();
            // 
            // frame
            // 
            this.frame.BackColor = System.Drawing.Color.Transparent;
            this.frame.Location = new System.Drawing.Point(120, 1);
            this.frame.Name = "frame";
            this.frame.Size = new System.Drawing.Size(490, 497);
            this.frame.TabIndex = 0;
            this.frame.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(26, 102);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Comenzar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // barSpeed
            // 
            this.barSpeed.Location = new System.Drawing.Point(12, 194);
            this.barSpeed.Maximum = 1000;
            this.barSpeed.Minimum = 100;
            this.barSpeed.Name = "barSpeed";
            this.barSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.barSpeed.Size = new System.Drawing.Size(104, 45);
            this.barSpeed.TabIndex = 2;
            this.barSpeed.Value = 500;
            this.barSpeed.Scroll += new System.EventHandler(this.BarSpeed_Scroll);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(26, 131);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Reset";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // lblGenerations
            // 
            this.lblGenerations.AutoSize = true;
            this.lblGenerations.Location = new System.Drawing.Point(29, 21);
            this.lblGenerations.Name = "lblGenerations";
            this.lblGenerations.Size = new System.Drawing.Size(74, 13);
            this.lblGenerations.TabIndex = 4;
            this.lblGenerations.Text = "Generacion: 0";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(29, 169);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(63, 13);
            this.lblSpeed.TabIndex = 5;
            this.lblSpeed.Text = "-Velocidad+";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(1, 253);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(119, 39);
            this.lblInstructions.TabIndex = 6;
            this.lblInstructions.Text = "Haz click en las casillas\r\npara activarlas y/o \r\ndesactivarlas.";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(26, 46);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(75, 20);
            this.txtSize.TabIndex = 7;
            this.txtSize.Text = "30";
            this.txtSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSize_KeyPress);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(26, 73);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generar";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // clrBorders
            // 
            this.clrBorders.AnyColor = true;
            this.clrBorders.Color = System.Drawing.Color.LightGray;
            // 
            // btn_BorderColor
            // 
            this.btn_BorderColor.Location = new System.Drawing.Point(4, 308);
            this.btn_BorderColor.Name = "btn_BorderColor";
            this.btn_BorderColor.Size = new System.Drawing.Size(89, 23);
            this.btn_BorderColor.TabIndex = 9;
            this.btn_BorderColor.Text = "Color de bordes";
            this.btn_BorderColor.UseVisualStyleBackColor = true;
            this.btn_BorderColor.Click += new System.EventHandler(this.BtnBorderColor_Click);
            // 
            // btn_FillColor
            // 
            this.btn_FillColor.Location = new System.Drawing.Point(4, 366);
            this.btn_FillColor.Name = "btn_FillColor";
            this.btn_FillColor.Size = new System.Drawing.Size(89, 23);
            this.btn_FillColor.TabIndex = 10;
            this.btn_FillColor.Text = "Color de activo";
            this.btn_FillColor.UseVisualStyleBackColor = true;
            this.btn_FillColor.Click += new System.EventHandler(this.Btn_FillColor_Click);
            // 
            // btn_BackgroundColor
            // 
            this.btn_BackgroundColor.Location = new System.Drawing.Point(4, 337);
            this.btn_BackgroundColor.Name = "btn_BackgroundColor";
            this.btn_BackgroundColor.Size = new System.Drawing.Size(89, 23);
            this.btn_BackgroundColor.TabIndex = 11;
            this.btn_BackgroundColor.Text = "Color de fondo";
            this.btn_BackgroundColor.UseVisualStyleBackColor = true;
            this.btn_BackgroundColor.Click += new System.EventHandler(this.Btn_BackgroundColor_Click);
            // 
            // clrBackground
            // 
            this.clrBackground.Color = System.Drawing.Color.White;
            // 
            // picBorder
            // 
            this.picBorder.BackColor = clrBorders.Color;
            this.picBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBorder.Enabled = false;
            this.picBorder.Location = new System.Drawing.Point(94, 308);
            this.picBorder.Name = "picBorder";
            this.picBorder.Size = new System.Drawing.Size(22, 22);
            this.picBorder.TabIndex = 12;
            this.picBorder.TabStop = false;
            // 
            // picBackground
            // 
            this.picBackground.BackColor = clrBackground.Color;
            this.picBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBackground.Enabled = false;
            this.picBackground.Location = new System.Drawing.Point(94, 336);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(22, 22);
            this.picBackground.TabIndex = 13;
            this.picBackground.TabStop = false;
            // 
            // picFill
            // 
            this.picFill.BackColor = clrFill.Color;
            this.picFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFill.Enabled = false;
            this.picFill.Location = new System.Drawing.Point(94, 367);
            this.picFill.Name = "picFill";
            this.picFill.Size = new System.Drawing.Size(22, 22);
            this.picFill.TabIndex = 14;
            this.picFill.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 499);
            this.Controls.Add(this.picFill);
            this.Controls.Add(this.picBackground);
            this.Controls.Add(this.picBorder);
            this.Controls.Add(this.btn_BackgroundColor);
            this.Controls.Add(this.btn_FillColor);
            this.Controls.Add(this.btn_BorderColor);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblGenerations);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.barSpeed);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.frame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game of life";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox frame;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TrackBar barSpeed;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblGenerations;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ColorDialog clrBorders;
        private System.Windows.Forms.Button btn_BorderColor;
        private System.Windows.Forms.Button btn_FillColor;
        private System.Windows.Forms.Button btn_BackgroundColor;
        private System.Windows.Forms.ColorDialog clrBackground;
        private System.Windows.Forms.ColorDialog clrFill;
        private System.Windows.Forms.PictureBox picBorder;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.PictureBox picFill;
    }
}

