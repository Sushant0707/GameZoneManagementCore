using GameZoneManagement.Models;

namespace GameZoneManagement.Services
{
    public interface IUserService
    {
        Task<bool> Register(TblGameZone GameZone);

        Task<TblGameZone> Login(string UserEmail, string UserPassword);

        Task<bool> AddModeAsync(string modeName);

        List<TblGameMode> GetGameModes();
    }
}
