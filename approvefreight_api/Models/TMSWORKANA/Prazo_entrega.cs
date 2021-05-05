using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Prazo_entrega
    {
        public int? COD_PRAZO_ENTREGA { get; set; }
        public int COD_LOCALIDADE_ORIGEM { get; set; }
        public int COD_LOCALIDADE_DESTINO { get; set; }
        public int? COD_NIVEL_SERVICO { get; set; }
        public int? COD_TRANSPORTADORA { get; set; }
        public int? QTD_DIA_PRAZO { get; set; }
        public string COD_EXTERNO { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public int COD_MIG_SAP_NOVO { get; set; }
    }
}
