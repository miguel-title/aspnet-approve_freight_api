using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class OcorrenciaTransporte
    {
        public int CodOcorrenciaTransporte { get; set; }
        public int? CodEmbalagem { get; set; }
        public int? CodProtocolo { get; set; }
        public int CodMotivoOcorrenciaPadrao { get; set; }
        public string DscOcorrenciaTransporte { get; set; }
        public DateTime? DatOcorrenciaTransporte { get; set; }
        public DateTime? DatLimiteOcorrencia { get; set; }
        public int? NumSequenciaTentativa { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public string CodCnpjCpfDestinatario { get; set; }
        public bool? IndFluxoEntrega { get; set; }
        public string CodExterno { get; set; }
        public int? CodProtocoloOrigem { get; set; }
        public string NomArquivoImportacao { get; set; }
        public DateTime? DatEnvioTrackingErp { get; set; }
        public string DscObservacao { get; set; }
        public DateTime? DatEnvioEcommerce { get; set; }
    }
}
