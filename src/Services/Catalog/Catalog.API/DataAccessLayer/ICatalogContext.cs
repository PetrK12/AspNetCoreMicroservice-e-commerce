using System;
using Catalog.API.Models;
using MongoDB.Driver;

namespace Catalog.API.DataAccessLayer
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}

