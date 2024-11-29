namespace TestWindMouse
{
    partial class Form1
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
            textBox_X_Cur = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox_Y_Cur = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBox_Y_New = new TextBox();
            label6 = new Label();
            textBox_X_New = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox_X_Cur
            // 
            textBox_X_Cur.Location = new Point(169, 11);
            textBox_X_Cur.MaxLength = 8;
            textBox_X_Cur.Name = "textBox_X_Cur";
            textBox_X_Cur.ReadOnly = true;
            textBox_X_Cur.Size = new Size(100, 23);
            textBox_X_Cur.TabIndex = 0;
            textBox_X_Cur.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 1;
            label1.Text = "Current coords:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 14);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 2;
            label2.Text = "X:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 14);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 4;
            label3.Text = "Y:";
            // 
            // textBox_Y_Cur
            // 
            textBox_Y_Cur.Location = new Point(312, 11);
            textBox_Y_Cur.MaxLength = 8;
            textBox_Y_Cur.Name = "textBox_Y_Cur";
            textBox_Y_Cur.ReadOnly = true;
            textBox_Y_Cur.Size = new Size(100, 23);
            textBox_Y_Cur.TabIndex = 3;
            textBox_Y_Cur.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 53);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 5;
            label4.Text = "New coords:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(289, 53);
            label5.Name = "label5";
            label5.Size = new Size(17, 15);
            label5.TabIndex = 9;
            label5.Text = "Y:";
            // 
            // textBox_Y_New
            // 
            textBox_Y_New.Location = new Point(312, 50);
            textBox_Y_New.MaxLength = 8;
            textBox_Y_New.Name = "textBox_Y_New";
            textBox_Y_New.Size = new Size(100, 23);
            textBox_Y_New.TabIndex = 8;
            textBox_Y_New.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(146, 53);
            label6.Name = "label6";
            label6.Size = new Size(17, 15);
            label6.TabIndex = 7;
            label6.Text = "X:";
            // 
            // textBox_X_New
            // 
            textBox_X_New.Location = new Point(169, 50);
            textBox_X_New.MaxLength = 8;
            textBox_X_New.Name = "textBox_X_New";
            textBox_X_New.Size = new Size(100, 23);
            textBox_X_New.TabIndex = 6;
            textBox_X_New.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(312, 89);
            button1.Name = "button1";
            button1.Size = new Size(100, 29);
            button1.TabIndex = 10;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 162);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(textBox_Y_New);
            Controls.Add(label6);
            Controls.Add(textBox_X_New);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox_Y_Cur);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_X_Cur);
            Name = "Form1";
            Text = "WindMouse";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_X_Cur;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox_Y_Cur;
        private Label label4;
        private Label label5;
        private TextBox textBox_Y_New;
        private Label label6;
        private TextBox textBox_X_New;
        private Button button1;
    }
}
