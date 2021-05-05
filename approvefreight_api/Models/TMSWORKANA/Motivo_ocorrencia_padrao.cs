using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Motivo_ocorrencia_padrao
    {
        public int? COD_MOTIVO_OCORRENCIA_PADRAO { get; set; }
        public string? DSC_MOTIVO_OCORRENCIA_PADRAO { get; set; }
        public int IND_DEVOLUCAO { get; set; }
        public int IND_SINISTRO { get; set; }
        public int IND_BAIXA_ENTREGA { get; set; }
        public int COD_TIPO_MOTIVO_OCORRENCIA_PADRAO { get; set; }
        public string DSC_MOTIVO_RESUMIDO { get; set; }
        public int IND_TENTATIVA_ENTREGA { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public int COD_MIG_SAP_NOVO { get; set; }
        public int IND_ENVIA_ALERTA { get; set; }
        public int IND_OTIF { get; set; }
        public int IND_ALTERA_PRAZO { get; set; }
        public int IND_COBRANCA_TRANSPORTADOR { get; set; }
        public int IND_ATIVO { get; set; }
        public int QTD_DIAS_EXTRAS_PRAZO_ENTREGA { get; set; }
        public string DSC_AREA_FOCAL { get; set; }
        public string DSC_AREA_FOCAL_MOVEL { get; set; }
        public string DSC_PERFIL_MOTIVO { get; set; }
    }
}
