using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.ModelImage
{
    public interface IImageService
    {
        Task<UploadResult> UploadAsync(IFormFile image);
    }
}