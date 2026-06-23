using Lecture_10.Enums;
using Lecture_10.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"../../../Data/CarsData.txt";

        string[] lines = File.ReadAllLines(path);

        Car[] cars = new Car[lines.Length];

        //int index = 0;

        //foreach (var item in lines)
        //{
        //    Console.WriteLine(item);
        //    

        //}


        Car c1 = new Car("Toyota", "Corolla", 2022, 25000, Color.White);
        Car c2 = new Car("Toyota", "Corolla", 2022, 25000, Color.White);

        Console.WriteLine(c1.Equals(c2));//true


        for (int i = 0; i < lines.Length; i++)
        {

            string[] parts = lines[i].Split(',');
            Car car = new Car();

            car.Maker = parts[0];
            car.Model = parts[1];
            car.Year = int.Parse(parts[2]);
            car.Price = decimal.Parse(parts[3]);
            car.Color = (Color)Enum.Parse(typeof(Color), parts[4]);

           

            cars[i] = car;


        }

        foreach (var item in cars)
        {
            Console.WriteLine(item.ToString());
            
        }


        Student student = new Student();

        student.Name = "John";
        student.Age = 30;
        student.GPA = 3.5;

        Teacher teacher = new Teacher();
        teacher.Name = "John";
        teacher.Age = 30;
        teacher.Salary = 3000;

        teacher.GetSalary();

    }

}
//virtual - შეუძლია შვილმა override გაუკეთოს და შეუძლია არ გაუკეთოს.

//abstract - სავალდებულო override.

//აბსტრაკტული კლსაცი new ვერ იქნება