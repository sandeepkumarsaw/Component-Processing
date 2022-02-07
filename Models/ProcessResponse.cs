using System;

namespace Component_Processing.Models
{
    public class ProcessResponse
    {
        public int RequestId { get; set; }

        public int ProcessingCharge { get; set; }

        public int PackagingAndDeliveryCharge { get; set; }

        public DateTime DateOfDelivery { get; set; }

    }
}
