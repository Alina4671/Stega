using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteganographyUI
{
    public partial class Preferinte : Form
    {
        private PreferencesSingleton m_Preferences = PreferencesSingleton.Instance;
        private String m_PasswordValue;

        public Preferinte()
        {
            InitializeComponent();
            if (checkBox2.Checked == false)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
           

            m_Preferences.AutoSave = checkBox1.Checked;
            m_Preferences.UsePassword = checkBox2.Checked;
            m_Preferences.Password = textBox1.Text;
            this.Dispose();


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox1.ReadOnly = false;
                button1.Enabled = false;
            }
            else
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                button1.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            m_PasswordValue = textBox1.Text;
            String retypedPassword = textBox2.Text;
            bool isMatch = true;
            if (m_PasswordValue.Contains(retypedPassword) == false)
            {

                isMatch = false;
            }
            if (m_PasswordValue.CompareTo(retypedPassword) != 0)
            {

                isMatch = false;
            }
            if (isMatch == false)
            {
                button1.Enabled = false;
                label5.Text = "Parolele nu sunt identice!";
            }
            else
            {
                button1.Enabled = true;
                label5.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0)
            {

                textBox2.ReadOnly = false; 
            }
            else
            {
                textBox2.ReadOnly = true;
            }
        }
    }
}
