using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Protocolo
    {
        public int? COD_PROTOCOLO { get; set; }
        public int? COD_UNIDADE_EMPRESA { get; set; }
        public int COD_AGENDA_TRANSPORTE { get; set; }
        public int COD_PRAZO_ENTREGA { get; set; }
        public int COD_OPERACAO_TRANSPORTE { get; set; }
        public int COD_NIVEL_SERVICO { get; set; }
        public DateTime DAT_PROTOCOLO { get; set; }
        public int COD_ROMANEIO { get; set; }
        public int COD_TRANSPORTADORA { get; set; }
        public string DSC_ENDERECO_ENTREGA { get; set; }
        public int COD_LOCALIDADE { get; set; }
        public DateTime DAT_ENTREGA { get; set; }
        public DateTime DAT_REGISTRO_ENTREGA { get; set; }
        public DateTime DAT_DEVOLUCAO { get; set; }
        public DateTime DAT_REGISTRO_DEVOLUCAO { get; set; }
        public DateTime DAT_BAIXA_NIVEL_SERVICO { get; set; }
        public DateTime DAT_BAIXA { get; set; }
        public int COD_USUARIO_BAIXA { get; set; }
        public string NOM_BAIRRO_ENTREGA { get; set; }
        public string COD_CEP_ENTREGA { get; set; }
        public int IND_PENDENTE { get; set; }
        public int IND_AUTORIZACAO { get; set; }
        public string COD_USUARIO_AUTORIZACAO { get; set; }
        public DateTime DAT_AUTORIZACAO { get; set; }
        public string DSC_JUSTIFICATIVA { get; set; }
        public float VAL_FRETE_PESO { get; set; }
        public DateTime DAT_CRIACAO { get; set; }
        public int IND_AVULSO { get; set; }
        public int QTD_PESO_TOTAL { get; set; }
        public int QTD_EMBALAGEM { get; set; }
        public float VAL_TAXA_TOTAL { get; set; }
        public int COD_MOTIVO_PROTOCOLO_AVULSO { get; set; }
        public int COD_PRE_FATURA { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public DateTime DAT_LIMITE_ENTREGA { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public int QTD_DIA_ENTREGA { get; set; }
        public int NUM_TIPO_PROTOCOLO { get; set; }
        public DateTime DAT_REMESSA { get; set; }
        public int COD_PROTOCOLO_MIGRACAO { get; set; }
        public int COD_PRAZO_ENTREGA_LOCALIDADE { get; set; }
        public int COD_LOTE_PROTOCOLO { get; set; }
        public DateTime DAT_IMPRESAO { get; set; }
        public int DAT_ROTA_ENTREGA { get; set; }
        public int COD_ROTA_ENTREGA { get; set; }
        public string NOM_CONTATO { get; set; }
        public float VLR_DESTAQUE_IMPOSTO { get; set; }
        public string DSC_IMPOSTO_DESTACADO { get; set; }
        public int IND_CIF_FOB_NOTFIS { get; set; }
        public DateTime DAT_ENTREGA_HISTORICO { get; set; }
        public int COD_USUARIO { get; set; }
        public DateTime DAT_AGENDAMENTO { get; set; }
        public int COD_USUARIO_AGENDAMENTO { get; set; }
        public string NOM_ROTA_ENTREGA { get; set; }
        public string NOM_RECEBEDOR { get; set; }
        public string NUM_DOCUMENTO_RECEBEDOR { get; set; }
        public DateTime DAT_LIMITE_EXPEDICAO { get; set; }
        public int QTD_DIA_EXPEDICAO { get; set; }
        public int COD_CONTA_CONTABIL { get; set; }
        public int COD_COMPANHIA_FISCAL { get; set; }
        public string NUM_PEDIDO { get; set; }
        public int COD_CENTRO_CUSTO { get; set; }
        public DateTime DAT_ENVIO_TRACKING_ERP { get; set; }
        public int IND_CANAL_VERMELHO { get; set; }
        public DateTime DAT_LIMITE_ORIGINAL { get; set; }
        public string END_EMAIL_AVISO_EXPEDICAO { get; set; }
        public int COD_PRAZO_ENTREGA_KM { get; set; }
        public string NUM_ORDEM_INTERNA { get; set; }
        public string NUM_ELEMENTO_PEP { get; set; }
        public int COD_CONTA_FINANCEIRA { get; set; }
        public float QTD_CUBAGEM_TOTAL { get; set; }
        public int COD_CLARO_CC_DETALHADA { get; set; }
        public string DSC_JUSTIFICATIVA_FRETE { get; set; }
        public int COD_USUARIO_APROVACAO_FRETE { get; set; }
        public DateTime DAT_APROVACAO_FRETE { get; set; }
        public int COD_UNIDADE_EMPRESA_SATELITE { get; set; }
        public float VAL_FRETE_SUGESTAO { get; set; }
        public int COD_TABELA_FRETE_SUGESTAO { get; set; }
        public DateTime DAT_LIBERACAO_FATURA { get; set; }
        public int COD_USUARIO_LIBERACAO_FATURA { get; set; }
        public string DSC_JUSTIFICATIVA_CORREIOS { get; set; }
        public int IND_ACAO_TRANSPORTADORA { get; set; }
        public DateTime DAT_ACAO_TRANSPORTADORA { get; set; }
        public int COD_OCORRENCIA_TRANSPORTE_ACAO { get; set; }
        public string VALIDACAO_ACAO_TRANSPORTADORA { get; set; }
        public int COD_PROTOCOLO_UNIFICADO { get; set; }
        public int IND_OPERACAO_CASADA { get; set; }
        public string DSC_XML_SIMULACAO { get; set; }
        public string DSC_JUSTIFICATIVA_CANAL_VERMELHO { get; set; }
        public DateTime DAT_LIMITE_ENTREGA_ATUAL { get; set; }
        public string DSC_COMPROVANTE { get; set; }
        public int IND_PROTOCOLO_PRINCIPAL_CONCILIACAO { get; set; }
        public int IND_MENOR_FRETE_SIMULACAO { get; set; }
        public int COD_PROTOCOLO_LOTE { get; set; }
    }
}
