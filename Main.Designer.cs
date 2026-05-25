namespace ООП_курсач_новый
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.животныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учётЖивотныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.коровыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свиньиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.курыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прививкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.пользователиToolStripMenuItem,
            this.животныеToolStripMenuItem,
            this.учётЖивотныхToolStripMenuItem,
            this.прививкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(700, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // пользователиToolStripMenuItem
            // 
            this.пользователиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактироватьToolStripMenuItem});
            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            this.пользователиToolStripMenuItem.Visible = false;
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // животныеToolStripMenuItem
            // 
            this.животныеToolStripMenuItem.Name = "животныеToolStripMenuItem";
            this.животныеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.животныеToolStripMenuItem.Text = "Животные";
            this.животныеToolStripMenuItem.Visible = false;
            this.животныеToolStripMenuItem.Click += new System.EventHandler(this.животныеToolStripMenuItem_Click);
            // 
            // учётЖивотныхToolStripMenuItem
            // 
            this.учётЖивотныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.коровыToolStripMenuItem,
            this.свиньиToolStripMenuItem,
            this.курыToolStripMenuItem});
            this.учётЖивотныхToolStripMenuItem.Name = "учётЖивотныхToolStripMenuItem";
            this.учётЖивотныхToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.учётЖивотныхToolStripMenuItem.Text = "Учёт животных";
            this.учётЖивотныхToolStripMenuItem.Visible = false;
            // 
            // коровыToolStripMenuItem
            // 
            this.коровыToolStripMenuItem.Name = "коровыToolStripMenuItem";
            this.коровыToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.коровыToolStripMenuItem.Text = "Коровы";
            this.коровыToolStripMenuItem.Click += new System.EventHandler(this.коровыToolStripMenuItem_Click);
            // 
            // свиньиToolStripMenuItem
            // 
            this.свиньиToolStripMenuItem.Name = "свиньиToolStripMenuItem";
            this.свиньиToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.свиньиToolStripMenuItem.Text = "Свиньи";
            this.свиньиToolStripMenuItem.Click += new System.EventHandler(this.свиньиToolStripMenuItem_Click);
            // 
            // курыToolStripMenuItem
            // 
            this.курыToolStripMenuItem.Name = "курыToolStripMenuItem";
            this.курыToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.курыToolStripMenuItem.Text = "Куры";
            this.курыToolStripMenuItem.Click += new System.EventHandler(this.курыToolStripMenuItem_Click);
            // 
            // прививкиToolStripMenuItem
            // 
            this.прививкиToolStripMenuItem.Name = "прививкиToolStripMenuItem";
            this.прививкиToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.прививкиToolStripMenuItem.Text = "Прививки";
            this.прививкиToolStripMenuItem.Visible = false;
            this.прививкиToolStripMenuItem.Click += new System.EventHandler(this.прививкиToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Visible = false;
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1190, 524);
            this.listBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(683, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Сортировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "По номеру",
            "По названию(алфавиту)",
            "По предстоящей прививки"});
            this.comboBox1.Location = new System.Drawing.Point(810, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(174, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 617);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учётЖивотныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem коровыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свиньиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem курыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прививкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem животныеToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
    }
}