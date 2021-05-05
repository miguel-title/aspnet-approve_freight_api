using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class Protocolo
    {
        public int CodProtocolo { get; set; }
        public int CodUnidadeEmpresa { get; set; }
        public int? CodAgendaTransporte { get; set; }
        public int? CodPrazoEntrega { get; set; }
        public int? CodOperacaoTransporte { get; set; }
        public int? CodNivelServico { get; set; }
        public DateTime DatProtocolo { get; set; }
        public int? CodRomaneio { get; set; }
        public int? CodTransportadora { get; set; }
        public string DscEnderecoEntrega { get; set; }
        public int? CodLocalidade { get; set; }
        public DateTime? DatEntrega { get; set; }
        public DateTime? DatRegistroEntrega { get; set; }
        public DateTime? DatDevolucao { get; set; }
        public DateTime? DatRegistroDevolucao { get; set; }
        public DateTime? DatBaixaNivelServico { get; set; }
        public DateTime? DatBaixa { get; set; }
        public int? CodUsuarioBaixa { get; set; }
        public string NomBairroEntrega { get; set; }
        public string CodCepEntrega { get; set; }
        public bool? IndPendente { get; set; }
        public bool? IndAutorizacao { get; set; }
        public int? CodUsuarioAutorizacao { get; set; }
        public DateTime? DatAutorizacao { get; set; }
        public string DscJustificativa { get; set; }
        public decimal? ValFretePeso { get; set; }
        public DateTime? DatCriacao { get; set; }
        public bool? IndAvulso { get; set; }
        public int? QtdPesoTotal { get; set; }
        public int? QtdEmbalagem { get; set; }
        public decimal? ValTaxaTotal { get; set; }
        public int? CodMotivoProtocoloAvulso { get; set; }
        public int? CodPreFatura { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public DateTime? DatLimiteEntrega { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public int? QtdDiaEntrega { get; set; }
        public int? NumTipoProtocolo { get; set; }
        public DateTime? DatRemessa { get; set; }
        public int? CodProtocoloMigracao { get; set; }
        public int? CodPrazoEntregaLocalidade { get; set; }
        public int? CodLoteProtocolo { get; set; }
        public DateTime? DatImpresao { get; set; }
        public int? DatRotaEntrega { get; set; }
        public int? CodRotaEntrega { get; set; }
        public string NomContato { get; set; }
        public decimal? VlrDestaqueImposto { get; set; }
        public string DscImpostoDestacado { get; set; }
        public bool? IndCifFobNotfis { get; set; }
        public DateTime? DatEntregaHistorico { get; set; }
        public int? CodUsuario { get; set; }
        public DateTime? DatAgendamento { get; set; }
        public int? CodUsuarioAgendamento { get; set; }
        public string NomRotaEntrega { get; set; }
        public string NomRecebedor { get; set; }
        public string NumDocumentoRecebedor { get; set; }
        public DateTime? DatLimiteExpedicao { get; set; }
        public int? QtdDiaExpedicao { get; set; }
        public int? CodContaContabil { get; set; }
        public int? CodCompanhiaFiscal { get; set; }
        public string NumPedido { get; set; }
        public int? CodCentroCusto { get; set; }
        public DateTime? DatEnvioTrackingErp { get; set; }
        public bool? IndCanalVermelho { get; set; }
        public DateTime? DatLimiteOriginal { get; set; }
        public string EndEmailAvisoExpedicao { get; set; }
        public int? CodPrazoEntregaKm { get; set; }
        public string NumOrdemInterna { get; set; }
        public string NumElementoPep { get; set; }
        public int? CodContaFinanceira { get; set; }
        public decimal? QtdCubagemTotal { get; set; }
        public int? CodClaroCcDetalhada { get; set; }
        public string DscJustificativaFrete { get; set; }
        public int? CodUsuarioAprovacaoFrete { get; set; }
        public DateTime? DatAprovacaoFrete { get; set; }
        public int? CodUnidadeEmpresaSatelite { get; set; }
        public decimal? ValFreteSugestao { get; set; }
        public int? CodTabelaFreteSugestao { get; set; }
        public DateTime? DatLiberacaoFatura { get; set; }
        public int? CodUsuarioLiberacaoFatura { get; set; }
        public string DscJustificativaCorreios { get; set; }
        public bool? IndAcaoTransportadora { get; set; }
        public DateTime? DatAcaoTransportadora { get; set; }
        public int? CodOcorrenciaTransporteAcao { get; set; }
        public string ValidacaoAcaoTransportadora { get; set; }
        public int? CodProtocoloUnificado { get; set; }
        public bool? IndOperacaoCasada { get; set; }
        public string DscXmlSimulacao { get; set; }
        public string DscJustificativaCanalVermelho { get; set; }
        public DateTime? DatLimiteEntregaAtual { get; set; }
        public string DscComprovante { get; set; }
        public bool? IndProtocoloPrincipalConciliacao { get; set; }
        public bool? IndMenorFreteSimulacao { get; set; }
        public int? CodProtocoloLote { get; set; }
    }
}
