using AutoMapper;
using IKEAProduct_API.Models;
using IKEAProduct_API.Models.API;
using IKEAProduct_API.Models.Dto;
using IKEAProduct_API.Models.Dto.ReadDTO;
using IKEAProduct_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IKEAProduct_API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IProductRepository _dbProduct;        
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper, IProductRepository dbProduct)        {
            _dbProduct = dbProduct;
            _response = new APIResponse();
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetProducts()
        {
            try
            {
                var productsList = (await _dbProduct.GetAllAsync(includeProperties: "ProductType,ProductColours.Colour"))
                .OrderByDescending(p => p.CreatedDate)
                .ToList();

                _response.Result = _mapper.Map<List<ProductListItemDto>>(productsList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return _response;
            }
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var product = await _dbProduct.GetAsync(u => u.Id == id, includeProperties: "ProductType,ProductColours.Colour");
                if (product == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ProductDTO>(product);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateProduct([FromBody] ProductCreateDTO createDTO)
        {
            try
            {
                if (await _dbProduct.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Product already Exists!");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Product product = _mapper.Map<Product>(createDTO);
                await _dbProduct.CreateAsync(product);
                ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
                _response.Result = createDTO;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetProduct", new { id = product.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
