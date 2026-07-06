using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_14_SashinaoDavaleba.Models
{
    internal class CryptoPayment : PaymentMethod
    {
        public string WalletAddress { get; set; }
        public string CryptoType { get; set; }

        public override void ProcessPayment()
        {
            Console.WriteLine($"Processed Crypto payment for {WalletAddress} using {CryptoType}");
        }
    }
}
