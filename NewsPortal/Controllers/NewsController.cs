using Microsoft.AspNetCore.Mvc;
using NewsPortal.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NewsPortal.Controllers
{
    public class NewsController : Controller
    {
        private readonly HttpClient _httpClient;

        public NewsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("JsonPlaceholder");
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _httpClient.GetFromJsonAsync<IEnumerable<Post>>("posts");
            return View(posts);
        }
    }
}
