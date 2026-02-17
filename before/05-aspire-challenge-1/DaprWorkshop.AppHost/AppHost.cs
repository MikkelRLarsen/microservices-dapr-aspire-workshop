using CommunityToolkit.Aspire.Hosting.Dapr;
using System.Collections.Immutable;

var builder = DistributedApplication.CreateBuilder(args);

var daprResources = ImmutableHashSet.Create("../../aspire-shared/resources-simple");

builder.AddProject<Projects.PizzaOrder>("pizzaorderservice")
	.WithDaprSidecar(new DaprSidecarOptions
	{
		AppId = "pizza-order",
		DaprHttpPort = 3501,
		ResourcesPaths = daprResources
	});

builder.Build().Run();
