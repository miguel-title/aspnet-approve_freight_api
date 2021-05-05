using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class PrazoEntrega
    {
        public int CodPrazoEntrega { get; set; }
        public int? CodLocalidadeOrigem { get; set; }
        public int? CodLocalidadeDestino { get; set; }
        public int CodNivelServico { get; set; }
        public int CodTransportadora { get; set; }
        public int QtdDiaPrazo { get; set; }
        public string CodExterno { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public int? CodMigSapNovo { get; set; }
    }
}
