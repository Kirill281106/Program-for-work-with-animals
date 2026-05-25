namespace ООП_курсач_новый
{
    partial class EditUsers
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
            this.Add = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.ESC = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.GroupUserBox = new System.Windows.Forms.FlowLayoutPanel();
            this.GroupUserBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(617, 47);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(131, 53);
            this.Add.TabIndex = 0;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(617, 147);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(131, 53);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Изменить";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(617, 247);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(131, 53);
            this.delete.TabIndex = 2;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // ESC
            // 
            this.ESC.Location = new System.Drawing.Point(12, 12);
            this.ESC.Name = "ESC";
            this.ESC.Size = new System.Drawing.Size(51, 27);
            this.ESC.TabIndex = 3;
            this.ESC.Text = "esc";
            this.ESC.UseVisualStyleBackColor = true;
            this.ESC.Click += new System.EventHandler(this.ESC_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(55, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(527, 238);
            this.listBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Login пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password пользователя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Роль пользователя";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Подтвердить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "admin",
            "user"});
            this.comboBox1.Location = new System.Drawing.Point(3, 94);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 20);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(149, 20);
            this.textBox2.TabIndex = 11;
            // 
            // GroupUserBox
            // 
            this.GroupUserBox.Controls.Add(this.label1);
            this.GroupUserBox.Controls.Add(this.textBox1);
            this.GroupUserBox.Controls.Add(this.label2);
            this.GroupUserBox.Controls.Add(this.textBox2);
            this.GroupUserBox.Controls.Add(this.label3);
            this.GroupUserBox.Controls.Add(this.comboBox1);
            this.GroupUserBox.Controls.Add(this.button1);
            this.GroupUserBox.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.GroupUserBox.Location = new System.Drawing.Point(49, 305);
            this.GroupUserBox.Name = "GroupUserBox";
            this.GroupUserBox.Size = new System.Drawing.Size(175, 164);
            this.GroupUserBox.TabIndex = 13;
            this.GroupUserBox.Visible = false;
            // 
            // EditUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 496);
            this.Controls.Add(this.GroupUserBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ESC);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Add);
            this.Name = "EditUsers";
            this.Text = "EditUsers";
            this.GroupUserBox.ResumeLayout(false);
            this.GroupUserBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button ESC;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.FlowLayoutPanel GroupUserBox;
    }
}