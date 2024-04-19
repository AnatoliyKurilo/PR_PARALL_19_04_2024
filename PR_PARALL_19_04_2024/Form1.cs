using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_PARALL_19_04_2024
{
    public partial class Form1 : Form
    {
        Thread thread1;
        Thread thread2;
        Thread thread3;
        private void DrawRectangle() {
            try
            {
                Random rnd = new Random();
                Graphics g = panel1.CreateGraphics();
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(4);
                    g.DrawRectangle(Pens.Pink, 0, 0, rnd.Next(this.Width), rnd.Next(this.Height));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void DrawEllipse()
        {
            try
            {
                Random rnd = new Random();
                Graphics g = panel2.CreateGraphics();

                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(4);
                    g.DrawEllipse(Pens.Yellow, 0, 0, rnd.Next(this.Width), rnd.Next(this.Height));

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RandomNumber() {
            try
            {

                Random rnd = new Random();
                Parallel.For(0, 100, i => {
                    Invoke((MethodInvoker)delegate () {
                        textBox1.Text += rnd.Next(1, 100).ToString();
                        textBox1.Text += " ";
                    
                    });



                });


                //textBox1.Invoke((MethodInvoker)delegate () { 
                //    for (int i = 0;i<100;i++) {
                //        textBox1.Text += rnd.Next(1, 100).ToString();
                //        textBox1.Text += " ";
                //    }
                
                //});

                //for (int i = 0; i < 100; i++)
                //{
                //    textBox1.Text += rnd.Next(1, 100).ToString();
                //    textBox1.Text += " ";
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Form1()
        {
            InitializeComponent();
            thread1 = new Thread(new ThreadStart(DrawRectangle));
            thread2 = new Thread(new ThreadStart(DrawEllipse));
            thread3 = new Thread(new ThreadStart(RandomNumber));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DrawRectangle();
            try
            {
                thread1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DrawEllipse();
            try
            {
                thread2.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //RandomNumber();
            try
            {
                thread3.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g1 = panel1.CreateGraphics();
            g1.Clear(Color.White);

            Graphics g2 = panel2.CreateGraphics();
            g2.Clear(Color.White);

            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            thread1.Interrupt();
            thread2.Interrupt();
            thread3.Interrupt();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread1.Abort();
            thread2.Abort();
            thread3.Abort();
        }
    }
}
