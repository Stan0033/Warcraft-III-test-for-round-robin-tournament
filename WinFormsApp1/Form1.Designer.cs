namespace WinFormsApp1
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
            listBox1 = new ListBox();
            button1 = new Button();
            Display = new Label();
            button2 = new Button();
            checkedListBox1 = new CheckedListBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            groupBox1 = new GroupBox();
            checkbox_Shuffle = new CheckBox();
            checkbox_maxPlayers = new CheckBox();
            button3 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Location = new Point(6, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(442, 613);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(474, 508);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Display
            // 
            Display.AutoSize = true;
            Display.Location = new Point(6, 48);
            Display.Name = "Display";
            Display.Size = new Size(12, 15);
            Display.TabIndex = 6;
            Display.Text = "_";
            // 
            // button2
            // 
            button2.Location = new Point(52, 21);
            button2.Name = "button2";
            button2.Size = new Size(98, 23);
            button2.TabIndex = 7;
            button2.Text = "Calc";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(454, 46);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(328, 454);
            checkedListBox1.TabIndex = 8;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(470, 25);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 9;
            label2.Text = "Playing";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "17", "19", "20", "21", "22", "23", "24" });
            comboBox2.Location = new Point(6, 22);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(40, 23);
            comboBox2.TabIndex = 10;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(Display);
            groupBox1.Location = new Point(470, 541);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 142);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Calculate potential";
            // 
            // checkbox_Shuffle
            // 
            checkbox_Shuffle.AutoSize = true;
            checkbox_Shuffle.Location = new Point(555, 510);
            checkbox_Shuffle.Name = "checkbox_Shuffle";
            checkbox_Shuffle.Size = new Size(63, 19);
            checkbox_Shuffle.TabIndex = 11;
            checkbox_Shuffle.Text = "Shuffle";
            checkbox_Shuffle.UseVisualStyleBackColor = true;
            // 
            // checkbox_maxPlayers
            // 
            checkbox_maxPlayers.AutoSize = true;
            checkbox_maxPlayers.Location = new Point(624, 510);
            checkbox_maxPlayers.Name = "checkbox_maxPlayers";
            checkbox_maxPlayers.Size = new Size(74, 19);
            checkbox_maxPlayers.TabIndex = 12;
            checkbox_maxPlayers.Text = "Reforged";
            checkbox_maxPlayers.UseVisualStyleBackColor = true;
            checkbox_maxPlayers.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // button3
            // 
            button3.Location = new Point(373, 631);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 13;
            button3.Text = "Copy";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 682);
            Controls.Add(button3);
            Controls.Add(checkbox_maxPlayers);
            Controls.Add(checkbox_Shuffle);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(checkedListBox1);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Round-robin tournament generator for Warcraft III in C#";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private Label Display;
        private Button button2;
        private CheckedListBox checkedListBox1;
        private Label label2;
        private ComboBox comboBox2;
        private GroupBox groupBox1;
        private CheckBox checkbox_Shuffle;
        private CheckBox checkbox_maxPlayers;
        private Button button3;
    }
}