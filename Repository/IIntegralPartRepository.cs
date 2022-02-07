
using Component_Processing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Component_Processing.Repository
{
    public interface IIntegralPartRepository
    {
        public IntegralPart GetIntegralPart(ProcessDetailsInputs input);


    }
}