using Newtonsoft.Json;

namespace Duco.Freubel.Models
{
   public class AppConfiguration
   {
      [JsonProperty("environment")]
      public string Environment { get; set; }
   }
}
