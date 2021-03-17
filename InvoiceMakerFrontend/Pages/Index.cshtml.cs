using InvoiceMakerFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace InvoiceMakerFrontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private HttpClient client;
        public string Name;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            client = factory.CreateClient("languageClient");
        }

        public async Task OnGet()
        {
            var content = await client.GetFromJsonAsync<IList<Language>>("");
            Name = content[0].Name;
        }
    }
}
