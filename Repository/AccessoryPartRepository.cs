using Component_Processing.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Component_Processing.Repository
{
    public class AccessoryPartRepository:IAccessoryPartRepository
    {
        private static List<AccessoryPart> parts = new List<AccessoryPart>() {
        new AccessoryPart{Charges=300,DurationTaken = DateTime.Now.AddDays(2) }
        
        };

        public AccessoryPart GetAccessoryPart(ProcessDetailsInputs input)
        {
            return parts.First();
        }




    }
}
