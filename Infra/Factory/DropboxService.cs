using Core.Entity;
using Core.Utils;
using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Factory
{
    public class DropboxService : ICloudProviderService
    {
        public Util.CloudProvider CloudProvider => Util.CloudProvider.DropBox;
        private IAzureRepository _clientLocalRepository;

        public DropboxService(IAzureRepository clientLocalRepository)
        {
            _clientLocalRepository = clientLocalRepository;
        }

        public IBaseRepository<Client> GetCloudProvider()
        {
            return _clientLocalRepository;
        }
    }
}
