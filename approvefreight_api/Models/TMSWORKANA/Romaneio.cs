using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class Romaneio
    {
        public int CodRomaneio { get; set; }
        public int CodUnidadeEmpresa { get; set; }
        public int CodTransportadora { get; set; }
        public int? NumTipoRomaneio { get; set; }
        public string NumExterno { get; set; }
        public DateTime DatCriacao { get; set; }
        public DateTime? DatSaida { get; set; }
        public bool? IndAutorizacao { get; set; }
        public int? CodMotorista { get; set; }
        public int? CodVeiculo { get; set; }
        public string NomMotorista { get; set; }
        public string NumTelefoneMotorista { get; set; }
        public string NumPlacaVeiculo { get; set; }
        public decimal? VlrFretePeso { get; set; }
        public decimal? VlrTaxaTotal { get; set; }
        public int? QtdPesoTotal { get; set; }
        public int? CodRomaneioMigracao { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public bool? IndAberto { get; set; }
        public int? CodRotaEntrega { get; set; }
        public DateTime? DatRegistroSaida { get; set; }
        public int? CodUsuarioRegistro { get; set; }
        public string DscJustificativa { get; set; }
        public bool? IndBloqueado { get; set; }
        public DateTime? DatDesbloqueio { get; set; }
        public string NomAcessoDesbloqueio { get; set; }
        public string CodCpfMotorista { get; set; }
        public int? CodUsuarioAprovacaoFrete { get; set; }
        public DateTime? DatAprovacaoFrete { get; set; }
        public int? CodUnidadeEmpresaSatelite { get; set; }
        public decimal? ValFreteSugestao { get; set; }
        public int? CodTabelaFreteSugestao { get; set; }
        public string DscJustificativaFrete { get; set; }
        public int? CodExternoSolicitacaoAgendamento { get; set; }
        public int? CodUsuarioInclusao { get; set; }
        public DateTime? DatSugestaoColeta { get; set; }
        public DateTime? DatEfetivaChegada { get; set; }
        public bool? IndAprovado { get; set; }
        public int? CodUsuarioAprovacao { get; set; }
    }
}
