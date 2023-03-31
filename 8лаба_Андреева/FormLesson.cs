using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _8лаба_Андреева
{
    public partial class FormLesson : Form
    {
        public FormLesson()
        {
            InitializeComponent();
        }

        private void FormLesson_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!IsAllTextBoxsNull())
            {
                Program.lessons.Add(new Lesson(textBox1.Text.Trim()));
                DialogResult = DialogResult.OK;
            }
        }

        private bool IsAllTextBoxsNull()
        {
            if (textBox1.Text.Trim() == "")
            {
                label1.ForeColor = Color.Red;
                label2.Visible = true;
                return true;
            }
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Label.DefaultForeColor;
            label2.Visible = false;
        }
    }
}
