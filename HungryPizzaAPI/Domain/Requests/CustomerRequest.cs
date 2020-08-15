using Newtonsoft.Json;

namespace HungryPizzaAPI.Domain.Requests
{
    public class CustomerRequest
    {
        [JsonProperty("cpf")]
        public string CPF { get; set; }
        [JsonProperty("cep")]
        public string CEP { get; set; }
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}