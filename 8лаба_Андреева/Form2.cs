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
    public partial class Form2 : Form
    {
        private CheckBox[] checkBoxes;
        private int checkIndex = 0;

        public Form2()
        {
            InitializeComponent();
            checkBoxes = new CheckBox[3] { checkBox1, checkBox2, checkBox3 };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (GetSelectCheckBox(checkBoxes))
                {
                    case 1:
                        FormStudent formStudent = new FormStudent();
                        if (formStudent.ShowDialog() == DialogResult.OK) { }
                        break;
                    case 2:
                        FormLesson formLesson = new FormLesson();
                        if (formLesson.ShowDialog() == DialogResult.OK) { }
                        break;
                    case 3:
                        FormSession formSession = new FormSession();
                        if (formSession.ShowDialog() == DialogResult.OK) { }
                        break;
                }
            }
            finally
            {
                DialogResult = DialogResult.OK;
            }
        }

        private int GetSelectCheckBox(CheckBox[] chBoxes)
        {
            for(int i = 1; i < chBoxes.Length + 1; i++)
            {
                if (checkBoxes[i - 1].Checked)
                    return i;
            }

            throw new Exception("Ни один CheckBox не выбран");
        }
        private void ControlCheckBox()
        {
            for(int i = 0; i < checkBoxes.Length; i++)
            {
                if(checkBoxes[i].Checked && i != checkIndex)
                {
                    checkIndex = i;
                    for(int j = 0; j < checkBoxes.Length; j++)
                    {
                        if(j != i)
                            checkBoxes[j].Checked = false;
                    }
                    break;
                }
            }
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            ControlCheckBox();
        }
    }
}
