using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CST.Demo.Ticketing.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CST.Demo.Web.Pages.Ticketing
{
    public class TicketsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ICollection<TicketListDto> Tickets
        {
            get; 
            private set;
        } = new List<TicketListDto>();

        public TicketsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(Constants.TicketingHttpClientName);
        }

        public async Task OnGet()
        {
            var ticketResponse = await _httpClient.GetAsync("ticketing/");
            if (!ticketResponse.IsSuccessStatusCode)
            {
                return;
            }

            var contentString = await ticketResponse.Content.ReadAsStringAsync();
            Tickets = JsonSerializer.Deserialize<List<TicketListDto>>(contentString);
        }
    }
}