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
    public class ChannelController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<channelResponse>> GetChannel([FromHeader] string authorization)
        {
            channelResponse responseData = new channelResponse();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<channel> _data = new List<channel>();
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
                    var channeldatas = from c in _context.CanalVenda
                                           orderby c.DscCanalVenda ascending
                                           select new
                                           {
                                               c.DscCanalVenda,
                                               c.CodCanalVenda
                                           };
                    foreach (var channeldata in channeldatas)
                    {
                        channel _channel = new channel();
                        _channel.dsc_canal_venda = channeldata.DscCanalVenda;
                        _channel.cod_canal_venda = channeldata.CodCanalVenda;
                        _data.Add(_channel);
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
