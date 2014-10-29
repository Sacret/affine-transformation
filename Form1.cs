using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Графика
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // массивы
        float[] one = new float[4];
        float[] two = new float[4];
        float[] three = new float[4];
        float[] local = new float[4];
        //
        float[] oone= new float[4];
        float[] otwo = new float[4];
        float[] othree = new float[4];
        //
        float[] prim = new float[4];
        float[,] A1 = new float[4, 4];
        float[,] A2 = new float[4, 4];
        float[,] A3 = new float[4, 4];
        float[,] A4 = new float[4, 4];   
        //
        int i = 0, j = 0;
        int N = 4;
        float sh = 0;
        float midx = 132;
        float midy = 113;        
        //
        // выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // ввод
        private void button1_Click(object sender, EventArgs e)
        {
            one[0] = oone[0] = float.Parse(textBox1.Text);
            one[1] = oone[1] = float.Parse(textBox2.Text);
            one[2] = oone[2] = float.Parse(textBox3.Text);
            //
            two[0] = otwo[0] = float.Parse(textBox6.Text);
            two[1] = otwo[1] = float.Parse(textBox5.Text);
            two[2] = otwo[2] = float.Parse(textBox4.Text);
            //
            three[0] = othree[0] = float.Parse(textBox9.Text);
            three[1] = othree[1] = float.Parse(textBox8.Text);
            three[2] = othree[2] = float.Parse(textBox7.Text);
            //
            local[0] = float.Parse(textBox12.Text);
            local[1] = float.Parse(textBox11.Text);
            local[2] = float.Parse(textBox10.Text);
            //
            one[3] = oone[3] = two[3] = otwo[3] = three[3] = othree[3] = local[3] = 1;
            Setka (Max(one,two,three));
            Postr(one, two, three,local,1);
        }
        // максимальное
        float Max(float[] a, float[] b, float[] c)
        {
            float max = Math.Abs(a[0]);
            for (i = 0; i < N-1; i++)
            {
                if (Math.Abs(a[i]) >= max) max = Math.Abs(a[i]);
                if (Math.Abs(b[i]) >= max) max = Math.Abs(b[i]);
                if (Math.Abs(c[i]) >= max) max = Math.Abs(c[i]);
            }
            return max;
        }
        // построение сетки
        void Setka(float max)
        {
            //Задаем цвет и толщину пера:            
            Graphics g1 = panel6.CreateGraphics();
            Graphics g2 = panel4.CreateGraphics();
            Graphics g3 = panel5.CreateGraphics();
            //
            SolidBrush myBrush1 = new SolidBrush(Color.White);
            g1.FillRectangle(myBrush1, new RectangleF(0, 0, 264, 226));
            g2.FillRectangle(myBrush1, new RectangleF(0, 0, 264, 226));
            g3.FillRectangle(myBrush1, new RectangleF(0, 0, 264, 226));
            //
            Pen myPen = new Pen(Color.Gray);
            myPen.Width = 1;
            Pen Pen2 = new Pen(Color.Black);
            Pen2.Width = 2;
            //
            sh = 113 / max;          
            //
            for (i = 0; i < max+1; i++)
            {
                g1.DrawLine(myPen, 0, midy - i * sh, midx*2, midy - i * sh); 
                g1.DrawLine(myPen, 0, midy + i * sh, midx*2, midy + i * sh);
                g1.DrawLine(myPen, midx - i * sh, 0, midx - i * sh, midy*2);
                g1.DrawLine(myPen, midx + i * sh, 0, midx + i * sh, midy*2);
                //
                g2.DrawLine(myPen, 0, midy - i * sh, midx * 2, midy - i * sh);
                g2.DrawLine(myPen, 0, midy + i * sh, midx * 2, midy + i * sh);
                g2.DrawLine(myPen, midx - i * sh, 0, midx - i * sh, midy * 2);
                g2.DrawLine(myPen, midx + i * sh, 0, midx + i * sh, midy * 2);
                //
                g3.DrawLine(myPen, 0, midy - i * sh, midx * 2, midy - i * sh);
                g3.DrawLine(myPen, 0, midy + i * sh, midx * 2, midy + i * sh);
                g3.DrawLine(myPen, midx - i * sh, 0, midx - i * sh, midy * 2);
                g3.DrawLine(myPen, midx + i * sh, 0, midx + i * sh, midy * 2);
            }
            //
            g1.DrawLine(Pen2, midx, 0, midx, midy * 2);
            g2.DrawLine(Pen2, midx, 0, midx, midy * 2);
            g3.DrawLine(Pen2, midx, 0, midx, midy * 2);
            //
            g1.DrawLine(Pen2, 0, midy, midx * 2, midy);
            g2.DrawLine(Pen2, 0, midy, midx * 2, midy);
            g3.DrawLine(Pen2, 0, midy, midx * 2, midy);            
        }
        // построение треугольников
        void Postr(float[] a, float[] b, float[] c, float[]d, int k)
        {
            //Задаем цвет и толщину пера:            
            Graphics g1 = panel6.CreateGraphics();
            Graphics g2 = panel4.CreateGraphics();
            Graphics g3 = panel5.CreateGraphics();
            //
            Pen Pen = new Pen(Color.Blue);
            if (k == 1) Pen.Color = Color.Blue;
            if (k == 2) Pen.Color = Color.Red;
            Pen.Width = 2;
            //
            SolidBrush myBrush = new SolidBrush(Color.Green);
            //
            g1.DrawLine(Pen, midx + a[0] * sh, midy - a[1] * sh, midx + b[0] * sh, midy - b[1] * sh);
            g1.DrawLine(Pen, midx + b[0] * sh, midy - b[1] * sh, midx + c[0] * sh, midy - c[1] * sh);
            g1.DrawLine(Pen, midx + c[0] * sh, midy - c[1] * sh, midx + a[0] * sh, midy - a[1] * sh);
            //
            g2.DrawLine(Pen, midx + a[1] * sh, midy - a[2] * sh, midx + b[1] * sh, midy - b[2] * sh);
            g2.DrawLine(Pen, midx + b[1] * sh, midy - b[2] * sh, midx + c[1] * sh, midy - c[2] * sh);
            g2.DrawLine(Pen, midx + c[1] * sh, midy - c[2] * sh, midx + a[1] * sh, midy - a[2] * sh);
            //
            g3.DrawLine(Pen, midx + a[0] * sh, midy - a[2] * sh, midx + b[0] * sh, midy - b[2] * sh);
            g3.DrawLine(Pen, midx + b[0] * sh, midy - b[2] * sh, midx + c[0] * sh, midy - c[2] * sh);
            g3.DrawLine(Pen, midx + c[0] * sh, midy - c[2] * sh, midx + a[0] * sh, midy - a[2] * sh);
            //
            float rad = 3.5F;
            g1.FillEllipse(myBrush, midx + d[0] * sh, midy - d[1] * sh, rad,rad);
            g2.FillEllipse(myBrush, midx + d[1] * sh, midy - d[2] * sh, rad,rad);
            g3.FillEllipse(myBrush, midx + d[0] * sh, midy - d[2] * sh, rad, rad);   
        }
        // умножение матриц 4 на 4
        void Mul44(float[,] a, float[,] b, float[,] c)
        {            
           float s=0;          
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    s=0;
                    for (int k = 0; k<N; k++)
                    {
                        s+=a[i,k]*b[k,j];
                    }
                    c[i,j]=s;                   
                }
            }
        }
        // умножение матриц 4 на 4 на столбец
        void Mul41(float[,] a, float[] b, float[] c)
        {
            for (i = 0; i < N; i++) c[i] = 0;
            float s = 0;
            for (i = 0; i < N; i++)
            {                
                s = 0;
                for (int k = 0; k < N; k++)
                {
                    s += a[i, k] * b[k];
                } 
                c[i] = s;
            }
        }
        // копирование массивов
        void Copy11(float[] a, float[] b)
        {
            for (i = 0; i < N; i++)
            {              
                 a[i] = b[i];                
            }
        }
        // новые матрицы
        void Matr(float[,] a)
        {
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    if (i == j) a[i, j] = 1;
                    else a[i, j] = 0;
                }
            }
        }
        // поворот
        private void button2_Click(object sender, EventArgs e)
        {
            Copy11(oone, one);
            Copy11(otwo, two);
            Copy11(othree, three);
            Matr(A1);
            Matr(A2);
            Matr(A3);       
            //
            float a = float.Parse(textBox13.Text); 
            //
            if (radioButton1.Checked)
            {
                A2[1, 1] = A2[2, 2] = (float)(Math.Cos(a*Math.PI/180));
                A2[2, 1] = (float)(Math.Sin(a * Math.PI / 180));
                A2[1, 2] = -(float)(Math.Sin(a * Math.PI / 180));
            }
            //
            if (radioButton2.Checked)
            {
                A2[0, 0] = A2[2, 2] = (float)(Math.Cos(a * Math.PI / 180));
                A2[0, 2] = (float)(Math.Sin(a * Math.PI / 180));
                A2[2, 0] = -(float)(Math.Sin(a * Math.PI / 180));
            }
            //
            if (radioButton3.Checked)
            {
                A2[0, 0] = A2[1, 1] = (float)(Math.Cos(a * Math.PI / 180));
                A2[1, 0] = (float)(Math.Sin(a * Math.PI / 180));
                A2[0, 1] = -(float)(Math.Sin(a * Math.PI / 180));
            }
           
            //
            if (checkBox1.Checked)
            {              
                for (i=0; i<N-1; i++)
                {
                    A1[i,3]=-local[i];
                    A3[i,3]=local[i];
                }
                Mul44(A2, A1, A4);
                Mul44(A3, A4, A2);  
            }
            Enter1(A2);
        }
        // вывод координат
        void Coord(float[] a, float[] b, float[] c)
        {
            textBox1.Text = a[0].ToString();
            textBox2.Text = a[1].ToString();
            textBox3.Text = a[2].ToString();
            //
            textBox6.Text = b[0].ToString();
            textBox5.Text = b[1].ToString();
            textBox4.Text = b[2].ToString();
            //
            textBox9.Text = c[0].ToString();
            textBox8.Text = c[1].ToString();
            textBox7.Text = c[2].ToString();
        }
        // построение предыдущего
        private void button5_Click(object sender, EventArgs e)
        {
            Postr(oone, otwo, othree, local, 1);
        }
        // масштабирование и отражение
        private void button3_Click(object sender, EventArgs e)
        {
            Copy11(oone, one);
            Copy11(otwo, two);
            Copy11(othree, three);
            //
            Matr(A1);
            Matr(A2);
            Matr(A3);
            //
            int k = 0;
            //
            A2[0, 0] = float.Parse(textBox14.Text);
            A2[1, 1] = float.Parse(textBox15.Text);
            A2[2, 2] = float.Parse(textBox16.Text);
            //
            if (checkBox2.Checked)
            {
                if (radioButton12.Checked)
                {
                    A1[0,0] = -1;
                }
                if (radioButton11.Checked)
                {
                    A1[1,1] = -1;
                }
                if (radioButton10.Checked)
                {
                    A1[2,2] = -1;
                }                
            }
            //
            if (A2[0, 0] > 0 && A2[1, 1] > 0 && A2[2, 2] > 0) k = 1;
            Mul44(A1, A2, A3);
            //
            if (checkBox3.Checked)
            {
                Matr(A1);
                Matr(A2);
                for (i = 0; i < N - 1; i++)
                {
                    A1[i, 3] = -local[i];
                    A2[i, 3] = local[i];
                }
                Mul44(A3, A1, A4);
                Mul44(A2, A4, A3);
            }
            //
            if (k==1) Enter1(A3);
        }
        // сдвиг
        private void button4_Click(object sender, EventArgs e)
        {
            Copy11(oone, one);
            Copy11(otwo, two);
            Copy11(othree, three);
            //
            Matr(A1);
            //
            if (radioButton6.Checked) j = 0;
            if (radioButton5.Checked) j = 1;
            if (radioButton4.Checked) j = 2;
            if (radioButton9.Checked) i = 0;
            if (radioButton8.Checked) i = 1;
            if (radioButton7.Checked) i = 2;
            A1[i, j] = float.Parse(textBox17.Text);
            //
            if (checkBox4.Checked)
            {
                Matr(A2);
                Matr(A3);
                Matr(A4);
                for (i = 0; i < N - 1; i++)
                {
                    A2[i, 3] = -local[i];
                    A3[i, 3] = local[i];
                }
                Mul44(A1, A2, A4);
                Mul44(A3, A4, A1);
            }
            Enter1(A1);                    
        }
        // новые координаты
        void Enter1(float[,] A)
        {
            Mul41(A, two, prim);
            Copy11(two, prim);

            Mul41(A, three, prim);
            Copy11(three, prim);

            Mul41(A, one, prim);
            Copy11(one, prim);
            //
            Coord(one, two, three);
            Setka(Max(one, two, three));
            Postr(one, two, three, local, 2);   
        }
        // новый ввод
        private void изПримераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = "";
            textBox11.Text = textBox12.Text = textBox13.Text = textBox17.Text = "";
            textBox14.Text = textBox15.Text = textBox16.Text = "1";
            //
            radioButton1.Checked = radioButton12.Checked = radioButton6.Checked = radioButton9.Checked = true;
            checkBox1.Checked = checkBox2.Checked = false;
        }
        // справка
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Эту и другие программы смотрите на www.sacret.ru/");
        }
        // перенос
        private void button6_Click(object sender, EventArgs e)
        {
            Copy11(oone, one);
            Copy11(otwo, two);
            Copy11(othree, three);
            //
            one[0]+=float.Parse(textBox18.Text);
            two[0]+= float.Parse(textBox18.Text);
            three[0]+= float.Parse(textBox18.Text);
            //
            one[1] += float.Parse(textBox19.Text);
            two[1] += float.Parse(textBox19.Text);
            three[1] += float.Parse(textBox19.Text);
            //
            one[2] += float.Parse(textBox20.Text);
            two[2] += float.Parse(textBox20.Text);
            three[2] += float.Parse(textBox20.Text);
            //
            Coord(one, two, three);
            Setka(Max(one, two, three));
            Postr(one, two, three, local, 2);   
        }













    }
}
