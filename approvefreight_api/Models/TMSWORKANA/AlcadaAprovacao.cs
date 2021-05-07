using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class AlcadaAprovacao
    {
        public AlcadaAprovacao()
        {
            AprovacaoAlcada = new HashSet<AprovacaoAlcadum>();
            AprovadorOcorrencia = new HashSet<AprovadorOcorrencium>();
        }

        public int CodAlcadaAprovacao { get; set; }
        public decimal? VlrInicial { get; set; }
        public decimal? VlrFinal { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public string DscAlcadaAprovacao { get; set; }
        public int? CodTipoAlcadaAprovacao { get; set; }

        public virtual ICollection<AprovacaoAlcadum> AprovacaoAlcada { get; set; }
        public virtual ICollection<AprovadorOcorrencium> AprovadorOcorrencia { get; set; }
    }
}
