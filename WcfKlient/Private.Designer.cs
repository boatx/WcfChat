namespace WcfKlient
{
    partial class Private
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Private));
            this.txtPrvLog = new System.Windows.Forms.TextBox();
            this.txtPrvMsg = new System.Windows.Forms.TextBox();
            this.btnPrvSend = new System.Windows.Forms.Button();
            this.chEnter = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyczyśćLogiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszLogiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrvLog
            // 
            this.txtPrvLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrvLog.Location = new System.Drawing.Point(16, 39);
            this.txtPrvLog.Multiline = true;
            this.txtPrvLog.Name = "txtPrvLog";
            this.txtPrvLog.ReadOnly = true;
            this.txtPrvLog.Size = new System.Drawing.Size(247, 181);
            this.txtPrvLog.TabIndex = 0;
            // 
            // txtPrvMsg
            // 
            this.txtPrvMsg.Location = new System.Drawing.Point(16, 238);
            this.txtPrvMsg.Name = "txtPrvMsg";
            this.txtPrvMsg.Size = new System.Drawing.Size(247, 20);
            this.txtPrvMsg.TabIndex = 1;
            this.txtPrvMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrvMsg_KeyPress);
            // 
            // btnPrvSend
            // 
            this.btnPrvSend.Location = new System.Drawing.Point(269, 238);
            this.btnPrvSend.Name = "btnPrvSend";
            this.btnPrvSend.Size = new System.Drawing.Size(51, 22);
            this.btnPrvSend.TabIndex = 2;
            this.btnPrvSend.Text = "Send";
            this.btnPrvSend.UseVisualStyleBackColor = true;
            this.btnPrvSend.Click += new System.EventHandler(this.btnPrvSend_Click);
            // 
            // chEnter
            // 
            this.chEnter.AutoSize = true;
            this.chEnter.Checked = true;
            this.chEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chEnter.Location = new System.Drawing.Point(16, 269);
            this.chEnter.Name = "chEnter";
            this.chEnter.Size = new System.Drawing.Size(87, 17);
            this.chEnter.TabIndex = 3;
            this.chEnter.Text = "Enter wysyła";
            this.chEnter.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(395, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logiToolStripMenuItem
            // 
            this.logiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyczyśćLogiToolStripMenuItem,
            this.zapiszLogiToolStripMenuItem});
            this.logiToolStripMenuItem.Name = "logiToolStripMenuItem";
            this.logiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.logiToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.logiToolStripMenuItem.Text = "&Logi";
            // 
            // wyczyśćLogiToolStripMenuItem
            // 
            this.wyczyśćLogiToolStripMenuItem.Name = "wyczyśćLogiToolStripMenuItem";
            this.wyczyśćLogiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.wyczyśćLogiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wyczyśćLogiToolStripMenuItem.Text = "&Wyczyść Logi";
            this.wyczyśćLogiToolStripMenuItem.Click += new System.EventHandler(this.wyczyśćLogiToolStripMenuItem_Click);
            // 
            // zapiszLogiToolStripMenuItem
            // 
            this.zapiszLogiToolStripMenuItem.Name = "zapiszLogiToolStripMenuItem";
            this.zapiszLogiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.zapiszLogiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zapiszLogiToolStripMenuItem.Text = "&Zapisz Logi";
            this.zapiszLogiToolStripMenuItem.Click += new System.EventHandler(this.zapiszLogiToolStripMenuItem_Click);
            // 
            // saveFile
            // 
            this.saveFile.DefaultExt = "txt";
            this.saveFile.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*;";
            this.saveFile.InitialDirectory = ".";
            this.saveFile.Title = "Zais logu do pliku";
            // 
            // Private
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 298);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.chEnter);
            this.Controls.Add(this.btnPrvSend);
            this.Controls.Add(this.txtPrvMsg);
            this.Controls.Add(this.txtPrvLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Private";
            this.Text = "Rozmowa Prywatna";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Private_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrvLog;
        private System.Windows.Forms.TextBox txtPrvMsg;
        private System.Windows.Forms.Button btnPrvSend;
        private System.Windows.Forms.CheckBox chEnter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyczyśćLogiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszLogiToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}