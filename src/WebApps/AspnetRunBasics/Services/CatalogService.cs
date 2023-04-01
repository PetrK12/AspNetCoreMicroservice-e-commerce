using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AspWebApp.Models;

namespace AspWebApp.Services
{
	public class CatalogService : ICatalogService
	{
        private readonly HttpClient _client;

		public CatalogService(HttpClient client)
		{
            _client = client;
		}

        public Task<CatalogModel> CreateCatalog(CatalogModel catalog)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            throw new NotImplementedException();
        }

        public Task<CatalogModel> GetCatalog(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogModel>> GetCatalogByCategory()
        {
            throw new NotImplementedException();
        }
    }
}

