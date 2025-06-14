using GbgGoodDeeds.Domain.Models;

namespace GbgGoodDeeds.Application.Interfaces;

/// <summary>
/// Interface för att hantera goda gärningar (CRUD).
/// </summary>
public interface IGoodDeedRepository
{
    Task<IEnumerable<GoodDeed>> GetAllAsync();
    Task<GoodDeed?> GetByIdAsync(string id);
    Task CreateAsync(GoodDeed deed);
    Task<bool> MarkAsCompletedAsync(string id);
}
