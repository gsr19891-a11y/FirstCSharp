using Practiculi.Models;

namespace Practiculi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>
{
    new Student { Name = "George", LastName = "Beridze", Age = 20, Email = "g.beridze@example.com", Faculty = Enums.Faculty.It, Number = "+995555112233", GPA = 3.8 },
    new Student { Name = "Nino", LastName = "Kapanadze", Age = 21, Email = "n.kapanadze@example.com", Faculty = Enums.Faculty.Bussiness, Number = "+995555445566", GPA = 3.9 },
    new Student { Name = "Luka", LastName = "Masurashvili", Age = 19, Email = "l.masurashvili@example.com", Faculty =Enums.Faculty.Marceting, Number = "+995555778899", GPA = 3.2 },
    new Student { Name = "Maria", LastName = "Ivanova", Age = 22, Email = "m.ivanova@example.com", Faculty = Enums.Faculty.Bussiness, Number = "+995555114477", GPA = 3.5 },
    new Student { Name = "Alexander", LastName = "Smirnov", Age = 20, Email = "a.smirnov@example.com", Faculty = Enums.Faculty.Marceting, Number = "+995555225588", GPA = 2.8 },
    new Student { Name = "Ana", LastName = "Baratamidze", Age = 21, Email = "a.baratamidze@example.com", Faculty = Enums.Faculty.Bussiness, Number = "+995555336699", GPA = 3.7 },
    new Student { Name = "David", LastName = "Kvirikashvili", Age = 23, Email = "d.kvirikashvili@example.com", Faculty = Enums.Faculty.Marceting, Number = "+995555998877", GPA = 4.0 },
    new Student { Name = "Elena", LastName = "Kuznetsova", Age = 19, Email = "e.kuznetsova@example.com", Faculty = Enums.Faculty.It, Number = "+995555665544", GPA = 3.1 },
    new Student { Name = "Teimuraz", LastName = "Shengelia", Age = 22, Email = "t.shengelia@example.com", Faculty = Enums.Faculty.Marceting, Number = "+995555332211", GPA = 3.4 },
    new Student { Name = "Sophia", LastName = "Dias", Age = 20, Email = "s.dias@example.com", Faculty = Enums.Faculty.Bussiness, Number = "+995555775533", GPA = 3.6 }
};

        }
    }
}
