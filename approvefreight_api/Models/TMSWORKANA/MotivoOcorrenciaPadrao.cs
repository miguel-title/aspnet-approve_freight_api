using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class MotivoOcorrenciaPadrao
    {
        public int CodMotivoOcorrenciaPadrao { get; set; }
        public string DscMotivoOcorrenciaPadrao { get; set; }
        public bool? IndDevolucao { get; set; }
        public bool? IndSinistro { get; set; }
        public bool? IndBaixaEntrega { get; set; }
        public int? CodTipoMotivoOcorrenciaPadrao { get; set; }
        public string DscMotivoResumido { get; set; }
        public bool? IndTentativaEntrega { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public int? CodMigSapNovo { get; set; }
        public bool? IndEnviaAlerta { get; set; }
        public bool? IndOtif { get; set; }
        public bool? IndAlteraPrazo { get; set; }
        public bool? IndCobrancaTransportador { get; set; }
        public bool? IndAtivo { get; set; }
        public int? QtdDiasExtrasPrazoEntrega { get; set; }
        public string DscAreaFocal { get; set; }
        public string DscAreaFocalMovel { get; set; }
        public string DscPerfilMotivo { get; set; }
    }
}
