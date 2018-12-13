using AppSettings;
using Microsoft.AspNetCore.Mvc;
using Mvc.Plugin.Vehicles.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Mvc.Plugin.Vehicles.Controllers
{
    public class VehiclesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            var stringTask = client.GetStringAsync(Constants.ApiUrl + "Vehicles");
            var msg = await stringTask;

            SampleViewModel model = new SampleViewModel();
            model.Initialize(msg);

            return View(model);
        }
    }
}
