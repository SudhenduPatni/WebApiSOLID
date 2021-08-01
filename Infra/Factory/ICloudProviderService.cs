using Core.Entity;
using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Factory
{
    public interface ICloudProviderService 
    {
        Core.Utils.Util.CloudProvider CloudProvider { get; }
        IBaseRepository<Client> GetCloudProvider();
    }
}
