namespace WebLinkChecker
{
    partial class WebLinkCheckerUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebLinkCheckerUI));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkWindowsAuthentication = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApplicationName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkAutoSendEmailtoSupportTeam = new System.Windows.Forms.CheckBox();
            this.dgResult = new System.Windows.Forms.DataGridView();
            this.ColState = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColApplicationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWebLinkURL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColIsWindowsAuthentication = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 7200000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkWindowsAuthentication
            // 
            this.chkWindowsAuthentication.AutoSize = true;
            this.chkWindowsAuthentication.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWindowsAuthentication.Location = new System.Drawing.Point(9, 64);
            this.chkWindowsAuthentication.Name = "chkWindowsAuthentication";
            this.chkWindowsAuthentication.Size = new System.Drawing.Size(138, 16);
            this.chkWindowsAuthentication.TabIndex = 36;
            this.chkWindowsAuthentication.Text = "使用Windows集成认证";
            this.chkWindowsAuthentication.UseVisualStyleBackColor = true;
            this.chkWindowsAuthentication.CheckedChanged += new System.EventHandler(this.chkWindowsAuthentication_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 49;
            this.label5.Text = "应用程序名称";
            // 
            // txtApplicationName
            // 
            this.txtApplicationName.Location = new System.Drawing.Point(101, 35);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Size = new System.Drawing.Size(307, 21);
            this.txtApplicationName.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "域";
            // 
            // txtDomain
            // 
            this.txtDomain.Enabled = false;
            this.txtDomain.Location = new System.Drawing.Point(286, 62);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(122, 21);
            this.txtDomain.TabIndex = 37;
            this.txtDomain.Text = "domain";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "rdp";
            this.openFileDialog1.Filter = "Remote Desktop File (*.rdp)|*.rdp";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(779, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 101);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(509, 9);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 101);
            this.btnUpdate.TabIndex = 43;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ok.png");
            this.imageList1.Images.SetKeyName(1, "alert.png");
            this.imageList1.Images.SetKeyName(2, "error.png");
            this.imageList1.Images.SetKeyName(3, "wait.png");
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(689, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 101);
            this.btnRefresh.TabIndex = 45;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(599, 9);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(84, 101);
            this.btnRemove.TabIndex = 44;
            this.btnRemove.Text = "删除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkAutoSendEmailtoSupportTeam
            // 
            this.chkAutoSendEmailtoSupportTeam.AutoSize = true;
            this.chkAutoSendEmailtoSupportTeam.Location = new System.Drawing.Point(11, 120);
            this.chkAutoSendEmailtoSupportTeam.Name = "chkAutoSendEmailtoSupportTeam";
            this.chkAutoSendEmailtoSupportTeam.Size = new System.Drawing.Size(456, 16);
            this.chkAutoSendEmailtoSupportTeam.TabIndex = 50;
            this.chkAutoSendEmailtoSupportTeam.Text = "如果发现无法访问的Web链接，则每过2个小时发送一次通知邮件给软件维护工程师";
            this.chkAutoSendEmailtoSupportTeam.UseVisualStyleBackColor = true;
            this.chkAutoSendEmailtoSupportTeam.CheckedChanged += new System.EventHandler(this.chkAutoSendEmailtoSupportTeam_CheckedChanged);
            // 
            // dgResult
            // 
            this.dgResult.AllowUserToAddRows = false;
            this.dgResult.AllowUserToDeleteRows = false;
            this.dgResult.AllowUserToResizeRows = false;
            this.dgResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColState,
            this.ColApplicationName,
            this.ColWebLinkURL,
            this.ColIsWindowsAuthentication,
            this.ColDomain,
            this.ColUserName,
            this.ColPassword});
            this.dgResult.Location = new System.Drawing.Point(12, 142);
            this.dgResult.MultiSelect = false;
            this.dgResult.Name = "dgResult";
            this.dgResult.ReadOnly = true;
            this.dgResult.RowHeadersVisible = false;
            this.dgResult.RowTemplate.Height = 23;
            this.dgResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResult.Size = new System.Drawing.Size(851, 335);
            this.dgResult.TabIndex = 47;
            this.dgResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResult_CellContentClick);
            this.dgResult.SelectionChanged += new System.EventHandler(this.dgResult_SelectionChanged);
            // 
            // ColState
            // 
            this.ColState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColState.Frozen = true;
            this.ColState.HeaderText = "状态";
            this.ColState.Name = "ColState";
            this.ColState.ReadOnly = true;
            this.ColState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColState.Width = 42;
            // 
            // ColApplicationName
            // 
            this.ColApplicationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColApplicationName.Frozen = true;
            this.ColApplicationName.HeaderText = "应用名称";
            this.ColApplicationName.Name = "ColApplicationName";
            this.ColApplicationName.ReadOnly = true;
            this.ColApplicationName.Width = 78;
            // 
            // ColWebLinkURL
            // 
            this.ColWebLinkURL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColWebLinkURL.HeaderText = "Web链接URL";
            this.ColWebLinkURL.Name = "ColWebLinkURL";
            this.ColWebLinkURL.ReadOnly = true;
            this.ColWebLinkURL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColWebLinkURL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColWebLinkURL.Width = 90;
            // 
            // ColIsWindowsAuthentication
            // 
            this.ColIsWindowsAuthentication.HeaderText = "使用Windows集成认证";
            this.ColIsWindowsAuthentication.Name = "ColIsWindowsAuthentication";
            this.ColIsWindowsAuthentication.ReadOnly = true;
            this.ColIsWindowsAuthentication.Visible = false;
            // 
            // ColDomain
            // 
            this.ColDomain.HeaderText = "域";
            this.ColDomain.Name = "ColDomain";
            this.ColDomain.ReadOnly = true;
            this.ColDomain.Visible = false;
            // 
            // ColUserName
            // 
            this.ColUserName.HeaderText = "用户名";
            this.ColUserName.Name = "ColUserName";
            this.ColUserName.ReadOnly = true;
            this.ColUserName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColUserName.Visible = false;
            // 
            // ColPassword
            // 
            this.ColPassword.HeaderText = "密码";
            this.ColPassword.Name = "ColPassword";
            this.ColPassword.ReadOnly = true;
            this.ColPassword.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPassword.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPassword.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "密码";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(286, 89);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(122, 21);
            this.txtPassword.TabIndex = 40;
            this.txtPassword.Text = "password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "用户名";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(101, 89);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(122, 21);
            this.txtUserName.TabIndex = 38;
            this.txtUserName.Text = "username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "Web应用URL";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(419, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 101);
            this.btnAdd.TabIndex = 41;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(101, 9);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(307, 21);
            this.txtURL.TabIndex = 33;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "双击托盘图标还原检查工具！";
            this.notifyIcon1.BalloonTipTitle = "Web应用链接检查工具";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Web应用链接检查工具";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // WebLinkCheckerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 487);
            this.Controls.Add(this.chkWindowsAuthentication);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtApplicationName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.chkAutoSendEmailtoSupportTeam);
            this.Controls.Add(this.dgResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtURL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WebLinkCheckerUI";
            this.Text = "Web应用链接检查工具";
            this.SizeChanged += new System.EventHandler(this.WebLinkCheckerUI_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkWindowsAuthentication;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApplicationName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkAutoSendEmailtoSupportTeam;
        private System.Windows.Forms.DataGridView dgResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridViewImageColumn ColState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColApplicationName;
        private System.Windows.Forms.DataGridViewLinkColumn ColWebLinkURL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsWindowsAuthentication;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDomain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPassword;
    }
}

