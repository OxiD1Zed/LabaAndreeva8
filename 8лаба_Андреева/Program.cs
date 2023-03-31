using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8лаба_Андреева
{
    internal static class Program
    {
        public static List<Lesson> lessons = new List<Lesson>() { new Lesson(), new Lesson("Алгебра"), new Lesson("Программирование")};
        public static List<Student> students = new List<Student>() { new Student(), new Student("Максим", "Скабо", "Геннадьевич")};
        public static List<Session> sessions = new List<Session>() { new Session(new Lesson[] { lessons[0] }), new Session(new Dictionary<Lesson, Dictionary<Student, int>>() { { lessons[0], new Dictionary<Student, int>() { { students[1], 5 } } } })};
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Person
    {
        public string Name;
        public string LastName;
        public string SecondName;

        public Person()
        {
            Name = "Иван";
            LastName = "Иванов";
            SecondName = "Иванович";
        }
        public Person(string name, string lastName, string secondName)
        {
            Name = name;
            LastName = lastName;
            SecondName = secondName;
        }
    }

    public class Student : Person
    {
        public string Group;


        public Student() : base()
        {
            Group = "ИСП-202о";
        }
        public Student(string group) : base()
        {
            Group = group;
        }
        public Student(string name, string lastName, string secondName) : base(name, lastName, secondName)
        {
            Group = "ИСП-202о";
        }
        public Student(string name, string lastName, string secondName, string group) : base(name, lastName, secondName)
        {
            Group = group;
        }

        public override string ToString()
        {
            return Name + " " + LastName + " " + SecondName + " " + Group;
        }
    }

    public class Lesson
    {
        public string Name;
        public List<Student> Students = new List<Student>();

        public Lesson()
        {
            Name = "Разработка программных модулей";
        }
        public Lesson(string name)
        {
            Name = name;
        }
    }

    public class Session
    {
        public Dictionary<Lesson, Dictionary<Student, int>> BallsOfStudents = new Dictionary<Lesson, Dictionary<Student, int>>();
        public readonly DateTime DateOfSession;

        public Session(Lesson[] lessons)
        {
            for (int i = 0; i < lessons.Length; i++)
                BallsOfStudents.Add(lessons[i], new Dictionary<Student, int>());
            DateOfSession = DateTime.Now;
        }
        public Session(Dictionary<Lesson, Dictionary<Student, int>> ballsOfStudents)
        {
            BallsOfStudents = ballsOfStudents;
            DateOfSession = DateTime.Now;
        }
        public Session(Dictionary<Lesson, Dictionary<Student, int>> ballsOfStudents, DateTime dateTime)
        {
            BallsOfStudents = ballsOfStudents;
            DateOfSession = dateTime;
        }

        public Dictionary<Lesson, int> GetBalls(Student student)
        {
            Dictionary<Lesson, int> tamp = new Dictionary<Lesson, int>();

            foreach (var l in BallsOfStudents)
            {
                if (l.Value.ContainsKey(student))
                {
                    tamp[l.Key] = l.Value[student];
                }
            }

            if (tamp.Count == 0)
                throw new Exception("Данного студента нет в сессии");
            else
                return tamp;
        }
    }
}
