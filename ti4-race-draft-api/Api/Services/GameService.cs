using DomainObjects;
using DomainObjects.Entities;
using DomainObjects.Repositories;
using Microsoft.EntityFrameworkCore;
using ti4_race_draft_api.DTO;

namespace ti4_race_draft_api.Services
{
    public interface IGameService
    {
        Task<Dict<Guid>> Create(string[] name);
    }
    
    public class GameService : IGameService
    {
        private readonly IDbRepository<Draft> _draftRepo;
        private readonly IDbRepository<Game> _gameRepo;
        private readonly IDbRepository<Player> _playerRepo;
        private readonly IDbRepository<Race> _raceRepo;
        
        public GameService(IDbRepository<Draft> draftRepo, IDbRepository<Game> gameRepo, IDbRepository<Player> playerRepo, IDbRepository<Race> raceRepo)
        {
            _draftRepo = draftRepo;
            _gameRepo = gameRepo;
            _playerRepo = playerRepo;
            _raceRepo = raceRepo;
        }

        public async Task<Dict<Guid>> Create(string[] names)
        {
            var publicId = Guid.NewGuid();
            var gameId = await _gameRepo.Create(new Game() { PublicId = publicId });

            names = names.OrderBy(_ => (new Random()).Next()).ToArray();
            for (int x = 0; x < names.Count(); x++)
            {
                await _playerRepo.Create(new Player()
                {
                    AuthToken = null,
                    DraftOrder = x,
                    GameId = gameId,
                    IsAdmin = false,
                    Name = names[x]
                });
            }

            var races = await _raceRepo.Search().Select(_ => _.Id).ToListAsync();
            races = races.OrderBy(_ => (new Random()).Next()).ToList();
            for (int x = 0; x < races.Count(); x++)
            {
                await _draftRepo.Create(new Draft()
                {
                    GameId = gameId,
                    Order = x,
                    RaceId = races[x]
                });
            }

            return new Dict<Guid>() { Id = publicId };
        }
    }
}
