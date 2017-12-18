using Duco.Freubel.Models;
using System.Threading.Tasks;

namespace Duco.Freubel.Services
{
    public interface IConfigService
    {
      Task<AppConfiguration> GetAppConfiguration();
    }
}
