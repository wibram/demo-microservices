﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService( HttpClient client )
        {
            _httpClient = client ?? throw new ArgumentNullException( nameof( client ) );
        }

        public async Task<BasketModel> GetBasket( string userName )
        {
            var response = await _httpClient.GetAsync( $"/Basket/{userName}" );
            return await response.ReadContentAs<BasketModel>();
        }

        public async Task<BasketModel> UpdateBasket( BasketModel model )
        {
            var response = await _httpClient.PostAsJson( $"/Basket", model );
            if ( response.IsSuccessStatusCode )
            {
                return await response.ReadContentAs<BasketModel>();
            }
            else
            {
                throw new ApplicationException( "Something went wrong while calling the api." );
            }
        }

        public async Task CheckoutBasket( BasketCheckoutModel model )
        {
            var response = await _httpClient.PostAsJson( $"/Basket/Checkout", model );
            if ( !response.IsSuccessStatusCode )
            {
                throw new ApplicationException( "Something went wrong while calling the api." );
            }
        }
    }
}
