using DomainObjects.Entities;
using DomainObjects.Repositories;
using Microsoft.EntityFrameworkCore;
using ti4_race_draft_api.DTO;

namespace ti4_race_draft_api.Services
{
    public interface IDraftService
    {
        Task Create(DraftPick draft);
    }
    
    public class DraftService : IDraftService
    {
        private readonly IDbRepository<Draft> _draftRepo;
        private readonly IDbRepository<Game> _gameRepo;
        private readonly IDbRepository<Group> _groupRepo;
        private readonly IDbRepository<Player> _playerRepo;
        
        public DraftService(IDbRepository<Draft> draftRepo, IDbRepository<Game> gameRepo, IDbRepository<Group> groupRepo, IDbRepository<Player> playerRepo)
        {
            _draftRepo = draftRepo;
            _gameRepo = gameRepo;
            _groupRepo = groupRepo;
            _playerRepo = playerRepo;
        }
        
        public async Task Create(DraftPick draft)
        {
            if (!(await _playerRepo.Search().AnyAsync(_ => _.Id == draft.PlayerId && _.AuthToken == draft.AuthToken)))
                throw new AccessViolationException("auth token mismatch");
            if (!(await _gameRepo.Search().AnyAsync(_ => _.Id == draft.GameId && _.CurrentPlayerId == draft.PlayerId)))
                throw new AccessViolationException("not current player's turn to draft");
            if (!(await _draftRepo.Search().AnyAsync(_ => _.PlayerId == draft.PlayerId && _.GroupId == null && _.Id == draft.DraftId)))
                throw new AccessViolationException("race not in player's hand");

            var pick = await _draftRepo.Get(draft.DraftId).FirstOrDefaultAsync();
            pick.GroupId = draft.GroupId;
            await _draftRepo.Update(pick);

            var game = await _gameRepo.Get(draft.GameId).FirstOrDefaultAsync();
            if (_draftRepo.Search().Any(_ => _.GameId == draft.GameId && _.SuperFaction == false && _.GroupId == null))
            {
                var newCard = await _draftRepo.Search().Where(_ => _.PlayerId == null && _.SuperFaction == false).OrderBy(_ => _.Order).FirstOrDefaultAsync();
                if (newCard != null)
                {
                    newCard.PlayerId = draft.PlayerId;
                    await _draftRepo.Update(newCard);
                }

                var players = await _playerRepo.Search().Where(_ => _.GameId == draft.GameId).OrderBy(_ => _.DraftOrder).ToListAsync();
                var oldPlayer = players.Where(_ => _.Id == game.CurrentPlayerId).FirstOrDefault();
                game.CurrentPlayerId = oldPlayer.DraftOrder == players.Count - 1 ? players[0].Id : players.Where(_ => _.DraftOrder == oldPlayer.DraftOrder + 1).Select(_ => _.Id).FirstOrDefault();
                await _gameRepo.Update(game);
            }
            else
            {
                game.Complete = true;
                game.CurrentPlayerId = null;
                await _gameRepo.Update(game);

                var groups = await _groupRepo.Search().Where(_ => _.GameId == draft.GameId).ToListAsync();
                groups = groups.OrderBy(_ => (new Random()).Next()).ToList();
                groups[0].Winner = true;
                await _groupRepo.Update(groups[0]);
            }
        }
    }
}
