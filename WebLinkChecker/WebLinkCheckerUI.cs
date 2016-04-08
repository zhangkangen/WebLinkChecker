using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace WebLinkChecker
{
    public partial class WebLinkCheckerUI : Form
    {
        private List<WebLinkConfigurationData> _configurations = new List<WebLinkConfigurationData>();
        private readonly string WEB_PAGE_CONFIGURATION_DATA_FILE_NAME = "WebLinkConfiguration.xml";
        private string body;
        private int cntLink;
        private int iLink = 0;

        public WebLinkCheckerUI()
        {
            InitializeComponent();

            LoadWebLinkConfigurationData();
            RefreshAllWebLinkCheckers();
        }

        private void chkWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            txtDomain.Enabled = chkWindowsAuthentication.Checked;
            txtUserName.Enabled = chkWindowsAuthentication.Checked;
            txtPassword.Enabled = chkWindowsAuthentication.Checked;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtURL.Text))
            {
                MessageBox.Show("请填写应用链接URL！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtURL.Focus();
                return;
            }
            else
            {
                if (FindRow(txtURL.Text) != null)
                {
                    MessageBox.Show("Web应用链接URL“" + txtURL.Text + "”已经存在于列表中，请指定的一个新的应用链接。", "输入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtURL.Focus();
                    return;
                }
            }
            if (string.IsNullOrEmpty(txtApplicationName.Text))
            {
                MessageBox.Show("请填写应用名称！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApplicationName.Focus();
                return;
            }
            if (chkWindowsAuthentication.Checked)
            {
                if (string.IsNullOrEmpty(txtDomain.Text))
                {
                    MessageBox.Show("请填写应用所在的域名！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDomain.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("请填写用户名！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUserName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("请填写密码！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Focus();
                    return;
                }
            }

            DataGridViewRow newRow = AddNewWebLinkChecker(new WebLinkConfigurationData()
            {
                ApplicationName = txtApplicationName.Text,
                WebLinkURL = txtURL.Text,
                IsWindowsAuthentication = chkWindowsAuthentication.Checked,
                Domain = txtDomain.Text,
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            });
            newRow.Selected = true;
            UpdateInputFromCurrentRow();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要被移除的Web应用链接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("确认移除当前选择的Web应用链接?", "移除链接", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                RemoveWebLinkChecker(dgResult.SelectedRows[0]);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAllWebLinkCheckers();
        }

        private void dgResult_SelectionChanged(object sender, EventArgs e)
        {
            UpdateInputFromCurrentRow();
        }

        private void dgResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dgResult.Columns[e.ColumnIndex].Name == "ColWebLinkURL")
                Process.Start(dgResult[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要被更新的Web应用链接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtURL.Text))
            {
                MessageBox.Show("请填写应用链接URL！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtURL.Focus();
                return;
            }
            else
            {
                DataGridViewRow row = FindRow(txtURL.Text);
                if (row != null && dgResult.SelectedRows[0] != row)
                {
                    MessageBox.Show("Web应用链接URL“" + txtURL.Text + "”已经存在于列表中，请指定的一个新的应用链接。", "输入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtURL.Focus();
                    return;
                }
            }
            if (string.IsNullOrEmpty(txtApplicationName.Text))
            {
                MessageBox.Show("请填写应用名称！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApplicationName.Focus();
                return;
            }
            if (chkWindowsAuthentication.Checked)
            {
                if (string.IsNullOrEmpty(txtDomain.Text))
                {
                    MessageBox.Show("请填写应用所在的域名！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDomain.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("请填写用户名！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUserName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("请填写密码！", "输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Focus();
                    return;
                }
            }

            UpdateWebLinkChecker(dgResult.SelectedRows[0], new WebLinkConfigurationData()
            {
                ApplicationName = txtApplicationName.Text,
                WebLinkURL = txtURL.Text,
                IsWindowsAuthentication = chkWindowsAuthentication.Checked,
                Domain = txtDomain.Text,
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveWebLinkConfigurationData();
        }

        private void WebLinkCheckerUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled)
            {
                DialogResult dialogResult = MessageBox.Show("您的部分改动没有被保存。\r\n\r\n单击“是”保存并退出，单击“否”取消并退出。", "关闭程序", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        SaveWebLinkConfigurationData();
                        e.Cancel = false;
                        break;

                    case DialogResult.No:
                        e.Cancel = false;
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void LoadWebLinkConfigurationData()
        {
            string filePath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, WEB_PAGE_CONFIGURATION_DATA_FILE_NAME);
            if (File.Exists(filePath))
            {
                _configurations = XMLFileSerializationHelper.DeserializeObjectFromXMLFile<List<WebLinkConfigurationData>>(filePath);

                _configurations.ForEach(configuration =>
                {
                    dgResult.Rows.Add();
                    UpdateRowWithConfigurationData(dgResult.Rows[dgResult.Rows.Count - 1], configuration);
                });
                if (dgResult.Rows.Count > 0)
                    dgResult.Rows[dgResult.Rows.Count - 1].Selected = true;

                btnSave.Enabled = false;
            }
            else
                MessageBox.Show("以下配置文件路径不存在，请检查！\r\n" + filePath);
        }

        private void RefreshAllWebLinkCheckers()
        {
            _configurations.ForEach(configuration => GetWebLinkAccessibilityAsync(configuration));
        }

        private DataGridViewRow AddNewWebLinkChecker(WebLinkConfigurationData newConfigurationData)
        {
            dgResult.Rows.Add();
            DataGridViewRow newRow = dgResult.Rows[dgResult.Rows.Count - 1];

            UpdateRowWithConfigurationData(newRow, newConfigurationData);
            GetWebLinkAccessibilityAsync(newConfigurationData);

            _configurations.Add(newConfigurationData);

            btnSave.Enabled = true;

            return newRow;
        }

        private void UpdateInputFromCurrentRow()
        {
            if (dgResult.SelectedRows.Count == 0)
            {
                txtURL.Text = string.Empty;
                txtApplicationName.Text = string.Empty;
                chkWindowsAuthentication.Checked = false;
                txtDomain.Text = "domain";
                txtUserName.Text = "username";
                txtPassword.Text = "password";
            }
            else
            {
                DataGridViewRow currentRow = dgResult.SelectedRows[0];
                if (currentRow.Cells["ColWebLinkURL"].Value != null)
                    txtURL.Text = currentRow.Cells["ColWebLinkURL"].Value.ToString();
                else
                    txtURL.Text = string.Empty;
                if (currentRow.Cells["ColApplicationName"].Value != null)
                    txtApplicationName.Text = currentRow.Cells["ColApplicationName"].Value.ToString();
                else
                    txtApplicationName.Text = string.Empty;
                if (currentRow.Cells["ColIsWindowsAuthentication"].Value != null)
                    chkWindowsAuthentication.Checked = (bool)currentRow.Cells["ColIsWindowsAuthentication"].Value;
                else
                    chkWindowsAuthentication.Checked = false;
                if (currentRow.Cells["ColDomain"].Value != null)
                    txtDomain.Text = currentRow.Cells["ColDomain"].Value.ToString();
                else
                    txtDomain.Text = "domain";
                if (currentRow.Cells["ColUserName"].Value != null)
                    txtUserName.Text = currentRow.Cells["ColUserName"].Value.ToString();
                else
                    txtUserName.Text = "username";
                if (currentRow.Cells["ColPassword"].Value != null)
                    txtPassword.Text = currentRow.Cells["ColPassword"].Value.ToString();
                else
                    txtPassword.Text = "password";
            }
        }

        private void UpdateWebLinkChecker(DataGridViewRow currentRow, WebLinkConfigurationData updatedConfigurationData)
        {
            string originalWebLinkURL = currentRow.Cells["ColWebLinkURL"].Value.ToString();
            string originalApplicationName = currentRow.Cells["ColApplicationName"].Value.ToString();
            bool originalIsWindowsAuthentication = (bool)currentRow.Cells["ColIsWindowsAuthentication"].Value;
            string originalDomain = currentRow.Cells["ColDomain"].Value.ToString();
            string originalUserName = currentRow.Cells["ColUserName"].Value.ToString();
            string originalPassword = currentRow.Cells["ColPassword"].Value.ToString();

            bool isChanged = !originalWebLinkURL.Equals(updatedConfigurationData.WebLinkURL, StringComparison.CurrentCultureIgnoreCase) ||
                !originalApplicationName.Equals(updatedConfigurationData.ApplicationName, StringComparison.CurrentCultureIgnoreCase) ||
                originalIsWindowsAuthentication != updatedConfigurationData.IsWindowsAuthentication ||
                !originalDomain.Equals(updatedConfigurationData.Domain, StringComparison.CurrentCultureIgnoreCase) ||
                !originalUserName.Equals(updatedConfigurationData.UserName, StringComparison.CurrentCultureIgnoreCase) ||
                !originalPassword.Equals(updatedConfigurationData.Password, StringComparison.CurrentCultureIgnoreCase);

            if (isChanged)
                UpdateRowWithConfigurationData(currentRow, updatedConfigurationData);

            GetWebLinkAccessibilityAsync(updatedConfigurationData);

            int originalConfigurationDataIndex = _configurations.FindIndex(c =>
                c.WebLinkURL.Equals(originalWebLinkURL, StringComparison.CurrentCultureIgnoreCase));
            if (originalConfigurationDataIndex >= 0)
            {
                _configurations.RemoveAt(originalConfigurationDataIndex);
                _configurations.Insert(originalConfigurationDataIndex, updatedConfigurationData);
            }
            else
                _configurations.Add(updatedConfigurationData);

            if (isChanged)
                btnSave.Enabled = true;
        }

        public void RemoveWebLinkChecker(DataGridViewRow currentRow)
        {
            string WebLinkURL = currentRow.Cells["ColWebLinkURL"].Value.ToString();
            dgResult.Rows.Remove(currentRow);

            int configurationDataIndex = _configurations.FindIndex(c =>
                c.WebLinkURL.Equals(WebLinkURL, StringComparison.CurrentCultureIgnoreCase));
            if (configurationDataIndex >= 0)
                _configurations.RemoveAt(configurationDataIndex);

            btnSave.Enabled = true;
        }

        private void SaveWebLinkConfigurationData()
        {
            string filePath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, WEB_PAGE_CONFIGURATION_DATA_FILE_NAME);
            XMLFileSerializationHelper.SerializeObjectToXMLFile<List<WebLinkConfigurationData>>(_configurations, filePath);

            btnSave.Enabled = false;
        }

        private static void UpdateRowWithConfigurationData(DataGridViewRow row, WebLinkConfigurationData configurationData)
        {
            row.Cells["ColWebLinkURL"].Value = configurationData.WebLinkURL;
            row.Cells["ColApplicationName"].Value = configurationData.ApplicationName;
            row.Cells["ColIsWindowsAuthentication"].Value = configurationData.IsWindowsAuthentication;
            row.Cells["ColDomain"].Value = configurationData.Domain;
            row.Cells["ColUserName"].Value = configurationData.UserName;
            row.Cells["ColPassword"].Value = configurationData.Password;
        }

        private void GetWebLinkAccessibilityAsync(WebLinkConfigurationData configurationData)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetWebLinkAccessibilityAsync), configurationData);
        }

        private void GetWebLinkAccessibilityAsync(object param)
        {
            if (param == null || !(param is WebLinkConfigurationData))
            {
                //Report Error
                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("Invalid argument: param", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                return;
            }

            WebLinkConfigurationData configuration = param as WebLinkConfigurationData;

            //Report Progress
            BeginInvoke(new Action<string, decimal>(ReportProgress), configuration.WebLinkURL, new Decimal(0));

            try
            {
                WebLinkCheckerData result = new WebLinkCheckerData();
                result.WebLinkURL = configuration.WebLinkURL;

                if (configuration.IsWindowsAuthentication)
                    result.WebLinkContent = WebLinkCheckerHelper.AccessWebLink(configuration.WebLinkURL, configuration.UserName, configuration.Password, configuration.Domain);
                else
                    result.WebLinkContent = WebLinkCheckerHelper.AccessWebLink(configuration.WebLinkURL);

                //Complete
                BeginInvoke(new Action<WebLinkCheckerData>(OnGetWebLinkAccessibilityAsyncCompleted), result);
            }
            catch (Exception ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Thread.Sleep(5000);
                    GetWebLinkAccessibilityAsync(param);
                }
                else
                    //Report Error
                    BeginInvoke(new Action<string, Exception>(ReportError), configuration.WebLinkURL, ex);
            }
        }

        private void ReportProgress(string WebLinkURL, decimal percentOfProgress)
        {
            DataGridViewRow theRow = FindRow(WebLinkURL);

            if (theRow != null)
            {
                if (percentOfProgress == 0)
                {
                    theRow.Cells["ColState"].ToolTipText = null;
                    theRow.Cells["ColState"].Value = imageList1.Images[3];
                }
            }
        }

        private void ReportError(string WebLinkURL, Exception ex)
        {
            DataGridViewRow theRow = FindRow(WebLinkURL);

            if (theRow != null)
            {
                theRow.Cells["ColState"].Value = imageList1.Images[2];
                theRow.Cells["ColState"].ToolTipText = ex.Message;
            }
        }

        private void OnGetWebLinkAccessibilityAsyncCompleted(WebLinkCheckerData data)
        {
            if (data == null)
                return;

            DataGridViewRow theRow = FindRow(data.WebLinkURL);
            if (theRow != null)
            {
                theRow.Cells["ColState"].Value = string.IsNullOrEmpty(data.WebLinkContent) ? imageList1.Images[1] : imageList1.Images[0];
                theRow.Cells["ColState"].ToolTipText = string.IsNullOrEmpty(data.WebLinkContent) ? "Blank Web Page" : null;
            }
        }

        private DataGridViewRow FindRow(string WebLinkURL)
        {
            //find the corresponding row with the same URL
            DataGridViewRow theRow = null;
            foreach (DataGridViewRow row in dgResult.Rows)
            {
                if (row.Cells["ColWebLinkURL"].Value != null &&
                    WebLinkURL.Equals(row.Cells["ColWebLinkURL"].Value.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    theRow = row;
                    break;
                }
            }
            return theRow;
        }

        private void GetWebLinkAccessibilityAsyncForEmail(WebLinkConfigurationData configurationData)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetWebLinkAccessibilityAsyncForEmail), configurationData);
        }

        private void GetWebLinkAccessibilityAsyncForEmail(object param)
        {
            if (param == null || !(param is WebLinkConfigurationData))
            {
                //Report Error
                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("Invalid argument: param", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                iLink++;
                if (iLink == cntLink)
                {
                    if (body != string.Empty)
                        SendEmail();
                    iLink = 0;
                }
                return;
            }

            WebLinkConfigurationData configuration = param as WebLinkConfigurationData;

            try
            {
                WebLinkCheckerData result = new WebLinkCheckerData();
                result.ApplicationName = configuration.ApplicationName;
                result.WebLinkURL = configuration.WebLinkURL;

                if (configuration.IsWindowsAuthentication)
                    result.WebLinkContent = WebLinkCheckerHelper.AccessWebLink(configuration.WebLinkURL, configuration.UserName, configuration.Password, configuration.Domain);
                else
                    result.WebLinkContent = WebLinkCheckerHelper.AccessWebLink(configuration.WebLinkURL);

                iLink++;
                //Complete
                BeginInvoke(new Action<WebLinkCheckerData>(OnGetWebLinkAccessibilityAsyncCompletedForEmail), result);
            }
            catch (Exception ex)
            {
                iLink++;
                body += string.Format("<B><FONT Color=\"Red\">{0}:</FONT> {1}</B></P>", configuration.ApplicationName, configuration.WebLinkURL);
                if (iLink == cntLink)
                {
                    if (body != string.Empty)
                        SendEmail();
                    iLink = 0;
                }
                //Report Error
                BeginInvoke(new Action<string, Exception>(ReportError), configuration.WebLinkURL, ex);
            }
        }

        private void OnGetWebLinkAccessibilityAsyncCompletedForEmail(WebLinkCheckerData data)
        {
            if (data == null)
                return;

            DataGridViewRow theRow = FindRow(data.WebLinkURL);
            if (theRow != null)
            {
                if (string.IsNullOrEmpty(data.WebLinkContent))
                    body += string.Format("<B><FONT Color=\"Red\">{0}:</FONT> {1}</B></P>", data.ApplicationName, data.WebLinkURL);

                if (iLink == cntLink)
                {
                    if (body != string.Empty)
                        SendEmail();
                    iLink = 0;
                }
            }
        }

        private void SendEmail()
        {
            MailMessage message = new MailMessage();
            message.To.Add("AppSupport@company.com");
            message.CC.Add("SupportEngineer1@company.com");
            message.CC.Add("SupportEngineer2@company.com");
            message.CC.Add("SupportEngineer3@company.com");
            message.CC.Add("SupportEngineer4@company.com");
            message.Subject = "Web应用链接URL无法访问通知邮件";
            message.From = new MailAddress("AppSupport@company.com");
            message.IsBodyHtml = true;
            message.Body = "这封邮件是Web应用链接检查工具发送的自动警告邮件，请勿回复。<P />" + body;
            SmtpClient client = new SmtpClient("MailServer.company.com")
            {
                EnableSsl = false
            };

            client.Send(message);
        }

        private void CheckLinksSendEmail()
        {
            body = string.Empty;
            cntLink = _configurations.Count;
            _configurations.ForEach(configuration => GetWebLinkAccessibilityAsyncForEmail(configuration));
        }

        private void chkAutoSendEmailtoSupportTeam_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = chkAutoSendEmailtoSupportTeam.Checked;
            if (chkAutoSendEmailtoSupportTeam.Checked)
                CheckLinksSendEmail();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckLinksSendEmail();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
                this.ShowInTaskbar = true;
                RefreshAllWebLinkCheckers();
            }
        }

        private void WebLinkCheckerUI_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) //判断是否最小化
            {
                this.ShowInTaskbar = false; //不显示在系统任务栏
                notifyIcon1.Visible = true; //托盘图标可见
                notifyIcon1.ShowBalloonTip(1000);
            }
        }
    }
}
