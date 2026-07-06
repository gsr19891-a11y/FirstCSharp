using Lecture_14_SashinaoDavaleba.Exeption;
using Lecture_14_SashinaoDavaleba.Models;

namespace Lecture_14_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CryptoPayment myCripto = new CryptoPayment();

            myCripto.WalletAddress = "0x123333";
            myCripto.CryptoType = "Bitcoin";

            try
            {


                myCripto.ProcessPayment();
            }
            catch (PaymentExeption ex)
            {

                Console.WriteLine(ex.Message);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          



            PayPalPayment payPalPayment = new PayPalPayment();
            payPalPayment.Email = "sdasda@gma";
            payPalPayment.ProcessPayment();


        }
    }
}
