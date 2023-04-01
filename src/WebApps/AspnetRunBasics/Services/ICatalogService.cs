using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspWebApp.Models;

namespace AspWebApp.Services
{
	public interface ICatalogService
	{
		Task<IEnumerable<CatalogModel>> GetCatalog();
		Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category);
		Task<CatalogModel> GetCatalog(string id);
		Task<CatalogModel> CreateCatalog(CatalogModel catalog);
	}
}

