using GameZoneManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace GameZoneManagement.Services
{
    public class UserService : IUserService
    {
        private readonly GameZoneContext _context;

        public UserService(GameZoneContext context)
        {
            _context = context;
        }

        public async Task<bool> Register(TblGameZone gameZone)
        {
            _context.TblGameZones.Add(gameZone);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TblGameZone> Login(string email, string password)
        {
            return await _context.TblGameZones
                .FirstOrDefaultAsync(u => u.UserEmail == email && u.UserPassword == password);
        }

        public async Task<bool> AddModeAsync(string modeName)
        {
            if (string.IsNullOrWhiteSpace(modeName))
                return false;

            // Optional: check for duplicate mode
            bool exists = await _context.TblGameModes.AnyAsync(m => m.GamingMode == modeName);
            if (exists)
                return false;

            var newMode = new TblGameMode
            {
                GamingMode = modeName
            };

            _context.TblGameModes.Add(newMode);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<TblGameMode> GetGameModes()
        {
            return _context.TblGameModes.ToList();
        }
    }
}
