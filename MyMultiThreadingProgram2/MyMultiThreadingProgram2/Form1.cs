using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int i = 0;
      //  int ans;
         
        public Form1()
        {
            InitializeComponent();
            Thread T1 = new Thread(FirstFunc);
            T1.Start(); 
            Thread T2 = new Thread(SecFunc);
            T2.Start();
            Thread T3 = new Thread(ThirdFunc);
                                           
            T3.Start();
            

            

            

           
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void FirstFunc()
        {
       //     textBox1.Text = i.ToString();
            for (i = 0; i <= 15; i++)
            {
                Thread.Sleep(1);
                listBox1.Items.Add(i);
                
           
            }
        }

        
        private void ThirdFunc()
        {

            for (i = 0; i <= 15; i++)
            {
                Thread.Sleep(1);
                listBox3.Items.Add(i.ToString());

            }
        }

        private void SecFunc()
        {

            for (i = 0; i <= 15; i++)
            {
                Thread.Sleep(1);
                listBox2.Items.Add(i.ToString());


            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            const string sPath = @"C:\Testing\Save.text";
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            SaveFile.Write("Func1, Func2, Func3");
            SaveFile.WriteLine(" ");
            foreach (var item in listBox1.Items)
            {
                SaveFile.Write("f1 ");
                //   SaveFile.Write(" , ");
                SaveFile.WriteLine(item.ToString());
            }
            foreach (var item in listBox2.Items)
            {
                SaveFile.Write("f2 ");
                //   SaveFile.Write(" , ");
                SaveFile.WriteLine(item.ToString());
            }
            foreach (var item in listBox3.Items)
            {
                SaveFile.Write("f3 ");
                //   SaveFile.Write(" , ");
                SaveFile.WriteLine(item.ToString());
            }


            SaveFile.ToString();
            SaveFile.Close();
          


        }

        private void btn_exit(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


    }
}


