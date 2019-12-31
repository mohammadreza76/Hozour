using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;

namespace Hozour
{
    class Program
    {
        static void Main(string[] args)
        {
            var aljebra = new ClassRoom("motahari", "جبر خطی", 40201);
            var student1 = new Student("ali", 1);
            aljebra.FirstGetList();
            aljebra.IntializeList();
            aljebra.CheckHozour();
            aljebra.CheckPresentce();
            aljebra.HistoryOfStudent(student1);
            aljebra.History();
            using (StreamReader sr = File.OpenText("hozour.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);

                }
            }
            
            using (StreamReader sr = File.OpenText("hozour_student.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);

                }
            }
        }
       
    }

    class Student
    {
        private string name;
        private int id;

        public Student(string name,int id)
        {
            this.id = id;
            this.name = name;
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

    }

    class ClassRoom
    {
        private string teacher;
        private string nameClass;
        private int idGroup;
        readonly ArrayList listOfStudentsOfClass = new ArrayList();

        public Dictionary<string, ArrayList> ListHozour = new Dictionary<string, ArrayList>();
        public Dictionary<string, int> CalculateListOfStudent = new Dictionary<string, int>();

        public ClassRoom(string teacher,string nameClass,int idGroup)
        {
            this.nameClass = nameClass;
            this.teacher = teacher;
            this.idGroup = idGroup;
        }
        public int IdGroup
        {
            set { idGroup = value; }
            get { return idGroup; }
        }
        public string NameClass
        {
            get { return nameClass; }
            set { nameClass = value; }
        }
        public string Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }

        //initialize CalculateListOfStudent Dictionary
        public void IntializeList()
        {
            foreach(Student s in listOfStudentsOfClass)
            {
                CalculateListOfStudent[s.Name] = 0;
            }
            
        }


        //do The presence and the absence of class
        public void CheckHozour()
        {

            DateTime today = DateTime.Now;
            ArrayList lists = new ArrayList();
            //add list to dictionary

            ListHozour.Add(today.ToString("dd-MM-yyyy"), GetList(lists));

            
        }
        // at first time get whole the students of the class
        public void FirstGetList()
        {
            GetList(listOfStudentsOfClass);
        }

        //write the listhozour in file
        public void History()
        {
            using StreamWriter file = new StreamWriter("hozour.txt");
            foreach (var item in ListHozour)
            {
                for (int j = 0; j < item.Value.Count; j++)
                {
                    var studentInstant = (Student)item.Value[j];
                    file.WriteLine("[{0} {1} {2}]", item.Key, studentInstant.Name, studentInstant.Id);
                }

            }
        }
        //write the number of absentes of student in file
        public void HistoryOfStudent(Student s)
        {
            //using StreamWriter file = new StreamWriter("hozour_student.txt");
            CheckPresentce();
            int studentAbsent = ListHozour.Count - CalculateListOfStudent[s.Name];
            //file.WriteLine("number of absents of {0} is:{1} ", s.Name, studentAbsent);
            Console.WriteLine( CalculateListOfStudent[s.Name]);
        }
        //determine the number of presentce for each student
        public void CheckPresentce()
        {
            foreach(Student pointer in listOfStudentsOfClass)
            {
                foreach(var pointer1 in ListHozour)
                {
                    if (pointer1.Value.Contains(pointer.Name))
                    {
                        CalculateListOfStudent[pointer.Name] += 1; 
                    }
                }
            }
        }
        // get students and added to arraylist
        public ArrayList GetList(ArrayList list)
        {
            try
            {
                Console.WriteLine("number of students");
                int tedadStudent = Convert.ToInt32(Console.ReadLine());
                //get arraylist of students
                for (int count = 1; count <= tedadStudent; count++)
                {
                    Console.WriteLine("name");
                    string name = Console.ReadLine();
                    Console.WriteLine("id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    list.Add(new Student(name, id));
                }
                
            }catch(FormatException)
            {
                Console.WriteLine("enter the correct input");

            }
            return list;

        }

    }
    
}
