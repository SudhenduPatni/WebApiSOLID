using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Factory
{
    public interface ICloudProviderFactory
    {
        ICloudProviderService Create(int cloudProviderId);
    }
}
