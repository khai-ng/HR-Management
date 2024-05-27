﻿using MongoDB.Driver;

namespace Core.MongoDB.Context
{
    public interface IMongoContext: IMongoContextResolver
    {
        void AddCommand(Func<Task> func);
        IMongoCollection<T> GetCollection<T>();
    }
}
