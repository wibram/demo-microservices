using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService( HttpClient client )
        {
            _httpClient = client ?? throw new ArgumentNullException( nameof( client ) );
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUsername( string userName )
        {
            var response = await _httpClient.GetAsync( $"/Order/{userName}" );
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}
