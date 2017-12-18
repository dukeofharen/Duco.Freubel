using System.Threading.Tasks;
using Duco.Freubel.Models;
using Duco.Freubel.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ConfigService))]
namespace Duco.Freubel.Services
{
   public class ConfigService : IConfigService
   {
      private static AppConfiguration _config;
      private readonly IFileStorage _fileStorage;

      public ConfigService()
      {
         _fileStorage = DependencyService.Get<IFileStorage>();
      }

      public async Task<AppConfiguration> GetAppConfiguration()
      {
         if(_config != null)
         {
            return _config;
         }

         string configText = await _fileStorage.ReadAsString("config.json");
         _config = JsonConvert.DeserializeObject<AppConfiguration>(configText);
         return _config;
      }
   }
}
