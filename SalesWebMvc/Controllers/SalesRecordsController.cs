using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordServices _salesRecordServices;

        public SalesRecordsController(SalesRecordServices salesRecordServices)
        {
            _salesRecordServices = salesRecordServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData[nameof(minDate)] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData[nameof(maxDate)] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordServices.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData[nameof(minDate)] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData[nameof(maxDate)] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordServices.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
