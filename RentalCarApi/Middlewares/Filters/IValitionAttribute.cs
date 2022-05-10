using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace RentalCarApi.Middlewares.Filters
{
    public interface IValitionAttribute
    {
        [JsonIgnore]
        HttpStatusCode Status { get; set; }
        [JsonIgnore]
        string ErrorMessage { get; set; }
        IEnumerable<IValidationError> Errors { get; set; }
    }
}