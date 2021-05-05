using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Localidade
    {
        public int? COD_LOCALIDADE { get; set; }
        public string NOM_LOCALIDADE { get; set; }
        public string COD_CEP { get; set; }
        public int COD_REGIAO { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public string NUM_LATITUDE { get; set; }
        public string NUM_LONGITUDE { get; set; }
        public string SGL_UNIDADE_FEDERACAO { get; set; }
        public float ALQ_ISS { get; set; }
        public int COD_MIG_SAP_NOVO { get; set; }
        public int COD_REGIAO_LOCALIDADE { get; set; }
        public int IND_SUFRAMA { get; set; }
        public int COD_IBGE { get; set; }
        public int IND_CAPITAL { get; set; }
        public string SGL_REGIAO_BRASIL { get; set; }
    }
}
