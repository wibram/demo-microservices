using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService( HttpClient httpClient )
        {
            _httpClient = httpClient ?? throw new ArgumentNullException( nameof( httpClient ) );
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogs()
        {
            var response = await _httpClient.GetAsync( "/api/v1/Catalog" );
            return await response.ReadContentAs<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalog( string id )
        {
            var response = await _httpClient.GetAsync( $"/api/v1/Catalog/{id}" );
            return await response.ReadContentAs<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogsByCategory( string category )
        {
            var response = await _httpClient.GetAsync( $"/api/v1/Catalog/GetProductByCategory/{category}" );
            return await response.ReadContentAs<List<CatalogModel>>();
        }
    }
}
