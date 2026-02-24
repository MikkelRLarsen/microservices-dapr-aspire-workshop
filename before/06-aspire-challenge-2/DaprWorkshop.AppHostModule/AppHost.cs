using Projects;
using System.Collections.Immutable;
using System.Xml.Linq;
using CommunityToolkit.Aspire.Hosting.Dapr;


var builder = DistributedApplication.CreateBuilder(args);

var daprResources = ImmutableHashSet.Create("../../aspire-shared/resources-simple");

var pizzastorefront = builder.AddProject<PizzaStorefront>("pizzastorefrontservice")
    .WithDaprSidecar(new DaprSidecarOptions
    {
        AppId = "pizza-storefront",
        DaprHttpPort = 3502,

        ResourcesPaths = daprResources
    });

builder.Build().Run();
