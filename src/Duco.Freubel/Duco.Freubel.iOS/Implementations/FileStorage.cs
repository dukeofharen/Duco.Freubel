using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duco.Freubel.iOS.Implementations;
using Duco.Freubel.Services;

[assembly: Xamarin.Forms.Dependency(typeof(FileStorage))]
namespace Duco.Freubel.iOS.Implementations
{
   public class FileStorage : IFileStorage
   {
      public Task<byte[]> ReadAsBytes(string filename)
      {
         var data = File.ReadAllBytes(filename);

         if (data != null)
         {
            data = CleanByteOrderMark(data);
         }

         return Task.FromResult(data);
      }

      public async Task<string> ReadAsString(string filename)
      {
         var data = await ReadAsBytes(filename);

         if (data == null)
         {
            return string.Empty;
         }

         return Encoding.UTF8.GetString(data);
      }

      private byte[] CleanByteOrderMark(byte[] bytes)
      {
         var bom = new byte[] { 0xEF, 0xBB, 0xBF };
         var empty = Enumerable.Empty<byte>();
         if (bytes.Take(3).SequenceEqual(bom))
         {
            return bytes.Skip(3).ToArray();
         }

         return bytes;
      }
   }
}