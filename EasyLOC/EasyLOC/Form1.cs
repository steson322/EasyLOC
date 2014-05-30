using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EasyLOC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void countButton_Click(object sender, EventArgs e)
        {
            if (lang_cs.Checked)
            {
                List<string> files = new List<string>();
                foreach (var i in fileList.Items)
                    files.Add(i.ToString());
                CSharpLineCounter cslc = new CSharpLineCounter();
                cslc.LoadFile(files);
                outputLabel.Text = "Count: " + cslc.Count();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (lang_cs.Checked)
            {
                LoadFile(".cs");
            }
        }

        /// <summary>
        /// Load file
        /// </summary>
        /// <param name="ext"></param>
        public void LoadFile(string ext)
        {
            //read file location
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(" + ext + ")|*" + ext + "";
            openFileDialog1.CheckFileExists = true;
            DialogResult result = openFileDialog1.ShowDialog();
            //make sure user click OK or Open
            if (result != System.Windows.Forms.DialogResult.OK)
                return;
            foreach (var FileName in openFileDialog1.FileNames)
            {
                //avoid same file
                bool match = false;
                foreach (var i in fileList.Items)
                {
                    if (String.Compare(i.ToString(), FileName) == 0)
                    {
                        match = true;
                        break;
                    }
                }
                if (match)
                    continue;
                //validate file
                if (!File.Exists(FileName))
                {
                    MessageBox.Show("File:\n" + FileName + " does not exists.");
                    continue;
                }
                //try load file
                FileInfo finfo = new FileInfo(FileName);
                if (finfo.Extension != ext)
                {
                    MessageBox.Show("File:\n" + FileName + " is not a valid " + ext + " file.");
                    continue;
                }
                fileList.Items.Add(FileName);
            }
        }

        /// <summary>
        /// Remove added source files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedIndex >= 0)
                fileList.Items.RemoveAt(fileList.SelectedIndex);
        }
    }
}
