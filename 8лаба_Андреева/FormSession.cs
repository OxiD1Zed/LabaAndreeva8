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
    public partial class FormSession : Form
    {
        private Session session;
        public int SelectedSession = -1;
        private ListBox[] listBoxes;
        private Label[] labels;
        private Label[] labelsNull;

        public FormSession()
        {
            InitializeComponent();
            listBoxes = new ListBox[3] { listBox1, listBox2, listBox3 };
            labels = new Label[3] { label1, label2, label3 };
            labelsNull = new Label[3] { label5, label6, label7 };
            LoadInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if(SelectedSession == -1)
                Program.sessions.Add(session);
        }
        public void OffDateTimePicker()
        {
            dateTimePicker1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!IsAllTextBoxsNull())
            {
                if (SelectedSession == -1)
                {
                    if (session != null)
                    {
                        if (session.BallsOfStudents.ContainsKey(Program.lessons[listBox1.SelectedIndex - 1]))
                        {
                            if (!session.BallsOfStudents[Program.lessons[listBox1.SelectedIndex - 1]].ContainsKey(Program.students[listBox2.SelectedIndex - 1]))
                                session.BallsOfStudents[Program.lessons[listBox1.SelectedIndex - 1]].Add(Program.students[listBox2.SelectedIndex - 1], listBox3.SelectedIndex);
                            else
                            {
                                session.BallsOfStudents[Program.lessons[listBox1.SelectedIndex - 1]].Remove(Program.students[listBox2.SelectedIndex - 1]);
                                session.BallsOfStudents[Program.lessons[listBox1.SelectedIndex - 1]].Add(Program.students[listBox2.SelectedIndex - 1], listBox3.SelectedIndex);
                            }
                        }
                        else
                        {
                            session.BallsOfStudents.Add(Program.lessons[listBox1.SelectedIndex - 1], new Dictionary<Student, int>()
                        {
                            { Program.students[listBox2.SelectedIndex - 1], listBox3.SelectedIndex}
                        });
                        }
                    }
                    else
                    {
                        session = new Session(new Dictionary<Lesson, Dictionary<Student, int>>()
                    {
                        { Program.lessons[listBox1.SelectedIndex - 1], new Dictionary<Student, int>()
                            {
                                { Program.students[listBox2.SelectedIndex - 1], listBox3.SelectedIndex}
                            }
                        }
                    }, dateTimePicker1.Value);
                    }
                    label4.Text = "Элемент добавлен!";
                }
                else
                {
                    if (Program.sessions[SelectedSession].BallsOfStudents.ContainsKey(Program.lessons[listBox1.SelectedIndex - 1]))
                    {
                        if (!Program.sessions[SelectedSession].BallsOfStudents[Program.lessons[listBox1.SelectedIndex - 1]].ContainsKey(Program.students[listBox2.SelectedIndex - 1]))
                            Program.sessions[SelectedSession].BallsOfStudents[Program.lessons[listBox1.SelectedIndex - 1]].Add(Program.students[listBox2.SelectedIndex - 1], listBox3.SelectedIndex);
                        else
                        {
                            Program.sessions[SelectedSession].BallsOfStudents[Program.lessons[listBox1.SelectedIndex - 1]].Remove(Program.students[listBox2.SelectedIndex - 1]);
                            Program.sessions[SelectedSession].BallsOfStudents[Program.lessons[listBox1.SelectedIndex - 1]].Add(Program.students[listBox2.SelectedIndex - 1], listBox3.SelectedIndex);
                        }
                    }
                    else
                    {
                        Program.sessions[SelectedSession].BallsOfStudents.Add(Program.lessons[listBox1.SelectedIndex - 1], new Dictionary<Student, int>()
                        {
                            { Program.students[listBox2.SelectedIndex - 1], listBox3.SelectedIndex}
                        });
                    }
                }
            }
        }

        private bool IsAllTextBoxsNull()
        {
            bool flag = false;

            for (int i = 0; i < listBoxes.Length; i++)
            {
                if (listBoxes[i].SelectedIndex == 0 || listBoxes[i].SelectedIndex == -1)
                {
                    labels[i].ForeColor = Color.Red;
                    labelsNull[i].Visible = true;
                    flag = true;
                }
            }

            return flag;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Label.DefaultForeColor;
            label5.Visible = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Label.DefaultForeColor;
            label6.Visible = false;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.ForeColor = Label.DefaultForeColor;
            label7.Visible = false;
        }
        private void LoadInfo()
        {
            for (int i = 0; i < Program.lessons.Count; i++)
            {
                listBox1.Items.Add(Program.lessons[i].Name);
            }
            for (int i = 0; i < Program.students.Count; i++)
            {
                listBox2.Items.Add(Program.students[i].Name + " " + Program.students[i].LastName + " " + Program.students[i].SecondName + " " + Program.students[i].Group);
            }
            for (int i = 1; i < 6; i++)
            {
                listBox3.Items.Add(i.ToString());
            }
        }
    }
}
