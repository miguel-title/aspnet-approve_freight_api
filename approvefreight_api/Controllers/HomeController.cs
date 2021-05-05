using approvefreight_api.Helper.Extension;
using approvefreight_api.Helper.TokenManager;
using approvefreight_api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace approvefreight_api.Controllers
{
    [ApiController]
    [Route("v1/[controller]/get-totals")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<getTotalResponse>> GetTotals([FromHeader] string authorization)
        {
            //Initial response data
            getTotalResponse responseData = new getTotalResponse();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            getTotal _totalData = new getTotal();
            responseData.data = _totalData;

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

            var totalRedChannels = 0;
            var totalOcurrences = 0;
            var totalExpensivesShipping = 0;
            var totalRevalidations = 0;
            var totalUnsuccessfulCollection = 0;
            var totalProtocolsWeight = 0;

            if (!ModelState.IsValid)
            {
                //header
                header.RequestStatus = "400";
                header.LanguageCode = "En";
                header.ReturnMessage = String.Join(", ", ModelState.GetErrorMessages().ToArray());
                //data
                responseData.data = null;
                return BadRequest(responseData);
            }

            //Get Detail Info
            try
            {
                using (TMSWORKANAContext _context = new TMSWORKANAContext())
                {
                    totalRedChannels = (from p in _context.Protocolos
                                        join ue in _context.UnidadeEmpresas on p.CodUnidadeEmpresa equals ue.CodUnidadeEmpresa
                                        join ns in _context.NivelServicos on p.CodNivelServico equals ns.CodNivelServico
                                        join t in _context.Transportadoras on p.CodTransportadora equals t.CodTransportadora
                                        join pe in _context.PrazoEntregas on p.CodPrazoEntrega equals pe.CodPrazoEntrega
                                        join pc in _context.ProtocoloCotacaos on p.CodProtocolo equals pc.CodProtocolo
                                        select p
                                        ).Count();
                }
            }
            catch (Exception ex)
            {
                //header
                header.RequestStatus = "400";
                header.LanguageCode = "En";
                header.ReturnMessage = ex.Message;
                //data
                responseData.data = null;
                return BadRequest(responseData);
            }

            //Insert the data to the response
            //header
            header.RequestStatus = "200";
            header.LanguageCode = "En";
            //data
            _totalData.totalRedChannels = totalRedChannels;
            _totalData.totalOcurrences = totalOcurrences;
            _totalData.totalExpensivesShipping = totalExpensivesShipping;
            _totalData.totalRevalidations = totalRevalidations;
            _totalData.totalUnsuccessfulCollection = totalUnsuccessfulCollection;
            _totalData.totalProtocolsWeight = totalProtocolsWeight;

            return Ok(responseData);

        }
    }
}
