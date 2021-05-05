using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Transportadora
    {
        public int? COD_TRANSPORTADORA { get; set; }
        public string DSC_RAZAO_SOCIAL { get; set; }
        public string NOM_FANTASIA { get; set; }
        public string COD_CGC_TRANSPORTADORA { get; set; }
        public string NUM_INSCRICAO_ESTADUAL { get; set; }
        public string DSC_ENDERECO { get; set; }
        public string NOM_BAIRRO { get; set; }
        public int COD_LOCALIDADE { get; set; }
        public string NUM_PREDIO { get; set; }
        public string COD_CEP { get; set; }
        public string NUM_TELEFONE { get; set; }
        public string NUM_FAX { get; set; }
        public string NOM_USUARIO { get; set; }
        public string END_WEB { get; set; }
        public string DSC_CONDICAO_PAGAMENTO { get; set; }
        public string DSC_OBSERVACAO { get; set; }
        public float VAL_FATURA_MINIMO { get; set; }
        public int QTD_PESO_MINIMO { get; set; }
        public int IND_NUMERO_OBJETO { get; set; }
        public int IND_CALCULA_IMPOSTO { get; set; }
        public string DSC_CALCULO_TARIFA { get; set; }
        public string SGL_TRANSPORTADORA { get; set; }
        public int QTD_PESO_ADVERTENCIA { get; set; }
        public int IND_XML_CONHECIMENTO_FRETE { get; set; }
        public int IND_XML_REMESSA { get; set; }
        public string NUM_VERSAO_EDI { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public int QTD_PESO_METRO_CUBICO { get; set; }
        public int IND_NAO_PARTICIPA_SIMULACAO { get; set; }
        public int COD_MIG_SAP_NOVO { get; set; }
        public int IND_CONSOLIDA_ROMANEIO { get; set; }
    }
}
