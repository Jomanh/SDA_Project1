using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RainbowSchoolSystem_SDA
{
    class Teacher
    {
        string path = @"C:..\TeacherData.txt";

        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }

        public Teacher()
        {

        }

        public Teacher(int ID, string Name, string Class, string Section)
        {
            this.ID = ID; this.Name = Name; this.Class = Class; this.Section = Section;
        }

        public string View()
        {
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();         
            return data;
        }

        public void Add(int ID, string Name, string Class, string Section)
        {
            StreamWriter writer = File.AppendText(path);
            string value = ID + ", " + Name + ", " + Class + ", " + Section + "\n";

            writer.Write(value);
            writer.Close();

            Console.WriteLine("Data Added Successfully!");
        }

        public void Update(int searchID, int ID, string Name, string Class, string Section)
        {
            string[] lines = File.ReadAllLines(path);
            bool status = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(",");

                if (int.Parse(line[0]) == searchID)
                {
                    lines[i] = ID + ", " + Name + ", " + Class + ", " + Section;
                    status = true;
                }
            }
            if (status)
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine("Data Updated Successfully!");
            }
        }

        public Teacher Search(int Id)
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string s in lines)
            {
                string[] line = s.Split(",");

                if (int.Parse(line[0]) == Id)
                {
                    Teacher data = new Teacher(int.Parse(line[0]), line[1], line[2], line[3]);
                    return data;
                }
            }

            return null;
        }
    }
}
