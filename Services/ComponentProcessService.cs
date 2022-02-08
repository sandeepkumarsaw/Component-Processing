using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Component_Processing.Models;
using Component_Processing.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Component_Processing.Services
{
    public class ComponentProcessService : IComponentProcessService
    {
        private readonly IAccessoryPartRepository ARepo;
        private readonly IIntegralPartRepository IRepo;
        public ComponentProcessService( IAccessoryPartRepository arepo, IIntegralPartRepository irepo )
        {
            ARepo = arepo;
            IRepo = irepo;
        }
        public  async Task<string> GetPackagingAndDeliveryAmount( ProcessDetailsInputs input )
        {
            using ( var httpClient = new HttpClient() )
            { 
                var value= new StringContent(JsonConvert.SerializeObject(new PackagingAndDeliveryInput { componentType = input.ComponentDetail.ComponentType, count = input.ComponentDetail.Quantity }), Encoding.UTF8, "application/json");
                using ( var response = await httpClient.PostAsync( "https://packagingdelivery.azurewebsites.net/api/PackagingAndDelivery", value ) )
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    string v = JsonConvert.DeserializeObject<string>( apiResponse );
                    //dynamic  v = JObject.Parse(apiResponse);
                    return v;
                }
            }
        }

        public PriceAndDuration GetIntegralPart( ProcessDetailsInputs input )
        {
            IntegralPart part = IRepo.GetIntegralPart( input );

            PriceAndDuration pricedetails = new PriceAndDuration
            {
                duration = part.DurationTaken, charges = part.Charges
            };
            return pricedetails;
        }

        public PriceAndDuration GetAccessoryPart( ProcessDetailsInputs input )
        {
            AccessoryPart part = ARepo.GetAccessoryPart( input );

            PriceAndDuration pricedetails = new PriceAndDuration
            {
                duration = part.DurationTaken, charges = part.Charges
            };
            return pricedetails;
        }

        public async Task<string> GetCompleteProcess( CompleteProcessInput input )
        {
            using ( var httpClient = new HttpClient() )
            {
                var value = new StringContent(JsonConvert.SerializeObject( new PaymentInput {creditCardNumber = input.CreditCardNumber, creditLimit = input.CreditLimit, processingCharge = input.ProcessingCharge} ), Encoding.UTF8, "application/json" );
                using ( var response = await httpClient.PostAsync( "https://paymentmicroserviceazure.azurewebsites.net/Payment", value ) )
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    string v = JsonConvert.DeserializeObject<string>( apiResponse );
                    //dynamic  v = JObject.Parse(apiResponse);
                    return v;
                }
            }
        }
    }
}
