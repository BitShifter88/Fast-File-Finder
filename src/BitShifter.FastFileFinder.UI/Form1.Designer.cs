namespace BitShifter.FastFileFinder.UI
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
            button1 = new Button();
            searchFor = new TextBox();
            button2 = new Button();
            groupBox1 = new GroupBox();
            button4 = new Button();
            searchButton = new Button();
            checkBox1 = new CheckBox();
            label3 = new Label();
            textBox3 = new TextBox();
            directory = new TextBox();
            label2 = new Label();
            label1 = new Label();
            searchResult = new RichTextBox();
            label4 = new Label();
            label5 = new Label();
            fileContent = new RichTextBox();
            label6 = new Label();
            status = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(662, 37);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // searchFor
            // 
            searchFor.Location = new Point(141, 22);
            searchFor.Name = "searchFor";
            searchFor.Size = new Size(481, 23);
            searchFor.TabIndex = 1;
            searchFor.Text = "public class";
            // 
            // button2
            // 
            button2.Location = new Point(662, 66);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(searchButton);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(directory);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(searchFor);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(628, 116);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search";
            // 
            // button4
            // 
            button4.Location = new Point(592, 50);
            button4.Name = "button4";
            button4.Size = new Size(30, 23);
            button4.TabIndex = 7;
            button4.Text = "...";
            button4.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(547, 82);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 6;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(141, 84);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(86, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Match case";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(233, 85);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 5;
            label3.Text = "Filename:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(297, 82);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(102, 23);
            textBox3.TabIndex = 4;
            textBox3.Text = "*.*";
            // 
            // directory
            // 
            directory.Location = new Point(141, 51);
            directory.Name = "directory";
            directory.Size = new Size(445, 23);
            directory.TabIndex = 3;
            directory.Text = "C:\\repos\\collapse";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Directory:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Search for:";
            // 
            // searchResult
            // 
            searchResult.Location = new Point(12, 185);
            searchResult.Name = "searchResult";
            searchResult.Size = new Size(1186, 275);
            searchResult.TabIndex = 4;
            searchResult.Text = "";
            searchResult.WordWrap = false;
            searchResult.Click += searchResult_Click;
            searchResult.TextChanged += searchResult_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 167);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 5;
            label4.Text = "Search Result:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 463);
            label5.Name = "label5";
            label5.Size = new Size(74, 15);
            label5.TabIndex = 6;
            label5.Text = "File Content:";
            // 
            // fileContent
            // 
            fileContent.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            fileContent.Location = new Point(12, 481);
            fileContent.Name = "fileContent";
            fileContent.Size = new Size(1186, 498);
            fileContent.TabIndex = 7;
            fileContent.Text = "";
            fileContent.WordWrap = false;
            fileContent.TextChanged += richTextBox2_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 140);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 8;
            label6.Text = "Status:";
            // 
            // status
            // 
            status.AutoSize = true;
            status.Location = new Point(60, 140);
            status.Name = "status";
            status.Size = new Size(34, 15);
            status.TabIndex = 9;
            status.Text = "none";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 991);
            Controls.Add(status);
            Controls.Add(label6);
            Controls.Add(fileContent);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(searchResult);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Click += Form1_Click;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox searchFor;
        private Button button2;
        private GroupBox groupBox1;
        private Label label1;
        private Button button4;
        private Button searchButton;
        private CheckBox checkBox1;
        private Label label3;
        private TextBox textBox3;
        private TextBox directory;
        private Label label2;
        private RichTextBox searchResult;
        private Label label4;
        private Label label5;
        private RichTextBox fileContent;
        private Label label6;
        private Label status;
    }
}