using Newtonsoft.Json;

namespace RentalCarApi.Middlewares.Filters
{
    public interface IValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}