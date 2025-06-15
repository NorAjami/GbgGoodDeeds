using GbgGoodDeeds.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GbgGoodDeeds.Web.ViewModels;
using GbgGoodDeeds.Domain.Models;

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


    // GET: /GoodDeed/Add
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    // POST: /GoodDeed/Add
    [HttpPost]
    public async Task<IActionResult> Add(AddGoodDeedViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var newDeed = new GoodDeed
        {
            Title = model.Title,
            Description = model.Description,
            Neighborhood = model.Neighborhood
        };

        await _repository.CreateAsync(newDeed);

        TempData["Success"] = "Gärningen har sparats!";
        return RedirectToAction("Today");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MarkAsCompleted(string id)
    {
        var success = await _repository.MarkAsCompletedAsync(id);

        if (success)
            TempData["Success"] = "Gärningen är nu markerad som utförd! 💚";
        else
            TempData["Error"] = "Något gick fel 😥";

        return RedirectToAction("Today");
    }

    [HttpGet]
    public async Task<IActionResult> History()
    {
        var deeds = await _repository.GetAllAsync();
        return View(deeds.OrderByDescending(d => d.CreatedAt));
    }

}
