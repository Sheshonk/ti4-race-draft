using DomainObjects.Entities;
using DomainObjects.Repositories;
using Microsoft.EntityFrameworkCore;
using ti4_race_draft_api.DTO;

namespace ti4_race_draft_api.Services
{
    public interface IPlayerService
    {
        Task<Guid> ClaimPlayer(PlayerClaim claim);
        Task UnclaimPlayer(PlayerUnclaim unclaim);
    }

    public class PlayerService : IPlayerService
    {
        private readonly IDbRepository<Draft> _draftRepo;
        private readonly IDbRepository<Player> _playerRepo;
        
        public PlayerService(IDbRepository<Draft> draftRepo, IDbRepository<Player> playerRepo)
        {
            _draftRepo = draftRepo;
            _playerRepo = playerRepo;
        }
        
        public async Task<Guid> ClaimPlayer(PlayerClaim claim)
        {
            var token = Guid.NewGuid();
            var player = _playerRepo.Get(claim.PlayerId).FirstOrDefault();

            if (player.AuthToken.HasValue)
                throw new Exception("Already has token");

            player.AuthToken = token;
            player.IsAdmin = !(await _playerRepo.Search().AnyAsync(_ => _.GameId == claim.GameId && _.IsAdmin == true));
            await _playerRepo.Update(player);

            if (!(await _draftRepo.Search().AnyAsync(_ => _.PlayerId == claim.PlayerId)))
            {
                var drafts = _draftRepo.Search().Where(_ => _.PlayerId == null).OrderBy(_ => _.Order).Take(2).ToList();
                foreach (var draft in drafts)
                {
                    draft.PlayerId = claim.PlayerId;
                    await _draftRepo.Update(draft);
                }
            }

            return token;
        }

        public async Task UnclaimPlayer(PlayerUnclaim unclaim)
        {
            var adminToken = await _playerRepo.Search().Where(_ => _.GameId == unclaim.GameId && _.IsAdmin == true).Select(_ => _.AuthToken).FirstOrDefaultAsync();

            if (adminToken != unclaim.AdminAuthToken)
                throw new AccessViolationException("Invalid admin token");

            var player = await _playerRepo.Get(unclaim.PlayerId).FirstOrDefaultAsync();
            player.AuthToken = null;
            await _playerRepo.Update(player);
        }
    }
}
