using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Alcada_aprovacao
    {
        public int? COD_ALCADA_APROVACAO { get; set; }
        public float VLR_INICIAL { get; set; }
        public float VLR_FINAL { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public string DSC_ALCADA_APROVACAO { get; set; }
        public int COD_TIPO_ALCADA_APROVACAO { get; set; }
    }
}
