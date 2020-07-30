#addin "Cake.Npm"

var configuration = Argument("configuration", "Debug");
var target = Argument("target", "Default");


Task("Restore")
	.Does(() =>
{
	DotNetCoreRestore("wedding.sln", new DotNetCoreRestoreSettings
	{
		Sources = new[] { "https://dotnet.myget.org/F/aspnetcore-ci-dev/api/v3/index.json",
				"https://dotnet.myget.org/F/aspnetcore-tools/api/v3/index.json",
				"https://api.nuget.org/v3/index.json",
				"https://dotnet.myget.org/F/templating/api/v3/index.json",
				"https://dotnet.myget.org/F/dotnet-core/api/v3/index.json",
				"https://dotnet.myget.org/F/aspnetcore-2-0-0-preview1-no-timestamp/api/v3/index.json",
				"https://dotnet.myget.org/F/aspnetcore-dev/api/v3/index.json",
				"https://dotnet.myget.org/F/dotnet-web/api/v3/index.json",
				"https://dotnet.myget.org/F/cli-deps/api/v3/index.json",
				"https://dotnet.myget.org/f/roslyn/api/v3/index.json",
				"https://dotnet.myget.org/f/symreader-native/api/v3/index.json",
				"https://www.myget.org/F/xunit/api/v3/index.json",
				"https://api.nuget.org/v3/index.json",
				"https://dotnet.myget.org/F/vstest/api/v3/index.json",
				"https://dotnet.myget.org/F/dotnet-buildtools/api/v3/index.json",
				"https://dotnet.myget.org/F/aspnet-feb2017-patch/api/v3/index.json", 
				"https://dotnet.myget.org/F/dotnet-web/api/v3/index.json",
		}
	});
});
 
Task("WeddingPortal build")
	.IsDependentOn("Restore")
	.Does(() =>
{
	DotNetCoreBuild("./wedding/wedding.csproj");
});

Task("Default")
	.IsDependentOn("WeddingPortal build");

RunTarget(target);