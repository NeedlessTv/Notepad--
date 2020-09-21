using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;

namespace some_thing_usefull
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string title = ConfigurationManager.AppSettings.Get("title");
            this.Text = title;
            string version = "1.0";
            WebClient Webclient = new WebClient();

            try
            {
                if (!Webclient.DownloadString("https://pastebin.com/raw/yheeMxUk").Contains(version))
                {
                    DialogResult dialogResult = MessageBox.Show("Download Latest Version?", "Updates available!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        WebClient client = new WebClient();
                        client.DownloadFile("http://127.0.0.1/Notepad--.exe", @"Notepad--.exe");
                        Process.Start(@"Notepad--.exe");
                        MessageBox.Show("Updated!");
                        Application.Exit();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        
                    }
                }
                else
                {
                    
                }
            }
            catch
            {

            }

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.DefaultExt = "*.txt";
                openFileDialog1.Filter = "Text Files|*.txt";
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text Files|*.txt";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("save successfully", "Address File : " + saveFile1.FileName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
