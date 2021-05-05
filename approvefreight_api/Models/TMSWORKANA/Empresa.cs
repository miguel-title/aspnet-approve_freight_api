using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class Empresa
    {
        public int CodEmpresa { get; set; }
        public string DscRazaoSocial { get; set; }
        public string NomFantasia { get; set; }
        public string CodCnpjEmpresa { get; set; }
        public string NumInscricaoEstadual { get; set; }
        public string DscEndereco { get; set; }
        public string NomBairro { get; set; }
        public int? CodLocalidade { get; set; }
        public string NumPredio { get; set; }
        public string CodCep { get; set; }
        public string NumTelefone { get; set; }
        public string NumFax { get; set; }
        public string EndWeb { get; set; }
        public string EndEmail { get; set; }
        public string CodExterno { get; set; }
        public int? CodGrupoEmpresa { get; set; }
        public string SglEmpresa { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public bool? IndCentroCustoProtocolo { get; set; }
        public decimal? VlrMaximoSeguro { get; set; }
        public int? CodMigSapNovo { get; set; }

        public virtual Localidade CodLocalidadeNavigation { get; set; }
    }
}
