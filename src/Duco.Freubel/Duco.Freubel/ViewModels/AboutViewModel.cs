using Duco.Freubel.Models;
using Duco.Freubel.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace Duco.Freubel.ViewModels
{
   public class AboutViewModel : BaseViewModel
   {
      private readonly IConfigService _configService;
      private readonly AppConfiguration _appConfig;

      public AboutViewModel()
      {
         _configService = DependencyService.Get<IConfigService>();
         _appConfig = Task.Run(() => _configService.GetAppConfiguration()).Result;
         Environment = _appConfig.Environment;
         Title = "About";

         OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
      }

      public ICommand OpenWebCommand { get; }

      string environment = string.Empty;
      public string Environment
      {
         get { return environment; }
         set { SetProperty(ref environment, value); }
      }
   }
}