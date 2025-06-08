using AutoMapper;
using IKEAProduct_API.Models;
using IKEAProduct_API.Models.API;
using IKEAProduct_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IKEAColour_API.Controllers
{
    [Route("api/colours")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IColourRepository _dbColour;
        private readonly IMapper _mapper;
        public ColourController(IMapper mapper, IColourRepository dbColour)
        {
            _dbColour = dbColour;
            _response = new APIResponse();
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetColours()
        {
            try
            {
                var coloursList = await _dbColour.GetAllAsync();

                _response.Result = _mapper.Map<List<ColourDTO>>(coloursList);
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
