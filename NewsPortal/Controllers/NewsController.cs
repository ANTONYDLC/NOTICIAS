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

        // Aquí agregas la acción Details
        public async Task<IActionResult> Details(int id)
        {
            // Obtener post
            var post = await _httpClient.GetFromJsonAsync<Post>($"posts/{id}");
            if (post == null)
            {
                return NotFound();
            }

            // Obtener autor
            var author = await _httpClient.GetFromJsonAsync<User>($"users/{post.UserId}");

            // Obtener comentarios del post
            var comments = await _httpClient.GetFromJsonAsync<List<Comment>>($"comments?postId={id}");

            // Preparar un ViewModel para pasar todo junto a la vista
            var vm = new PostDetailsViewModel
            {
                Post = post,
                Author = author,
                Comments = comments
            };

            return View(vm);
        }
    }
}
