using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SteganographyUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.Step = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   Thread runningTread = new Thread(new ThreadStart(new RunOnThreadClass().executeSomething));
           // runningTread.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked==true)
            {
                progressBar1.PerformStep();
            }
        }
    }

    //class RunOnThreadClass
    //{
    //    public void executeSomething()
    //    {
    //        while(true)
    //        {
    //            Console.WriteLine("On Thread");
    //        }

    //    }
    //}

}
