using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class EventoErp
    {
        public int CodEventoErp { get; set; }
        public int? CodTransportadora { get; set; }
        public int? CodAgendamentoColeta { get; set; }
        public int? CodSequencial { get; set; }
        public int CodUnidadeEmpresa { get; set; }
        public string CodRegistro { get; set; }
        public string CodExternoEmpresa { get; set; }
        public string CodExternoUnidadeEmpresa { get; set; }
        public long? NumPedido { get; set; }
        public string NumNotaFiscal { get; set; }
        public string NumSerieNotaFiscal { get; set; }
        public DateTime? DatNotaFiscal { get; set; }
        public decimal? VlrNotaFiscal { get; set; }
        public int? CodProtocolo { get; set; }
        public string NumCfop { get; set; }
        public string NomTransportadora { get; set; }
        public short? CodExternoNivelServico { get; set; }
        public string CodCnpjCpfCliente { get; set; }
        public string NomCliente { get; set; }
        public string NomBairro { get; set; }
        public string NomCidade { get; set; }
        public string SglUnidadeFederacao { get; set; }
        public string CodCep { get; set; }
        public bool? IndCancelado { get; set; }
        public int? CodTipoOperacaoFiscal { get; set; }
        public int? CodCanalVenda { get; set; }
        public int? CodUnidadeEmpresaDestino { get; set; }
        public string NumContrato { get; set; }
        public string DscPontoReferencia { get; set; }
        public string NumTelefoneContato { get; set; }
        public int? QtdPesoTotal { get; set; }
        public string NumTelefoneAuxiliar { get; set; }
        public DateTime? DatPedido { get; set; }
        public DateTime? DatLiberacaoPedido { get; set; }
        public string NumEmbarque { get; set; }
        public bool? IndCifFob { get; set; }
        public string NumEmbalagem { get; set; }
        public string CodInscricaoEstadual { get; set; }
        public string CodExternoAgendaTransporte { get; set; }
        public bool? IndAvulso { get; set; }
        public string NumSolicitacao { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public decimal? VlrIcms { get; set; }
        public decimal? VlrBaseIcms { get; set; }
        public decimal? VlrIcmsSubstituicaoTributaria { get; set; }
        public decimal? VlrBaseIcmsSubstituicaoTributaria { get; set; }
        public decimal? QtdPesoCubado { get; set; }
        public int? QtdEmbalagemUnitizada { get; set; }
        public decimal? VlrRateioPeso { get; set; }
        public decimal? VlrRateioValor { get; set; }
        public int? CodGrupoCliente { get; set; }
        public string CodCnpjCpfClienteFiscal { get; set; }
        public string NomClienteFiscal { get; set; }
        public string NomBairroFiscal { get; set; }
        public string NomCidadeFiscal { get; set; }
        public string SglUnidadeFederacaoFiscal { get; set; }
        public string CodCepFiscal { get; set; }
        public string CodInscricaoEstadualFiscal { get; set; }
        public string NumOrdemSeparacao { get; set; }
        public string NumPedidoEcomerce { get; set; }
        public string NumPedidoEcommerce { get; set; }
        public string NumChaveNotaFiscal { get; set; }
        public string EndCliente { get; set; }
        public string EndClienteFiscal { get; set; }
        public int? CodCentroCusto { get; set; }
        public DateTime? DatLimiteExpedicao { get; set; }
        public int? QtdDiaExpedicao { get; set; }
        public int? CodTabelaFrete { get; set; }
        public int? CodDestinatario { get; set; }
        public int? CodContaContabil { get; set; }
        public int? CodCompanhiaFiscal { get; set; }
        public string NumPedidoFiscal { get; set; }
        public int? CodCentroCustoFiscal { get; set; }
        public string DscTipoVolume { get; set; }
        public string NumRemessa { get; set; }
        public string DscTermoPesquisa { get; set; }
        public string CodCnpjCpfEmitente { get; set; }
        public string NomClienteEmitente { get; set; }
        public string NomBairroEmitente { get; set; }
        public string NomCidadeEmitente { get; set; }
        public string SglUnidadeFederacaoEmitente { get; set; }
        public string CodCepEmitente { get; set; }
        public int? CodCentroCustoCtv { get; set; }
        public string NomContatoEntrega { get; set; }
        public string NomContatoAuxiliar { get; set; }
        public int? CodContaFinanceira { get; set; }
        public string NumOrdemInterna { get; set; }
        public string NumElementoPep { get; set; }
        public string NumReserva { get; set; }
        public int? CodUnidadeEmpresaSatelite { get; set; }
        public DateTime? DatAgendaSolicitacao { get; set; }
        public DateTime? DatAgendaAgendamento { get; set; }
        public DateTime? DatAgendaEntrega { get; set; }
        public DateTime? DatAgendaNoshow { get; set; }
        public DateTime? DatAgendaCancelamento { get; set; }
        public string StatusAgenda { get; set; }
        public DateTime? DatEnvioEntregaErp { get; set; }
        public string NumCentroCustoSap { get; set; }
        public string DscCentroCustoSap { get; set; }
        public string NumElementoPepSap { get; set; }
        public string NumContaContabilSap { get; set; }
        public string DscContaContabilSap { get; set; }
        public bool? IndFreteCifFob { get; set; }
        public string NomLogradouroEntrega { get; set; }
        public string NumCasaEntrega { get; set; }
        public string DscComplementoEntrega { get; set; }
        public string NomLogradouroFiscal { get; set; }
        public string NumCasaFiscal { get; set; }
        public string DscComplementoFiscal { get; set; }
        public string NomContato { get; set; }
        public string NumTelefoneEntrega { get; set; }
        public string NumZnota { get; set; }
        public string NumOrdemVenda { get; set; }

        public virtual CanalVendum CodCanalVendaNavigation { get; set; }
    }
}
