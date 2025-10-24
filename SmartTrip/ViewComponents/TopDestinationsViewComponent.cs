using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SmartTrip.Services.Interfaces;

namespace SmartTrip.ViewComponents
{
    public class TopDestinationsViewComponent : ViewComponent
    {
        private readonly ITourService _tourService;
        private readonly IMemoryCache _cache;

        public TopDestinationsViewComponent(ITourService tourService, IMemoryCache cache)
        {
            _tourService = tourService;
            _cache = cache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            const string cacheKey = "TopDestinations";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<SmartTrip.Models.Destination>? destinations))
            {
                destinations = await _tourService.GetTopDestinationsAsync(3);

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                _cache.Set(cacheKey, destinations, cacheOptions);
            }

            return View(destinations);
        }
    }
}
