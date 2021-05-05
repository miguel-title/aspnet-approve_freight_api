using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Romaneio
    {
        public int? COD_ROMANEIO { get; set; }
        public int? COD_UNIDADE_EMPRESA { get; set; }
        public int? COD_TRANSPORTADORA { get; set; }
        public int NUM_TIPO_ROMANEIO { get; set; }
        public string NUM_EXTERNO { get; set; }
        public DateTime DAT_CRIACAO { get; set; }
        public DateTime DAT_SAIDA { get; set; }
        public int IND_AUTORIZACAO { get; set; }
        public int COD_MOTORISTA { get; set; }
        public int COD_VEICULO { get; set; }
        public string NOM_MOTORISTA { get; set; }
        public string NUM_TELEFONE_MOTORISTA { get; set; }
        public string NUM_PLACA_VEICULO { get; set; }
        public float VLR_FRETE_PESO { get; set; }
        public float VLR_TAXA_TOTAL { get; set; }
        public int QTD_PESO_TOTAL { get; set; }
        public int COD_ROMANEIO_MIGRACAO { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public int IND_ABERTO { get; set; }
        public int COD_ROTA_ENTREGA { get; set; }
        public DateTime DAT_REGISTRO_SAIDA { get; set; }
        public int COD_USUARIO_REGISTRO { get; set; }
        public string DSC_JUSTIFICATIVA { get; set; }
        public int IND_BLOQUEADO { get; set; }
        public DateTime DAT_DESBLOQUEIO { get; set; }
        public string NOM_ACESSO_DESBLOQUEIO { get; set; }
        public string COD_CPF_MOTORISTA { get; set; }
        public int COD_USUARIO_APROVACAO_FRETE { get; set; }
        public DateTime DAT_APROVACAO_FRETE { get; set; }
        public int COD_UNIDADE_EMPRESA_SATELITE { get; set; }
        public float VAL_FRETE_SUGESTAO { get; set; }
        public int COD_TABELA_FRETE_SUGESTAO { get; set; }
        public string DSC_JUSTIFICATIVA_FRETE { get; set; }
        public int COD_EXTERNO_SOLICITACAO_AGENDAMENTO { get; set; }
        public int COD_USUARIO_INCLUSAO { get; set; }
        public DateTime DAT_SUGESTAO_COLETA { get; set; }
        public DateTime DAT_EFETIVA_CHEGADA { get; set; }
        public int IND_APROVADO { get; set; }
        public int COD_USUARIO_APROVACAO { get; set; }
    }
}
