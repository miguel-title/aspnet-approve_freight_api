using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Models.TMSWORKANA
{
    public class TMSWORKANAContext : DbContext
    {
        public TMSWORKANAContext()
        {

        }

        public TMSWORKANAContext(DbContextOptions<TMSWORKANAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Protocolo> Protocolos { get; set; }
        public virtual DbSet<Unidade_empresa> Unidade_empresa { get; set; }
        public virtual DbSet<Nivel_servico> Nivel_servico { get; set; }
        public virtual DbSet<Transportadora> Transportadora { get; set; }
        public virtual DbSet<Prazo_entrega> Prazo_entrega { get; set; }
        public virtual DbSet<Protocolo_cotacao> Protocolo_cotacao { get; set; }
        public virtual DbSet<Alcada_aprovacao> Alcada_aprovacao { get; set; }
        public virtual DbSet<Ocorrencia_transporte> Ocorrencia_transporte { get; set; }
        public virtual DbSet<Aprovacao_alcada> Aprovacao_alcada { get; set; }
        public virtual DbSet<Romaneio> Romaneio { get; set; }
        public virtual DbSet<Localidade> Localidade { get; set; }
        public virtual DbSet<Motivo_ocorrencia_padrao> Motivo_ocorrencia_padrao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Canal_venda> Canal_venda { get; set; }
        public virtual DbSet<Evento_erp> Evento_erp { get; set; }
    }
}
