using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_15.Models
{
    internal class CryptoPayment : PaymentMethod
    {
        public string WalletAddress { get; set; }
        public string CryptoType { get; set; }


        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processed Crypto payment for {amount}");
        }


    }





    public enum CryptoType
    {
        Bitcoin,
        Ethereum,
        Litecoin,
        Ripple,
        Dogecoin
    }
}
