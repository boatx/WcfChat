namespace WcfKlient
{
    partial class KlientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KlientForm));
            this.btnCon = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtWiad = new System.Windows.Forms.TextBox();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.Nickname = new System.Windows.Forms.Label();
            this.lsUsers = new System.Windows.Forms.ListBox();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyczyśćLogiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszLogiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chEnter = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCon
            // 
            this.btnCon.Location = new System.Drawing.Point(326, 44);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(96, 30);
            this.btnCon.TabIndex = 0;
            this.btnCon.Text = "Połącz";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(326, 308);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(97, 20);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Wyślij wiadomość";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Location = new System.Drawing.Point(24, 44);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(273, 244);
            this.txtLog.TabIndex = 2;
            // 
            // txtWiad
            // 
            this.txtWiad.Location = new System.Drawing.Point(24, 308);
            this.txtWiad.Name = "txtWiad";
            this.txtWiad.Size = new System.Drawing.Size(273, 20);
            this.txtWiad.TabIndex = 3;
            this.txtWiad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWiad_KeyPress);
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(327, 95);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(96, 20);
            this.txtNick.TabIndex = 4;
            // 
            // Nickname
            // 
            this.Nickname.AutoSize = true;
            this.Nickname.Location = new System.Drawing.Point(346, 77);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(55, 13);
            this.Nickname.TabIndex = 5;
            this.Nickname.Text = "Nickname";
            // 
            // lsUsers
            // 
            this.lsUsers.FormattingEnabled = true;
            this.lsUsers.Location = new System.Drawing.Point(327, 128);
            this.lsUsers.Name = "lsUsers";
            this.lsUsers.Size = new System.Drawing.Size(95, 160);
            this.lsUsers.TabIndex = 6;
            this.lsUsers.SelectedIndexChanged += new System.EventHandler(this.lsUsers_SelectedIndexChanged);
            // 
            // txtMachine
            // 
            this.txtMachine.Location = new System.Drawing.Point(10, 61);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(96, 20);
            this.txtMachine.TabIndex = 7;
            this.txtMachine.Text = "localhost";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(10, 125);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(45, 20);
            this.txtPort.TabIndex = 8;
            this.txtPort.Text = "4477";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Machine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(16, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "STATUS:";
            // 
            // lstatus
            // 
            this.lstatus.AutoSize = true;
            this.lstatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstatus.ForeColor = System.Drawing.Color.Red;
            this.lstatus.Location = new System.Drawing.Point(16, 195);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(71, 14);
            this.lstatus.TabIndex = 12;
            this.lstatus.Text = "niepołączony";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logiToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(593, 24);
            this.menuStrip1.TabIndex = 13;
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
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacjeToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pomocToolStripMenuItem.Text = "&Pomoc";
            // 
            // informacjeToolStripMenuItem
            // 
            this.informacjeToolStripMenuItem.Name = "informacjeToolStripMenuItem";
            this.informacjeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.informacjeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.informacjeToolStripMenuItem.Text = "&Informacje ";
            this.informacjeToolStripMenuItem.Click += new System.EventHandler(this.informacjeToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*;";
            this.saveFileDialog1.InitialDirectory = ".";
            this.saveFileDialog1.Title = "Zais logu do pliku";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtMachine);
            this.groupBox1.Location = new System.Drawing.Point(444, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 243);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opcje";
            // 
            // chEnter
            // 
            this.chEnter.AutoSize = true;
            this.chEnter.Checked = true;
            this.chEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chEnter.Location = new System.Drawing.Point(24, 334);
            this.chEnter.Name = "chEnter";
            this.chEnter.Size = new System.Drawing.Size(87, 17);
            this.chEnter.TabIndex = 15;
            this.chEnter.Text = "Enter wysyła";
            this.chEnter.UseVisualStyleBackColor = true;
            // 
            // KlientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(593, 362);
            this.Controls.Add(this.chEnter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsUsers);
            this.Controls.Add(this.Nickname);
            this.Controls.Add(this.txtNick);
            this.Controls.Add(this.txtWiad);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCon);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KlientForm";
            this.Text = "WcfKlient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KlientForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtWiad;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label Nickname;
        private System.Windows.Forms.ListBox lsUsers;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lstatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyczyśćLogiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszLogiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacjeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chEnter;
    }
}

