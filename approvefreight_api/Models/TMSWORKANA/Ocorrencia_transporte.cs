using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Ocorrencia_transporte
    {
        public int? COD_TIPO_ALCADA_APROVACAO { get; set; }
        public int COD_EMBALAGEM { get; set; }
        public int COD_PROTOCOLO { get; set; }
        public int? COD_MOTIVO_OCORRENCIA_PADRAO { get; set; }
        public string? DSC_OCORRENCIA_TRANSPORTE { get; set; }
        public DateTime DAT_OCORRENCIA_TRANSPORTE { get; set; }
        public DateTime DAT_LIMITE_OCORRENCIA { get; set; }
        public int NUM_SEQUENCIA_TENTATIVA { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public string COD_CNPJ_CPF_DESTINATARIO { get; set; }
        public int IND_FLUXO_ENTREGA { get; set; }
        public string COD_EXTERNO { get; set; }
        public int COD_PROTOCOLO_ORIGEM { get; set; }
        public string NOM_ARQUIVO_IMPORTACAO { get; set; }
        public DateTime DAT_ENVIO_TRACKING_ERP { get; set; }
        public string DSC_OBSERVACAO { get; set; }
        public DateTime DAT_ENVIO_ECOMMERCE { get; set; }
    }
}
