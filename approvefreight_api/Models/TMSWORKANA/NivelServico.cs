using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class NivelServico
    {
        public int CodNivelServico { get; set; }
        public string DscNivelServico { get; set; }
        public string DscObservacao { get; set; }
        public bool IndLogisticaReversa { get; set; }
        public int? QtdPesoLogisticaReversa { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public string DscModalTransporte { get; set; }
        public int? CodTransportadora { get; set; }
        public string CodExterno { get; set; }
        public bool? IndCargaFechada { get; set; }
        public int? CodMigSapNovo { get; set; }
        public string DscTipoFrete { get; set; }
        public int? QtdPesoLimite { get; set; }
    }
}
