using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
	public interface ICatalogService
	{
		Task<IEnumerable<CatalogModel>> GetCatalog();
		Task<IEnumerable<CatalogModel>> GetCatalogByCategory();
		Task<CatalogModel> GetCatalog(string id);
		Task<CatalogModel> CreateCatalog(CatalogModel catalog);
	}
}

