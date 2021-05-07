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
            //

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
                                        join pe in _context.PrazoEntregas on p.CodPrazoEntrega equals pe.CodPrazoEntrega into tmp1
                                        from tmp1result in tmp1.DefaultIfEmpty()
                                        join pc in _context.ProtocoloCotacaos on p.CodProtocolo equals pc.CodProtocolo into tmp2
                                        from tmp2result in tmp2.DefaultIfEmpty()
                                        where (
                                        from ap in _context.AprovacaoAlcada
                                        join al in _context.AlcadaAprovacaos on ap.CodAlcadaAprovacao equals al.CodAlcadaAprovacao
                                        where ap.CodProtocolo == p.CodProtocolo && al.CodTipoAlcadaAprovacao == 2 && ap.DatAprovacao == null
                                        select 0
                                        ).Count() > 0
                                        select p
                                       ).Count();

                    totalOcurrences = (from p in _context.Protocolos
                                       join ue in _context.UnidadeEmpresas on p.CodUnidadeEmpresa equals ue.CodUnidadeEmpresa
                                       join ot in _context.OcorrenciaTransportes on p.CodOcorrenciaTransporteAcao equals ot.CodOcorrenciaTransporte
                                        join aa in _context.AprovacaoAlcada on p.CodProtocolo equals aa.CodProtocolo
                                        where p.CodOcorrenciaTransporteAcao == aa.CodOcorrenciaTransporte
                                        join r in _context.Romaneios on p.CodRomaneio equals r.CodRomaneio
                                        join l in _context.Localidades on p.CodLocalidade equals l.CodLocalidade
                                        join mop in _context.MotivoOcorrenciaPadraos on ot.CodMotivoOcorrenciaPadrao equals mop.CodMotivoOcorrenciaPadrao
                                        join t in _context.Transportadoras on r.CodTransportadora equals t.CodTransportadora
                                        join u in _context.Usuarios on aa.CodUsuarioValidador equals u.CodUsuario
                                        where aa.DatAprovacao == null && (from ao in _context.AprovadorOcorrencia where ao.CodUsuario == 855 && ao.CodUnidadeEmpresa == ue.CodUnidadeEmpresa select ao.CodAlcadaAprovacao).Contains(aa.CodAlcadaAprovacao)
                                        select new
                                        {
                                            p.CodProtocolo,
                                            cliente = (from erp in _context.EventoErps where p.CodProtocolo == erp.CodProtocolo select erp.NomCliente).FirstOrDefault(),
                                            mop.DscMotivoOcorrenciaPadrao,
                                            t.NomFantasia,
                                            dat_saida = r.DatSaida.ToString(),
                                            dat_limite_entrega = p.DatLimiteEntrega.ToString(),
                                            VALOR = p.ValFretePeso + p.ValTaxaTotal,
                                            p.ValidacaoAcaoTransportadora,
                                            u.NomUsuario,
                                            l.SglUnidadeFederacao
                                        }
                                        ).Distinct().Count();

                    totalExpensivesShipping = (
                                            from p in _context.Protocolos
                                            join ue in _context.UnidadeEmpresas on p.CodUnidadeEmpresa equals ue.CodUnidadeEmpresa
                                            join ns in _context.NivelServicos on p.CodNivelServico equals ns.CodNivelServico
                                            join t in _context.Transportadoras on p.CodTransportadora equals t.CodTransportadora
                                            join pe in _context.PrazoEntregas on p.CodPrazoEntrega equals pe.CodPrazoEntrega into tmp1
                                            from tmp1result in tmp1.DefaultIfEmpty()
                                            join pc in _context.ProtocoloCotacaos on p.CodProtocolo equals pc.CodProtocolo into tmp2
                                            from tmp2result in tmp2.DefaultIfEmpty()
                                            where (from ap in _context.AprovacaoAlcada
                                                    join al in _context.AlcadaAprovacaos on ap.CodAlcadaAprovacao equals al.CodAlcadaAprovacao
                                                    where ap.CodProtocolo == p.CodProtocolo && al.CodTipoAlcadaAprovacao == 5 && ap.DatAprovacao == null
                                                    select 0).Count() > 0
                                            select p
                                            ).Count();
                    totalRevalidations = (
                                            from p in _context.Protocolos
                                            join l in _context.Localidades on p.CodLocalidade equals l.CodLocalidade
                                            join ue in _context.UnidadeEmpresas on p.CodUnidadeEmpresa equals ue.CodUnidadeEmpresa
                                            join ot in _context.OcorrenciaTransportes on p.CodOcorrenciaTransporteAcao equals ot.CodOcorrenciaTransporte
                                            join mop in _context.MotivoOcorrenciaPadraos on ot.CodMotivoOcorrenciaPadrao equals mop.CodMotivoOcorrenciaPadrao
                                            join t in _context.Transportadoras on p.CodTransportadora equals t.CodTransportadora
                                            join r in _context.Romaneios on p.CodRomaneio equals r.CodRomaneio
                                            where p.DatAcaoTransportadora == null && (p.IndAcaoTransportadora == null ? false : p.IndAcaoTransportadora) == true 
                                            && (p.ValidacaoAcaoTransportadora == null ? "" : p.ValidacaoAcaoTransportadora) == ""
                                            select p
                                            ).Count();
                    totalUnsuccessfulCollection = (
                                                    from p in _context.Protocolos
                                                    join r in _context.Romaneios on p.CodRomaneio equals r.CodRomaneio
                                                    where (from ap in _context.AprovacaoAlcada
                                                           join al in _context.AlcadaAprovacaos on ap.CodAlcadaAprovacao equals al.CodAlcadaAprovacao
                                                           where ap.CodProtocolo == p.CodProtocolo && al.CodTipoAlcadaAprovacao == 3 && ap.DatAprovacao == null
                                                           select 0).Count() > 0
                                                    select p
                                                    ).Count();
                    totalProtocolsWeight = (
                                            from p in _context.Protocolos
                                            join ue in _context.UnidadeEmpresas on p.CodUnidadeEmpresa equals ue.CodUnidadeEmpresa
                                            where (from ap in _context.AprovacaoAlcada
                                                   join al in _context.AlcadaAprovacaos on ap.CodAlcadaAprovacao equals al.CodAlcadaAprovacao
                                                   where ap.CodProtocolo == p.CodProtocolo && al.CodTipoAlcadaAprovacao == 4 && ap.DatAprovacao == null
                                                   select 0).Count() > 0
                                            select p
                                            ).Count();
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
