using Core.Entity;
using Dapper;
using Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Clients
{
    public class AzureRepository : IAzureRepository
    {
        private readonly IConfiguration configuration;

        public AzureRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddClientAsync(Client entity)
        {
            var sql = "Insert into Client ([ClientGlobalId],[Name],[CloudProviderId],[CreatedDate],[ModifiedDate],[Status]) VALUES (@ClientGlobalId,@Name,@CloudProviderId,@CreatedDate,@ModifiedDate,@Status)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<List<Client>> GetAllAsync()
        {
            var sql = "SELECT * FROM Client";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Client>(sql);
                return result.ToList();
            }
        }

        public async Task<Client> GetByIdAsync(Guid clientGlobalId)
        {
            var sql = "SELECT * FROM Client WHERE ClientGlobalId = @clientGlobalId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Client>(sql, new { ClientGlobalId = clientGlobalId });
                return result;
            }
        }

        public async Task<List<Files>> GetAllFilesAsync()
        {
            var sql = "SELECT * FROM Files";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Files>(sql);
                return result.ToList();
            }
        }

        public async Task<List<Files>> GetAllFilesByIdAsync(Guid clientGlobalId)
        {
            var sql = "SELECT * FROM Files WHERE ClientGlobalId = @clientGlobalId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Files>(sql);
                return result.ToList();
            }
        }

        public async Task SaveFileAsync(Files entity)
        {
            var sql = "Insert into Files ([FileGlobalId],[ClientGlobalId],[Name],[FileContent],[CreatedDate],[ModifiedDate]) VALUES (@FileGlobalId,@ClientGlobalId,@Name,@FileContent,@CreatedDate,@ModifiedDate)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
            }
        }

        public async Task<Files> GetFileAsync(Guid fileGlobalId)
        {
            var sql = "SELECT * FROM Files WHERE FileGlobalId = @fileGlobalId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<Files>(sql, new { FileGlobalId = fileGlobalId });
            }
        }

        public async Task<int> AddSubscriptionAsync(Subscription entity)
        {
            var sql = "Insert into Subscription ([ClientGlobalId],[Subscribed],[FromDate],[ToDate],[Charges]) VALUES (@ClientGlobalId,@Subscribed,@FromDate,@ToDate,@Charges)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                return await connection.ExecuteAsync(sql, entity);
            }
        }

        public async Task<List<Subscription>> GetAllSubscriptionAsync()
        {
            var sql = "SELECT * FROM Subscription";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Subscription>(sql);
                return result.ToList();
            }
        }

        public async Task<Subscription> GetSubscriptionByIdAsync(Guid clientGlobalId)
        {
            var sql = "SELECT * FROM Subscription WHERE ClientGlobalId = @clientGlobalId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<Subscription>(sql, new { ClientGlobalId = clientGlobalId });
            }
        }
    }
}
