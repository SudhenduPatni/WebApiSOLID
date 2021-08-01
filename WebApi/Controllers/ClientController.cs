using AutoMapper;
using Core.Entity;
using Core.Utils;
using Data;
using Infra.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Core.Utils.Util;

namespace WebApi.Controllers
{
    /// <summary>
    /// Client controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClientController> _logger;
        private readonly IAzureRepository _clientRepository;
        private readonly IDropboxRepository _clientLocalRepository;
        private readonly ICloudProviderFactory _cloudProviderFactory;
        //private readonly ICloudProviderService _clientRepositoryService;

        public ClientController(IMapper mapper, ILogger<ClientController> logger, IAzureRepository clientRepository, IDropboxRepository clientLocalRepository, ICloudProviderFactory cloudProviderFactory)
        {
            _mapper = mapper;
            _logger = logger;
            _cloudProviderFactory = cloudProviderFactory;
            _clientRepository = clientRepository;
            _clientLocalRepository = clientLocalRepository;
        }

        /// <summary>
        /// Endpoint used to get all clients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Client> clients = new List<Client>();

            foreach (int cloudProviderId in Enum.GetValues(typeof(CloudProvider)))
            {
                var _repository = GetProvider(cloudProviderId);
                var result = await _repository.GetAllAsync();
                clients.AddRange(result);

            }

            return Ok(clients);
        }

        /// <summary>
        /// Endpoint used to get client by id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("{clientGlobalId}/{cloudProviderId}")]
        public async Task<IActionResult> GetById(Guid clientGlobalId, int cloudProviderId)
        {
            var _repository = GetProvider(cloudProviderId);
            var data = await _repository.GetByIdAsync(clientGlobalId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        /// <summary>
        /// Endpoint used to add new client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddClient(Client client)
        {
            var _repository = GetProvider(client.CloudProviderId);
            client.ClientGlobalId = Guid.NewGuid();
            client.CreatedDate = DateTime.UtcNow;
            client.ModifiedDate = DateTime.UtcNow;
            client.Status = true;

            var data = await _repository.AddClientAsync(client);
            return Ok(data);
        }

        /// <summary>
        /// Endpoint used to get all files
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpGet("files")]
        public async Task<IActionResult> GetAllFiles()
        {
            List<Files> files = new List<Files>();

            foreach (int cloudProviderId in Enum.GetValues(typeof(CloudProvider)))
            {
                var _repository = GetProvider(cloudProviderId);
                var result = await _repository.GetAllFilesAsync();
                files.AddRange(result);

            }

            return Ok(files);
        }

        /// <summary>
        /// Endpoint used to get all files by client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpGet("files/{clientGlobalId}/{cloudProviderId}")]
        public async Task<IActionResult> GetAllFilesById(Guid clientGlobalId, int cloudProviderId)
        {
            List<Files> files = new List<Files>();

            var _repository = GetProvider(cloudProviderId);
            var result = await _repository.GetAllFilesByIdAsync(clientGlobalId);
            files.AddRange(result);

            return Ok(files);
        }

        /// <summary>
        /// Endpoint used to add new file
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost("file/{clientGlobalId}/{cloudProviderId}")]
        public async Task<IActionResult> SaveFile(List<IFormFile> files, Guid clientGlobalId, int cloudProviderId)
        {
            var _repository = GetProvider(cloudProviderId);
            var target = Path.Combine(Util.LOCAL_PATH);

            files.ForEach(async file =>
            {
                var guid = Guid.NewGuid();

                if (file.Length <= 0) return;
                var filePath = string.Format(Util.LOCAL_PATH + @"\" + guid + "." + Path.GetExtension(file.FileName));

                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Files uploadFile = new Files();
                    uploadFile.Name = Path.GetFileName(file.FileName);
                    uploadFile.FileGlobalId = guid;
                    uploadFile.ClientGlobalId = clientGlobalId;
                    uploadFile.CreatedDate = DateTime.UtcNow;
                    uploadFile.ModifiedDate = DateTime.UtcNow;

                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        uploadFile.FileContent = target.ToArray();
                    }
                    await file.CopyToAsync(stream);
                    await _repository.SaveFileAsync(uploadFile);
                }
            });

            return Ok();
        }

        /// <summary>
        /// Endpoint used to download file
        /// </summary>
        /// <param name="fileGlobalId"></param>
        /// <param name="cloudProviderId"></param>
        /// <returns></returns>
        [HttpGet("file/{fileGlobalId}/{cloudProviderId}")]
        public async Task<IActionResult> GetFile(Guid fileGlobalId, int cloudProviderId)
        {
            var _repository = GetProvider(cloudProviderId);
            string mimeType = "text/plain";
            var entity = await _repository.GetFileAsync(fileGlobalId);
            return new FileContentResult(entity.FileContent, mimeType)
            {
                FileDownloadName = entity.Name
            };
        }

        /// <summary>
        /// Endpoint used to add client subscription
        /// </summary>
        [HttpPost("subscription/{cloudProviderId}")]
        public async Task<IActionResult> AddSubscription(Subscription subscription, int cloudProviderId)
        {
            var _repository = GetProvider(cloudProviderId);
            subscription.Subscribed = true;
            subscription.FromDate = DateTime.UtcNow;
            subscription.ToDate = DateTime.UtcNow.AddMonths(12);

            var data = await _repository.AddSubscriptionAsync(subscription);
            return Ok(data);
        }

        /// <summary>
        /// Endpoint used to get all subscription
        /// </summary>
        /// <returns></returns>
        [HttpGet("subscription")]
        public async Task<IActionResult> GetAllSubscription()
        {
            List<Subscription> subscriptions = new List<Subscription>();

            foreach (int cloudProviderId in Enum.GetValues(typeof(CloudProvider)))
            {
                var _repository = GetProvider(cloudProviderId);
                var result = await _repository.GetAllSubscriptionAsync();
                subscriptions.AddRange(result);
            }

            return Ok(subscriptions);
        }

        /// <summary>
        /// Endpoint used to get subscription by id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("subscription/{clientGlobalId}/{cloudProviderId}")]
        public async Task<IActionResult> GetSubscriptionById(Guid clientGlobalId, int cloudProviderId)
        {
            var _repository = GetProvider(cloudProviderId);
            var data = await _repository.GetSubscriptionByIdAsync(clientGlobalId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        private IBaseRepository<Client> GetProvider(int cloudProviderId)
        {
            //var providerService = _cloudProviderFactory.Create(cloudProviderId);
            //return providerService.GetCloudProvider();
            if (cloudProviderId == 1)
                return _clientRepository;
            else if (cloudProviderId == 2)
                return _clientLocalRepository;
            else
                return null;
        }
    }
}
