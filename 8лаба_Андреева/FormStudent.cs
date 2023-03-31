using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8лаба_Андреева
{
    public partial class FormStudent : Form
    {
        private TextBox[] textBoxes;
        private Label[] labels;
        private Label[] labelsNull;

        public FormStudent()
        {
            InitializeComponent();
            textBoxes = new TextBox[4] { textBox1, textBox2, textBox3, textBox4 };
            labels = new Label[4] { label1, label2, label3, label4 };
            labelsNull = new Label[4] { label5, label6, label7, label8 };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsAllTextBoxsNull())
            {
                Program.students.Add(new Student(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim()));
                DialogResult = DialogResult.OK;
            }
        }

        private bool IsAllTextBoxsNull()
        {
            bool flag = false;

            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (textBoxes[i].Text.Trim() == "")
                {
                    labels[i].ForeColor = Color.Red;
                    labelsNull[i].Visible = true;
                    flag = true;
                }
            }

            return flag;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Label.DefaultForeColor;
            label6.Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Label.DefaultForeColor;
            label5.Visible = false;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label3.ForeColor = Label.DefaultForeColor;
            label7.Visible = false;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label4.ForeColor = Label.DefaultForeColor;
            label8.Visible = false;
        }
    }
}
