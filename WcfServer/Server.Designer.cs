namespace WcfServer
{
    partial class Server:IServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.btnStart = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.lsUsers = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.Machine = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyczyśćLogiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszLogiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnKick = new System.Windows.Forms.Button();
            this.btnBan = new System.Windows.Forms.Button();
            this.numH = new System.Windows.Forms.NumericUpDown();
            this.numS = new System.Windows.Forms.NumericUpDown();
            this.numM = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBanList = new System.Windows.Forms.ComboBox();
            this.btnUnBan = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(311, 48);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 41);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Location = new System.Drawing.Point(12, 48);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(280, 250);
            this.txtLog.TabIndex = 1;
            // 
            // txtMsg
            // 
            this.txtMsg.Enabled = false;
            this.txtMsg.Location = new System.Drawing.Point(12, 322);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(280, 20);
            this.txtMsg.TabIndex = 2;
            this.txtMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsg_KeyPress);
            // 
            // lsUsers
            // 
            this.lsUsers.FormattingEnabled = true;
            this.lsUsers.Location = new System.Drawing.Point(311, 112);
            this.lsUsers.Name = "lsUsers";
            this.lsUsers.Size = new System.Drawing.Size(94, 186);
            this.lsUsers.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(312, 321);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(93, 20);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Wyslij";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSlij_Click);
            // 
            // txtMachine
            // 
            this.txtMachine.Location = new System.Drawing.Point(16, 51);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(98, 20);
            this.txtMachine.TabIndex = 5;
            this.txtMachine.Text = "localhost";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(16, 95);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(98, 20);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "4477";
          
            // 
            // Machine
            // 
            this.Machine.AutoSize = true;
            this.Machine.Location = new System.Drawing.Point(31, 35);
            this.Machine.Name = "Machine";
            this.Machine.Size = new System.Drawing.Size(48, 13);
            this.Machine.TabIndex = 7;
            this.Machine.Text = "Machine";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Port";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Machine);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtMachine);
            this.groupBox1.Location = new System.Drawing.Point(411, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 137);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opcje Połączenia";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logiToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(646, 24);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(422, 325);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Enter Wysyła";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnKick
            // 
            this.btnKick.Location = new System.Drawing.Point(11, 18);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(57, 24);
            this.btnKick.TabIndex = 17;
            this.btnKick.Text = "Kick";
            this.btnKick.UseVisualStyleBackColor = true;
            this.btnKick.Click += new System.EventHandler(this.btnKick_Click);
            // 
            // btnBan
            // 
            this.btnBan.Location = new System.Drawing.Point(11, 48);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(57, 24);
            this.btnBan.TabIndex = 18;
            this.btnBan.Text = "Ban";
            this.btnBan.UseVisualStyleBackColor = true;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // numH
            // 
            this.numH.Location = new System.Drawing.Point(74, 52);
            this.numH.Name = "numH";
            this.numH.Size = new System.Drawing.Size(38, 20);
            this.numH.TabIndex = 19;
            // 
            // numS
            // 
            this.numS.Location = new System.Drawing.Point(161, 52);
            this.numS.Name = "numS";
            this.numS.Size = new System.Drawing.Size(38, 20);
            this.numS.TabIndex = 21;
            // 
            // numM
            // 
            this.numM.Location = new System.Drawing.Point(117, 52);
            this.numM.Name = "numM";
            this.numM.Size = new System.Drawing.Size(38, 20);
            this.numM.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "H";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Sek";
            // 
            // comboBanList
            // 
            this.comboBanList.FormattingEnabled = true;
            this.comboBanList.Location = new System.Drawing.Point(74, 81);
            this.comboBanList.Name = "comboBanList";
            this.comboBanList.Size = new System.Drawing.Size(125, 21);
            this.comboBanList.TabIndex = 26;
            // 
            // btnUnBan
            // 
            this.btnUnBan.Location = new System.Drawing.Point(11, 78);
            this.btnUnBan.Name = "btnUnBan";
            this.btnUnBan.Size = new System.Drawing.Size(57, 24);
            this.btnUnBan.TabIndex = 27;
            this.btnUnBan.Text = "UnBan";
            this.btnUnBan.UseVisualStyleBackColor = true;
            this.btnUnBan.Click += new System.EventHandler(this.btnUnBan_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUnBan);
            this.groupBox2.Controls.Add(this.comboBanList);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numM);
            this.groupBox2.Controls.Add(this.numS);
            this.groupBox2.Controls.Add(this.numH);
            this.groupBox2.Controls.Add(this.btnBan);
            this.groupBox2.Controls.Add(this.btnKick);
            this.groupBox2.Location = new System.Drawing.Point(411, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 107);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opcje Administratora";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 353);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lsUsers);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Server";
            this.Text = "WcfServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.ListBox lsUsers;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label Machine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyczyśćLogiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszLogiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacjeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.NumericUpDown numH;
        private System.Windows.Forms.NumericUpDown numS;
        private System.Windows.Forms.NumericUpDown numM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBanList;
        private System.Windows.Forms.Button btnUnBan;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

