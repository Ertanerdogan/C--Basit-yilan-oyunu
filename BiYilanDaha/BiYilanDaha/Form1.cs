using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BiYilanDaha
{
    public partial class Form1 : Form
    {
        Random randX = new Random();
        Random randY = new Random();
        List<Panel> yilan = new List<Panel>();
        List<Panel> elmalar = new List<Panel>();
        List<int> locX = new List<int>();
        List<int> locY = new List<int>();   
        string yon = "sag";
        bool meyve = false;
        int skor = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        int elmaX = 0;
        int elmaY = 0;
        private void elma_olustur()
        {
            elmaX = randX.Next(1,49);
            elmaY = randY.Next(1, 24);
            Panel elma = new Panel();
            elma.BackColor = Color.Red;
            elma.Size = new Size(20, 20);
            elma.Location = new Point(elmaX*20, elmaY*20);
            elmalar.Add(elma);
            int sayi = elmalar.Count;
            PnlAlan.Controls.Add(elmalar[sayi-1]);
            meyve = true;
        }
  
        private void govde_ekle()
        {
            Panel govde = new Panel();
            govde.Size = new Size(20, 20);
            govde.BackColor = Color.White;
            govde.Location = new Point(eskiX,eskiY);
            yilan.Add(govde);
            PnlAlan.Controls.Add(yilan[yilan.Count-1]);
            locX.Add(yilan[yilan.Count - 1].Location.X);
            locY.Add(yilan[yilan.Count - 1].Location.Y);
        }
        int eskiX;
        int eskiY;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int X = yilan[0].Location.X;
            int Y = yilan[0].Location.Y;

            if(yilan.Count > 1)
            {
                for (int j = 1; j < yilan.Count; j++)
                {
                    yilan[j].Location = new Point(locX[j - 1], locY[j-1]); 
                }
            }
            

            if (meyve == false)
            {
                elma_olustur();
            }

            if (yon == "sag")
            {
                if (X < 980)
                {
                    X += 20;
                }
                else
                {
                    X = 0;
                }
            }
            else if (yon == "sol")
            {
                if (X > 0)
                {
                    X -= 20;
                }
                else
                {
                    X = 980;
                }
            }
            else if (yon == "yukari")
            {
                if (Y > 0)
                {
                    Y -= 20;
                }
                else
                {
                    Y = 480;
                }
            }
            else if (yon == "asagi")
            {
                if (Y < 480)
                {
                    Y += 20;
                }
                else
                {
                    Y = 0;
                }
            }

            yilan[0].Location = new Point(X, Y);
            if(meyve == true)
            {
                if(X == elmaX*20)
                {
                    if(Y == elmaY*20)
                    {
                        skor += 10;
                        label1.Text = "SKOR : " + skor;
                        int sayi = elmalar.Count;
                        elmalar[sayi - 1].Visible = false;
                        meyve = false;
                        govde_ekle();
                    }
                }
            }
            for(int i = 0;i<yilan.Count;i++)
            {
                locX[i] = yilan[i].Location.X;
                locY[i] = yilan[i].Location.Y;
            }
            for (int k = 1; k < yilan.Count; k++)
            {
                if (yilan[0].Location.X == locX[k] && yilan[0].Location.Y == locY[k])
                {
                    timer1.Stop();
                    MessageBox.Show("YANDINIZ !\n Puan : " + skor);
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show(eskiX + " " + eskiY);
            }
            if(yon == "sag")
            {
                if (e.KeyCode == Keys.Up)
                {
                    yon = "yukari";
                }
                else if (e.KeyCode == Keys.Down)
                {
                    yon = "asagi";
                }
            }
            else if(yon == "sol")
            {
                if (e.KeyCode == Keys.Up)
                {
                    yon = "yukari";
                }
                else if (e.KeyCode == Keys.Down)
                {
                    yon = "asagi";
                }
            }
            else if (yon == "yukari")
            {
                if (e.KeyCode == Keys.Left)
                {
                    yon = "sol";
                }
                else if (e.KeyCode == Keys.Right)
                {
                    yon = "sag";
                }
            }
            else if (yon == "asagi")
            {
                if (e.KeyCode == Keys.Left)
                {
                    yon = "sol";
                }
                else if (e.KeyCode == Keys.Right)
                {
                    yon = "sag";
                }
            }
            
        }
        Panel elma = new Panel();
        private void Form1_Load(object sender, EventArgs e)
        {
            PnlAlan.Size = new Size(1000, 500);
            Panel kafa = new Panel();
            kafa.BackColor = Color.Blue;
            kafa.Size = new Size(20, 20);
            kafa.Location = new Point(340, 140);
            yilan.Add(kafa);
            PnlAlan.Controls.Add(yilan[0]);
            timer1.Start();
            elma_olustur();
            locX.Add(yilan[0].Location.X);
            locY.Add(yilan[0].Location.Y);
        }


    }
}
