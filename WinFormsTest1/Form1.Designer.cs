namespace WinFormsTest1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(431, 137);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(226, 43);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(431, 66);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(226, 43);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 143);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(128, 37);
            label1.TabIndex = 2;
            label1.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(260, 72);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(148, 37);
            label2.TabIndex = 3;
            label2.Text = "User Name";
            // 
            // button1
            // 
            button1.Location = new Point(701, 127);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(169, 53);
            button1.TabIndex = 4;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(324, 309);
            label3.Name = "label3";
            label3.Size = new Size(84, 37);
            label3.TabIndex = 5;
            label3.Text = "coinA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(326, 398);
            label4.Name = "label4";
            label4.Size = new Size(82, 37);
            label4.TabIndex = 6;
            label4.Text = "coinB";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(324, 491);
            label5.Name = "label5";
            label5.Size = new Size(84, 37);
            label5.TabIndex = 7;
            label5.Text = "coinC";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(322, 579);
            label6.Name = "label6";
            label6.Size = new Size(86, 37);
            label6.TabIndex = 8;
            label6.Text = "coinD";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(327, 664);
            label7.Name = "label7";
            label7.Size = new Size(81, 37);
            label7.TabIndex = 9;
            label7.Text = "coinE";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(328, 752);
            label8.Name = "label8";
            label8.Size = new Size(80, 37);
            label8.TabIndex = 10;
            label8.Text = "coinF";
            // 
            // button2
            // 
            button2.Location = new Point(32, 294);
            button2.Name = "button2";
            button2.Size = new Size(169, 52);
            button2.TabIndex = 11;
            button2.Text = "Home";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(32, 383);
            button3.Name = "button3";
            button3.Size = new Size(169, 52);
            button3.TabIndex = 12;
            button3.Text = "Portfolio";
            button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(945, 883);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button2;
        private Button button3;
    }
}