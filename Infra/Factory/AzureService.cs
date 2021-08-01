using Core.Entity;
using Core.Utils;
using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Factory
{
    public class AzureService : ICloudProviderService
    {
        private IAzureRepository _clientRepository;

        public AzureService(IAzureRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Util.CloudProvider CloudProvider => Util.CloudProvider.Azure;

        public IBaseRepository<Client> GetCloudProvider()
        {
            return _clientRepository;
        }
    }
}
