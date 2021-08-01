using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Factory
{
    public class CloudProviderFactory : ICloudProviderFactory
    {
        private readonly IEnumerable<ICloudProviderService> _cloudProviderServices;

        public CloudProviderFactory(IEnumerable<ICloudProviderService> cloudProviderServices)
        {
            _cloudProviderServices = cloudProviderServices;
        }

        public ICloudProviderService Create(int cloudProviderId)
        {
            var cloudProviderService = _cloudProviderServices.FirstOrDefault(cd => (int)cd.CloudProvider == cloudProviderId);
            if (cloudProviderService == null)
            {
                throw new Exception($"No provider found for the give cloud provider : {cloudProviderId}");
            }

            return cloudProviderService;
        }
    }
}
