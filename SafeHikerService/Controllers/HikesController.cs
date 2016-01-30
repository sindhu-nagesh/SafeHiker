using SafeHikerService.Factory;
using SafeHikerService.Models;
using Storage;
using System.Web.Http;

namespace SafeHikerService.Controllers
{
    public class HikesController : ApiController
    {
        public ReturnCode Post(string userEmail, [FromBody] HikeDataModel data)
        {
            AzureStorageServiceClient storageClient = ServiceFactory.GetStorageClient();
            if (storageClient.HikeStorage.HasEntity())
            {
                return ReturnCode.Duplicate;
            }
            else
            {
                storageClient.HikeStorage.InsertEntity();
            }
            return ReturnCode.Success;
        }
    }
}