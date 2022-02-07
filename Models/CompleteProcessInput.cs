using System;

namespace Component_Processing.Models
{
    public class CompleteProcessInput
    {
        public int RequestId { get; set; }

        public string  CreditCardNumber { get; set; }

        public int CreditLimit { get; set; }

        public int ProcessingCharge { get; set; }


    }
}
