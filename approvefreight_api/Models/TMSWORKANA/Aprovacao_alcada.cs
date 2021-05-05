using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Aprovacao_alcada
    {
        public int? COD_APROVACAO_ALCADA { get; set; }
        public int COD_USUARIO_VALIDADOR { get; set; }
        public int COD_USUARIO_APROVADOR { get; set; }
        public int COD_PROTOCOLO { get; set; }
        public int COD_OCORRENCIA_TRANSPORTE { get; set; }
        public DateTime DAT_APROVACAO { get; set; }
        public int COD_ALCADA_APROVACAO { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public string VALIDACAO_ACAO_TRANSPORTADORA { get; set; }
        public string DSC_ACAO { get; set; }
    }
}
