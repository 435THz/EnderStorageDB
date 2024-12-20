namespace EnderStorageDB
{
    partial class DatabaseUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseUI));
            this.ColorBox1 = new System.Windows.Forms.ComboBox();
            this.ColorBox2 = new System.Windows.Forms.ComboBox();
            this.ColorBox3 = new System.Windows.Forms.ComboBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPageChest = new System.Windows.Forms.TabPage();
            this.TabPageTank = new System.Windows.Forms.TabPage();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorComboName = new System.Windows.Forms.ComboBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ContextMenuColors = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ColorListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.ContextMenuColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColorBox1
            // 
            this.ColorBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorBox1.Location = new System.Drawing.Point(30, 41);
            this.ColorBox1.Name = "ColorBox1";
            this.ColorBox1.Size = new System.Drawing.Size(90, 21);
            this.ColorBox1.TabIndex = 1;
            this.ColorBox1.SelectionChangeCommitted += new System.EventHandler(this.ColorComboChanged);
            this.ColorBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorBox1_MouseClick);
            // 
            // ColorBox2
            // 
            this.ColorBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorBox2.FormattingEnabled = true;
            this.ColorBox2.Location = new System.Drawing.Point(126, 41);
            this.ColorBox2.Name = "ColorBox2";
            this.ColorBox2.Size = new System.Drawing.Size(90, 21);
            this.ColorBox2.TabIndex = 2;
            this.ColorBox2.SelectionChangeCommitted += new System.EventHandler(this.ColorComboChanged);
            this.ColorBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorBox2_MouseClick);
            // 
            // ColorBox3
            // 
            this.ColorBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorBox3.FormattingEnabled = true;
            this.ColorBox3.Location = new System.Drawing.Point(222, 41);
            this.ColorBox3.Name = "ColorBox3";
            this.ColorBox3.Size = new System.Drawing.Size(90, 21);
            this.ColorBox3.TabIndex = 3;
            this.ColorBox3.SelectionChangeCommitted += new System.EventHandler(this.ColorComboChanged);
            this.ColorBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorBox3_MouseClick);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPageChest);
            this.TabControl.Controls.Add(this.TabPageTank);
            this.TabControl.Location = new System.Drawing.Point(12, 8);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(338, 18);
            this.TabControl.TabIndex = 0;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.ColorComboChanged);
            // 
            // TabPageChest
            // 
            this.TabPageChest.Location = new System.Drawing.Point(4, 22);
            this.TabPageChest.Name = "TabPageChest";
            this.TabPageChest.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageChest.Size = new System.Drawing.Size(330, 0);
            this.TabPageChest.TabIndex = 0;
            this.TabPageChest.Text = "Chests";
            this.TabPageChest.UseVisualStyleBackColor = true;
            // 
            // TabPageTank
            // 
            this.TabPageTank.Location = new System.Drawing.Point(4, 22);
            this.TabPageTank.Name = "TabPageTank";
            this.TabPageTank.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageTank.Size = new System.Drawing.Size(330, 0);
            this.TabPageTank.TabIndex = 1;
            this.TabPageTank.Text = "Tanks";
            this.TabPageTank.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.ColorComboName);
            this.groupBox.Controls.Add(this.ColorBox3);
            this.groupBox.Controls.Add(this.ColorBox2);
            this.groupBox.Controls.Add(this.ColorBox1);
            this.groupBox.Location = new System.Drawing.Point(12, 20);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(338, 136);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Color Code";
            // 
            // ColorComboName
            // 
            this.ColorComboName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorComboName.FormattingEnabled = true;
            this.ColorComboName.Location = new System.Drawing.Point(30, 97);
            this.ColorComboName.Name = "ColorComboName";
            this.ColorComboName.Size = new System.Drawing.Size(282, 21);
            this.ColorComboName.TabIndex = 4;
            this.ColorComboName.DropDown += new System.EventHandler(this.ColorComboName_DropDown);
            this.ColorComboName.SelectionChangeCommitted += new System.EventHandler(this.ColorComboName_SelectionChanged);
            this.ColorComboName.TextUpdate += new System.EventHandler(this.ColorComboName_TextChanged);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(249, 162);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 23);
            this.OpenFileButton.TabIndex = 5;
            this.OpenFileButton.Text = "Open File";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(42, 162);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ContextMenuColors
            // 
            this.ContextMenuColors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorListMenuItem});
            this.ContextMenuColors.Name = "ContextMenuColors";
            this.ContextMenuColors.Size = new System.Drawing.Size(132, 26);
            // 
            // ColorListMenuItem
            // 
            this.ColorListMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ColorListMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NoneToolStripMenuItem});
            this.ColorListMenuItem.Name = "ColorListMenuItem";
            this.ColorListMenuItem.Size = new System.Drawing.Size(131, 22);
            this.ColorListMenuItem.Text = "Free colors";
            // 
            // NoneToolStripMenuItem
            // 
            this.NoneToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NoneToolStripMenuItem.Enabled = false;
            this.NoneToolStripMenuItem.Name = "NoneToolStripMenuItem";
            this.NoneToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.NoneToolStripMenuItem.Text = "(None)";
            // 
            // DatabaseUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 197);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DatabaseUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ender Storage DB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseUI_FormClosing);
            this.Shown += new System.EventHandler(this.DatabaseUI_Shown);
            this.TabControl.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ContextMenuColors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ColorBox1;
        private System.Windows.Forms.ComboBox ColorBox2;
        private System.Windows.Forms.ComboBox ColorBox3;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPageChest;
        private System.Windows.Forms.TabPage TabPageTank;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ColorComboName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ContextMenuStrip ContextMenuColors;
        private System.Windows.Forms.ToolStripMenuItem ColorListMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NoneToolStripMenuItem;
    }
}

