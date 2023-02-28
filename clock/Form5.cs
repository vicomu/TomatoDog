using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TomatoDog
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.TopMost = true;
        }
        Point mPoint = new Point();
        private static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string info;
        string img;
        int backcolor;
        int fontcolor;
        int i = 0;
        public void SetBackColor(int color)
        {
            if (color == 0)
            {
                this.BackColor = Color.White;
            }
            if (color == 1)
            {
                this.BackColor = Color.SkyBlue;             
            }
            if (color == 2)
            {
                this.BackColor = Color.Tomato;
            }
            if (color == 3)
            {
                this.BackColor = Color.LawnGreen;
            }
            if (color == 4)
            {
                this.BackColor = Color.Pink;
            }
        }

        public void SetFontColor(int colorz)
        {
            if (colorz == 0)
            {
                this.ForeColor = Color.Black;

            }
            if (colorz == 1)
            {
                this.ForeColor = Color.SkyBlue;

            }
            if (colorz == 2)
            {
                this.ForeColor = Color.Tomato;


            }
            if (colorz == 3)
            {
                this.ForeColor = Color.LawnGreen;

            }
            if (colorz == 4)
            {
                this.ForeColor = Color.Pink;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(i==2)
            {
                this.Close();
            }
            i++;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.TopMost = true;
            info = File.ReadAllText(AppData + "/TomatoDog/info.tomatodog");
            img = File.ReadAllText(AppData + "/TomatoDog/img.tomatodog");

            int j = 0;
            foreach (char i in info)
            {
                if (i != ' ')
                {
                    switch (j)
                    {
                        case 0: backcolor = int.Parse(i.ToString()); break;
                        case 1: fontcolor = int.Parse(i.ToString()); break;
                        default: break;
                    }

                    j++;
                }

            }
            if (backcolor < 5)
                SetBackColor(backcolor);
            else
            {
                try
                {
                    this.BackgroundImage = Image.FromFile(img);
                }
                catch
                {
                    SetBackColor(0);
                    backcolor = 0;
                }

            }


            SetFontColor(fontcolor);

        }
    }
}
