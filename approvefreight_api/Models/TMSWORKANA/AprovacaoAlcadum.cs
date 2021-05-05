using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class AprovacaoAlcadum
    {
        public int CodAprovacaoAlcada { get; set; }
        public int? CodUsuarioValidador { get; set; }
        public int? CodUsuarioAprovador { get; set; }
        public int? CodProtocolo { get; set; }
        public int? CodOcorrenciaTransporte { get; set; }
        public DateTime? DatAprovacao { get; set; }
        public int? CodAlcadaAprovacao { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public string ValidacaoAcaoTransportadora { get; set; }
        public string DscAcao { get; set; }

        public virtual AlcadaAprovacao CodAlcadaAprovacaoNavigation { get; set; }
    }
}
