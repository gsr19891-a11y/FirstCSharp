namespace Lection3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*


            bool isValid = byte.TryParse(Console.ReadLine(), out byte age);

            if (age >= 18 && isValid)
            {
                Console.WriteLine("you can vote");
            }
            else if(age <18 && isValid)
            {
                Console.WriteLine("you cant vote");
            }
            else
            {
                Console.WriteLine("Error input");
            }


            */

            //-----------------------------------


            /*
            int num1, num2, num3;

            bool isNum1Valid = int.TryParse(Console.ReadLine(), out num1);
            bool isNum2Valid = int.TryParse(Console.ReadLine(), out num2);
            bool isNum3Valid = int.TryParse(Console.ReadLine(), out num3);

            int result = num3;



            if(isNum1Valid && isNum2Valid && isNum3Valid && num1 > num2 && num1 > num3)
            {
                result = num1;
            }else if (isNum1Valid && isNum2Valid && isNum3Valid && num2 > num1 && num2 > num3)
            {
                result = num2;
            }else if (isNum1Valid && isNum2Valid && isNum3Valid && num3 > num2 && num3 > num1)
            {
                result = num3;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine(result);
            */

            //-----------------------------------

            /*
            int num1, num2;

            bool isNum1Valid = int.TryParse(Console.ReadLine(), out num1);
            bool isNum2Valid = int.TryParse(Console.ReadLine(), out num2);

            if (isNum1Valid && isNum2Valid && num1 == num2)
            {
                Console.WriteLine((num1 + num2) * 3);
            }
            else
            {
                Console.WriteLine(num1 + num2);
            }
            */

            //============================================================================

            //SWITCH

            //ჩამოთვლადი

            int z = 11;

            /*
            switch (z)
            {
                case 5:
                    Console.WriteLine("z is 5");
                    break;

                case 8:
                case 9:
                    Console.WriteLine("z is 8 or 9");
                    break;

                case 10:
                    Console.WriteLine("z is 10");
                    return;//მთლიანად ხურავს მეთოდს და აღარ განახორციელებს შემდეგ კოდს

                case 11:
                    Console.WriteLine("z is ");
                    goto case 15;//გადადის 15 კეისზე და იქიდან განახორციელებს კოდს

                case 15:
                    Console.WriteLine("z is 15");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;

            }
            */

            //break, return, goto


            //davaleba 1

            /*
            int day;
            Console.WriteLine("Enter a number to display the day:");
            bool isDayValid = int.TryParse(Console.ReadLine(), out day);

            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;

                case 2:
                    Console.WriteLine("Tuesday");
                    break;

                case 3:
                    Console.WriteLine("Wednesday");
                    break;

                case 4:
                    Console.WriteLine("Thursday");
                    break;

                case 5:
                    Console.WriteLine("Friday");
                    break;

                case 6:
                    Console.WriteLine("Saturday");
                    break;

                case 7:
                    Console.WriteLine("Sunday");
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            */

            //------------------------------------------------

            //davaleba 2 

           bool isScoreValid = int.TryParse(Console.ReadLine(), out int score);

            if (isScoreValid) {
                switch (score)
                {
                    case >= 90:
                         Console.WriteLine("A");
                        break;

                    case >= 70:
                         Console.WriteLine("B");
                        break;
                    case >= 50:
                         Console.WriteLine("C");
                        break;

                    default:
                        Console.WriteLine("F");
                        break;
                }
            }
            else
                Console.WriteLine("error input");
            }







            }
    }
}
