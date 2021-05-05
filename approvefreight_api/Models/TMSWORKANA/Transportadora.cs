using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class Transportadora
    {
        public int CodTransportadora { get; set; }
        public string DscRazaoSocial { get; set; }
        public string NomFantasia { get; set; }
        public string CodCgcTransportadora { get; set; }
        public string NumInscricaoEstadual { get; set; }
        public string DscEndereco { get; set; }
        public string NomBairro { get; set; }
        public int? CodLocalidade { get; set; }
        public string NumPredio { get; set; }
        public string CodCep { get; set; }
        public string NumTelefone { get; set; }
        public string NumFax { get; set; }
        public string NomUsuario { get; set; }
        public string EndWeb { get; set; }
        public string DscCondicaoPagamento { get; set; }
        public string DscObservacao { get; set; }
        public decimal? ValFaturaMinimo { get; set; }
        public int? QtdPesoMinimo { get; set; }
        public bool? IndNumeroObjeto { get; set; }
        public bool? IndCalculaImposto { get; set; }
        public string DscCalculoTarifa { get; set; }
        public string SglTransportadora { get; set; }
        public int? QtdPesoAdvertencia { get; set; }
        public bool? IndXmlConhecimentoFrete { get; set; }
        public bool? IndXmlRemessa { get; set; }
        public string NumVersaoEdi { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public int? QtdPesoMetroCubico { get; set; }
        public bool? IndNaoParticipaSimulacao { get; set; }
        public int? CodMigSapNovo { get; set; }
        public bool? IndConsolidaRomaneio { get; set; }
    }
}
