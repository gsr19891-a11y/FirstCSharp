using System.Numerics;

namespace Lecture_13
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Money m = new();

            m.Value = 100;

            m++;

            Console.WriteLine(m);








        }
    }




    public class Money
    {

        public decimal Value;


        public static Money operator ++(Money m)
        {
            m.Value += 1;
            return m;
        }


        public static Money operator +(Money m, Money m2)
        {

            //return new Money()
            //{
            //    Value = m.Value + m2.Value,
            //};


            Money m3 = new Money();
            m3.Value = m.Value + m2.Value;

            return m3;


        }


        //-------------------
        //==
        public static bool operator ==(Money m, Money m2)
        {

            return m.Value == m2.Value;
       
        }

        public static bool operator !=(Money m, Money m2)
        {

            return m.Value != m2.Value;

        }

        //--------------------
        //>|<
        //>=|<=

        public static bool operator >(Money m, Money m2)
        {

            return m.Value > m2.Value;

        }
        public static bool operator <(Money m, Money m2)
        {

            return m.Value < m2.Value;

        }

        //------------------------------


        public static Money operator %(Money m, Money m2)
        {
            m.Value = m.Value % m2.Value;

            return m;

        }








        public override string? ToString()
        {
            return $"{Value}";
        }
    }






}
