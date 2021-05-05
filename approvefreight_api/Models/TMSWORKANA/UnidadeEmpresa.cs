using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class UnidadeEmpresa
    {
        public int CodUnidadeEmpresa { get; set; }
        public string NomUnidadeEmpresa { get; set; }
        public int CodEmpresa { get; set; }
        public string CodCnpjUnidadeEmpresa { get; set; }
        public string SglUnidadeEmpresa { get; set; }
        public string DscEndereco { get; set; }
        public string NomBairro { get; set; }
        public int? CodLocalidade { get; set; }
        public string NumPredio { get; set; }
        public string CodCep { get; set; }
        public string NumTelefone { get; set; }
        public string NumFax { get; set; }
        public bool? IndHorarioVerao { get; set; }
        public int? QtdHoraFusoHorario { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public int? CodRegiaoAtendimento { get; set; }
        public int? CodMigSapNovo { get; set; }
        public int? CodUnidadeEmpresaExpedidora { get; set; }
        public bool? IndRomaneioExclusivo { get; set; }
        public bool? IndGeraRomaneio { get; set; }
        public bool? IndRegraFracionado { get; set; }
        public bool? IndGeraSolicitacao { get; set; }
        public bool? IndLoja { get; set; }
        public bool? IndEstoqueCentral { get; set; }
        public bool? IndSugestaoColeta { get; set; }
        public bool? IndCentroDistribuicao { get; set; }
        public string TagIdBringg { get; set; }
        public string TimeBringg { get; set; }
        public string HorarioColetaBringg { get; set; }
    }
}
