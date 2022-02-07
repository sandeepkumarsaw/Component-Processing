
using Component_Processing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Component_Processing.Services
{
    public interface IComponentProcessService
    {


        public Task<string> GetPackagingAndDeliveryAmount(ProcessDetailsInputs input);

        public PriceAndDuration GetIntegralPart(ProcessDetailsInputs input);
        public PriceAndDuration GetAccessoryPart(ProcessDetailsInputs input);

        public  Task<string> GetCompleteProcess(CompleteProcessInput input);
    }
}