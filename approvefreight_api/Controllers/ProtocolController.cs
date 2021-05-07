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
    [ApiController]
    public class ProtocolController : ControllerBase
    {

        [Route("v1/[controller]/get-red-channels")]
        [HttpGet]
        public async Task<ActionResult<protocol_redchannel_response>> GetRedChannels([FromHeader] string authorization, 
            [FromQuery] int cod_unidade_empresa, [FromQuery] int cod_empresa, 
            [FromQuery] int cod_transportadora, [FromQuery] string sgl_unidade_federacao, [FromQuery] int cod_canal_venda)
        {
            protocol_redchannel_response responseData = new protocol_redchannel_response();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<protocol_redchannel> _data = new List<protocol_redchannel>();
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
                    var redchannelsfulldatas = from p in _context.Protocolos
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
                                               select new
                                               {
                                                   ns.DscNivelServico,
                                                   p.CodProtocolo,
                                                   t.NomFantasia,
                                                   val_frete = (p.ValFretePeso == null ? 0 : p.ValFretePeso) + (p.ValTaxaTotal == null ? 0 : p.ValTaxaTotal),
                                                   p.DscJustificativaCanalVermelho,
                                                   ALCADA = (
                                                   from aa in _context.AlcadaAprovacaos
                                                   join aal in _context.AprovacaoAlcada on aa.CodAlcadaAprovacao equals aal.CodAlcadaAprovacao
                                                   where aal.CodProtocolo == p.CodProtocolo && aa.CodTipoAlcadaAprovacao == 2 && aal.DatAprovacao == null
                                                   orderby aal.CodAprovacaoAlcada
                                                   select aa.DscAlcadaAprovacao
                                                   ).FirstOrDefault(),
                                                   qtd_dia_prazo = (tmp1result.QtdDiaPrazo == null ? tmp2result.QtdDiaPrazo : tmp1result.QtdDiaPrazo),
                                                   p.CodUnidadeEmpresa, ue.CodEmpresa, p.CodTransportadora, p.CodLocalidade
                                               };
                    if (cod_unidade_empresa != 0)
                    {
                        redchannelsfulldatas = redchannelsfulldatas.Where(x => x.CodUnidadeEmpresa == cod_unidade_empresa);
                    }
                    if (cod_empresa != 0)
                    {
                        redchannelsfulldatas = redchannelsfulldatas.Where(x => x.CodEmpresa == cod_empresa);
                    }
                    if (cod_transportadora != 0)
                    {
                        redchannelsfulldatas = redchannelsfulldatas.Where(x => x.CodTransportadora == cod_transportadora);
                    }
                    if (sgl_unidade_federacao != null && sgl_unidade_federacao.Trim() != "")
                    {
                        string[] sgl_unidade_federacao_list = sgl_unidade_federacao.Split(",");
                        var tmpconditiondatas = from l in _context.Localidades
                                                where sgl_unidade_federacao.Contains(l.SglUnidadeFederacao)
                                                select l.CodLocalidade;

                        redchannelsfulldatas = redchannelsfulldatas.Where(x => tmpconditiondatas.Contains(x.CodLocalidade.Value));
                    }
                    if (cod_canal_venda != 0)
                    {
                        redchannelsfulldatas = redchannelsfulldatas.Where(x => (from erp in _context.EventoErps
                                                                                where x.CodProtocolo == erp.CodProtocolo && erp.CodCanalVenda == cod_canal_venda
                                                                                select 0).Count() > 0);
                    }

                    foreach (var redchannelsfulldata in redchannelsfulldatas)
                    {
                        protocol_redchannel _redchannel = new protocol_redchannel();
                        _redchannel.alcada = redchannelsfulldata.ALCADA;
                        _redchannel.cod_protocolo = redchannelsfulldata.CodProtocolo;
                        _redchannel.dsc_justificativa_canal_vermelho = redchannelsfulldata.DscJustificativaCanalVermelho;
                        _redchannel.dsc_nivel_servico = redchannelsfulldata.DscNivelServico;
                        _redchannel.nom_fantasia = redchannelsfulldata.NomFantasia;
                        _redchannel.qtd_dia_prazo = redchannelsfulldata.qtd_dia_prazo;
                        _redchannel.val_frete = redchannelsfulldata.val_frete;
                        _data.Add(_redchannel);
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


        [Route("v1/[controller]/get-unsuccessful-collection")]
        [HttpGet]
        public async Task<ActionResult<protocol_unsuccessful_collection_response>> GetUnsuccessfulCollection([FromHeader] string authorization,
            [FromQuery] int cod_unidade_empresa, [FromQuery] int cod_empresa,
            [FromQuery] int cod_transportadora, [FromQuery] string sgl_unidade_federacao, [FromQuery] int cod_canal_venda)
        {
            protocol_unsuccessful_collection_response responseData = new protocol_unsuccessful_collection_response();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<protocol_unsuccessful_collection> _data = new List<protocol_unsuccessful_collection>();
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
                    var unsuccessfulCollectionsfulldatas = from p in _context.Protocolos
                                                           join ue in _context.UnidadeEmpresas on p.CodUnidadeEmpresa equals ue.CodUnidadeEmpresa
                                                           join t in _context.Transportadoras on p.CodTransportadora equals t.CodTransportadora
                                                           join r in _context.Romaneios on p.CodRomaneio equals r.CodRomaneio
                                                           where (from ap in _context.AprovacaoAlcada
                                                                  join al in _context.AlcadaAprovacaos on ap.CodAlcadaAprovacao equals al.CodAlcadaAprovacao
                                                                  where ap.CodProtocolo == p.CodProtocolo && al.CodTipoAlcadaAprovacao == 3 && ap.DatAprovacao == null
                                                                  select 0).Count() > 0
                                                           select new
                                                           {
                                                               p.CodProtocolo,
                                                               cliente = (from erp in _context.EventoErps where p.CodProtocolo == erp.CodProtocolo select erp.NomCliente).FirstOrDefault(),
                                                               t.NomFantasia,
                                                               dat_saida = r.DatSaida.ToString(),
                                                               dat_limite_entrega = p.DatLimiteEntrega.ToString(),
                                                               VALOR = "R$" + Math.Round(p.ValFretePeso.Value + p.ValTaxaTotal.Value, 2, MidpointRounding.AwayFromZero).ToString().Replace('.', ','),
                                                               notas = (from erp in _context.EventoErps where p.CodProtocolo == erp.CodProtocolo select string.Join(",", Convert.ToInt32(erp.NumNotaFiscal).ToString().Replace("A", string.Empty))).AsEnumerable(),
                                                               VALOR_ACAO = "R$" + Math.Round((p.ValFretePeso.Value + p.ValTaxaTotal.Value) * (decimal)0.2, 2, MidpointRounding.AwayFromZero).ToString().Replace('.', ','),
                                                               ALCADA = (
                                                               from aa in _context.AlcadaAprovacaos
                                                               join aal in _context.AprovacaoAlcada on aa.CodAlcadaAprovacao equals aal.CodAlcadaAprovacao
                                                               where aal.CodProtocolo == p.CodProtocolo && aa.CodTipoAlcadaAprovacao == 2 && aal.DatAprovacao == null
                                                               orderby aal.CodAprovacaoAlcada
                                                               select aa.DscAlcadaAprovacao
                                                               ).FirstOrDefault(),
                                                               p.CodUnidadeEmpresa, ue.CodEmpresa, p.CodTransportadora, p.CodLocalidade
                                                           };
                    if (cod_unidade_empresa != 0)
                    {
                        unsuccessfulCollectionsfulldatas = unsuccessfulCollectionsfulldatas.Where(x => x.CodUnidadeEmpresa == cod_unidade_empresa);
                    }
                    if (cod_empresa != 0)
                    {
                        unsuccessfulCollectionsfulldatas = unsuccessfulCollectionsfulldatas.Where(x => x.CodEmpresa == cod_empresa);
                    }
                    if (cod_transportadora != 0)
                    {
                        unsuccessfulCollectionsfulldatas = unsuccessfulCollectionsfulldatas.Where(x => x.CodTransportadora == cod_transportadora);
                    }
                    if (sgl_unidade_federacao != null && sgl_unidade_federacao.Trim() != "")
                    {
                        string[] sgl_unidade_federacao_list = sgl_unidade_federacao.Split(",");
                        var tmpconditiondatas = from l in _context.Localidades
                                                where sgl_unidade_federacao.Contains(l.SglUnidadeFederacao)
                                                select l.CodLocalidade;

                        unsuccessfulCollectionsfulldatas = unsuccessfulCollectionsfulldatas.Where(x => tmpconditiondatas.Contains(x.CodLocalidade.Value));
                    }
                    if (cod_canal_venda != 0)
                    {
                        unsuccessfulCollectionsfulldatas = unsuccessfulCollectionsfulldatas.Where(x => (from erp in _context.EventoErps
                                                                                                        where x.CodProtocolo == erp.CodProtocolo && erp.CodCanalVenda == cod_canal_venda
                                                                                                        select 0).Count() > 0);
                    }

                    
                    foreach (var unsuccessfulCollectionsfulldata in unsuccessfulCollectionsfulldatas)
                    {
                        protocol_unsuccessful_collection _unsuccessfulcollection = new protocol_unsuccessful_collection();
                        _unsuccessfulcollection.alcada = unsuccessfulCollectionsfulldata.ALCADA;
                        _unsuccessfulcollection.cod_protocolo = unsuccessfulCollectionsfulldata.CodProtocolo;
                        _unsuccessfulcollection.cliente = unsuccessfulCollectionsfulldata.cliente;
                        _unsuccessfulcollection.dat_limite_entrega = unsuccessfulCollectionsfulldata.dat_limite_entrega;
                        _unsuccessfulcollection.dat_saida = unsuccessfulCollectionsfulldata.dat_saida;
                        _unsuccessfulcollection.nom_fantasia = unsuccessfulCollectionsfulldata.NomFantasia;
                        _unsuccessfulcollection.notas = string.Join(",", unsuccessfulCollectionsfulldata.notas);
                        _unsuccessfulcollection.valor = unsuccessfulCollectionsfulldata.VALOR;
                        _unsuccessfulcollection.valor_acao = unsuccessfulCollectionsfulldata.VALOR_ACAO;
                        _data.Add(_unsuccessfulcollection);
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


        [Route("v1/[controller]/get-expensive-shipping")]
        [HttpGet]
        public async Task<ActionResult<protocol_expensive_shipping_response>> GetExpensiveShipping([FromHeader] string authorization,
            [FromQuery] int cod_unidade_empresa, [FromQuery] int cod_empresa,
            [FromQuery] int cod_transportadora, [FromQuery] string sgl_unidade_federacao, [FromQuery] int cod_canal_venda)
        {
            protocol_expensive_shipping_response responseData = new protocol_expensive_shipping_response();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<protocol_expensive_shipping> _data = new List<protocol_expensive_shipping>();
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
                    var protocolExpensiveShippingfulldatas = from p in _context.Protocolos
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
                                                           select new
                                                           {
                                                               ns.DscNivelServico,
                                                               p.CodProtocolo,
                                                               t.NomFantasia,
                                                               val_frete = (p.ValFretePeso == null ? 0 : p.ValFretePeso) + (p.ValTaxaTotal == null ? 0 : p.ValTaxaTotal),
                                                               ALCADA = (
                                                                  from aa in _context.AlcadaAprovacaos
                                                                  join aal in _context.AprovacaoAlcada on aa.CodAlcadaAprovacao equals aal.CodAlcadaAprovacao
                                                                  where aal.CodProtocolo == p.CodProtocolo && aa.CodTipoAlcadaAprovacao == 2 && aal.DatAprovacao == null
                                                                  select aa.DscAlcadaAprovacao
                                                                  ).FirstOrDefault(),
                                                               qtd_dia_prazo = (tmp1result.QtdDiaPrazo == null ? tmp2result.QtdDiaPrazo : tmp1result.QtdDiaPrazo),
                                                               p.CodRomaneio,
                                                               p.CodUnidadeEmpresa,
                                                               ue.CodEmpresa,
                                                               p.CodTransportadora,
                                                               p.CodLocalidade
                                                           };
                    if (cod_unidade_empresa != 0)
                    {
                        protocolExpensiveShippingfulldatas = protocolExpensiveShippingfulldatas.Where(x => x.CodUnidadeEmpresa == cod_unidade_empresa);
                    }
                    if (cod_empresa != 0)
                    {
                        protocolExpensiveShippingfulldatas = protocolExpensiveShippingfulldatas.Where(x => x.CodEmpresa == cod_empresa);
                    }
                    if (cod_transportadora != 0)
                    {
                        protocolExpensiveShippingfulldatas = protocolExpensiveShippingfulldatas.Where(x => x.CodTransportadora == cod_transportadora);
                    }
                    if (sgl_unidade_federacao != null && sgl_unidade_federacao.Trim() != "")
                    {
                        string[] sgl_unidade_federacao_list = sgl_unidade_federacao.Split(",");
                        var tmpconditiondatas = from l in _context.Localidades
                                                where sgl_unidade_federacao.Contains(l.SglUnidadeFederacao)
                                                select l.CodLocalidade;

                        protocolExpensiveShippingfulldatas = protocolExpensiveShippingfulldatas.Where(x => tmpconditiondatas.Contains(x.CodLocalidade.Value));
                    }
                    if (cod_canal_venda != 0)
                    {
                        protocolExpensiveShippingfulldatas = protocolExpensiveShippingfulldatas.Where(x => (from erp in _context.EventoErps
                                                                                                        where x.CodProtocolo == erp.CodProtocolo && erp.CodCanalVenda == cod_canal_venda
                                                                                                        select 0).Count() > 0);
                    }


                    foreach (var protocolExpensiveShippingfulldata in protocolExpensiveShippingfulldatas)
                    {
                        protocol_expensive_shipping _expensiveshipping = new protocol_expensive_shipping();
                        _expensiveshipping.alcada = protocolExpensiveShippingfulldata.ALCADA;
                        _expensiveshipping.cod_protocolo = protocolExpensiveShippingfulldata.CodProtocolo;
                        _expensiveshipping.cod_romaneio = protocolExpensiveShippingfulldata.CodRomaneio.Value;
                        _expensiveshipping.dsc_nivel_servico = protocolExpensiveShippingfulldata.DscNivelServico;
                        _expensiveshipping.nom_fantasia = protocolExpensiveShippingfulldata.NomFantasia;
                        _expensiveshipping.qtd_dia_prazo = protocolExpensiveShippingfulldata.qtd_dia_prazo.Value;
                        _expensiveshipping.val_frete = protocolExpensiveShippingfulldata.val_frete.Value;
                        _data.Add(_expensiveshipping);
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


        [Route("v1/[controller]/get-ocurrences")]
        [HttpGet]
        public async Task<ActionResult<protocol_ocurrences_response>> GetOcurrences([FromHeader] string authorization,
            [FromQuery] int cod_unidade_empresa, [FromQuery] int cod_empresa,
            [FromQuery] int cod_transportadora, [FromQuery] string sgl_unidade_federacao, [FromQuery] int cod_canal_venda)
        {
            protocol_ocurrences_response responseData = new protocol_ocurrences_response();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<protocol_ocurrences> _data = new List<protocol_ocurrences>();
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
            string useremail = TokenManager.ValidateToken(token);
            if (string.IsNullOrEmpty(useremail))
            {
                //header
                header.RequestStatus = "401";
                header.LanguageCode = "En";
                //data
                responseData.data = null;
                return Unauthorized(responseData);
            }

            int n_userid = 0;
            try
            {
                using (TMSWORKANAContext _context = new TMSWORKANAContext())
                {
                    n_userid = _context.Usuarios.Where(u => u.EndEmail == useremail).Select(u => u.CodUsuario).FirstOrDefault();
                }
            }catch (Exception ex)
            {

                //header
                header.RequestStatus = "500";
                header.LanguageCode = "En";
                header.ReturnMessage = ex.Message;
                //data
                responseData.data = null;
                return StatusCode(500, responseData);
            }

            try
            {
                using (TMSWORKANAContext _context = new TMSWORKANAContext())
                {
                    var protocolOcurrencesfulldatas = from p in _context.Protocolos
                                                      join ue in _context.UnidadeEmpresas on p.CodUnidadeEmpresa equals ue.CodUnidadeEmpresa
                                                      join ot in _context.OcorrenciaTransportes on p.CodOcorrenciaTransporteAcao equals ot.CodOcorrenciaTransporte
                                                      join aa in _context.AprovacaoAlcada on p.CodProtocolo equals aa.CodProtocolo
                                                      where p.CodOcorrenciaTransporteAcao == aa.CodOcorrenciaTransporte
                                                      join r in _context.Romaneios on p.CodRomaneio equals r.CodRomaneio
                                                      join l in _context.Localidades on p.CodLocalidade equals l.CodLocalidade
                                                      join mop in _context.MotivoOcorrenciaPadraos on ot.CodMotivoOcorrenciaPadrao equals mop.CodMotivoOcorrenciaPadrao
                                                      join t in _context.Transportadoras on r.CodTransportadora equals t.CodTransportadora
                                                      join u in _context.Usuarios on aa.CodUsuarioValidador equals u.CodUsuario
                                                      where aa.DatAprovacao == null && (from ao in _context.AprovadorOcorrencia where ao.CodUsuario == n_userid && ao.CodUnidadeEmpresa == ue.CodUnidadeEmpresa select ao.CodAlcadaAprovacao).Contains(aa.CodAlcadaAprovacao)
                                                      select new
                                                      {
                                                          p.CodProtocolo,
                                                          cliente = (from erp in _context.EventoErps where p.CodProtocolo == erp.CodProtocolo select erp.NomCliente).FirstOrDefault(),
                                                          mop.DscMotivoOcorrenciaPadrao,
                                                          t.NomFantasia,
                                                          dat_saida = r.DatSaida.ToString(),
                                                          dat_limite_entrega = p.DatLimiteEntrega.ToString(),
                                                          VALOR = p.ValFretePeso + p.ValTaxaTotal,
                                                          notas = (from erp in _context.EventoErps where p.CodProtocolo == erp.CodProtocolo select string.Join(",", Convert.ToInt32(erp.NumNotaFiscal).ToString().Replace("A", string.Empty))).AsEnumerable(),
                                                          p.ValidacaoAcaoTransportadora,
                                                          u.NomUsuario,
                                                          l.SglUnidadeFederacao,
                                                          p.CodUnidadeEmpresa,
                                                          ue.CodEmpresa,
                                                          p.CodTransportadora,
                                                          p.CodLocalidade
                                                      };
                    if (cod_unidade_empresa != 0)
                    {
                        protocolOcurrencesfulldatas = protocolOcurrencesfulldatas.Where(x => x.CodUnidadeEmpresa == cod_unidade_empresa);
                    }
                    if (cod_empresa != 0)
                    {
                        protocolOcurrencesfulldatas = protocolOcurrencesfulldatas.Where(x => x.CodEmpresa == cod_empresa);
                    }
                    if (cod_transportadora != 0)
                    {
                        protocolOcurrencesfulldatas = protocolOcurrencesfulldatas.Where(x => x.CodTransportadora == cod_transportadora);
                    }
                    if (sgl_unidade_federacao != null && sgl_unidade_federacao.Trim() != "")
                    {
                        string[] sgl_unidade_federacao_list = sgl_unidade_federacao.Split(",");
                        var tmpconditiondatas = from l in _context.Localidades
                                                where sgl_unidade_federacao.Contains(l.SglUnidadeFederacao)
                                                select l.CodLocalidade;

                        protocolOcurrencesfulldatas = protocolOcurrencesfulldatas.Where(x => tmpconditiondatas.Contains(x.CodLocalidade.Value));
                    }
                    if (cod_canal_venda != 0)
                    {
                        protocolOcurrencesfulldatas = protocolOcurrencesfulldatas.Where(x => (from erp in _context.EventoErps
                                                                                                            where x.CodProtocolo == erp.CodProtocolo && erp.CodCanalVenda == cod_canal_venda
                                                                                                            select 0).Count() > 0);
                    }

                    int prevcodprotocolodata = 0;
                    foreach (var protocolOcurrencesfulldata in protocolOcurrencesfulldatas)
                    {
                        if (prevcodprotocolodata == protocolOcurrencesfulldata.CodProtocolo)
                        {
                            prevcodprotocolodata = protocolOcurrencesfulldata.CodProtocolo;
                            continue;
                        }

                        prevcodprotocolodata = protocolOcurrencesfulldata.CodProtocolo;

                        protocol_ocurrences _ocurrences = new protocol_ocurrences();
                        _ocurrences.cliente = protocolOcurrencesfulldata.cliente;
                        _ocurrences.cod_protocolo = protocolOcurrencesfulldata.CodProtocolo;
                        _ocurrences.dat_limite_entrega = DateTime.Parse(protocolOcurrencesfulldata.dat_limite_entrega);
                        _ocurrences.dat_saida = DateTime.Parse(protocolOcurrencesfulldata.dat_saida);
                        _ocurrences.dsc_motivo_ocorrencia_padrao = protocolOcurrencesfulldata.DscMotivoOcorrenciaPadrao;
                        _ocurrences.nom_fantasia = protocolOcurrencesfulldata.NomFantasia;
                        _ocurrences.nom_usuario = protocolOcurrencesfulldata.NomUsuario;
                        _ocurrences.notas = string.Join(",", protocolOcurrencesfulldata.notas);
                        _ocurrences.sgl_unidade_federacao = protocolOcurrencesfulldata.SglUnidadeFederacao;
                        _ocurrences.validaao_acao_transportadora = protocolOcurrencesfulldata.ValidacaoAcaoTransportadora;
                        _ocurrences.valor = protocolOcurrencesfulldata.VALOR.Value;
                        _data.Add(_ocurrences);
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


        [Route("v1/[controller]/get-protocols-weight")]
        [HttpGet]
        public async Task<ActionResult<protocol_weight_response>> GetProtocolsWeight([FromHeader] string authorization,
            [FromQuery] int cod_unidade_empresa, [FromQuery] int cod_empresa,
            [FromQuery] int cod_transportadora, [FromQuery] string sgl_unidade_federacao, [FromQuery] int cod_canal_venda)
        {
            protocol_weight_response responseData = new protocol_weight_response();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<protocol_weight> _data = new List<protocol_weight>();
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
                    var protocolWeightfulldatas = from p in _context.Protocolos
                                                  join ue in _context.UnidadeEmpresas on p.CodUnidadeEmpresa equals ue.CodUnidadeEmpresa
                                                  where (from ap in _context.AprovacaoAlcada
                                                         join al in _context.AlcadaAprovacaos on ap.CodAlcadaAprovacao equals al.CodAlcadaAprovacao
                                                         where ap.CodProtocolo == p.CodProtocolo && al.CodTipoAlcadaAprovacao == 4 && ap.DatAprovacao == null
                                                         select 0).Count() > 0
                                                  select new
                                                  {
                                                      p.CodProtocolo,
                                                      notas = (from erp in _context.EventoErps where p.CodProtocolo == erp.CodProtocolo select string.Join(",", Convert.ToInt32(erp.NumNotaFiscal).ToString().Replace("A", string.Empty))).AsEnumerable(),
                                                      produtos = (from erp in _context.EventoErps
                                                                             join ierp in _context.ItemEventoErps on erp.CodEventoErp equals ierp.CodEventoErp
                                                                             where erp.CodProtocolo == p.CodProtocolo
                                                                             select new { ierp.QtdProduto, ierp.DscGrupoProduto }).AsEnumerable(),
                                                      p.QtdPesoTotal,
                                                      valor = "R$" + Math.Round(p.ValFretePeso.Value + p.ValTaxaTotal.Value, 2, MidpointRounding.AwayFromZero).ToString().Replace('.', ','),
                                                      p.CodUnidadeEmpresa,
                                                      ue.CodEmpresa,
                                                      p.CodTransportadora,
                                                      p.CodLocalidade
                                                  };
                    if (cod_unidade_empresa != 0)
                    {
                        protocolWeightfulldatas = protocolWeightfulldatas.Where(x => x.CodUnidadeEmpresa == cod_unidade_empresa);
                    }
                    if (cod_empresa != 0)
                    {
                        protocolWeightfulldatas = protocolWeightfulldatas.Where(x => x.CodEmpresa == cod_empresa);
                    }
                    if (cod_transportadora != 0)
                    {
                        protocolWeightfulldatas = protocolWeightfulldatas.Where(x => x.CodTransportadora == cod_transportadora);
                    }
                    if (sgl_unidade_federacao != null && sgl_unidade_federacao.Trim() != "")
                    {
                        string[] sgl_unidade_federacao_list = sgl_unidade_federacao.Split(",");
                        var tmpconditiondatas = from l in _context.Localidades
                                                where sgl_unidade_federacao.Contains(l.SglUnidadeFederacao)
                                                select l.CodLocalidade;

                        protocolWeightfulldatas = protocolWeightfulldatas.Where(x => tmpconditiondatas.Contains(x.CodLocalidade.Value));
                    }
                    if (cod_canal_venda != 0)
                    {
                        protocolWeightfulldatas = protocolWeightfulldatas.Where(x => (from erp in _context.EventoErps
                                                                                      where x.CodProtocolo == erp.CodProtocolo && erp.CodCanalVenda == cod_canal_venda
                                                                                      select 0).Count() > 0);
                    }


                    foreach (var protocolWeightfulldata in protocolWeightfulldatas)
                    {
                        protocol_weight _protocolweight = new protocol_weight();
                        _protocolweight.cod_protocolo = protocolWeightfulldata.CodProtocolo;
                        _protocolweight.notas = string.Join(",", protocolWeightfulldata.notas);

                        var produtosdata = protocolWeightfulldata.produtos;
                        var result = new List<string>();
                        var groupedList = produtosdata.GroupBy(p => p.DscGrupoProduto)
                                        .Select(
                                            grp => new { 
                                                key = grp.Key,
                                                sum = grp.Sum(s => s.QtdProduto)
                                            });
                        foreach(var data in groupedList)
                        {
                            var sumProduto = data.sum;
                            var dscgroupproduto = data.key;
                            result.Add("(" + sumProduto + ")" + dscgroupproduto + " ");
                        }

                        _protocolweight.produtos = string.Join(",", result);

                        _protocolweight.qtd_peso_total = protocolWeightfulldata.QtdPesoTotal.Value;
                        _protocolweight.valor = protocolWeightfulldata.valor;
                        _data.Add(_protocolweight);
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


        [Route("v1/[controller]/get-ocurrences-revalidation")]
        [HttpGet]
        public async Task<ActionResult<protocol_ocurrences_revalidation_response>> GetOcurrencesRevalidation([FromHeader] string authorization,
            [FromQuery] int cod_protocolo, [FromQuery] int num_nota_fiscal)
        {
            protocol_ocurrences_revalidation_response responseData = new protocol_ocurrences_revalidation_response();
            ResponseHeader header = new ResponseHeader();
            responseData.Header = header;
            List<protocol_ocurrences_revalidation> _data = new List<protocol_ocurrences_revalidation>();
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
                    var protocolOcurrencesRevalidationfulldatas = from p in _context.Protocolos
                                                                  join l in _context.Localidades on p.CodLocalidade equals l.CodLocalidade
                                                                  join ue in _context.UnidadeEmpresas on p.CodUnidadeEmpresa equals ue.CodUnidadeEmpresa
                                                                  join ot in _context.OcorrenciaTransportes on p.CodOcorrenciaTransporteAcao equals ot.CodOcorrenciaTransporte
                                                                  join mop in _context.MotivoOcorrenciaPadraos on ot.CodMotivoOcorrenciaPadrao equals mop.CodMotivoOcorrenciaPadrao
                                                                  join t in _context.Transportadoras on p.CodTransportadora equals t.CodTransportadora
                                                                  join r in _context.Romaneios on p.CodRomaneio equals r.CodRomaneio
                                                                  where (p.IndAcaoTransportadora == null ? false : p.IndAcaoTransportadora) == true && p.DatAcaoTransportadora != null && (p.ValidacaoAcaoTransportadora == null ? "" : p.ValidacaoAcaoTransportadora) != ""
                                                                  select new
                                                                  {
                                                                      p.CodProtocolo,
                                                                      cliente = (from erp in _context.EventoErps where p.CodProtocolo == erp.CodProtocolo select erp.NomCliente).FirstOrDefault(),
                                                                      mop.DscMotivoOcorrenciaPadrao,
                                                                      t.NomFantasia,
                                                                      dat_saida = r.DatSaida.ToString(),
                                                                      dat_limite_entrega = p.DatLimiteEntrega.ToString(),
                                                                      VALOR = "R$" + Math.Round(p.ValFretePeso.Value + p.ValTaxaTotal.Value, 2, MidpointRounding.AwayFromZero).ToString().Replace('.', ','),
                                                                      notas = (from erp in _context.EventoErps where erp.CodProtocolo == p.CodProtocolo select Convert.ToInt32(erp.NumNotaFiscal).ToString().Replace("A", string.Empty)).AsEnumerable(),
                                                                      p.ValidacaoAcaoTransportadora,
                                                                      VALOR_ACAO = (p.ValidacaoAcaoTransportadora == "'Reentrega'" ? ("R$" + Math.Round((p.ValFretePeso.Value + p.ValTaxaTotal.Value) * (decimal)0.5, 2, MidpointRounding.AwayFromZero).ToString().Replace('.', ',')) : ("R$" + Math.Round(p.ValFretePeso.Value + p.ValTaxaTotal.Value, 2, MidpointRounding.AwayFromZero).ToString().Replace('.', ',')))
                                                                  };
                    if (cod_protocolo != 0)
                    {
                        protocolOcurrencesRevalidationfulldatas = protocolOcurrencesRevalidationfulldatas.Where(x => x.CodProtocolo == cod_protocolo);
                    }
                    if (num_nota_fiscal != 0)
                    {
                        protocolOcurrencesRevalidationfulldatas = protocolOcurrencesRevalidationfulldatas.Where(x => (from erp in _context.EventoErps
                                                                                                                      where x.CodProtocolo == erp.CodProtocolo && erp.NumNotaFiscal == num_nota_fiscal.ToString()
                                                                                                                      select 0).Count() > 0);
                    }


                    foreach (var protocolOcurrencesRevalidationfulldata in protocolOcurrencesRevalidationfulldatas)
                    {
                        protocol_ocurrences_revalidation _ocurrencesrevalidation = new protocol_ocurrences_revalidation();
                        _ocurrencesrevalidation.cliente = protocolOcurrencesRevalidationfulldata.cliente;
                        _ocurrencesrevalidation.cod_protocolo = protocolOcurrencesRevalidationfulldata.CodProtocolo;
                        _ocurrencesrevalidation.dat_limite_entrega = DateTime.Parse(protocolOcurrencesRevalidationfulldata.dat_limite_entrega);
                        _ocurrencesrevalidation.dat_saida = DateTime.Parse(protocolOcurrencesRevalidationfulldata.dat_saida);
                        _ocurrencesrevalidation.dsc_motivo_ocorrencia_padrao = protocolOcurrencesRevalidationfulldata.DscMotivoOcorrenciaPadrao;
                        _ocurrencesrevalidation.nom_fantasia = protocolOcurrencesRevalidationfulldata.NomFantasia;
                        _ocurrencesrevalidation.notas = string.Join(",", protocolOcurrencesRevalidationfulldata.notas);
                        _ocurrencesrevalidation.validaao_acao_transportadora = protocolOcurrencesRevalidationfulldata.ValidacaoAcaoTransportadora;
                        _ocurrencesrevalidation.valor = protocolOcurrencesRevalidationfulldata.VALOR;
                        _ocurrencesrevalidation.valor_acao = protocolOcurrencesRevalidationfulldata.VALOR_ACAO;
                        _data.Add(_ocurrencesrevalidation);
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
