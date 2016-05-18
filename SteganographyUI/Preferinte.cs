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
        private readonly OpenFileDialog OpenDialog = new OpenFileDialog();
        public Preferinte()
        {
            InitializeComponent();
            comboBox1.Items.Add(new ComboBoxItem(0x00, " "));
            comboBox1.Items.Add(new ComboBoxItem(0x01, "Text"));
            comboBox1.Items.Add(new ComboBoxItem(0x02, "Imagine"));
            comboBox1.SelectedIndex = 0;
            if (checkBox2.Checked == false)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
            }
            updateUiAccordingToComboBoxItem();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0x01)
            {
                m_Preferences.PlainText = richTextBox1.Text;



            }

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
            if (textBox1.Text.Length > 0)
            {

                textBox2.ReadOnly = false;
            }
            else
            {
                textBox2.ReadOnly = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenDialog.Filter = "PNG Images|*.png|BMP Images|*.bmp|JPG Images|*.jpg";
            OpenDialog.FilterIndex = 1;

            OpenDialog.Multiselect = false;
            DialogResult result = OpenDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                m_Preferences.HiddenImagePath = OpenDialog.InitialDirectory + OpenDialog.FileName;
               
            }
        }
        private void updateUiAccordingToComboBoxItem()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0x00:
                    button2.Enabled = false;
                    richTextBox1.Enabled = false;
                    
                    break;
                case 0x01:
                    button2.Enabled = false;
                    richTextBox1.Enabled = true;
                    break;
                case 0x02:
                    button2.Enabled = true;
                    richTextBox1.Enabled = false;
                    break;
                default:
                    break;

            }
            m_Preferences.EncodingDataIndex = (byte)comboBox1.SelectedIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateUiAccordingToComboBoxItem();
        }

        private void Preferinte_Load(object sender, EventArgs e)
        {

        }
    }
}
