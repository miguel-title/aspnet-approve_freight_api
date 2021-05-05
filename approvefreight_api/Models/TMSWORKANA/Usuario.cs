using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class Usuario
    {
        public int CodUsuario { get; set; }
        public int? CodPerfilUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string DscSenha { get; set; }
        public int? CodEmpresa { get; set; }
        public int? CodUnidadeEmpresa { get; set; }
        public string NomAcesso { get; set; }
        public string DscMotivoBloqueio { get; set; }
        public string EndEmail { get; set; }
        public DateTime? DatExpiracaoSenha { get; set; }
        public DateTime DatAlteraSenha { get; set; }
        public bool? IndBloqueio { get; set; }
        public bool? IndAdministrador { get; set; }
        public DateTime? DatUltimoAcesso { get; set; }
        public DateTime? DatBloqueio { get; set; }
        public DateTime? DatTerminoBloqueio { get; set; }
        public bool? IndMonitoraAcesso { get; set; }
        public int? QtdDiaTrocaSenha { get; set; }
        public bool? IndConsultaGlobal { get; set; }
        public string IndLiberaBloqueio { get; set; }
        public string NumMatricula { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public string NomImpressoraPadrao { get; set; }
        public string NomImpressoraLaserjet { get; set; }
        public bool? IndAcessoExterno { get; set; }
        public string NomArquivoAvatar { get; set; }
        public int? CodTransportadora { get; set; }
        public int? CodMigSapNovo { get; set; }
        public bool? IndAlertaOcorrencia { get; set; }
        public int? CodUsuarioAgendamento { get; set; }
        public bool? IndRecebeEmailLote { get; set; }
    }
}
