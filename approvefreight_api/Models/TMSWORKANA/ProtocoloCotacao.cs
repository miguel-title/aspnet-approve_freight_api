using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class ProtocoloCotacao
    {
        public int CodProtocoloCotacao { get; set; }
        public int? CodProtocolo { get; set; }
        public int? CodNivelServico { get; set; }
        public int? CodTipoVeiculo { get; set; }
        public DateTime DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public int? CodExternoSolicitacao { get; set; }
        public int? QtdDiaPrazo { get; set; }
    }
}
