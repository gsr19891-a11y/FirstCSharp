namespace Lecture_16_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> names = new List<string>();

            Dictionary<string, int> studentPoints = new Dictionary<string, int>();

            Console.WriteLine("Enter student name");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter student Score");
            bool isValiAge = int.TryParse(Console.ReadLine(), out int studentPoint);


            foreach (var item in studentPoints.Values)
            {
                if (item.Equals(studentName))
                {
                    throw new ArgumentException("Name us alredy in list");

                }

            }


            names.Add(studentName);

            studentPoints.Add(studentName, studentPoint);



            while (true)
            {
                Console.WriteLine("enter 1 - to add student");
                Console.WriteLine("enter 2 - to search student");
                Console.WriteLine("enter 3 - to update student");
                Console.WriteLine("enter 4 - to display all student");
                Console.WriteLine("enter 5 - to exit");

                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        Console.WriteLine("add student name:");
                        string newName = Console.ReadLine();

                        if (studentPoints.ContainsKey(newName))
                        {
                            Console.WriteLine("error name");
                            break;
                        }
                        Console.WriteLine("add student score:");
                        if (int.TryParse(Console.ReadLine(), out int score))
                        {
                            names.Add(newName);
                            studentPoints.Add(newName, score);
                            Console.WriteLine($"Student {newName} added!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid score1");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Input name for search"); 
                        string searchName = Console.ReadLine();

                        if (studentPoints.TryGetValue(searchName, out int foundScore))
                        {
                            Console.WriteLine($"Student: {searchName}, Score: {foundScore}");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Input student name for update:");
                        string updateName = Console.ReadLine();

                        if (studentPoints.ContainsKey(updateName))
                        {
                            Console.WriteLine("Input new Score:");

                            if(int.TryParse(Console.ReadLine(), out int newScore))
                            {
                                studentPoints[updateName] = newScore;
                                Console.WriteLine("Succsess!");
                            }
                            else
                            {
                                Console.WriteLine("Error input");
                            }
                        }
                        break;

                    case "4":
                        Console.WriteLine("Enter 4 for DIsplay all students");
                        if(names.Count == 0)
                        {
                            Console.WriteLine("List empty");
                            break;
                        }
                        foreach (var name in names)
                        {
                            Console.WriteLine($"Name: {name}");
                            
                        }
                        break;

                    case "5":
                        Console.WriteLine("exit");
                        return;

                    default:
                        Console.WriteLine("Error Choose ");
                        break;
                }

            }











        }
    }
}
