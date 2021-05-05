using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Protocolo_cotacao
    {
        public int? COD_PROTOCOLO_COTACAO { get; set; }
        public int COD_PROTOCOLO { get; set; }
        public int COD_NIVEL_SERVICO { get; set; }
        public int COD_TIPO_VEICULO { get; set; }
        public int? DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public int COD_EXTERNO_SOLICITACAO { get; set; }
        public int QTD_DIA_PRAZO { get; set; }
    }
}
