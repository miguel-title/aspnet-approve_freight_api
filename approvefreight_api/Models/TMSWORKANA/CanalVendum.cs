using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class CanalVendum
    {
        public CanalVendum()
        {
            EventoErps = new HashSet<EventoErp>();
        }

        public int CodCanalVenda { get; set; }
        public string DscCanalVenda { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public int? CodMigSapNovo { get; set; }

        public virtual ICollection<EventoErp> EventoErps { get; set; }
    }
}
