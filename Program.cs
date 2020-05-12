using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace CovidSafeWatch
{
  public class Program
  {
    public static async Task<int> Main(string[] args) =>
      await Bootstrapper
        .Factory
        .CreateWeb(args)
        .AddSetting(Keys.Host, "covidsafe.watch")
        .AddSetting(WebKeys.ValidateAbsoluteLinks, true)
        .AddSetting(Keys.LinksUseHttps, true)
        .AddSetting(WebKeys.MirrorResources, true)
        .AddSetting("EditLink", Config.FromDocument((doc, ctx) => "https://github.com/covidsave-watch/website/edit/master/input/" + doc.Source.GetRelativeInputPath()))
        .AddPipelines()
        .RunAsync();
  }
}