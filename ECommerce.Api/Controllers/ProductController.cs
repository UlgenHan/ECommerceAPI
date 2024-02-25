using AutoMapper;
using ECommerce.Core.DTOs;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Models;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<Product> _service;

        public ProductController(IMapper mapper, IGenericService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAll();

            var productsDtos = _mapper.Map<List<ProductDTO>>(products.ToList());

            return CreateActionResult(ResponseDTO<List<ProductDTO>>.Succes(200, productsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            var productsDtos = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(ResponseDTO<ProductDTO>.Succes(200, productsDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDTO));
            var productsDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(ResponseDTO<ProductDTO>.Succes(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO productDTO)
        {
            _service.Update(_mapper.Map<Product>(productDTO));
            return CreateActionResult(ResponseDTO<ProductDTO>.Succes(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);
             _service.Remove(product);
            return CreateActionResult(ResponseDTO<ProductDTO>.Succes(204));
        }
    }
}
