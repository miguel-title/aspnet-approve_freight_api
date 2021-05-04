using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Unidade_empresa
    {
        public int? COD_UNIDADE_EMPRESA { get; set; }
        public string? NOM_UNIDADE_EMPRESA { get; set; }
        public int? COD_EMPRESA { get; set; }
        public string COD_CNPJ_UNIDADE_EMPRESA { get; set; }
        public string SGL_UNIDADE_EMPRESA { get; set; }
        public string DSC_ENDERECO { get; set; }
        public string NOM_BAIRRO { get; set; }
        public int COD_LOCALIDADE { get; set; }
        public string NUM_PREDIO { get; set; }
        public string COD_CEP { get; set; }
        public string NUM_TELEFONE { get; set; }
        public string NUM_FAX { get; set; }
        public int IND_HORARIO_VERAO { get; set; }
        public int QTD_HORA_FUSO_HORARIO { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get;set;}
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public int COD_REGIAO_ATENDIMENTO { get; set; }
        public int COD_MIG_SAP_NOVO { get; set; }
        public int COD_UNIDADE_EMPRESA_EXPEDIDORA { get; set; }
        public int IND_ROMANEIO_EXCLUSIVO { get; set; }
        public int IND_GERA_ROMANEIO { get; set; }
        public int IND_REGRA_FRACIONADO { get; set; }
        public int IND_GERA_SOLICITACAO { get; set; }
        public int IND_LOJA { get; set; }
        public int IND_ESTOQUE_CENTRAL { get; set; }
        public int IND_SUGESTAO_COLETA { get; set; }
        public int IND_CENTRO_DISTRIBUICAO { get; set; }
        public string TAG_ID_BRINGG { get; set; }
        public string TIME_BRINGG { get; set; }
        public string HORARIO_COLETA_BRINGG { get; set; }
    }
}
