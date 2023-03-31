using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8лаба_Андреева
{
    public partial class Form1 : Form
    {
        private int BackListBox1Selected = -2;
        private int BackListBox2Selected = -2;
        private int BackListBox3Selected = -2;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == -1)
            {
                Form2 form2 = new Form2();

                if (form2.ShowDialog() == DialogResult.OK)
                {
                    LoadInfo();
                }
            }
            else
            {
                FormSession formSession = new FormSession();
                formSession.SelectedSession = listBox3.SelectedIndex;
                formSession.OffDateTimePicker();
                if (formSession.ShowDialog() == DialogResult.OK)
                {
                    LoadInfo();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlSelectedListBox(listBox1, ref BackListBox1Selected);
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlSelectedListBox(listBox2, ref BackListBox2Selected);
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlSelectedListBox(listBox3, ref BackListBox3Selected);
        }

        private List<string> Seach(ListBox listBox1, ListBox listBox2, ListBox listBox3, int[] balls = null)
        {
            List<string> result = new List<string>();
            if(listBox3.SelectedIndex != -1)
            {
                if(listBox2.SelectedIndex != -1)
                {
                    if (Program.sessions[listBox3.SelectedIndex].BallsOfStudents.ContainsKey(Program.lessons[listBox2.SelectedIndex]))
                    {
                        if (listBox1.SelectedIndex != -1)
                        {
                            if (Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]].ContainsKey(Program.students[listBox1.SelectedIndex]))
                            {
                                string tamp;
                                if (balls == null && Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[listBox1.SelectedIndex]] == 5)
                                {
                                    tamp = "Сессия: " + Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[listBox2.SelectedIndex].Name + " Студент: " + Program.students[listBox1.SelectedIndex].ToString() + " Оценка: " + 5;
                                    result.Add(tamp);
                                }
                                else
                                {
                                    for (int i = 0; i < balls.Length; i++)
                                    {
                                        if (balls[i] == Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[listBox1.SelectedIndex]])
                                        {
                                            tamp = "Сессия: " + Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[listBox2.SelectedIndex].Name + " Студент: " + Program.students[listBox1.SelectedIndex].ToString() + " Оценка: " + Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[listBox1.SelectedIndex]];
                                            result.Add(tamp);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                result.Add($"Сессия: {Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString()} Дисциплина: {Program.lessons[listBox2.SelectedIndex].Name} Студент: {Program.students[listBox1.SelectedIndex].ToString()} отсутствует");
                            }
                        }
                        else
                        {
                            for (int i = 0; i < Program.students.Count; i++)
                            {
                                if (Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]].ContainsKey(Program.students[i]))
                                {
                                    string tamp;
                                    if (balls == null && Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[i]] == 5)
                                    {
                                        tamp = "Сессия: " + Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[listBox2.SelectedIndex].Name + " Студент: " + Program.students[i].ToString() + " Оценка: " + 5;
                                        result.Add(tamp);
                                    }
                                    else
                                    {
                                        for (int j = 0; j < balls.Length; j++)
                                        {
                                            if (balls[j] == Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[i]])
                                            {
                                                tamp = "Сессия: " + Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[listBox2.SelectedIndex].Name + " Студент: " + Program.students[listBox1.SelectedIndex].ToString() + " Оценка: " + Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[i]];
                                                result.Add(tamp);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        result.Add($"Сессия: {Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString()} Дисциплина: {Program.lessons[listBox2.SelectedIndex].Name} отсутствует");
                    }
                }
                else
                {
                    for (int i = 0; i < Program.lessons.Count; i++)
                    {
                        if (Program.sessions[listBox3.SelectedIndex].BallsOfStudents.ContainsKey(Program.lessons[i]))
                        {
                            if (listBox1.SelectedIndex != -1)
                            {
                                if (Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[i]].ContainsKey(Program.students[listBox1.SelectedIndex]))
                                {
                                    string tamp;
                                    if (balls == null && Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[i]][Program.students[listBox1.SelectedIndex]] == 5)
                                    {
                                        tamp = "Сессия: " + Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[i].Name + " Студент: " + Program.students[listBox1.SelectedIndex].ToString() + " Оценка: " + 5;
                                        result.Add(tamp);
                                    }
                                    else
                                    {
                                        for (int j = 0; j < balls.Length; j++)
                                        {
                                            if (balls[j] == Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[i]][Program.students[listBox1.SelectedIndex]])
                                            {
                                                tamp = "Сессия: " + Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[i].Name + " Студент: " + Program.students[listBox1.SelectedIndex].ToString() + " Оценка: " + Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[i]][Program.students[listBox1.SelectedIndex]];
                                                result.Add(tamp);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int j = 0; j < Program.students.Count; j++)
                                {
                                    if (Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[i]].ContainsKey(Program.students[j]))
                                    {
                                        string tamp;
                                        if (balls == null && Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[i]][Program.students[j]] == 5)
                                        {
                                            tamp = "Сессия: " + Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[i].Name + " Студент: " + Program.students[j].ToString() + " Оценка: " + 5;
                                            result.Add(tamp);
                                        }
                                        else
                                        {
                                            for (int k = 0; k < balls.Length; k++)
                                            {
                                                if (balls[k] == Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[i]][Program.students[j]])
                                                {
                                                    tamp = "Сессия: " + Program.sessions[listBox3.SelectedIndex].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[i].Name + " Студент: " + Program.students[j].ToString() + " Оценка: " + Program.sessions[listBox3.SelectedIndex].BallsOfStudents[Program.lessons[i]][Program.students[j]];
                                                    result.Add(tamp);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if(listBox2.SelectedIndex != -1)
                {
                    if(listBox1.SelectedIndex != -1)
                    {
                        for (int i = 0; i < Program.sessions.Count; i++)
                        {
                            if (Program.sessions[i].BallsOfStudents.ContainsKey(Program.lessons[listBox2.SelectedIndex]))
                            {
                                if (Program.sessions[i].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]].ContainsKey(Program.students[listBox1.SelectedIndex]))
                                {
                                    string tamp;
                                    if (balls == null && Program.sessions[i].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[listBox1.SelectedIndex]] == 5)
                                    {
                                        tamp = "Сессия: " + Program.sessions[i].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[listBox2.SelectedIndex].Name + " Студент: " + Program.students[listBox1.SelectedIndex].ToString() + " Оценка: " + 5;
                                        result.Add(tamp);
                                    }
                                    else
                                    {
                                        for (int j = 0; j < balls.Length; j++)
                                        {
                                            if (balls[j] == Program.sessions[i].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[listBox1.SelectedIndex]])
                                            {
                                                tamp = "Сессия: " + Program.sessions[i].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[listBox2.SelectedIndex].Name + " Студент: " + Program.students[listBox1.SelectedIndex].ToString() + " Оценка: " + Program.sessions[i].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[listBox1.SelectedIndex]];
                                                result.Add(tamp);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for(int i = 0; i < Program.sessions.Count; i++)
                        {
                            if (Program.sessions[i].BallsOfStudents.ContainsKey(Program.lessons[listBox2.SelectedIndex]))
                            {
                                for (int j = 0; j < Program.students.Count; j++)
                                {
                                    if (Program.sessions[i].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]].ContainsKey(Program.students[j]))
                                    {
                                        string tamp;
                                        if (balls == null && Program.sessions[i].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[j]] == 5)
                                        {
                                            tamp = "Сессия: " + Program.sessions[i].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[listBox2.SelectedIndex].Name + " Студент: " + Program.students[j].ToString() + " Оценка: " + 5;
                                            result.Add(tamp);
                                        }
                                        else
                                        {
                                            for (int k = 0; k < balls.Length; k++)
                                            {
                                                if (balls[k] == Program.sessions[i].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[j]])
                                                {
                                                    tamp = "Сессия: " + Program.sessions[i].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[listBox2.SelectedIndex].Name + " Студент: " + Program.students[j].ToString() + " Оценка: " + Program.sessions[i].BallsOfStudents[Program.lessons[listBox2.SelectedIndex]][Program.students[j]];
                                                    result.Add(tamp);
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    if (listBox1.SelectedIndex != -1)
                    {
                        for (int i = 0; i < Program.sessions.Count; i++)
                        {
                            for (int k = 0; k < Program.lessons.Count; k++)
                            {
                                if (Program.sessions[i].BallsOfStudents.ContainsKey(Program.lessons[k]))
                                {
                                    string tamp;
                                    if (balls == null && Program.sessions[i].BallsOfStudents[Program.lessons[k]][Program.students[listBox1.SelectedIndex]] == 5)
                                    {
                                        tamp = "Сессия: " + Program.sessions[i].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[k].Name + " Студент: " + Program.students[listBox1.SelectedIndex].ToString() + " Оценка: " + 5;
                                        result.Add(tamp);
                                    }
                                    else
                                    {
                                        for (int j = 0; j < balls.Length; j++)
                                        {
                                            if (balls[j] == Program.sessions[i].BallsOfStudents[Program.lessons[k]][Program.students[listBox1.SelectedIndex]])
                                            {
                                                tamp = "Сессия: " + Program.sessions[i].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[k].Name + " Студент: " + Program.students[listBox1.SelectedIndex].ToString() + " Оценка: " + Program.sessions[i].BallsOfStudents[Program.lessons[k]][Program.students[listBox1.SelectedIndex]];
                                                result.Add(tamp);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Program.sessions.Count; i++)
                        {
                            for (int l = 0; l < Program.lessons.Count; l++)
                            {
                                if (Program.sessions[i].BallsOfStudents.ContainsKey(Program.lessons[l]))
                                {
                                    for (int j = 0; j < Program.students.Count; j++)
                                    {
                                        if (Program.sessions[i].BallsOfStudents[Program.lessons[l]].ContainsKey(Program.students[j]))
                                        {
                                            string tamp;
                                            if (balls == null && Program.sessions[i].BallsOfStudents[Program.lessons[l]][Program.students[j]] == 5)
                                            {
                                                tamp = "Сессия: " + Program.sessions[i].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[l].Name + " Студент: " + Program.students[j].ToString() + " Оценка: " + 5;
                                                result.Add(tamp);
                                            }
                                            else
                                            {
                                                for (int k = 0; k < balls.Length; k++)
                                                {
                                                    if (balls[k] == Program.sessions[i].BallsOfStudents[Program.lessons[l]][Program.students[j]])
                                                    {
                                                        tamp = "Сессия: " + Program.sessions[i].DateOfSession.ToLongDateString() + " Дисциплина: " + Program.lessons[l].Name + " Студент: " + Program.students[j].ToString() + " Оценка: " + Program.sessions[i].BallsOfStudents[Program.lessons[l]][Program.students[j]];
                                                        result.Add(tamp);
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            if (result.Count == 0)
                return new List<string>() { "Ничего не найдено..." };
            else
                return result;
        }
        private void ControlSelectedListBox(ListBox listBox, ref int BackListBoxSelected)
        {
            if (listBox.SelectedIndex == BackListBoxSelected)
            {
                listBox.SetSelected(BackListBoxSelected, false);
            }
            else
            {
                BackListBoxSelected = listBox.SelectedIndex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result = "";
            foreach (string line in Seach(listBox1, listBox2, listBox3))
            {
                result += line + "\t";
            }
            textBox1.Text = result;
            if (result.Length > 195)
                textBox1.ScrollBars = ScrollBars.Vertical;
            
        }
        private void LoadInfo()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < Program.students.Count; i++)
            {
                listBox1.Items.Add(Program.students[i].Name + " " + Program.students[i].LastName + " " + Program.students[i].SecondName + " " + Program.students[i].Group);
            }
            listBox2.Items.Clear();
            for (int i = 0; i < Program.lessons.Count; i++)
            {
                listBox2.Items.Add(Program.lessons[i].Name);
            }
            listBox3.Items.Clear();
            for (int i = 0; i < Program.sessions.Count; i++)
            {
                listBox3.Items.Add(Program.sessions[i].DateOfSession.ToLongDateString());
            }
        }
    }
}
