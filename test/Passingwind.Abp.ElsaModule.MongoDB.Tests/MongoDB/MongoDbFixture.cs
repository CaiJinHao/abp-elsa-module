using System;
using Mongo2Go;

namespace Passingwind.Abp.ElsaModule.MongoDB;

public class MongoDbFixture : IDisposable
{
    public static readonly MongoDbRunner MongoDbRunner;
    public static readonly string ConnectionString;

    static MongoDbFixture()
    {
        MongoDbRunner = MongoDbRunner.Start(singleNodeReplSet: true, singleNodeReplSetWaitTimeout: 20);
        ConnectionString = MongoDbRunner.ConnectionString;
    }

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
    public void Dispose()
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
    {
        MongoDbRunner?.Dispose();
    }
}
