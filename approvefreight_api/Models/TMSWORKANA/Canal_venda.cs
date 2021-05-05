using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Canal_venda
    {
        public int? COD_CANAL_VENDA { get; set; }
        public string? DSC_CANAL_VENDA { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public int COD_MIG_SAP_NOVO { get; set; }
    }
}
