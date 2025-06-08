using AutoMapper;
using IKEAProduct_API.Models;
using IKEAProduct_API.Models.API;
using IKEAProduct_API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IKEAProduct_API.Controllers
{
    [Route("api/productTypes")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IProductTypeRepository _dbProductType;
        private readonly IMapper _mapper;
        public ProductTypeController(IMapper mapper, IProductTypeRepository dbProductType)
        {
            _dbProductType = dbProductType;
            _response = new APIResponse();
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetProductTypes()
        {
            try
            {
                var productTypeList = await _dbProductType.GetAllAsync();

                _response.Result = _mapper.Map<List<ProductTypeDTO>>(productTypeList);
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
    }
}
