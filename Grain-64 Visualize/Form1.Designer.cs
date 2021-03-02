namespace Grain_64_Visualize
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Key = new System.Windows.Forms.TextBox();
            this.NFSR = new System.Windows.Forms.TextBox();
            this.LFSR = new System.Windows.Forms.TextBox();
            this.Key_label = new System.Windows.Forms.Label();
            this.LFSR_label = new System.Windows.Forms.Label();
            this.NFSR_label = new System.Windows.Forms.Label();
            this.Start_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Stop_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.KeyStreamTextBox = new System.Windows.Forms.TextBox();
            this.OpenTextbox = new System.Windows.Forms.TextBox();
            this.Keystream_label = new System.Windows.Forms.Label();
            this.OpenText_label = new System.Windows.Forms.Label();
            this.ChiperText_label = new System.Windows.Forms.Label();
            this.chiperTextBox = new System.Windows.Forms.TextBox();
            this.h_label = new System.Windows.Forms.Label();
            this.Step_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Key
            // 
            this.Key.Location = new System.Drawing.Point(58, 70);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(1040, 22);
            this.Key.TabIndex = 0;
            // 
            // NFSR
            // 
            this.NFSR.Location = new System.Drawing.Point(16, 150);
            this.NFSR.Name = "NFSR";
            this.NFSR.Size = new System.Drawing.Size(521, 22);
            this.NFSR.TabIndex = 1;
            // 
            // LFSR
            // 
            this.LFSR.Location = new System.Drawing.Point(576, 150);
            this.LFSR.Name = "LFSR";
            this.LFSR.Size = new System.Drawing.Size(521, 22);
            this.LFSR.TabIndex = 2;
            // 
            // Key_label
            // 
            this.Key_label.AutoSize = true;
            this.Key_label.Location = new System.Drawing.Point(12, 75);
            this.Key_label.Name = "Key_label";
            this.Key_label.Size = new System.Drawing.Size(40, 17);
            this.Key_label.TabIndex = 3;
            this.Key_label.Text = "Key: ";
            // 
            // LFSR_label
            // 
            this.LFSR_label.AutoSize = true;
            this.LFSR_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LFSR_label.Location = new System.Drawing.Point(818, 118);
            this.LFSR_label.Name = "LFSR_label";
            this.LFSR_label.Size = new System.Drawing.Size(74, 29);
            this.LFSR_label.TabIndex = 4;
            this.LFSR_label.Text = "LFSR";
            // 
            // NFSR_label
            // 
            this.NFSR_label.AutoSize = true;
            this.NFSR_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NFSR_label.Location = new System.Drawing.Point(241, 118);
            this.NFSR_label.Name = "NFSR_label";
            this.NFSR_label.Size = new System.Drawing.Size(79, 29);
            this.NFSR_label.TabIndex = 5;
            this.NFSR_label.Text = "NSFR";
            // 
            // Start_button
            // 
            this.Start_button.BackColor = System.Drawing.Color.Lime;
            this.Start_button.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_button.Location = new System.Drawing.Point(420, 430);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(75, 39);
            this.Start_button.TabIndex = 6;
            this.Start_button.Text = "Start";
            this.Start_button.UseVisualStyleBackColor = false;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Iteration: ";
            // 
            // Stop_button
            // 
            this.Stop_button.BackColor = System.Drawing.Color.Red;
            this.Stop_button.Enabled = false;
            this.Stop_button.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stop_button.Location = new System.Drawing.Point(514, 430);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(80, 39);
            this.Stop_button.TabIndex = 8;
            this.Stop_button.Text = "Stop";
            this.Stop_button.UseVisualStyleBackColor = false;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "|*.key;";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1109, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyOpenToolStripMenuItem,
            this.fileOpenToolStripMenuItem1});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // keyOpenToolStripMenuItem
            // 
            this.keyOpenToolStripMenuItem.Name = "keyOpenToolStripMenuItem";
            this.keyOpenToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.keyOpenToolStripMenuItem.Text = "Key";
            this.keyOpenToolStripMenuItem.Click += new System.EventHandler(this.KeyOpenToolStripMenuItem_Click);
            // 
            // fileOpenToolStripMenuItem1
            // 
            this.fileOpenToolStripMenuItem1.Name = "fileOpenToolStripMenuItem1";
            this.fileOpenToolStripMenuItem1.Size = new System.Drawing.Size(116, 26);
            this.fileOpenToolStripMenuItem1.Text = "File";
            this.fileOpenToolStripMenuItem1.Click += new System.EventHandler(this.FileToolStripMenuItem1_ClickAsync);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "|*.txt";
            // 
            // KeyStreamTextBox
            // 
            this.KeyStreamTextBox.Location = new System.Drawing.Point(101, 272);
            this.KeyStreamTextBox.Name = "KeyStreamTextBox";
            this.KeyStreamTextBox.Size = new System.Drawing.Size(996, 22);
            this.KeyStreamTextBox.TabIndex = 10;
            // 
            // OpenTextbox
            // 
            this.OpenTextbox.Location = new System.Drawing.Point(101, 318);
            this.OpenTextbox.Name = "OpenTextbox";
            this.OpenTextbox.Size = new System.Drawing.Size(997, 22);
            this.OpenTextbox.TabIndex = 11;
            // 
            // Keystream_label
            // 
            this.Keystream_label.AutoSize = true;
            this.Keystream_label.Location = new System.Drawing.Point(12, 275);
            this.Keystream_label.Name = "Keystream_label";
            this.Keystream_label.Size = new System.Drawing.Size(83, 17);
            this.Keystream_label.TabIndex = 12;
            this.Keystream_label.Text = "Keystream: ";
            // 
            // OpenText_label
            // 
            this.OpenText_label.AutoSize = true;
            this.OpenText_label.Location = new System.Drawing.Point(13, 323);
            this.OpenText_label.Name = "OpenText_label";
            this.OpenText_label.Size = new System.Drawing.Size(77, 17);
            this.OpenText_label.TabIndex = 14;
            this.OpenText_label.Text = "Open text: ";
            // 
            // ChiperText_label
            // 
            this.ChiperText_label.AutoSize = true;
            this.ChiperText_label.Location = new System.Drawing.Point(13, 374);
            this.ChiperText_label.Name = "ChiperText_label";
            this.ChiperText_label.Size = new System.Drawing.Size(83, 17);
            this.ChiperText_label.TabIndex = 15;
            this.ChiperText_label.Text = "Chiper text: ";
            // 
            // chiperTextBox
            // 
            this.chiperTextBox.Location = new System.Drawing.Point(101, 371);
            this.chiperTextBox.Name = "chiperTextBox";
            this.chiperTextBox.Size = new System.Drawing.Size(996, 22);
            this.chiperTextBox.TabIndex = 16;
            // 
            // h_label
            // 
            this.h_label.AutoSize = true;
            this.h_label.Location = new System.Drawing.Point(534, 220);
            this.h_label.Name = "h_label";
            this.h_label.Size = new System.Drawing.Size(45, 17);
            this.h_label.TabIndex = 17;
            this.h_label.Text = "h(i) = ";
            // 
            // Step_button
            // 
            this.Step_button.BackColor = System.Drawing.Color.Aqua;
            this.Step_button.Enabled = false;
            this.Step_button.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step_button.Location = new System.Drawing.Point(613, 430);
            this.Step_button.Name = "Step_button";
            this.Step_button.Size = new System.Drawing.Size(80, 39);
            this.Step_button.TabIndex = 18;
            this.Step_button.Text = "Step";
            this.Step_button.UseVisualStyleBackColor = false;
            this.Step_button.Click += new System.EventHandler(this.Step_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 481);
            this.Controls.Add(this.Step_button);
            this.Controls.Add(this.h_label);
            this.Controls.Add(this.chiperTextBox);
            this.Controls.Add(this.ChiperText_label);
            this.Controls.Add(this.OpenText_label);
            this.Controls.Add(this.Keystream_label);
            this.Controls.Add(this.OpenTextbox);
            this.Controls.Add(this.KeyStreamTextBox);
            this.Controls.Add(this.Stop_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start_button);
            this.Controls.Add(this.NFSR_label);
            this.Controls.Add(this.LFSR_label);
            this.Controls.Add(this.Key_label);
            this.Controls.Add(this.LFSR);
            this.Controls.Add(this.NFSR);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Grain-64";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Key;
        private System.Windows.Forms.TextBox NFSR;
        private System.Windows.Forms.TextBox LFSR;
        private System.Windows.Forms.Label Key_label;
        private System.Windows.Forms.Label LFSR_label;
        private System.Windows.Forms.Label NFSR_label;
        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Stop_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyOpenToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem fileOpenToolStripMenuItem1;
        private System.Windows.Forms.TextBox KeyStreamTextBox;
        private System.Windows.Forms.TextBox OpenTextbox;
        private System.Windows.Forms.Label Keystream_label;
        private System.Windows.Forms.Label OpenText_label;
        private System.Windows.Forms.Label ChiperText_label;
        private System.Windows.Forms.TextBox chiperTextBox;
        private System.Windows.Forms.Label h_label;
        private System.Windows.Forms.Button Step_button;
    }
}

