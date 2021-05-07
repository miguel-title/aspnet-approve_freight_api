using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class AprovadorOcorrencium
    {
        public int CodAprovadorOcorrencia { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodUnidadeEmpresa { get; set; }
        public int? CodAlcadaAprovacao { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }

        public virtual AlcadaAprovacao CodAlcadaAprovacaoNavigation { get; set; }
        public virtual UnidadeEmpresa CodUnidadeEmpresaNavigation { get; set; }
    }
}
