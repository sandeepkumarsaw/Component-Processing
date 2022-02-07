using Component_Processing.Models;
using Component_Processing.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Component_Processing.Controllers
{
    [ApiController]
    [Route("api")]
    public class ComponentProcessingController : Controller
    {
        private readonly IComponentProcessService myService;
        public ComponentProcessingController(IComponentProcessService service)
        {
            myService = service;
        }
        [HttpPost("ProcessDetail")]

      public IActionResult getprocessdetails(ProcessDetailsInputs process) 
      {
            Task<string> r = myService.GetPackagingAndDeliveryAmount( process );
            try
            {

                int packaginganddeliveryamount = Convert.ToInt32(r.Result);
                ProcessResponse res = new ProcessResponse();

                res.RequestId = 123;
                res.PackagingAndDeliveryCharge = packaginganddeliveryamount;
                if (process.ComponentDetail.ComponentType == "IntegralItem")
                {
                    PriceAndDuration ipandd = myService.GetIntegralPart(process);
                    res.ProcessingCharge = ipandd.charges;
                    res.DateOfDelivery = ipandd.duration;
                }

                else if (process.ComponentDetail.ComponentType == "Accessory")
                {
                    PriceAndDuration apandd = myService.GetAccessoryPart(process);
                    res.ProcessingCharge = apandd.charges;
                    res.DateOfDelivery = apandd.duration;

                }
                else
                {
                    res.ProcessingCharge = 0;
                    res.DateOfDelivery = DateTime.Now;
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
      }



        [HttpPost("CompleteProcessing")]
        public IActionResult CompleteProcess(CompleteProcessInput input)
        {
            Task<string> r = myService.GetCompleteProcess(input);

            try
            {
                if (r.Result == "Deduction failed due to low balance or incorrect card details")
                {
                    return BadRequest(r.Result);
                }

                else
                {
                    return Ok(JObject.Parse("{'res':'Transaction Successful'}"));
                }
            }
            catch(Exception ex)
            {
                return BadRequest(JObject.Parse("{'res':'Transaction Failed'}"));
            }
            
        }
    }
}
