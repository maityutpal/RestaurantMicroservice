using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ConfigConstants.ApiType.POST,
                Data = productDto,
                Url = ConfigConstants.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ConfigConstants.ApiType.DELETE,
                Url = ConfigConstants.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            //var url = ConfigConstants.ProductAPIBase + "/api/products";
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ConfigConstants.ApiType.GET,
                Url = ConfigConstants.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ConfigConstants.ApiType.GET,
                Url = ConfigConstants.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ConfigConstants.ApiType.PUT,
                Data = productDto,
                Url = ConfigConstants.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }
    }
}
