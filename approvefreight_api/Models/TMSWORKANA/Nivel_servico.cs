using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Nivel_servico
    {
        public int? COD_NIVEL_SERVICO { get; set; }
        public string? DSC_NIVEL_SERVICO { get; set; }
        public string DSC_OBSERVACAO { get; set; }
        public int? IND_LOGISTICA_REVERSA { get; set; }
        public int QTD_PESO_LOGISTICA_REVERSA { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public string DSC_MODAL_TRANSPORTE { get; set; }
        public int COD_TRANSPORTADORA { get; set; }
        public string COD_EXTERNO { get; set; }
        public int IND_CARGA_FECHADA { get; set; }
        public int COD_MIG_SAP_NOVO { get; set; }
        public string DSC_TIPO_FRETE { get; set; }
        public int QTD_PESO_LIMITE { get; set; }
    }
}
