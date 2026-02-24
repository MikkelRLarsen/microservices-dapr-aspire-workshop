using Aspire.Hosting;
using CommunityToolkit.Aspire.Hosting.Dapr;
using DaprWorkshop.AppHost;
using Dutchskull.Aspire.PolyRepo;
using Projects;
using System.Collections.Immutable;

var builder = DistributedApplication.CreateBuilder(args);

var daprResources = ImmutableHashSet.Create("../../aspire-shared/resources-simple");

builder.AddProject<PizzaOrder>("pizzaorderservice")
	.WithDaprSidecar(new DaprSidecarOptions
	{
		AppId = "pizza-order",
		DaprHttpPort = 3501,
		ResourcesPaths = daprResources
	});

//builder.AddContainer("pizzaorderservice").WithDockerfile("../PizzaOrder/Dockerfile.file")
//	.WithDaprSidecar(new DaprSidecarOptions
//	{
//		AppId = "pizza-order",
//		DaprHttpPort = 3501,
//		ResourcesPaths = daprResources
//	});


//builder.AddProject<PizzaStorefront>("pizzastorefrontservice")
//	.WithDaprSidecar(new DaprSidecarOptions
//	{
//		AppId = "pizza-storefront",
//		DaprHttpPort = 3502,

//        ResourcesPaths = ImmutableHashSet<string>.Empty
//    });

//builder.AddPizzaStorefrontService();

//var pizzaStorefrontRepo = builder.AddRepository(
//	"pizzastorefrontRepo",
//	"")


builder.AddProject<PizzaKitchen>("pizzakitchenservice")
	.WithDaprSidecar(new DaprSidecarOptions
	{
		AppId = "pizza-kitchen",
		DaprHttpPort = 3503,
        ResourcesPaths = ImmutableHashSet<string>.Empty
    });



builder.AddProject<PizzaDelivery>("pizzadeliveryservice")
	.WithDaprSidecar(new DaprSidecarOptions
	{
		AppId = "pizza-delivery",
		DaprHttpPort = 3504,
        ResourcesPaths = ImmutableHashSet<string>.Empty
    });

builder.Build().Run();
