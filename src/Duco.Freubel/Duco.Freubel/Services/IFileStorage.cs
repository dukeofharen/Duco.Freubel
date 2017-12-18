using System.Threading.Tasks;

namespace Duco.Freubel.Services
{
   public interface IFileStorage
   {
      Task<byte[]> ReadAsBytes(string filename);

      Task<string> ReadAsString(string filename);
   }
}
