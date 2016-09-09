using FileWatcher;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FileWatcherDemo
{
    public partial class Form1Ex : Form
    {
        List<IFileWatcher> lstFileWatcher = new List<IFileWatcher>();
        IFileWatcher objFileWatcher = FileWatcherService.CreateFileWatcher();
        IRuleEngine objRuleEngine = RuleEngineService.CreateInstance();  
        ILogger objLogger = LoggerService.CreateLogger();
        public Form1Ex()
        {
            InitializeComponent();
            this.textBoxFolderToWatch.Text = string.Empty;
            lstFolderToWatch.View = View.Details;
            this.buttonStart.Enabled = false;
            this.buttonStop.Enabled = false;                      
            objLogger.WritelogInfo("Application Started");           
        }
        #region File Monitor Initialization   

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Initializes the Watcher object. In the interest of providing a complete 
        /// demonstration, all change events are monitored. This will unlikely be a 
        /// real-world requirement in most cases.
        /// </summary>
        private bool InitWatcher()
        {
            bool result = false;

            for (int i = 0; i < lstFolderToWatch.Items.Count; i++)
            {
                string folderPath = lstFolderToWatch.Items[i].SubItems[0].Text.Trim();
                string searchCriteria =  lstFolderToWatch.Items[i].SubItems[3].Text.Trim();
                bool includeSubFolder = Convert.ToBoolean(lstFolderToWatch.Items[i].SubItems[2].Text);
                int threshold = Convert.ToInt32(lstFolderToWatch.Items[i].SubItems[1].Text.Trim());
                if (Directory.Exists(folderPath) || File.Exists(folderPath))
                {
                    //if (objFileWatcher != null)
                    {
                        objFileWatcher.CreateFileWatcher(folderPath, searchCriteria, includeSubFolder, threshold);                       
                        objFileWatcher.Start(i);
                        objLogger.WritelogInfo("File Watcher started for folder " + folderPath);
                        objRuleEngine.FileTimer(DateTime.Now, lstFolderToWatch.Items[i].Text.Trim(),threshold);                                            
                        lstFileWatcher.Add(objFileWatcher);
                        result = true;
                    }
                }
                else
                {
                    MessageBox.Show("The folder (or file) specified does not exist.\nPlease specify a valid folder or filename.");
                }
              
            }
          
            return result;
        }
        #endregion 
        #region Form Events
        //--------------------------------------------------------------------------------
        /// <summary>
        /// Fired when the form is closing. Disposes the Watcher object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1Ex_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lstFileWatcher != null && lstFileWatcher.Count > 0)
            {
                foreach (var fileWatcher in lstFileWatcher)
                {
                    fileWatcher.Dispose();
                }
            }
            ClearDictionaryList();
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Fired when the user clicks the Start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
                if (InitWatcher())
                {
                    this.buttonStart.Enabled = false;
                    this.buttonStop.Enabled = true;
                this.buttonBrowse.Enabled = false;
                this.textBoxFolderToWatch.Enabled = false;
                }

            }
        /// <summary>
        /// Fired when the user clicks the Stop button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {        
            objRuleEngine.StopFileTimer();
           
            for (int i = 0; i <lstFolderToWatch.Items.Count; i++)
            {
                string folderPath = lstFolderToWatch.Items[i].SubItems[0].Text.Trim();
                    objFileWatcher.Stop(i);                    
                objLogger.WritelogInfo("File Watcher stopped successfully for folder " + folderPath);                
            }
            foreach (var fileWatcher in lstFileWatcher)
            {
                fileWatcher.Dispose();
            }
            lstFileWatcher.Clear();
            lstFolderToWatch.Items.Clear();
            ClearDictionaryList();
            this.buttonBrowse.Enabled = true;
            this.textBoxFolderToWatch.Enabled = true;
            this.buttonStart.Enabled = false;
            this.buttonStop.Enabled = false;
            
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Fired when the user clicks the Done button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDone_Click(object sender, EventArgs e)
        {
            ClearDictionaryList();
            Application.Exit();
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Fired when the user clicks the Browse button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (string.IsNullOrEmpty(appDataFolder))
            {
                MessageBox.Show("Could not determine the name of the ApplicationData folder\non this machine. Terminating browse attempt.");
                return;
            }            

            FolderBrowserDialog dlg = new FolderBrowserDialog();       
            DialogResult result = dlg.ShowDialog();
            string[] arr = new string[4];
            ListViewItem itm;
            if (result == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.SelectedPath))
                {
                    lstFolderToWatch.View = View.Details;
                    
                    //Add first item
                    arr[0] = dlg.SelectedPath;
                    string value = "60000";
                   string searchCriteria = "*.*";
                   bool includeSubFolder = true;
                    if (InputBox("TimeInterval", "Enter time interval(ms) for this folder:", ref value,ref includeSubFolder,ref searchCriteria) == DialogResult.OK)
                    {
                        arr[1] = value.ToString();
                        arr[2] = includeSubFolder.ToString();
                        arr[3] = searchCriteria;
                    }
                    
                    itm = new ListViewItem(arr);
                    lstFolderToWatch.Items.Add(itm);
                    lstFolderToWatch.Update();
                }
                else
                {
                    //Add first item
                    arr[0] = appDataFolder;
                    arr[1] = "60000";
                    arr[2] = "*.*";
                    arr[3] = "false";
                    itm = new ListViewItem(arr);
                    lstFolderToWatch.Items.Add(itm);
                }
                if (lstFolderToWatch.Items.Count > 0)
                    this.buttonStart.Enabled = true;
            }
        }       

        /// <summary>
        /// clear folder access list
        /// </summary>
        private void ClearDictionaryList()
        {
            if(Program.FileCreationList.Any())
                Program.FileCreationList.Clear();
            if (Program.FileRemainingList.Any())
                Program.FileRemainingList.Clear();
            if (Program.FolderLastAccessTimeList.Any())
                Program.FolderLastAccessTimeList.Clear();
        }
        private static DialogResult InputBox(string title, string promptText, ref string value,ref bool includeSubFolder,ref string searchCriteria)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Label label1 = new Label();
            TextBox textBox1 = new TextBox();
            Label label2 = new Label();
            CheckBox chk = new CheckBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            label1.Text = "Enter Search Criteria:";
            textBox1.Text = searchCriteria;
            label2.Text = "Include Subfolders:";
            chk.Checked = includeSubFolder;
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 172, 13);
            textBox.SetBounds(185, 18, 172, 20);
            label1.SetBounds(9,40, 172, 13);
            textBox1.SetBounds(185,40,172,20);
            label2.SetBounds(9,60,172,32);
            chk.SetBounds(185,60,172,32);
            buttonOk.SetBounds(160,100,62,20);
            buttonCancel.SetBounds(230,100,62,20);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            label1.AutoSize = true;
            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            label2.AutoSize = true;
            chk.Anchor = chk.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(400,140);
            form.Controls.AddRange(new Control[] { label, textBox,label1,textBox1,label2,chk, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(400, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            searchCriteria = textBox1.Text;
           if(chk.Checked) 
           {
               includeSubFolder = true;
           }
           else
           {
               includeSubFolder = false;
           }
            return dialogResult;
        }

        #endregion Form Events
    }
}
