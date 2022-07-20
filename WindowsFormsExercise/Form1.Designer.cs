namespace CalculatorApp
{
    partial class Form1
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
            this.ansScreen = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAns = new System.Windows.Forms.Button();
            this.buttonCA = new System.Windows.Forms.Button();
            this.buttonSQRT = new System.Windows.Forms.Button();
            this.buttonSqr = new System.Windows.Forms.Button();
            this.buttonRightParantheses = new System.Windows.Forms.Button();
            this.buttonLeftParantheses = new System.Windows.Forms.Button();
            this.buttonDvider = new System.Windows.Forms.Button();
            this.buttonMultiply = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.button1Equal = new System.Windows.Forms.Button();
            this.buttonZero = new System.Windows.Forms.Button();
            this.buttonComma = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.buttonConsol = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ansScreen
            // 
            this.ansScreen.Location = new System.Drawing.Point(6, 38);
            this.ansScreen.Name = "ansScreen";
            this.ansScreen.Size = new System.Drawing.Size(315, 20);
            this.ansScreen.TabIndex = 0;
            this.ansScreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(172, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(66, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 35);
            this.button4.TabIndex = 4;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(119, 57);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 35);
            this.button5.TabIndex = 5;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(172, 57);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 35);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonConsol);
            this.groupBox1.Controls.Add(this.buttonAns);
            this.groupBox1.Controls.Add(this.buttonCA);
            this.groupBox1.Controls.Add(this.buttonSQRT);
            this.groupBox1.Controls.Add(this.buttonSqr);
            this.groupBox1.Controls.Add(this.buttonRightParantheses);
            this.groupBox1.Controls.Add(this.buttonLeftParantheses);
            this.groupBox1.Controls.Add(this.buttonDvider);
            this.groupBox1.Controls.Add(this.buttonMultiply);
            this.groupBox1.Controls.Add(this.buttonMinus);
            this.groupBox1.Controls.Add(this.buttonPlus);
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.button1Equal);
            this.groupBox1.Controls.Add(this.buttonZero);
            this.groupBox1.Controls.Add(this.buttonComma);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 195);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonAns
            // 
            this.buttonAns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonAns.Location = new System.Drawing.Point(13, 139);
            this.buttonAns.Name = "buttonAns";
            this.buttonAns.Size = new System.Drawing.Size(47, 35);
            this.buttonAns.TabIndex = 23;
            this.buttonAns.Text = "Ans";
            this.buttonAns.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAns.UseVisualStyleBackColor = false;
            this.buttonAns.Click += new System.EventHandler(this.buttonAns_Click);
            // 
            // buttonCA
            // 
            this.buttonCA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonCA.Location = new System.Drawing.Point(274, 16);
            this.buttonCA.Name = "buttonCA";
            this.buttonCA.Size = new System.Drawing.Size(47, 35);
            this.buttonCA.TabIndex = 22;
            this.buttonCA.Text = "CA";
            this.buttonCA.UseVisualStyleBackColor = false;
            this.buttonCA.Click += new System.EventHandler(this.buttonCA_Click);
            // 
            // buttonSQRT
            // 
            this.buttonSQRT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonSQRT.Location = new System.Drawing.Point(278, 139);
            this.buttonSQRT.Name = "buttonSQRT";
            this.buttonSQRT.Size = new System.Drawing.Size(47, 35);
            this.buttonSQRT.TabIndex = 21;
            this.buttonSQRT.Text = "X ^ -2";
            this.buttonSQRT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSQRT.UseVisualStyleBackColor = false;
            this.buttonSQRT.Click += new System.EventHandler(this.buttonSQRT_Click);
            // 
            // buttonSqr
            // 
            this.buttonSqr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonSqr.Location = new System.Drawing.Point(278, 98);
            this.buttonSqr.Name = "buttonSqr";
            this.buttonSqr.Size = new System.Drawing.Size(47, 35);
            this.buttonSqr.TabIndex = 20;
            this.buttonSqr.Text = "X ^ 2";
            this.buttonSqr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSqr.UseVisualStyleBackColor = false;
            this.buttonSqr.Click += new System.EventHandler(this.buttonSqr_Click);
            // 
            // buttonRightParantheses
            // 
            this.buttonRightParantheses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonRightParantheses.Location = new System.Drawing.Point(13, 98);
            this.buttonRightParantheses.Name = "buttonRightParantheses";
            this.buttonRightParantheses.Size = new System.Drawing.Size(47, 35);
            this.buttonRightParantheses.TabIndex = 19;
            this.buttonRightParantheses.Text = ")";
            this.buttonRightParantheses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRightParantheses.UseVisualStyleBackColor = false;
            this.buttonRightParantheses.Click += new System.EventHandler(this.buttonRightParantheses_Click);
            // 
            // buttonLeftParantheses
            // 
            this.buttonLeftParantheses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonLeftParantheses.Location = new System.Drawing.Point(13, 57);
            this.buttonLeftParantheses.Name = "buttonLeftParantheses";
            this.buttonLeftParantheses.Size = new System.Drawing.Size(47, 35);
            this.buttonLeftParantheses.TabIndex = 18;
            this.buttonLeftParantheses.Text = "(";
            this.buttonLeftParantheses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLeftParantheses.UseVisualStyleBackColor = false;
            this.buttonLeftParantheses.Click += new System.EventHandler(this.buttonLeftParantheses_Click);
            // 
            // buttonDvider
            // 
            this.buttonDvider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonDvider.Location = new System.Drawing.Point(278, 57);
            this.buttonDvider.Name = "buttonDvider";
            this.buttonDvider.Size = new System.Drawing.Size(47, 35);
            this.buttonDvider.TabIndex = 17;
            this.buttonDvider.Text = "/";
            this.buttonDvider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDvider.UseVisualStyleBackColor = false;
            this.buttonDvider.Click += new System.EventHandler(this.buttonDvider_Click);
            // 
            // buttonMultiply
            // 
            this.buttonMultiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonMultiply.Location = new System.Drawing.Point(225, 139);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.Size = new System.Drawing.Size(47, 35);
            this.buttonMultiply.TabIndex = 16;
            this.buttonMultiply.Text = "*";
            this.buttonMultiply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMultiply.UseVisualStyleBackColor = false;
            this.buttonMultiply.Click += new System.EventHandler(this.buttonMultiply_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonMinus.Location = new System.Drawing.Point(225, 98);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(47, 35);
            this.buttonMinus.TabIndex = 15;
            this.buttonMinus.Text = "-";
            this.buttonMinus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMinus.UseVisualStyleBackColor = false;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonPlus
            // 
            this.buttonPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonPlus.Location = new System.Drawing.Point(225, 57);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(47, 35);
            this.buttonPlus.TabIndex = 14;
            this.buttonPlus.Text = "+";
            this.buttonPlus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPlus.UseVisualStyleBackColor = false;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonClear.Location = new System.Drawing.Point(225, 16);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(47, 35);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button1Equal
            // 
            this.button1Equal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1Equal.Location = new System.Drawing.Point(172, 139);
            this.button1Equal.Name = "button1Equal";
            this.button1Equal.Size = new System.Drawing.Size(47, 35);
            this.button1Equal.TabIndex = 12;
            this.button1Equal.Text = "=";
            this.button1Equal.UseVisualStyleBackColor = false;
            this.button1Equal.Click += new System.EventHandler(this.ButtonEqual_Click);
            // 
            // buttonZero
            // 
            this.buttonZero.Location = new System.Drawing.Point(119, 139);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(47, 35);
            this.buttonZero.TabIndex = 11;
            this.buttonZero.Text = "0";
            this.buttonZero.UseVisualStyleBackColor = true;
            this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
            // 
            // buttonComma
            // 
            this.buttonComma.Location = new System.Drawing.Point(66, 139);
            this.buttonComma.Name = "buttonComma";
            this.buttonComma.Size = new System.Drawing.Size(47, 35);
            this.buttonComma.TabIndex = 10;
            this.buttonComma.Text = ",";
            this.buttonComma.UseVisualStyleBackColor = true;
            this.buttonComma.Click += new System.EventHandler(this.buttonComma_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(172, 98);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(47, 35);
            this.button9.TabIndex = 9;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(119, 98);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 35);
            this.button8.TabIndex = 8;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(66, 98);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 35);
            this.button7.TabIndex = 7;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.InputBox);
            this.groupBox2.Controls.Add(this.ansScreen);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 58);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(6, 19);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(315, 20);
            this.InputBox.TabIndex = 1;
            this.InputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.outputBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.outputBox.Location = new System.Drawing.Point(12, 286);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(329, 318);
            this.outputBox.TabIndex = 9;
            this.outputBox.Text = "//Console:";
            // 
            // buttonConsol
            // 
            this.buttonConsol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonConsol.Location = new System.Drawing.Point(13, 19);
            this.buttonConsol.Name = "buttonConsol";
            this.buttonConsol.Size = new System.Drawing.Size(47, 35);
            this.buttonConsol.TabIndex = 24;
            this.buttonConsol.Text = "Consol";
            this.buttonConsol.UseVisualStyleBackColor = false;
            this.buttonConsol.Click += new System.EventHandler(this.buttonConsol_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 613);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.button1_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ansScreen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1Equal;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.Button buttonComma;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMultiply;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button buttonCA;
        private System.Windows.Forms.Button buttonSQRT;
        private System.Windows.Forms.Button buttonSqr;
        private System.Windows.Forms.Button buttonRightParantheses;
        private System.Windows.Forms.Button buttonLeftParantheses;
        private System.Windows.Forms.Button buttonDvider;
        private System.Windows.Forms.Button buttonAns;
        protected System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button buttonConsol;
    }
}

