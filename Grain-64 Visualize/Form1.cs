using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Grain_64_Visualize;
using System.IO;

namespace Grain_64_Visualize
{
    public partial class Form1 : Form
    {
        private bool _working;
        private bool _isOn;
        public int i;
        public byte[] key;
        public byte[] openText;
        public byte[] keyStream;
        public byte[] chiperText;
        Grain_64 grain;
        public int h;

        public Form1()
        {
            InitializeComponent();

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            key = new byte[16] { 8, 4, 5, 6, 6, 6, 1, 6, 2, 6, 8, 6, 5, 4, 3, 12 };
            openText = new byte[26] { 49, 50, 32, 52, 54, 32, 51, 52, 32, 56, 57, 32, 56, 48, 32, 52, 53, 32, 54, 51, 32, 56, 50, 32, 55, 49 };
            chiperText = new byte[openText.Length];
            keyStream = new byte[openText.Length];
            loadKey();
            loadOpenText();
        }

        void loadKey()
        {
            ByteToText(key, Key);
        }
        void loadOpenText()
        {
            ByteToText(openText, OpenTextbox);
        }
        void loadLFSR()
        {
            ByteToText(grain.lfsr, LFSR);
        }
        void loadNFSR()
        {
            ByteToText(grain.nfsr, NFSR);
        }
        void loadKeyStream()
        {
            ByteToText(keyStream, KeyStreamTextBox);
        }
        void loadChiperText()
        {
            ByteToText(chiperText, chiperTextBox);
        }
        void ByteToText(byte[] Bt, TextBox txb)
        {
            string str = "";
            for (int i = 0; i < Bt.Length; i++)
                str += Convert.ToString(Bt[i], 2).PadLeft(8, '0') + "  ";
            txb.Text = str;
        }
        private void Start_button_Click(object sender, EventArgs e)
        {
            _working = true;
            Stop_button.Enabled = true;
            _isOn = true;
            Stop_button.Text = "Stop";
            grain = new Grain_64
            {
                key = key,
                lfsr = key.Take(key.Length / 2).ToArray(),
                nfsr = key.Skip(key.Length / 2).ToArray()
            };
            chiperText = new byte[openText.Length];
            keyStream = new byte[openText.Length];

            grain.Init();
            backgroundWorker1.WorkerSupportsCancellation = true;
            if (backgroundWorker1.WorkerSupportsCancellation)
            {
                backgroundWorker1.CancelAsync();
                i = 0;
            }
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();             
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (i = 0; i < openText.Length*8; i++)
            {
                h = Convert.ToInt32(grain.Enc());
                int ha = h << (7 - (i % 8));
                keyStream[i / 8] = Convert.ToByte(Convert.ToInt32(keyStream[i / 8]) ^ ha);//??

                if (i % 8 == 7)
                    chiperText[i/8] = Convert.ToByte(Convert.ToInt32(openText[i/8]) ^ Convert.ToInt32(keyStream[i/8]));

                Thread.Sleep(1000);
                while(!_working)
                    Thread.Sleep(1000);
                backgroundWorker1.ReportProgress(i);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            label1.Text = "Iteration: " + e.ProgressPercentage.ToString();

            loadLFSR();
            loadNFSR();
            loadKeyStream();
            h_label.Text = "h(i) = " + h.ToString();

            loadChiperText();
        }

        private void Stop_button_Click(object sender, EventArgs e)
        {
            if (_isOn)
            {
                _working = false;
                _isOn = false;
                Stop_button.Text = "Continue";
            }
            else
            {
                _working = true;
                _isOn = true;
                Stop_button.Text = "Stop";
            }
        }

        private void KeyOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                try
                {
                    string[] file_txt = File.ReadAllText(fileName).Split(' ');
                    for (int i = 0; i < key.Length; i++)
                        key[i] = Convert.ToByte(file_txt[i]);
                    loadKey();
                }
                catch (IOException exp)
                {
                    MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        private async void FileToolStripMenuItem1_ClickAsync(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                try
                {
                    using (FileStream SourceStream = File.Open(fileName, FileMode.Open))
                    {
                        openText = new byte[SourceStream.Length];
                        await SourceStream.ReadAsync(openText, 0, (int)SourceStream.Length);
                    }
                }
                catch (IOException exp)
                {
                    MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            loadOpenText();
            keyStream = new byte[openText.Length];
        }

        private void PolynomsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
