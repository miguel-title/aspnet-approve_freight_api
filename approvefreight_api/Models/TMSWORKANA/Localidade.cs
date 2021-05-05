using System;
using System.Collections.Generic;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class Localidade
    {
        public Localidade()
        {
            Empresas = new HashSet<Empresa>();
        }

        public int CodLocalidade { get; set; }
        public string NomLocalidade { get; set; }
        public string CodCep { get; set; }
        public int? CodRegiao { get; set; }
        public DateTime? DatCtrInclusao { get; set; }
        public string NomCtrAcesso { get; set; }
        public string NomCtrProcesso { get; set; }
        public string NumLatitude { get; set; }
        public string NumLongitude { get; set; }
        public string SglUnidadeFederacao { get; set; }
        public decimal? AlqIss { get; set; }
        public int? CodMigSapNovo { get; set; }
        public int? CodRegiaoLocalidade { get; set; }
        public bool? IndSuframa { get; set; }
        public int? CodIbge { get; set; }
        public bool? IndCapital { get; set; }
        public string SglRegiaoBrasil { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
