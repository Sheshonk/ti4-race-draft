using DomainObjects;
using DomainObjects.Entities;
using DomainObjects.Repositories;
using ti4_race_draft_api.DTO;

namespace ti4_race_draft_api.Services
{
    public interface IGameService
    {
        Task<Dict<Guid>> Create(string[] name);
    }
    
    public class GameService : IGameService
    {
        private readonly IDbRepository<Game> _gameRepo;
        private readonly IDbRepository<Player> _playerRepo;
        
        public GameService(IDbRepository<Game> gameRepo, IDbRepository<Player> playerRepo)
        {
            _gameRepo = gameRepo;
            _playerRepo = playerRepo;
            _db = tiContext;
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
                }); ;
            }

            return new Dict<Guid>() { Id = publicId };
        }
    }
}
