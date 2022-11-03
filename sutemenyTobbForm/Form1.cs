using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sutemenyTobbForm
{
    public partial class Form1 : Form
    {
        List<Suti> adatok = new List<Suti>();

        public Form1()
        {
            InitializeComponent();
        }

        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.ShowDialog();
        }

        private void tsmFile_Click(object sender, EventArgs e)
        {
            ofdFile.ShowDialog();
        }

        private void tsmNevjegy_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.ShowDialog();
        }

        private void ofdFile_FileOk(object sender, CancelEventArgs e)
        {
            string path = ofdFile.FileName;

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] temp = sr.ReadLine().Split(';');
                    string nev = temp[0];
                    int ar = Convert.ToInt32(temp[1]);
                    adatok.Add(new Suti(nev, ar));
                }
            }

            tsmSutemenyek.Enabled = true;

        }

        private void tsmSutemenyek_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItallapForm itallap = new ItallapForm(this);
            itallap.ShowDialog();
        }
    }
}
