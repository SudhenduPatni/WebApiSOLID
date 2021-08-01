using Core.Entity;
using Core.Utils;
using Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Clients
{
    public class DropboxRepository : IDropboxRepository
    {
        private readonly IConfiguration configuration;

        public DropboxRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddClientAsync(Client entity)
        {
            List<Client> clients = await GetAllAsync();
            clients.Add(entity);

            if (File.Exists(Util.CLIENT_DETAILS_PATH))
                File.Delete(Util.CLIENT_DETAILS_PATH);

            string json = JsonConvert.SerializeObject(clients.ToArray());
            File.WriteAllText(Util.CLIENT_DETAILS_PATH, json);

            return clients.Count();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            if (File.Exists(Util.CLIENT_DETAILS_PATH))
            {
                using (StreamReader reader = new StreamReader(Util.CLIENT_DETAILS_PATH))
                {
                    string json = await reader.ReadToEndAsync();

                    return await Task.FromResult(JsonConvert.DeserializeObject<List<Client>>(json));
                }
            }

            return await Task.FromResult(new List<Client>());
        }

        public async Task<Client> GetByIdAsync(Guid clientGlobalId)
        {
            if (File.Exists(Util.CLIENT_DETAILS_PATH))
            {
                using (StreamReader r = new StreamReader(Util.CLIENT_DETAILS_PATH))
                {
                    string json = r.ReadToEnd();
                    List<Client> clients = await GetAllAsync();
                    return clients.FirstOrDefault(c => c.ClientGlobalId == clientGlobalId);
                }
            }

            return null;
        }

        public async Task<List<Files>> GetAllFilesAsync()
        {
            if (File.Exists(Util.FILE_DETAILS_PATH))
            {
                using (StreamReader reader = new StreamReader(Util.FILE_DETAILS_PATH))
                {
                    string json = await reader.ReadToEndAsync();

                    return await Task.FromResult(JsonConvert.DeserializeObject<List<Files>>(json));
                }
            }

            return await Task.FromResult(new List<Files>());
        }

        public async Task<List<Files>> GetAllFilesByIdAsync(Guid clientGlobalId)
        {
            if (File.Exists(Util.FILE_DETAILS_PATH))
            {
                List<Files> files = new List<Files>();
                using (StreamReader reader = new StreamReader(Util.FILE_DETAILS_PATH))
                {
                    string json = await reader.ReadToEndAsync();
                    files = await Task.FromResult(JsonConvert.DeserializeObject<List<Files>>(json));
                }

                return files.FindAll(c => c.ClientGlobalId == clientGlobalId);
            }

            return await Task.FromResult(new List<Files>());
        }

        public async Task SaveFileAsync(Files entity)
        {
            List<Files> files = await GetAllFilesAsync();
            files.Add(entity);

            if (File.Exists(Util.FILE_DETAILS_PATH))
                File.Delete(Util.FILE_DETAILS_PATH);

            string fileJson = JsonConvert.SerializeObject(files.ToArray());
            File.WriteAllText(Util.FILE_DETAILS_PATH, fileJson);
        }

        public async Task<Files> GetFileAsync(Guid fileGlobalId)
        {
            if (File.Exists(Util.FILE_DETAILS_PATH))
            {
                List<Files> files = new List<Files>();
                using (StreamReader reader = new StreamReader(Util.FILE_DETAILS_PATH))
                {
                    string json = await reader.ReadToEndAsync();
                    files = await Task.FromResult(JsonConvert.DeserializeObject<List<Files>>(json));
                }

                return files.FirstOrDefault(c => c.FileGlobalId == fileGlobalId);
            }
            return null;
        }

        public async Task<int> AddSubscriptionAsync(Subscription entity)
        {
            List<Subscription> subscriptions = await GetAllSubscriptionAsync();
            subscriptions.Add(entity);

            if (File.Exists(Util.SUBSCRIPTION_DETAILS_PATH))
                File.Delete(Util.SUBSCRIPTION_DETAILS_PATH);

            string json = JsonConvert.SerializeObject(subscriptions.ToArray());
            File.WriteAllText(Util.SUBSCRIPTION_DETAILS_PATH, json);

            return subscriptions.Count();
        }

        public async Task<List<Subscription>> GetAllSubscriptionAsync()
        {
            if (File.Exists(Util.SUBSCRIPTION_DETAILS_PATH))
            {
                using (StreamReader reader = new StreamReader(Util.SUBSCRIPTION_DETAILS_PATH))
                {
                    string json = await reader.ReadToEndAsync();

                    return await Task.FromResult(JsonConvert.DeserializeObject<List<Subscription>>(json));
                }
            }

            return await Task.FromResult(new List<Subscription>());
        }

        public async Task<Subscription> GetSubscriptionByIdAsync(Guid clientGlobalId)
        {
            if (File.Exists(Util.SUBSCRIPTION_DETAILS_PATH))
            {
                using (StreamReader r = new StreamReader(Util.SUBSCRIPTION_DETAILS_PATH))
                {
                    string json = r.ReadToEnd();
                    List<Subscription> subscriptions = await GetAllSubscriptionAsync();
                    return subscriptions.FirstOrDefault(c => c.ClientGlobalId == clientGlobalId);
                }
            }

            return null;
        }
    }
}
