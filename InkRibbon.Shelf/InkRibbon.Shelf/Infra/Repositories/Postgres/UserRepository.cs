using InkRibbon.Shelf.Application.Static;
using InkRibbon.Shelf.Domain.Entities;
using InkRibbon.Shelf.Domain.Interfaces.Repositories;
using InkRibbon.Shelf.Infra.Context;

namespace InkRibbon.Shelf.Infra.Repositories.Postgres
{
    public class UserRepository : BaseAuroraRepository<User>, IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(AuroraDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task Delete(string idUser)
        {
            try
            {                
                await DeleteAsync(StatementConfig.DeleteUser(idUser));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ao Deletar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<User>> Get(string idUser)
        {
            try
            {
                return await GetListAsync(StatementConfig.SelectUser());
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Insert(User user)
        {
            try
            {
                await InsertAsync(StatementConfig.InsertUser(user), user);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Inserir Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task BulkInsert(IEnumerable<User> user)
        {
            try
            {
                await InsertAsync(StatementConfig.BulkInsertUser(user), user);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Inserir Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                await UpdateAsync(StatementConfig.UpdateUser(user), user);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Update Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task BulkUpdate(IEnumerable<User> user)
        {
            try
            {
                await UpdateAsync(StatementConfig.BulkUpdateUser(user), user);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Update Flower: {0}", ex.Message);
                throw;
            }
        }
    }
}
