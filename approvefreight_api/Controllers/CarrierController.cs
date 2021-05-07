using approvefreight_api.Helper.TokenManager;
using approvefreight_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<carrierResponse>> GetCarrier([FromHeader] string authorization)
        {
            carrierResponse responseData = new carrierResponse();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<carrier> _data = new List<carrier>();
            responseData.data = _data;

            //Check the JWT Authentication
            if (String.IsNullOrEmpty(authorization))
            {
                //header
                header.RequestStatus = "401";
                header.LanguageCode = "En";
                //data
                responseData.data = null;
                return Unauthorized(responseData);
            }

            if (!authorization.StartsWith("Bearer", StringComparison.OrdinalIgnoreCase))
            {
                //header
                header.RequestStatus = "401";
                header.LanguageCode = "En";
                //data
                responseData.data = null;
                return Unauthorized(responseData);
            }

            var token = authorization.Substring("Bearer".Length).Trim();
            string username = TokenManager.ValidateToken(token);
            if (string.IsNullOrEmpty(username))
            {
                //header
                header.RequestStatus = "401";
                header.LanguageCode = "En";
                //data
                responseData.data = null;
                return Unauthorized(responseData);
            }


            try
            {
                using (TMSWORKANAContext _context = new TMSWORKANAContext())
                {
                    var carrierdatas = from t in _context.Transportadoras
                                       orderby t.NomFantasia ascending
                                       select new
                                       {
                                           t.CodTransportadora,
                                           t.NomFantasia
                                       };
                    foreach (var carrierdata in carrierdatas)
                    {
                        carrier _carrier = new carrier();
                        _carrier.cod_transportadora = carrierdata.CodTransportadora;
                        _carrier.nom_fantasia = carrierdata.NomFantasia;
                        _data.Add(_carrier);
                    }
                }
            }
            catch (Exception ex)
            {

                //header
                header.RequestStatus = "500";
                header.LanguageCode = "En";
                header.ReturnMessage = ex.Message;
                //data
                responseData.data = null;
                return StatusCode(500, responseData);
            }

            //Insert the data to the response
            //header
            header.RequestStatus = "200";
            header.LanguageCode = "En";

            return Ok(responseData);
        }
    }
}
