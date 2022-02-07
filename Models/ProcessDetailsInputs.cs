using System;

namespace Component_Processing.Models
{
    public class ProcessDetailsInputs
    {
        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string CreditCardNumber { get; set; }

    public  bool IsPriorityRequest {get;set;}

        public  DefectiveComponetDetail ComponentDetail { get; set; }

}
}
