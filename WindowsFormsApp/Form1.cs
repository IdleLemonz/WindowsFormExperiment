using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{    
    public partial class Form1 : Form
    {
        //List<string> locations = new List<string>();      
        Data info = new Data();  

        public Form1()
        {
            InitializeComponent();            
        }      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs me = e as MouseEventArgs;
   
                info.locations.Add(me.Location.ToString() + Environment.NewLine);
                textOutput.Text = "";
                foreach (string item in info.locations)
                {
                    textOutput.AppendText(item);
                }
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Stream myStream; // handles saving and loading
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt"; // chooses the txt file dialog dropdown
            saveFileDialog1.DefaultExt = "txt"; // forces the file to be saved as .txt even when not specified
         
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // if the dialog is open, then...
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.                    
                    StreamWriter sw = new StreamWriter(myStream);
                    sw.WriteLine(textOutput.Text); // write text from the textbox textOutput
                    sw.Flush(); // clears buffers for the current buffer, causes buffered data to be written to underlying stream
                    sw.Close();
                    myStream.Close();
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textOutput.Text = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newMDIChild = new Form2();
            // Set the Parent Form of the Child window
            newMDIChild.MdiParent = this;
            // Display the new form
            newMDIChild.Show();
        }
    }
}
