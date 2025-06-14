using GbgGoodDeeds.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GbgGoodDeeds.Web.Controllers;

public class GoodDeedController : Controller
{
    private readonly IGoodDeedRepository _repository;

    public GoodDeedController(IGoodDeedRepository repository)
    {
        _repository = repository;
    }

    // GET: /GoodDeed/Today
    public async Task<IActionResult> Today()
    {
        var allDeeds = await _repository.GetAllAsync();

        // Hämta en slumpmässig gärning
        var random = new Random();
        var deedList = allDeeds.ToList();
        var todayDeed = deedList.Count > 0 ? deedList[random.Next(deedList.Count)] : null;

        return View(todayDeed);
    }
}
