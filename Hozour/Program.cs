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
            aljebra.CheckHozour();
            //aljebra.f();
     
            aljebra.history();
            using (StreamReader sr = File.OpenText("hozour.txt"))
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
        //List<Student> lists = new List<Student>();
        
        public Dictionary<string, ArrayList> ListHozour = new Dictionary<string, ArrayList>();

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
        //do The presence and the absence of class
        public void CheckHozour()
        {

            DateTime today = DateTime.Now;
            Console.WriteLine("number of students");
            int tedadStudent = Convert.ToInt32(Console.ReadLine());
            //Student[] lists = new Student[tedadStudent];
            ArrayList lists = new ArrayList();
            //get array of students
            for (int count = 1; count<= tedadStudent; count++)
            {
                Console.WriteLine("name");
                string name = Console.ReadLine();
                Console.WriteLine("id");
                int id = Convert.ToInt32(Console.ReadLine());
                lists.Add(new Student(name, id));
                                
                
            }
            //add list to dictionary
            ListHozour.Add(today.ToString("dd-MM-yyyy"),lists);

        }
        public void f()
        {
            foreach (var item in ListHozour)
            {
                var studentInstant = (Student)item.Value[1];
                Console.WriteLine("[{0} {1} {2}]", item.Key, studentInstant.Name, studentInstant.Id);
                
            }
        }

        //write the listhozour in file
        public void history()
        {
            using (StreamWriter file = new StreamWriter("hozour.txt"))
            {
                for(int i = 0; i < ListHozour.Count; i ++ )
                {
                    var item = ListHozour.ElementAt(i);
                    var itemKey = item.Key;
                    var itemValue = item.Value;
                    var studentInstant = (Student)itemValue[i];
                    file.WriteLine("[{0} {1} {2}]", itemKey, studentInstant.Name, studentInstant.Id );
                    
                }
                
           }

         

        }
        



    }
    
}
