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
    public class CompanyUnitController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<companyResponse>> GetCompanyUnit([FromHeader] string authorization)
        {
            companyUnitResponse responseData = new companyUnitResponse();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<companyUnit> _data = new List<companyUnit>();
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
                    var companyunitdatas = from ue in _context.UnidadeEmpresas
                                       join e in _context.Empresas on ue.CodEmpresa equals e.CodEmpresa
                                       where ue.CodUnidadeEmpresaExpedidora == null
                                       orderby ue.NomUnidadeEmpresa ascending
                                       select new
                                       {
                                           NOM_UNIDADE_EMPRESA = ue.NomUnidadeEmpresa + "-" + e.NomFantasia,
                                           ue.CodUnidadeEmpresa
                                       };
                    foreach (var companyunitdata in companyunitdatas)
                    {
                        companyUnit _companyunit = new companyUnit();
                        _companyunit.cod_unidade_empresa = companyunitdata.CodUnidadeEmpresa;
                        _companyunit.nom_unidade_empresa = companyunitdata.NOM_UNIDADE_EMPRESA;
                        _data.Add(_companyunit);
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
