using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class ItemEventoErp
    {
        public int CodItemEventoErp { get; set; }
        public int? CodEventoErp { get; set; }
        public int? CodSequencial { get; set; }
        public int CodProduto { get; set; }
        public string CodRegistro { get; set; }
        public string CodExternoEmpresa { get; set; }
        public string CodExternoUnidadeEmpresa { get; set; }
        public string NumPedido { get; set; }
        public string NumNotaFiscal { get; set; }
        public string NumSerieNotaFiscal { get; set; }
        public DateTime? DatNotaFiscal { get; set; }
        public string CodExternoProduto { get; set; }
        public string DscProduto { get; set; }
        public int? QtdProduto { get; set; }
        public string CodExternoGrupoProduto { get; set; }
        public decimal? VlrUnitarioFaturado { get; set; }
        public string DscGrupoProduto { get; set; }
        public bool? IndCancelado { get; set; }
        public string CodAuxiliarProduto { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public decimal? AlqIcms { get; set; }
        public decimal? AlqIcmsSubstituicaoTributaria { get; set; }
        public decimal? VlrRateioPeso { get; set; }
        public decimal? VlrRateioValor { get; set; }
        public decimal? VlrRateioPesoTotal { get; set; }
        public decimal? VlrRateioValorTotal { get; set; }
        public string CodCfop { get; set; }
        public decimal? QtdAltura { get; set; }
        public decimal? QtdLargura { get; set; }
        public decimal? QtdComprimento { get; set; }
        public string NumCfop { get; set; }
        public int? QtdPesoProduto { get; set; }

        public virtual EventoErp CodEventoErpNavigation { get; set; }
    }
}
