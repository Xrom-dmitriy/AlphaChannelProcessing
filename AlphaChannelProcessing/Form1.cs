using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaChannelProcessing
{
    public partial class Form1 : Form
    {
        string filename;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 255;
            openFileDialog1.Filter = "Image file(*.png)|*.png|All files(*.*)|*.*";
            trackBar1.Value = 1;
            trackR.Minimum = 0;
            trackG.Minimum = 0;
            trackB.Minimum = 0;
            trackR.Maximum = 100;
            trackG.Maximum = 100;
            trackB.Maximum = 100;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Text = $"{(double)trackBar1.Value/255*100}%";
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(filename);
            bmp = new Bitmap(pictureBox1.Image);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (bmp == null)
                return;
            pictureBox1.Image = imageColor(new Bitmap(filename), trackBar1.Value, trackR.Value / 100.0, trackG.Value / 100.0, trackB.Value / 100.0);
            
        }
        private Image imageColor(Bitmap image, int opacity, double R, double G, double B)
        {
            for (int w = 0; w < image.Width; w++)
            {
                for (int h = 0; h < image.Height; h++)
                {
                    Color c = image.GetPixel(w, h);
                    if (c != Color.Transparent) 
                    {
                        Color newC = Color.FromArgb(opacity , (int)(c.R * R), (int)(c.G * G), (int)(c.B * B));
                        image.SetPixel(w, h, newC);
                    }
                }
            }
            return image;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }
    }
}
