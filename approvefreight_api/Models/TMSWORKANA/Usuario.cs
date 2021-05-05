using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class Usuario
    {
        public int? COD_USUARIO { get; set; }
        public int COD_PERFIL_USUARIO { get; set; }
        public string NOM_USUARIO { get; set; }
        public string DSC_SENHA { get; set; }
        public int COD_EMPRESA { get; set; }
        public int COD_UNIDADE_EMPRESA { get; set; }
        public string NOM_ACESSO { get; set; }
        public string DSC_MOTIVO_BLOQUEIO { get; set; }
        public string END_EMAIL { get; set; }
        public DateTime DAT_EXPIRACAO_SENHA { get; set; }
        public DateTime DAT_ALTERA_SENHA { get; set; }
        public int IND_BLOQUEIO { get; set; }
        public int IND_ADMINISTRADOR { get; set; }
        public DateTime DAT_ULTIMO_ACESSO { get; set; }
        public DateTime DAT_BLOQUEIO { get; set; }
        public DateTime DAT_TERMINO_BLOQUEIO { get; set; }
        public int IND_MONITORA_ACESSO { get; set; }
        public int QTD_DIA_TROCA_SENHA { get; set; }
        public int IND_CONSULTA_GLOBAL { get; set; }
        public string IND_LIBERA_BLOQUEIO { get; set; }
        public string NUM_MATRICULA { get; set; }
        public DateTime DAT_CTR_INCLUSAO { get; set; }
        public string NOM_CTR_ACESSO { get; set; }
        public string NOM_CTR_PROCESSO { get; set; }
        public string NOM_IMPRESSORA_PADRAO { get; set; }
        public string NOM_IMPRESSORA_LASERJET { get; set; }
        public int IND_ACESSO_EXTERNO { get; set; }
        public string NOM_ARQUIVO_AVATAR { get; set; }
        public int COD_TRANSPORTADORA { get; set; }
        public int COD_MIG_SAP_NOVO { get; set; }
        public int IND_ALERTA_OCORRENCIA { get; set; }
        public int COD_USUARIO_AGENDAMENTO { get; set; }
        public int IND_RECEBE_EMAIL_LOTE { get; set; }
    }
}
