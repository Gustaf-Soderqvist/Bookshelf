using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Bookshelf.Core.Interfaces.Gateways.Repositories;
using Bookshelf.Infrastructure.Data.Repositories;

namespace Bookshelf.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(DataRepository<>))
                .As(typeof(IDataRepository<>))
                .InstancePerDependency();

        }
    }
}
