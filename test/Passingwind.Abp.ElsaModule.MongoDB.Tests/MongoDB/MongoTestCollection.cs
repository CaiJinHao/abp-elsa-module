using Xunit;

namespace Passingwind.Abp.ElsaModule.MongoDB;

[CollectionDefinition(Name)]
#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
public class MongoTestCollection : ICollectionFixture<MongoDbFixture>
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
{
    public const string Name = "MongoDB Collection";
}
