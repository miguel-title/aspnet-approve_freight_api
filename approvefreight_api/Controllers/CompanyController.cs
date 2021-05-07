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
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<companyResponse>> GetCompany([FromHeader] string authorization)
        {
            companyResponse responseData = new companyResponse();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<company> _data = new List<company>();
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
                    var companydatas = from e in _context.Empresas
                                      orderby e.NomFantasia ascending
                                      select new
                                      {
                                          nom_famtasia = e.NomFantasia,
                                          cod_empresa = e.CodEmpresa
                                      };
                    foreach (var companydata in companydatas)
                    {
                        company _company = new company();
                        _company.cod_empresa = companydata.cod_empresa;
                        _company.nom_fantasia = companydata.nom_famtasia;
                        _data.Add(_company);
                    }
                }
            }catch(Exception ex){

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
