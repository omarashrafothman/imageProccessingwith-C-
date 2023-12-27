using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
 


namespace image_proccesing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap img;




        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
               OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|PNG files(*.png)|*.png|All Files(*.*)|*.*";
                
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    imageLocation = dialog.FileName;
                    image1.ImageLocation = imageLocation;

                }


            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }

        private void image1_Click(object sender, EventArgs e)
        {

        }

        private void rEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void gREENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)image1.Image);
            processImgToGray(copyBitmap);
            PictureBox2.Image = copyBitmap;
        }
        public bool processImgToGray(Bitmap bmp)
        {
            for(int x = 0; x < bmp.Width; x++)
            {

                for(int y = 0; y < bmp.Height; y++) {
                    Color bmpColor = bmp.GetPixel(x, y);
                    int alpha=bmpColor.A;
                    int red = bmpColor.R;
                    int green = bmpColor.G;
                    int blue = bmpColor.B;
                    int gray = (red+green+blue)/3;
                    bmp.SetPixel(x, y, Color.FromArgb(alpha, gray, gray, gray));

                }


            }
            return true;


        }
        public bool processImgToColors(Bitmap bmp,string filterType)
        {
            Bitmap rbmp = new Bitmap(bmp);
            Bitmap gbmp = new Bitmap(bmp);
            Bitmap bbmp = new Bitmap(bmp);


            for (int x = 0; x < bmp.Width; x++)
            {

                for (int y = 0; y < bmp.Height; y++)
                {
                    Color bmpColor = bmp.GetPixel(x, y);
                    int alpha = bmpColor.A;
                    int red = bmpColor.R;
                    int green = bmpColor.G;
                    int blue = bmpColor.B;
                    if (filterType == "red")
                    {

                        rbmp.SetPixel(x, y, Color.FromArgb(alpha, red, 0, 0));
                        pictureBox3.Image = rbmp;

                    }
                    else if (filterType == "blue")
                    {
                       
                        bbmp.SetPixel(x, y, Color.FromArgb(alpha, 0, 0, blue));
                        pictureBox4.Image = bbmp;

                    }
                    else
                    {
                        gbmp.SetPixel(x, y, Color.FromArgb(alpha, 0, green, 0));
                        Box4.Image = gbmp;

                    }

                }


            }
            return true;


        }

        private void rEDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)image1.Image);
            processImgToColors(copyBitmap, "red");
        }

        private void gREENToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)image1.Image);
            processImgToColors(copyBitmap, "green");
        }

        private void bLUEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)image1.Image);
            processImgToColors(copyBitmap, "blue");
        }

        private void randomPixelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // random pixels
            Bitmap copyBitmap = new Bitmap((Bitmap)image1.Image);
            randomPixels(copyBitmap);

        }
        public bool randomPixels(Bitmap bmp)
        {
            Random rand = new Random();
            Bitmap randomPixels = new Bitmap(bmp);



            for (int y = 0; y < bmp.Height; y++)
            {

                for (int x = 0; x < bmp.Width; x++)
                {
                    //generate random ARDB values

                    Color bmpColor = bmp.GetPixel(x, y);
                    int alpha = rand.Next(256);
                    int red = rand.Next(256);
                    int green = rand.Next(256);
                    int blue = rand.Next(256);
                    //set ARGB values
                    randomPixels.SetPixel(x,y,Color.FromArgb(alpha,red,green,blue)); 
                    

                }

            }
            pictureBox5.Image = randomPixels;
            //            bmp.Save("D\\Image\\RandomImage.png");

            return true;


        }


    }
}
