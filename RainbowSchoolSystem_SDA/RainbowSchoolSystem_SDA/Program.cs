using System;

namespace RainbowSchoolSystem_SDA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" -------------------------------------------------------");
            Console.WriteLine("|\t\t\t\t\t\t\t|");
            Console.WriteLine("|\t\t   Rainbow School System     \t\t|");
            Console.WriteLine("|\t\t\t\t\t\t\t|");
            Console.WriteLine(" -------------------------------------------------------");

            Teacher o = new Teacher();

            int? choice = null;

            while (choice != 4)
            {
                Console.Write("\nEnter Choice:\n [1: View Data  2: Add Data  3: Update  Data 4: Exit] ");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please enter valid choice");         
                }

                switch (choice)
                {
                    case 1:
                        try
                        {
                            string data = o.View();
                            Console.WriteLine(data);
                            Console.WriteLine("Data View ended Successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.Write("ID: ");
                            int ID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Name: ");
                            string Name = Console.ReadLine();
                            Console.Write("Class: ");
                            string Class = Console.ReadLine();
                            Console.Write("Section: ");
                            string Section = Console.ReadLine();
                            o.Add(ID, Name, Class, Section);
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.Write("Enter ID You Want To Update:");
                            int searchID = int.Parse(Console.ReadLine());
                            Teacher tData = o.Search(searchID);

                            if (tData != null)
                            {
                                Console.Write("New ID: ");
                                int newID = Convert.ToInt32(Console.ReadLine());
                                Console.Write("New Name: ");
                                string newName = Console.ReadLine();
                                Console.Write("New Class: ");
                                string newClass = Console.ReadLine();
                                Console.Write("New Section: ");
                                string newSection = Console.ReadLine();
                                o.Update(searchID, newID, newName, newClass, newSection);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(searchID + " Does Not Exist!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case 4:
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not a valid choice!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            Console.WriteLine("Have a nice day!");
        }
    }
}
