using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Empresa
    {
        public int? COD_EMPRESA { get; set; }
        public string DSC_RAZAO_SOCIAL { get; set; }
        public string NOM_FANTASIA { get; set; }
        public string COD_CNPJ_EMPRESA { get; set; }
        public string NUM_INSCRICAO_ESTADUAL { get; set; }
        public string DSC_ENDERECO { get; set; }
        public string NOM_BAIRRO { get; set; }
        public int COD_LOCALIDADE { get; set; }
        public string NUM_PREDIO { get; set; }
        public string COD_CEP { get; set; }
        public string NUM_TELEFONE { get; set; }
        public string NUM_FAX { get; set; }
        public string END_WEB { get; set; }
        public string END_EMAIL { get; set; }
        public int COD_GRUPO_EMPRESA { get; set; }
        public string SGL_EMPRESA { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public int IND_CENTRO_CUSTO_PROTOCOLO { get; set; }
        public float VLR_MAXIMO_SEGURO { get; set; }
        public int COD_MIG_SAP_NOVO { get; set; }
    }
}
