using CommunityToolkit.Aspire.Hosting.Dapr;
using Projects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace DaprWorkshop.AppHost
{
    internal static class PizzaStorefrontModule
    {
        public static IResourceBuilder<ProjectResource> AddPizzaStorefrontService(
            this IDistributedApplicationBuilder builder,
            string name = "pizzastorefrontservice")
        {
            var daprResources = ImmutableHashSet.Create("../../aspire-shared/resources-simple");

            var pizzastorefront = builder.AddProject<PizzaStorefront>(name)
                .WithDaprSidecar(new DaprSidecarOptions
                {
                    AppId = "pizza-storefront",
                    DaprHttpPort = 3502,

                    ResourcesPaths = ImmutableHashSet<string>.Empty
                });

            return pizzastorefront;
        }
    }
}
