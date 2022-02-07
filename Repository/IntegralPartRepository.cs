using Component_Processing.Models;
using Component_Processing.Repository;
using System;
using System.Collections.Generic;

namespace Component_Processing.Repository
{
    public class IntegralPartRepository :IIntegralPartRepository
    {
        private static List<IntegralPart> parts = new List<IntegralPart>() {
        new IntegralPart{IsPriorityRequest=true,Charges=700,DurationTaken=DateTime.Now.AddDays(2) },
        new IntegralPart{IsPriorityRequest=false,Charges=500,DurationTaken= DateTime.Now.AddDays(5) }
        };
        
        public IntegralPart GetIntegralPart(ProcessDetailsInputs input )
        {
            IntegralPart ipart = parts.Find(part => part.IsPriorityRequest == input.IsPriorityRequest);

            return ipart;
            //PriceAndDuration pricedetails = new PriceAndDuration
            //{ duration = ipart.DurationTaken, charges = ipart.Charges };
            //return pricedetails;
           
        }




    }
}
