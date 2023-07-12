using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RichTextLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBold_MouseClick(object sender, MouseEventArgs e)
        {
            if (rtbDoc.SelectedText != null)
            {
                if (((Button)sender).Text == "Жирный")
                {
                    var defaultFont = rtbDoc.Font;
                    rtbDoc.SelectionFont = new Font(defaultFont.FontFamily, defaultFont.Size, FontStyle.Bold);
                    //rtbDoc.SelectionFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                }
                else
                {
                    if (((Button)sender).Text == "Курсив")
                    {
                        rtbDoc.SelectionFont = new Font("Microsoft Sans Serif", 12, FontStyle.Italic);
                    }
                    else
                    {
                        rtbDoc.SelectionFont = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                    }
                }
                
            }
        }
        
        private string OpenFile()
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "rtf files(*.rtf)|*.rtf";
                of.InitialDirectory = Environment.CurrentDirectory;
                of.ShowDialog();
                if (of.ShowDialog() == DialogResult.OK)
                {
                   return of.FileName;
                }
            }
            return "none";
        }
        private void btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            rtbDoc.SaveFile("Dock.rtf");           
        }

        private void btnLoad_MouseClick(object sender, MouseEventArgs e)
        {
            var result = OpenFile();
            if (result != "none")
            {
                rtbDoc.LoadFile(result);
            }
            
        }
    }
}
