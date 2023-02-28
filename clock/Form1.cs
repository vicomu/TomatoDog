using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace TomatoDog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Point mPoint;
        bool TomatoClock = false;
        int backcolor;
        int fontcolor;
        int m;
        int s = 0;
        int i = 0;
        int r;
        string info ="0 0";
        bool sx = false;
        string img = "";
        private static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        int all_time = 0;
        int all_clocks;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool MessageBeep(uint uType);

        public static bool IsRealImage(string path)
        {
            try
            {
                Image img = Image.FromFile(path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public void SetBackColor(int color)
        {
            if (color == 0)
            {
                this.BackColor = Color.White;
                panel1.BackgroundImage = null;
                panel2.BackgroundImage = null;
                panel4.BackgroundImage = null;
            }
            if (color == 1)
            {
                this.BackColor = Color.SkyBlue;
                panel1.BackgroundImage = null;
                panel2.BackgroundImage = null;
                panel4.BackgroundImage = null;
            }
            if (color == 2)
            {
                this.BackColor = Color.Tomato;
                panel1.BackgroundImage = null;
                panel2.BackgroundImage = null;
                panel4.BackgroundImage = null;
            }
            if (color == 3)
            {
                this.BackColor = Color.LawnGreen;
                panel1.BackgroundImage = null;
                panel2.BackgroundImage = null;
                panel4.BackgroundImage = null;
            }
            if (color == 4)
            {
                this.BackColor = Color.Pink;
                panel1.BackgroundImage = null;
                panel2.BackgroundImage = null;
                panel4.BackgroundImage = null;
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

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {        
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           if(!TomatoClock)
                label1.Text=DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.Second.ToString();
           label2.Text = DateTime.Now.ToLongDateString().ToString();
           label8.Text = label1.Text;
           if(label1.Text == "0:0:0")
           {
                File.WriteAllText(AppData + "/TomatoDog/all_clocks.tomatodog", "0");
                File.WriteAllText(AppData + "/TomatoDog/all_time.tomatodog", "0");
                File.WriteAllText(AppData + "/TomatoDog/date.tomatodog", DateTime.Now.ToShortDateString().ToString());
                all_time = 0;
                all_clocks = 0;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TomatoClock = true;
            button2.Visible = true;
            button1.Visible = false;
        }      

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (TomatoClock)
            {
                if(s==0)
                {
                    if(m==0)
                    {
                        i++;
                        MessageBeep(1);
                        Form5 form5 = new Form5();
                        form5.Show();
                        
                       
                        if(i==2)
                        {
                            /*
                            button2.Visible = false;
                            button1.Visible = true;
                            TomatoClock = false;
                            */
                            i = 0;
                            m = int.Parse(File.ReadAllText(AppData + "/TomatoDog/m.tomatodog"));
                            all_clocks++;
                            all_time += m;
                            File.WriteAllText(AppData + "/TomatoDog/all_clocks.tomatodog", all_clocks.ToString());
                            File.WriteAllText(AppData + "/TomatoDog/all_time.tomatodog", all_time.ToString());
                        }
                        else
                        {
                            m = r;
                        }
                    }
                    else
                    {
                        s=60;
                        m--;
                    }
                }
                else
                {
                    s--;
                    label1.Text = m.ToString() + ":" + s.ToString();
                }
                    
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TomatoClock = false;
            m = int.Parse(File.ReadAllText(AppData + "/TomatoDog/m.tomatodog"));
            s = 0;           
            button2.Visible = false;
            button1.Visible = true;
        }

        private void Set_ToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            panel1.Visible = false;
            panel2.Visible = true;
            panel1.Location = new Point(500,500);
            panel2.Location = new Point(0, 0);
            comboBox1.SelectedIndex = backcolor;
            comboBox2.SelectedIndex = fontcolor;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            numericUpDown1.Value = 25;
            numericUpDown2.Value = 5;
            comboBox1.SelectedItem = "默认";
            comboBox2.SelectedItem = "默认";
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.TopMost = true;           
            try
            {
                info = File.ReadAllText(AppData+"/TomatoDog/info.tomatodog");
                m = int.Parse(File.ReadAllText(AppData + "/TomatoDog/m.tomatodog"));
                r = int.Parse(File.ReadAllText(AppData + "/TomatoDog/r.tomatodog"));
                img = File.ReadAllText(AppData + "/TomatoDog/img.tomatodog");
                File.ReadAllText(AppData + "/TomatoDog/all_time.tomatodog");
                File.ReadAllText(AppData + "/TomatoDog/all_clocks.tomatodog");
                File.ReadAllText(AppData + "/TomatoDog/date.tomatodog");
            }            
            catch
            {
                Directory.CreateDirectory(Path.Combine(AppData , "TomatoDog"));
                File.WriteAllText(AppData+ "/TomatoDog/info.tomatodog", "0 0");
                File.WriteAllText(AppData + "/TomatoDog/m.tomatodog", "25");
                File.WriteAllText(AppData + "/TomatoDog/r.tomatodog", "5");
                File.WriteAllText(AppData + "/TomatoDog/img.tomatodog", "");
                File.WriteAllText(AppData + "/TomatoDog/all_time.tomatodog", "0");
                File.WriteAllText(AppData + "/TomatoDog/all_clocks.tomatodog", "0");
                File.WriteAllText(AppData + "/TomatoDog/date.tomatodog", DateTime.Now.ToShortDateString().ToString()); 

            }
            
            if(File.ReadAllText(AppData + "/TomatoDog/date.tomatodog") == DateTime.Now.ToShortDateString().ToString())
            {           
               all_clocks = int.Parse(File.ReadAllText(AppData + "/TomatoDog/all_clocks.tomatodog"));
               all_time = int.Parse(File.ReadAllText(AppData + "/TomatoDog/all_time.tomatodog"));
            }
            else
            {
                File.WriteAllText(AppData + "/TomatoDog/all_clocks.tomatodog", "0");
                File.WriteAllText(AppData + "/TomatoDog/all_time.tomatodog", "0");
                File.WriteAllText(AppData + "/TomatoDog/date.tomatodog", DateTime.Now.ToShortDateString().ToString());
            }
            int j = 0;
            foreach (char i in info)
            {
                if(i!=' ')
                {
                    switch (j)
                    {
                        case 0: backcolor = int.Parse(i.ToString()); break;
                        case 1: fontcolor = int.Parse(i.ToString()); break;
                        default:  break;
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
                    this.panel1.BackgroundImage = Image.FromFile(img);
                    this.panel2.BackgroundImage = Image.FromFile(img);
                    this.panel4.BackgroundImage = Image.FromFile(img);
                }
                catch
                {
                    SetBackColor(0);
                    backcolor = 0;
                }
               
            }
               

            SetFontColor(fontcolor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backcolor = comboBox1.SelectedIndex;
            fontcolor = comboBox2.SelectedIndex;
            SetBackColor(backcolor);
            SetFontColor(fontcolor);
            m = int.Parse(numericUpDown1.Value.ToString());
            r = int.Parse(numericUpDown2.Value.ToString());
            
            
            File.WriteAllText(AppData + "/TomatoDog/info.tomatodog", backcolor + " " + fontcolor);
            File.WriteAllText(AppData + "/TomatoDog/m.tomatodog",m.ToString());
            File.WriteAllText(AppData + "/TomatoDog/r.tomatodog", r.ToString());
            
            
            panel1.Visible = true;
            panel2.Visible = false;
            panel1.Location = new Point(0, 0);
            panel2.Location = new Point(500, 500);
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                img = openFileDialog1.FileName;
                this.panel1.BackgroundImage = Image.FromFile(img);
                this.panel2.BackgroundImage = Image.FromFile(img);
                this.panel4.BackgroundImage = Image.FromFile(img);
                File.WriteAllText(AppData + "/TomatoDog/img.tomatodog", img);
                comboBox1.SelectedItem = "图片";
            }
       
        }
   
        private void About_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void What_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
     
        private void Small_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (!sx)
            {
                panel4.Location = new Point(0, 0);
                System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
                myPath.AddEllipse(30, 30, this.Width - 194, this.Height - 109);
                this.Region = new Region(myPath);
                if(TomatoClock)
                {
                    label8.Location = new Point(31, 55);
                    label8.Font = new System.Drawing.Font("华文琥珀", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
                else
                {
                    label8.Location = new Point(29, 58);
                    label8.Font = new System.Drawing.Font("华文琥珀", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
                Small_ToolStripMenuItem.Text = "复原";
                Set_ToolStripMenuItem.Visible = false;
                sx = true;                
            }
            else
            {
                this.Region = new Region();
                panel4.Location = new Point(0, 200);
                Small_ToolStripMenuItem.Text = "缩小";
                Set_ToolStripMenuItem.Visible = true;
                sx = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 5 && panel1.BackgroundImage == null)
            {
                comboBox1.SelectedIndex = 0;
                MessageBox.Show("请先选择图片");
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {  
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.All;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (s.Length != 1)
            {
                MessageBox.Show("请只选择一张图片哦");
            }

            if(!IsRealImage(s[0]))
            {
                MessageBox.Show("选择的不是图片哦，请选择图片");
            }
            img = s[0];
            backcolor = 5;
            this.panel1.BackgroundImage = Image.FromFile(img);
            this.panel2.BackgroundImage = Image.FromFile(img);
            this.panel4.BackgroundImage = Image.FromFile(img);
            File.WriteAllText(AppData + "/TomatoDog/img.tomatodog", img);
            File.WriteAllText(AppData + "/TomatoDog/info.tomatodog", backcolor + " " + fontcolor);
        }

        private void Hide_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
            this.ShowIcon = false;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            this.ShowIcon = false;
        }

        private void Statistics_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        #region WindowMove
        private void label8_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        #endregion
    }
}
