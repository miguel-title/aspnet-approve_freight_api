using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace approvefreight_api.Models
{
    public partial class TMSWORKANAContext : DbContext
    {
        public TMSWORKANAContext()
        {
        }

        public TMSWORKANAContext(DbContextOptions<TMSWORKANAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlcadaAprovacao> AlcadaAprovacaos { get; set; }
        public virtual DbSet<AprovacaoAlcadum> AprovacaoAlcada { get; set; }
        public virtual DbSet<CanalVendum> CanalVenda { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<EventoErp> EventoErps { get; set; }
        public virtual DbSet<Localidade> Localidades { get; set; }
        public virtual DbSet<MotivoOcorrenciaPadrao> MotivoOcorrenciaPadraos { get; set; }
        public virtual DbSet<NivelServico> NivelServicos { get; set; }
        public virtual DbSet<OcorrenciaTransporte> OcorrenciaTransportes { get; set; }
        public virtual DbSet<PrazoEntrega> PrazoEntregas { get; set; }
        public virtual DbSet<Protocolo> Protocolos { get; set; }
        public virtual DbSet<ProtocoloCotacao> ProtocoloCotacaos { get; set; }
        public virtual DbSet<Romaneio> Romaneios { get; set; }
        public virtual DbSet<Transportadora> Transportadoras { get; set; }
        public virtual DbSet<UnidadeEmpresa> UnidadeEmpresas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TMSWORKANA;Trusted_Connection=true;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AlcadaAprovacao>(entity =>
            {
                entity.HasKey(e => e.CodAlcadaAprovacao)
                    .HasName("PK__ALCADA_A__5E8AF30678D1EB5A");

                entity.ToTable("ALCADA_APROVACAO");

                entity.Property(e => e.CodAlcadaAprovacao).HasColumnName("COD_ALCADA_APROVACAO");

                entity.Property(e => e.CodTipoAlcadaAprovacao).HasColumnName("COD_TIPO_ALCADA_APROVACAO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DscAlcadaAprovacao)
                    .HasMaxLength(60)
                    .HasColumnName("DSC_ALCADA_APROVACAO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.VlrFinal)
                    .HasColumnType("decimal(14, 2)")
                    .HasColumnName("VLR_FINAL");

                entity.Property(e => e.VlrInicial)
                    .HasColumnType("decimal(14, 2)")
                    .HasColumnName("VLR_INICIAL");
            });

            modelBuilder.Entity<AprovacaoAlcadum>(entity =>
            {
                entity.HasKey(e => e.CodAprovacaoAlcada)
                    .HasName("PK__APROVACA__888BAE6FCD861EA0");

                entity.ToTable("APROVACAO_ALCADA");

                entity.Property(e => e.CodAprovacaoAlcada).HasColumnName("COD_APROVACAO_ALCADA");

                entity.Property(e => e.CodAlcadaAprovacao).HasColumnName("COD_ALCADA_APROVACAO");

                entity.Property(e => e.CodOcorrenciaTransporte).HasColumnName("COD_OCORRENCIA_TRANSPORTE");

                entity.Property(e => e.CodProtocolo).HasColumnName("COD_PROTOCOLO");

                entity.Property(e => e.CodUsuarioAprovador).HasColumnName("COD_USUARIO_APROVADOR");

                entity.Property(e => e.CodUsuarioValidador).HasColumnName("COD_USUARIO_VALIDADOR");

                entity.Property(e => e.DatAprovacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_APROVACAO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DscAcao)
                    .HasMaxLength(60)
                    .HasColumnName("DSC_ACAO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.ValidacaoAcaoTransportadora)
                    .HasMaxLength(60)
                    .HasColumnName("VALIDACAO_ACAO_TRANSPORTADORA");

                entity.HasOne(d => d.CodAlcadaAprovacaoNavigation)
                    .WithMany(p => p.AprovacaoAlcada)
                    .HasForeignKey(d => d.CodAlcadaAprovacao)
                    .HasConstraintName("FK__APROVACAO__COD_A__4BAC3F29");
            });

            modelBuilder.Entity<CanalVendum>(entity =>
            {
                entity.HasKey(e => e.CodCanalVenda)
                    .HasName("PK__CANAL_VE__8118028AC6403F4A");

                entity.ToTable("CANAL_VENDA");

                entity.Property(e => e.CodCanalVenda).HasColumnName("COD_CANAL_VENDA");

                entity.Property(e => e.CodMigSapNovo).HasColumnName("COD_MIG_SAP_NOVO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DscCanalVenda)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("DSC_CANAL_VENDA");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.CodEmpresa)
                    .HasName("PK__EMPRESA__1A1E887BCE477A91")
                    .IsClustered(false);

                entity.ToTable("EMPRESA");

                entity.Property(e => e.CodEmpresa).HasColumnName("COD_EMPRESA");

                entity.Property(e => e.CodCep)
                    .HasMaxLength(10)
                    .HasColumnName("COD_CEP");

                entity.Property(e => e.CodCnpjEmpresa)
                    .HasMaxLength(20)
                    .HasColumnName("COD_CNPJ_EMPRESA");

                entity.Property(e => e.CodExterno)
                    .HasMaxLength(20)
                    .HasColumnName("COD_EXTERNO");

                entity.Property(e => e.CodGrupoEmpresa).HasColumnName("COD_GRUPO_EMPRESA");

                entity.Property(e => e.CodLocalidade).HasColumnName("COD_LOCALIDADE");

                entity.Property(e => e.CodMigSapNovo).HasColumnName("COD_MIG_SAP_NOVO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DscEndereco)
                    .HasMaxLength(60)
                    .HasColumnName("DSC_ENDERECO");

                entity.Property(e => e.DscRazaoSocial)
                    .HasMaxLength(80)
                    .HasColumnName("DSC_RAZAO_SOCIAL");

                entity.Property(e => e.EndEmail)
                    .HasMaxLength(80)
                    .HasColumnName("END_EMAIL");

                entity.Property(e => e.EndWeb)
                    .HasMaxLength(100)
                    .HasColumnName("END_WEB");

                entity.Property(e => e.IndCentroCustoProtocolo).HasColumnName("IND_CENTRO_CUSTO_PROTOCOLO");

                entity.Property(e => e.NomBairro)
                    .HasMaxLength(60)
                    .HasColumnName("NOM_BAIRRO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.NomFantasia)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_FANTASIA");

                entity.Property(e => e.NumFax)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_FAX");

                entity.Property(e => e.NumInscricaoEstadual)
                    .HasMaxLength(30)
                    .HasColumnName("NUM_INSCRICAO_ESTADUAL");

                entity.Property(e => e.NumPredio)
                    .HasMaxLength(12)
                    .HasColumnName("NUM_PREDIO");

                entity.Property(e => e.NumTelefone)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_TELEFONE");

                entity.Property(e => e.SglEmpresa)
                    .HasMaxLength(5)
                    .HasColumnName("SGL_EMPRESA")
                    .IsFixedLength(true);

                entity.Property(e => e.VlrMaximoSeguro)
                    .HasColumnType("decimal(18, 7)")
                    .HasColumnName("VLR_MAXIMO_SEGURO");

                entity.HasOne(d => d.CodLocalidadeNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.CodLocalidade)
                    .HasConstraintName("FK__EMPRESA__COD_LOC__7D2E8C24");
            });

            modelBuilder.Entity<EventoErp>(entity =>
            {
                entity.HasKey(e => e.CodEventoErp)
                    .HasName("PK__EVENTO_ERP__21C0F255");

                entity.ToTable("EVENTO_ERP");

                entity.Property(e => e.CodEventoErp).HasColumnName("COD_EVENTO_ERP");

                entity.Property(e => e.CodAgendamentoColeta).HasColumnName("COD_AGENDAMENTO_COLETA");

                entity.Property(e => e.CodCanalVenda).HasColumnName("COD_CANAL_VENDA");

                entity.Property(e => e.CodCentroCusto).HasColumnName("COD_CENTRO_CUSTO");

                entity.Property(e => e.CodCentroCustoCtv).HasColumnName("COD_CENTRO_CUSTO_CTV");

                entity.Property(e => e.CodCentroCustoFiscal).HasColumnName("COD_CENTRO_CUSTO_FISCAL");

                entity.Property(e => e.CodCep)
                    .HasMaxLength(20)
                    .HasColumnName("COD_CEP");

                entity.Property(e => e.CodCepEmitente)
                    .HasMaxLength(20)
                    .HasColumnName("COD_CEP_EMITENTE");

                entity.Property(e => e.CodCepFiscal)
                    .HasMaxLength(20)
                    .HasColumnName("COD_CEP_FISCAL");

                entity.Property(e => e.CodCnpjCpfCliente)
                    .HasMaxLength(36)
                    .HasColumnName("COD_CNPJ_CPF_CLIENTE");

                entity.Property(e => e.CodCnpjCpfClienteFiscal)
                    .HasMaxLength(36)
                    .HasColumnName("COD_CNPJ_CPF_CLIENTE_FISCAL");

                entity.Property(e => e.CodCnpjCpfEmitente)
                    .HasMaxLength(36)
                    .HasColumnName("COD_CNPJ_CPF_EMITENTE");

                entity.Property(e => e.CodCompanhiaFiscal).HasColumnName("COD_COMPANHIA_FISCAL");

                entity.Property(e => e.CodContaContabil).HasColumnName("COD_CONTA_CONTABIL");

                entity.Property(e => e.CodContaFinanceira).HasColumnName("COD_CONTA_FINANCEIRA");

                entity.Property(e => e.CodDestinatario).HasColumnName("COD_DESTINATARIO");

                entity.Property(e => e.CodExternoAgendaTransporte)
                    .HasMaxLength(20)
                    .HasColumnName("COD_EXTERNO_AGENDA_TRANSPORTE");

                entity.Property(e => e.CodExternoEmpresa)
                    .HasMaxLength(8)
                    .HasColumnName("COD_EXTERNO_EMPRESA");

                entity.Property(e => e.CodExternoNivelServico).HasColumnName("COD_EXTERNO_NIVEL_SERVICO");

                entity.Property(e => e.CodExternoUnidadeEmpresa)
                    .HasMaxLength(8)
                    .HasColumnName("COD_EXTERNO_UNIDADE_EMPRESA");

                entity.Property(e => e.CodGrupoCliente).HasColumnName("COD_GRUPO_CLIENTE");

                entity.Property(e => e.CodInscricaoEstadual)
                    .HasMaxLength(60)
                    .HasColumnName("COD_INSCRICAO_ESTADUAL");

                entity.Property(e => e.CodInscricaoEstadualFiscal)
                    .HasMaxLength(60)
                    .HasColumnName("COD_INSCRICAO_ESTADUAL_FISCAL");

                entity.Property(e => e.CodProtocolo).HasColumnName("COD_PROTOCOLO");

                entity.Property(e => e.CodRegistro)
                    .HasMaxLength(2)
                    .HasColumnName("COD_REGISTRO");

                entity.Property(e => e.CodSequencial).HasColumnName("COD_SEQUENCIAL");

                entity.Property(e => e.CodTabelaFrete).HasColumnName("COD_TABELA_FRETE");

                entity.Property(e => e.CodTipoOperacaoFiscal).HasColumnName("COD_TIPO_OPERACAO_FISCAL");

                entity.Property(e => e.CodTransportadora).HasColumnName("COD_TRANSPORTADORA");

                entity.Property(e => e.CodUnidadeEmpresa).HasColumnName("COD_UNIDADE_EMPRESA");

                entity.Property(e => e.CodUnidadeEmpresaDestino).HasColumnName("COD_UNIDADE_EMPRESA_DESTINO");

                entity.Property(e => e.CodUnidadeEmpresaSatelite).HasColumnName("COD_UNIDADE_EMPRESA_SATELITE");

                entity.Property(e => e.DatAgendaAgendamento)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_AGENDA_AGENDAMENTO");

                entity.Property(e => e.DatAgendaCancelamento)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_AGENDA_CANCELAMENTO");

                entity.Property(e => e.DatAgendaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_AGENDA_ENTREGA");

                entity.Property(e => e.DatAgendaNoshow)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_AGENDA_NOSHOW");

                entity.Property(e => e.DatAgendaSolicitacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_AGENDA_SOLICITACAO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DatEnvioEntregaErp)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_ENVIO_ENTREGA_ERP");

                entity.Property(e => e.DatLiberacaoPedido)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_LIBERACAO_PEDIDO");

                entity.Property(e => e.DatLimiteExpedicao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_LIMITE_EXPEDICAO");

                entity.Property(e => e.DatNotaFiscal)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_NOTA_FISCAL");

                entity.Property(e => e.DatPedido)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_PEDIDO");

                entity.Property(e => e.DscCentroCustoSap)
                    .HasMaxLength(120)
                    .HasColumnName("DSC_CENTRO_CUSTO_SAP");

                entity.Property(e => e.DscComplementoEntrega)
                    .HasMaxLength(120)
                    .HasColumnName("DSC_COMPLEMENTO_ENTREGA");

                entity.Property(e => e.DscComplementoFiscal)
                    .HasMaxLength(120)
                    .HasColumnName("DSC_COMPLEMENTO_FISCAL");

                entity.Property(e => e.DscContaContabilSap)
                    .HasMaxLength(120)
                    .HasColumnName("DSC_CONTA_CONTABIL_SAP");

                entity.Property(e => e.DscPontoReferencia)
                    .HasMaxLength(50)
                    .HasColumnName("DSC_PONTO_REFERENCIA");

                entity.Property(e => e.DscTermoPesquisa)
                    .HasMaxLength(60)
                    .HasColumnName("DSC_TERMO_PESQUISA");

                entity.Property(e => e.DscTipoVolume)
                    .HasMaxLength(80)
                    .HasColumnName("DSC_TIPO_VOLUME");

                entity.Property(e => e.EndCliente)
                    .HasMaxLength(300)
                    .HasColumnName("END_CLIENTE");

                entity.Property(e => e.EndClienteFiscal)
                    .HasMaxLength(300)
                    .HasColumnName("END_CLIENTE_FISCAL");

                entity.Property(e => e.IndAvulso).HasColumnName("IND_AVULSO");

                entity.Property(e => e.IndCancelado).HasColumnName("IND_CANCELADO");

                entity.Property(e => e.IndCifFob).HasColumnName("IND_CIF_FOB");

                entity.Property(e => e.IndFreteCifFob).HasColumnName("IND_FRETE_CIF_FOB");

                entity.Property(e => e.NomBairro)
                    .HasMaxLength(50)
                    .HasColumnName("NOM_BAIRRO");

                entity.Property(e => e.NomBairroEmitente)
                    .HasMaxLength(50)
                    .HasColumnName("NOM_BAIRRO_EMITENTE");

                entity.Property(e => e.NomBairroFiscal)
                    .HasMaxLength(50)
                    .HasColumnName("NOM_BAIRRO_FISCAL");

                entity.Property(e => e.NomCidade)
                    .HasMaxLength(50)
                    .HasColumnName("NOM_CIDADE");

                entity.Property(e => e.NomCidadeEmitente)
                    .HasMaxLength(50)
                    .HasColumnName("NOM_CIDADE_EMITENTE");

                entity.Property(e => e.NomCidadeFiscal)
                    .HasMaxLength(50)
                    .HasColumnName("NOM_CIDADE_FISCAL");

                entity.Property(e => e.NomCliente)
                    .HasMaxLength(80)
                    .HasColumnName("NOM_CLIENTE");

                entity.Property(e => e.NomClienteEmitente)
                    .HasMaxLength(80)
                    .HasColumnName("NOM_CLIENTE_EMITENTE");

                entity.Property(e => e.NomClienteFiscal)
                    .HasMaxLength(80)
                    .HasColumnName("NOM_CLIENTE_FISCAL");

                entity.Property(e => e.NomContato)
                    .HasMaxLength(120)
                    .HasColumnName("NOM_CONTATO");

                entity.Property(e => e.NomContatoAuxiliar)
                    .HasMaxLength(100)
                    .HasColumnName("NOM_CONTATO_AUXILIAR");

                entity.Property(e => e.NomContatoEntrega)
                    .HasMaxLength(100)
                    .HasColumnName("NOM_CONTATO_ENTREGA");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(80)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.NomLogradouroEntrega)
                    .HasMaxLength(120)
                    .HasColumnName("NOM_LOGRADOURO_ENTREGA");

                entity.Property(e => e.NomLogradouroFiscal)
                    .HasMaxLength(120)
                    .HasColumnName("NOM_LOGRADOURO_FISCAL");

                entity.Property(e => e.NomTransportadora)
                    .HasMaxLength(160)
                    .HasColumnName("NOM_TRANSPORTADORA");

                entity.Property(e => e.NumCasaEntrega)
                    .HasMaxLength(10)
                    .HasColumnName("NUM_CASA_ENTREGA");

                entity.Property(e => e.NumCasaFiscal)
                    .HasMaxLength(10)
                    .HasColumnName("NUM_CASA_FISCAL");

                entity.Property(e => e.NumCentroCustoSap)
                    .HasMaxLength(80)
                    .HasColumnName("NUM_CENTRO_CUSTO_SAP");

                entity.Property(e => e.NumCfop)
                    .HasMaxLength(12)
                    .HasColumnName("NUM_CFOP");

                entity.Property(e => e.NumChaveNotaFiscal)
                    .HasMaxLength(50)
                    .HasColumnName("NUM_CHAVE_NOTA_FISCAL");

                entity.Property(e => e.NumContaContabilSap)
                    .HasMaxLength(120)
                    .HasColumnName("NUM_CONTA_CONTABIL_SAP");

                entity.Property(e => e.NumContrato)
                    .HasMaxLength(40)
                    .HasColumnName("NUM_CONTRATO");

                entity.Property(e => e.NumElementoPep)
                    .HasMaxLength(500)
                    .HasColumnName("NUM_ELEMENTO_PEP");

                entity.Property(e => e.NumElementoPepSap)
                    .HasMaxLength(120)
                    .HasColumnName("NUM_ELEMENTO_PEP_SAP");

                entity.Property(e => e.NumEmbalagem)
                    .HasMaxLength(40)
                    .HasColumnName("NUM_EMBALAGEM");

                entity.Property(e => e.NumEmbarque)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_EMBARQUE");

                entity.Property(e => e.NumNotaFiscal)
                    .HasMaxLength(12)
                    .HasColumnName("NUM_NOTA_FISCAL");

                entity.Property(e => e.NumOrdemInterna)
                    .HasMaxLength(300)
                    .HasColumnName("NUM_ORDEM_INTERNA");

                entity.Property(e => e.NumOrdemSeparacao)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_ORDEM_SEPARACAO");

                entity.Property(e => e.NumOrdemVenda)
                    .HasMaxLength(80)
                    .HasColumnName("NUM_ORDEM_VENDA");

                entity.Property(e => e.NumPedido).HasColumnName("NUM_PEDIDO");

                entity.Property(e => e.NumPedidoEcomerce)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_PEDIDO_ECOMERCE");

                entity.Property(e => e.NumPedidoEcommerce)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_PEDIDO_ECOMMERCE");

                entity.Property(e => e.NumPedidoFiscal)
                    .HasMaxLength(300)
                    .HasColumnName("NUM_PEDIDO_FISCAL")
                    .IsFixedLength(true);

                entity.Property(e => e.NumRemessa)
                    .HasMaxLength(80)
                    .HasColumnName("NUM_REMESSA")
                    .IsFixedLength(true);

                entity.Property(e => e.NumReserva)
                    .HasMaxLength(80)
                    .HasColumnName("NUM_RESERVA");

                entity.Property(e => e.NumSerieNotaFiscal)
                    .HasMaxLength(6)
                    .HasColumnName("NUM_SERIE_NOTA_FISCAL");

                entity.Property(e => e.NumSolicitacao)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_SOLICITACAO");

                entity.Property(e => e.NumTelefoneAuxiliar)
                    .HasMaxLength(50)
                    .HasColumnName("NUM_TELEFONE_AUXILIAR");

                entity.Property(e => e.NumTelefoneContato)
                    .HasMaxLength(50)
                    .HasColumnName("NUM_TELEFONE_CONTATO");

                entity.Property(e => e.NumTelefoneEntrega)
                    .HasMaxLength(40)
                    .HasColumnName("NUM_TELEFONE_ENTREGA");

                entity.Property(e => e.NumZnota)
                    .HasMaxLength(80)
                    .HasColumnName("NUM_ZNOTA");

                entity.Property(e => e.QtdDiaExpedicao).HasColumnName("QTD_DIA_EXPEDICAO");

                entity.Property(e => e.QtdEmbalagemUnitizada).HasColumnName("QTD_EMBALAGEM_UNITIZADA");

                entity.Property(e => e.QtdPesoCubado)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("QTD_PESO_CUBADO");

                entity.Property(e => e.QtdPesoTotal).HasColumnName("QTD_PESO_TOTAL");

                entity.Property(e => e.SglUnidadeFederacao)
                    .HasMaxLength(6)
                    .HasColumnName("SGL_UNIDADE_FEDERACAO");

                entity.Property(e => e.SglUnidadeFederacaoEmitente)
                    .HasMaxLength(6)
                    .HasColumnName("SGL_UNIDADE_FEDERACAO_EMITENTE");

                entity.Property(e => e.SglUnidadeFederacaoFiscal)
                    .HasMaxLength(6)
                    .HasColumnName("SGL_UNIDADE_FEDERACAO_FISCAL");

                entity.Property(e => e.StatusAgenda)
                    .HasMaxLength(100)
                    .HasColumnName("STATUS_AGENDA");

                entity.Property(e => e.VlrBaseIcms)
                    .HasColumnType("decimal(18, 7)")
                    .HasColumnName("VLR_BASE_ICMS");

                entity.Property(e => e.VlrBaseIcmsSubstituicaoTributaria)
                    .HasColumnType("decimal(18, 7)")
                    .HasColumnName("VLR_BASE_ICMS_SUBSTITUICAO_TRIBUTARIA");

                entity.Property(e => e.VlrIcms)
                    .HasColumnType("decimal(18, 7)")
                    .HasColumnName("VLR_ICMS");

                entity.Property(e => e.VlrIcmsSubstituicaoTributaria)
                    .HasColumnType("decimal(18, 7)")
                    .HasColumnName("VLR_ICMS_SUBSTITUICAO_TRIBUTARIA");

                entity.Property(e => e.VlrNotaFiscal)
                    .HasColumnType("decimal(18, 7)")
                    .HasColumnName("VLR_NOTA_FISCAL");

                entity.Property(e => e.VlrRateioPeso)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VLR_RATEIO_PESO");

                entity.Property(e => e.VlrRateioValor)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VLR_RATEIO_VALOR");

                entity.HasOne(d => d.CodCanalVendaNavigation)
                    .WithMany(p => p.EventoErps)
                    .HasForeignKey(d => d.CodCanalVenda)
                    .HasConstraintName("FK__EVENTO_ER__COD_C__25918339");
            });

            modelBuilder.Entity<Localidade>(entity =>
            {
                entity.HasKey(e => e.CodLocalidade)
                    .HasName("PK__LOCALIDADE__1920BF5C")
                    .IsClustered(false);

                entity.ToTable("LOCALIDADE");

                entity.Property(e => e.CodLocalidade).HasColumnName("COD_LOCALIDADE");

                entity.Property(e => e.AlqIss)
                    .HasColumnType("decimal(7, 7)")
                    .HasColumnName("ALQ_ISS");

                entity.Property(e => e.CodCep)
                    .HasMaxLength(10)
                    .HasColumnName("COD_CEP");

                entity.Property(e => e.CodIbge).HasColumnName("COD_IBGE");

                entity.Property(e => e.CodMigSapNovo).HasColumnName("COD_MIG_SAP_NOVO");

                entity.Property(e => e.CodRegiao).HasColumnName("COD_REGIAO");

                entity.Property(e => e.CodRegiaoLocalidade).HasColumnName("COD_REGIAO_LOCALIDADE");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.IndCapital).HasColumnName("IND_CAPITAL");

                entity.Property(e => e.IndSuframa).HasColumnName("IND_SUFRAMA");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.NomLocalidade)
                    .HasMaxLength(80)
                    .HasColumnName("NOM_LOCALIDADE");

                entity.Property(e => e.NumLatitude)
                    .HasMaxLength(100)
                    .HasColumnName("NUM_LATITUDE");

                entity.Property(e => e.NumLongitude)
                    .HasMaxLength(100)
                    .HasColumnName("NUM_LONGITUDE");

                entity.Property(e => e.SglRegiaoBrasil)
                    .HasMaxLength(2)
                    .HasColumnName("SGL_REGIAO_BRASIL");

                entity.Property(e => e.SglUnidadeFederacao)
                    .HasMaxLength(2)
                    .HasColumnName("SGL_UNIDADE_FEDERACAO");
            });

            modelBuilder.Entity<MotivoOcorrenciaPadrao>(entity =>
            {
                entity.HasKey(e => e.CodMotivoOcorrenciaPadrao)
                    .HasName("PK__MOTIVO_O__53B576654D1D323C");

                entity.ToTable("MOTIVO_OCORRENCIA_PADRAO");

                entity.Property(e => e.CodMotivoOcorrenciaPadrao).HasColumnName("COD_MOTIVO_OCORRENCIA_PADRAO");

                entity.Property(e => e.CodMigSapNovo).HasColumnName("COD_MIG_SAP_NOVO");

                entity.Property(e => e.CodTipoMotivoOcorrenciaPadrao).HasColumnName("COD_TIPO_MOTIVO_OCORRENCIA_PADRAO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DscAreaFocal)
                    .HasMaxLength(50)
                    .HasColumnName("DSC_AREA_FOCAL");

                entity.Property(e => e.DscAreaFocalMovel)
                    .HasMaxLength(50)
                    .HasColumnName("DSC_AREA_FOCAL_MOVEL");

                entity.Property(e => e.DscMotivoOcorrenciaPadrao)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("DSC_MOTIVO_OCORRENCIA_PADRAO");

                entity.Property(e => e.DscMotivoResumido)
                    .HasMaxLength(80)
                    .HasColumnName("DSC_MOTIVO_RESUMIDO");

                entity.Property(e => e.DscPerfilMotivo)
                    .HasMaxLength(50)
                    .HasColumnName("DSC_PERFIL_MOTIVO");

                entity.Property(e => e.IndAlteraPrazo).HasColumnName("IND_ALTERA_PRAZO");

                entity.Property(e => e.IndAtivo).HasColumnName("IND_ATIVO");

                entity.Property(e => e.IndBaixaEntrega).HasColumnName("IND_BAIXA_ENTREGA");

                entity.Property(e => e.IndCobrancaTransportador).HasColumnName("IND_COBRANCA_TRANSPORTADOR");

                entity.Property(e => e.IndDevolucao).HasColumnName("IND_DEVOLUCAO");

                entity.Property(e => e.IndEnviaAlerta).HasColumnName("IND_ENVIA_ALERTA");

                entity.Property(e => e.IndOtif).HasColumnName("IND_OTIF");

                entity.Property(e => e.IndSinistro).HasColumnName("IND_SINISTRO");

                entity.Property(e => e.IndTentativaEntrega).HasColumnName("IND_TENTATIVA_ENTREGA");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.QtdDiasExtrasPrazoEntrega).HasColumnName("QTD_DIAS_EXTRAS_PRAZO_ENTREGA");
            });

            modelBuilder.Entity<NivelServico>(entity =>
            {
                entity.HasKey(e => e.CodNivelServico)
                    .HasName("PK__NIVEL_SE__29BBDF811133940F");

                entity.ToTable("NIVEL_SERVICO");

                entity.Property(e => e.CodNivelServico).HasColumnName("COD_NIVEL_SERVICO");

                entity.Property(e => e.CodExterno)
                    .HasMaxLength(10)
                    .HasColumnName("COD_EXTERNO");

                entity.Property(e => e.CodMigSapNovo).HasColumnName("COD_MIG_SAP_NOVO");

                entity.Property(e => e.CodTransportadora).HasColumnName("COD_TRANSPORTADORA");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DscModalTransporte)
                    .HasMaxLength(40)
                    .HasColumnName("DSC_MODAL_TRANSPORTE");

                entity.Property(e => e.DscNivelServico)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("DSC_NIVEL_SERVICO");

                entity.Property(e => e.DscObservacao)
                    .HasColumnType("ntext")
                    .HasColumnName("DSC_OBSERVACAO");

                entity.Property(e => e.DscTipoFrete)
                    .HasMaxLength(40)
                    .HasColumnName("DSC_TIPO_FRETE");

                entity.Property(e => e.IndCargaFechada).HasColumnName("IND_CARGA_FECHADA");

                entity.Property(e => e.IndLogisticaReversa).HasColumnName("IND_LOGISTICA_REVERSA");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.QtdPesoLimite).HasColumnName("QTD_PESO_LIMITE");

                entity.Property(e => e.QtdPesoLogisticaReversa).HasColumnName("QTD_PESO_LOGISTICA_REVERSA");
            });

            modelBuilder.Entity<OcorrenciaTransporte>(entity =>
            {
                entity.HasKey(e => e.CodOcorrenciaTransporte)
                    .HasName("PK__OCORRENC__2434ADBA10B9D1F3");

                entity.ToTable("OCORRENCIA_TRANSPORTE");

                entity.Property(e => e.CodOcorrenciaTransporte).HasColumnName("COD_OCORRENCIA_TRANSPORTE");

                entity.Property(e => e.CodCnpjCpfDestinatario)
                    .HasMaxLength(20)
                    .HasColumnName("COD_CNPJ_CPF_DESTINATARIO");

                entity.Property(e => e.CodEmbalagem).HasColumnName("COD_EMBALAGEM");

                entity.Property(e => e.CodExterno)
                    .HasMaxLength(15)
                    .HasColumnName("COD_EXTERNO");

                entity.Property(e => e.CodMotivoOcorrenciaPadrao).HasColumnName("COD_MOTIVO_OCORRENCIA_PADRAO");

                entity.Property(e => e.CodProtocolo).HasColumnName("COD_PROTOCOLO");

                entity.Property(e => e.CodProtocoloOrigem).HasColumnName("COD_PROTOCOLO_ORIGEM");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DatEnvioEcommerce)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_ENVIO_ECOMMERCE");

                entity.Property(e => e.DatEnvioTrackingErp)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_ENVIO_TRACKING_ERP");

                entity.Property(e => e.DatLimiteOcorrencia)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_LIMITE_OCORRENCIA");

                entity.Property(e => e.DatOcorrenciaTransporte)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DAT_OCORRENCIA_TRANSPORTE");

                entity.Property(e => e.DscObservacao)
                    .HasMaxLength(200)
                    .HasColumnName("DSC_OBSERVACAO");

                entity.Property(e => e.DscOcorrenciaTransporte)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("DSC_OCORRENCIA_TRANSPORTE");

                entity.Property(e => e.IndFluxoEntrega).HasColumnName("IND_FLUXO_ENTREGA");

                entity.Property(e => e.NomArquivoImportacao)
                    .HasMaxLength(255)
                    .HasColumnName("NOM_ARQUIVO_IMPORTACAO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.NumSequenciaTentativa).HasColumnName("NUM_SEQUENCIA_TENTATIVA");
            });

            modelBuilder.Entity<PrazoEntrega>(entity =>
            {
                entity.HasKey(e => e.CodPrazoEntrega)
                    .HasName("PK__PRAZO_EN__3841F7876439958D");

                entity.ToTable("PRAZO_ENTREGA");

                entity.Property(e => e.CodPrazoEntrega).HasColumnName("COD_PRAZO_ENTREGA");

                entity.Property(e => e.CodExterno)
                    .HasMaxLength(10)
                    .HasColumnName("COD_EXTERNO");

                entity.Property(e => e.CodLocalidadeDestino).HasColumnName("COD_LOCALIDADE_DESTINO");

                entity.Property(e => e.CodLocalidadeOrigem).HasColumnName("COD_LOCALIDADE_ORIGEM");

                entity.Property(e => e.CodMigSapNovo).HasColumnName("COD_MIG_SAP_NOVO");

                entity.Property(e => e.CodNivelServico).HasColumnName("COD_NIVEL_SERVICO");

                entity.Property(e => e.CodTransportadora).HasColumnName("COD_TRANSPORTADORA");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.QtdDiaPrazo).HasColumnName("QTD_DIA_PRAZO");
            });

            modelBuilder.Entity<Protocolo>(entity =>
            {
                entity.HasKey(e => e.CodProtocolo)
                    .HasName("PK__PROTOCOLO__729BEF18")
                    .IsClustered(false);

                entity.ToTable("PROTOCOLO");

                entity.Property(e => e.CodProtocolo).HasColumnName("COD_PROTOCOLO");

                entity.Property(e => e.CodAgendaTransporte).HasColumnName("COD_AGENDA_TRANSPORTE");

                entity.Property(e => e.CodCentroCusto).HasColumnName("COD_CENTRO_CUSTO");

                entity.Property(e => e.CodCepEntrega)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COD_CEP_ENTREGA")
                    .IsFixedLength(true);

                entity.Property(e => e.CodClaroCcDetalhada).HasColumnName("COD_CLARO_CC_DETALHADA");

                entity.Property(e => e.CodCompanhiaFiscal).HasColumnName("COD_COMPANHIA_FISCAL");

                entity.Property(e => e.CodContaContabil).HasColumnName("COD_CONTA_CONTABIL");

                entity.Property(e => e.CodContaFinanceira).HasColumnName("COD_CONTA_FINANCEIRA");

                entity.Property(e => e.CodLocalidade).HasColumnName("COD_LOCALIDADE");

                entity.Property(e => e.CodLoteProtocolo).HasColumnName("COD_LOTE_PROTOCOLO");

                entity.Property(e => e.CodMotivoProtocoloAvulso).HasColumnName("COD_MOTIVO_PROTOCOLO_AVULSO");

                entity.Property(e => e.CodNivelServico).HasColumnName("COD_NIVEL_SERVICO");

                entity.Property(e => e.CodOcorrenciaTransporteAcao).HasColumnName("COD_OCORRENCIA_TRANSPORTE_ACAO");

                entity.Property(e => e.CodOperacaoTransporte).HasColumnName("COD_OPERACAO_TRANSPORTE");

                entity.Property(e => e.CodPrazoEntrega).HasColumnName("COD_PRAZO_ENTREGA");

                entity.Property(e => e.CodPrazoEntregaKm).HasColumnName("COD_PRAZO_ENTREGA_KM");

                entity.Property(e => e.CodPrazoEntregaLocalidade).HasColumnName("COD_PRAZO_ENTREGA_LOCALIDADE");

                entity.Property(e => e.CodPreFatura).HasColumnName("COD_PRE_FATURA");

                entity.Property(e => e.CodProtocoloLote).HasColumnName("COD_PROTOCOLO_LOTE");

                entity.Property(e => e.CodProtocoloMigracao).HasColumnName("COD_PROTOCOLO_MIGRACAO");

                entity.Property(e => e.CodProtocoloUnificado).HasColumnName("COD_PROTOCOLO_UNIFICADO");

                entity.Property(e => e.CodRomaneio).HasColumnName("COD_ROMANEIO");

                entity.Property(e => e.CodRotaEntrega).HasColumnName("COD_ROTA_ENTREGA");

                entity.Property(e => e.CodTabelaFreteSugestao).HasColumnName("COD_TABELA_FRETE_SUGESTAO");

                entity.Property(e => e.CodTransportadora).HasColumnName("COD_TRANSPORTADORA");

                entity.Property(e => e.CodUnidadeEmpresa).HasColumnName("COD_UNIDADE_EMPRESA");

                entity.Property(e => e.CodUnidadeEmpresaSatelite).HasColumnName("COD_UNIDADE_EMPRESA_SATELITE");

                entity.Property(e => e.CodUsuario).HasColumnName("COD_USUARIO");

                entity.Property(e => e.CodUsuarioAgendamento).HasColumnName("COD_USUARIO_AGENDAMENTO");

                entity.Property(e => e.CodUsuarioAprovacaoFrete).HasColumnName("COD_USUARIO_APROVACAO_FRETE");

                entity.Property(e => e.CodUsuarioAutorizacao).HasColumnName("COD_USUARIO_AUTORIZACAO");

                entity.Property(e => e.CodUsuarioBaixa).HasColumnName("COD_USUARIO_BAIXA");

                entity.Property(e => e.CodUsuarioLiberacaoFatura).HasColumnName("COD_USUARIO_LIBERACAO_FATURA");

                entity.Property(e => e.DatAcaoTransportadora)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_ACAO_TRANSPORTADORA");

                entity.Property(e => e.DatAgendamento)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_AGENDAMENTO");

                entity.Property(e => e.DatAprovacaoFrete)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_APROVACAO_FRETE");

                entity.Property(e => e.DatAutorizacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_AUTORIZACAO");

                entity.Property(e => e.DatBaixa)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_BAIXA");

                entity.Property(e => e.DatBaixaNivelServico)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_BAIXA_NIVEL_SERVICO");

                entity.Property(e => e.DatCriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CRIACAO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DatDevolucao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_DEVOLUCAO");

                entity.Property(e => e.DatEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_ENTREGA");

                entity.Property(e => e.DatEntregaHistorico)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_ENTREGA_HISTORICO");

                entity.Property(e => e.DatEnvioTrackingErp)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_ENVIO_TRACKING_ERP");

                entity.Property(e => e.DatImpresao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_IMPRESAO");

                entity.Property(e => e.DatLiberacaoFatura)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_LIBERACAO_FATURA");

                entity.Property(e => e.DatLimiteEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_LIMITE_ENTREGA");

                entity.Property(e => e.DatLimiteEntregaAtual)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_LIMITE_ENTREGA_ATUAL");

                entity.Property(e => e.DatLimiteExpedicao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_LIMITE_EXPEDICAO");

                entity.Property(e => e.DatLimiteOriginal)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_LIMITE_ORIGINAL");

                entity.Property(e => e.DatProtocolo)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DAT_PROTOCOLO");

                entity.Property(e => e.DatRegistroDevolucao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_REGISTRO_DEVOLUCAO");

                entity.Property(e => e.DatRegistroEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_REGISTRO_ENTREGA");

                entity.Property(e => e.DatRemessa)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_REMESSA");

                entity.Property(e => e.DatRotaEntrega).HasColumnName("DAT_ROTA_ENTREGA");

                entity.Property(e => e.DscComprovante)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DSC_COMPROVANTE");

                entity.Property(e => e.DscEnderecoEntrega)
                    .HasMaxLength(120)
                    .HasColumnName("DSC_ENDERECO_ENTREGA");

                entity.Property(e => e.DscImpostoDestacado)
                    .HasMaxLength(15)
                    .HasColumnName("DSC_IMPOSTO_DESTACADO");

                entity.Property(e => e.DscJustificativa)
                    .HasColumnType("ntext")
                    .HasColumnName("DSC_JUSTIFICATIVA");

                entity.Property(e => e.DscJustificativaCanalVermelho)
                    .HasMaxLength(140)
                    .HasColumnName("DSC_JUSTIFICATIVA_CANAL_VERMELHO");

                entity.Property(e => e.DscJustificativaCorreios)
                    .HasMaxLength(200)
                    .HasColumnName("DSC_JUSTIFICATIVA_CORREIOS");

                entity.Property(e => e.DscJustificativaFrete)
                    .HasColumnType("ntext")
                    .HasColumnName("DSC_JUSTIFICATIVA_FRETE");

                entity.Property(e => e.DscXmlSimulacao)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("DSC_XML_SIMULACAO");

                entity.Property(e => e.EndEmailAvisoExpedicao)
                    .HasColumnType("ntext")
                    .HasColumnName("END_EMAIL_AVISO_EXPEDICAO");

                entity.Property(e => e.IndAcaoTransportadora).HasColumnName("IND_ACAO_TRANSPORTADORA");

                entity.Property(e => e.IndAutorizacao).HasColumnName("IND_AUTORIZACAO");

                entity.Property(e => e.IndAvulso).HasColumnName("IND_AVULSO");

                entity.Property(e => e.IndCanalVermelho).HasColumnName("IND_CANAL_VERMELHO");

                entity.Property(e => e.IndCifFobNotfis).HasColumnName("IND_CIF_FOB_NOTFIS");

                entity.Property(e => e.IndMenorFreteSimulacao).HasColumnName("IND_MENOR_FRETE_SIMULACAO");

                entity.Property(e => e.IndOperacaoCasada).HasColumnName("IND_OPERACAO_CASADA");

                entity.Property(e => e.IndPendente).HasColumnName("IND_PENDENTE");

                entity.Property(e => e.IndProtocoloPrincipalConciliacao).HasColumnName("IND_PROTOCOLO_PRINCIPAL_CONCILIACAO");

                entity.Property(e => e.NomBairroEntrega)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_BAIRRO_ENTREGA");

                entity.Property(e => e.NomContato)
                    .HasMaxLength(80)
                    .HasColumnName("NOM_CONTATO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.NomRecebedor)
                    .HasMaxLength(200)
                    .HasColumnName("NOM_RECEBEDOR");

                entity.Property(e => e.NomRotaEntrega)
                    .HasMaxLength(60)
                    .HasColumnName("NOM_ROTA_ENTREGA");

                entity.Property(e => e.NumDocumentoRecebedor)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_DOCUMENTO_RECEBEDOR");

                entity.Property(e => e.NumElementoPep)
                    .HasMaxLength(240)
                    .HasColumnName("NUM_ELEMENTO_PEP");

                entity.Property(e => e.NumOrdemInterna)
                    .HasMaxLength(240)
                    .HasColumnName("NUM_ORDEM_INTERNA");

                entity.Property(e => e.NumPedido)
                    .HasMaxLength(150)
                    .HasColumnName("NUM_PEDIDO");

                entity.Property(e => e.NumTipoProtocolo).HasColumnName("NUM_TIPO_PROTOCOLO");

                entity.Property(e => e.QtdCubagemTotal)
                    .HasColumnType("decimal(16, 7)")
                    .HasColumnName("QTD_CUBAGEM_TOTAL");

                entity.Property(e => e.QtdDiaEntrega).HasColumnName("QTD_DIA_ENTREGA");

                entity.Property(e => e.QtdDiaExpedicao).HasColumnName("QTD_DIA_EXPEDICAO");

                entity.Property(e => e.QtdEmbalagem).HasColumnName("QTD_EMBALAGEM");

                entity.Property(e => e.QtdPesoTotal).HasColumnName("QTD_PESO_TOTAL");

                entity.Property(e => e.ValFretePeso)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VAL_FRETE_PESO");

                entity.Property(e => e.ValFreteSugestao)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VAL_FRETE_SUGESTAO");

                entity.Property(e => e.ValTaxaTotal)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VAL_TAXA_TOTAL");

                entity.Property(e => e.ValidacaoAcaoTransportadora)
                    .HasMaxLength(20)
                    .HasColumnName("VALIDACAO_ACAO_TRANSPORTADORA");

                entity.Property(e => e.VlrDestaqueImposto)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VLR_DESTAQUE_IMPOSTO");
            });

            modelBuilder.Entity<ProtocoloCotacao>(entity =>
            {
                entity.HasKey(e => e.CodProtocoloCotacao);

                entity.ToTable("PROTOCOLO_COTACAO");

                entity.Property(e => e.CodProtocoloCotacao).HasColumnName("COD_PROTOCOLO_COTACAO");

                entity.Property(e => e.CodExternoSolicitacao).HasColumnName("COD_EXTERNO_SOLICITACAO");

                entity.Property(e => e.CodNivelServico).HasColumnName("COD_NIVEL_SERVICO");

                entity.Property(e => e.CodProtocolo).HasColumnName("COD_PROTOCOLO");

                entity.Property(e => e.CodTipoVeiculo).HasColumnName("COD_TIPO_VEICULO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(60)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(80)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.QtdDiaPrazo).HasColumnName("QTD_DIA_PRAZO");
            });

            modelBuilder.Entity<Romaneio>(entity =>
            {
                entity.HasKey(e => e.CodRomaneio)
                    .HasName("PK__ROMANEIO__1A1FD08D")
                    .IsClustered(false);

                entity.ToTable("ROMANEIO");

                entity.Property(e => e.CodRomaneio).HasColumnName("COD_ROMANEIO");

                entity.Property(e => e.CodCpfMotorista)
                    .HasMaxLength(15)
                    .HasColumnName("COD_CPF_MOTORISTA");

                entity.Property(e => e.CodExternoSolicitacaoAgendamento).HasColumnName("COD_EXTERNO_SOLICITACAO_AGENDAMENTO");

                entity.Property(e => e.CodMotorista).HasColumnName("COD_MOTORISTA");

                entity.Property(e => e.CodRomaneioMigracao).HasColumnName("COD_ROMANEIO_MIGRACAO");

                entity.Property(e => e.CodRotaEntrega).HasColumnName("COD_ROTA_ENTREGA");

                entity.Property(e => e.CodTabelaFreteSugestao).HasColumnName("COD_TABELA_FRETE_SUGESTAO");

                entity.Property(e => e.CodTransportadora).HasColumnName("COD_TRANSPORTADORA");

                entity.Property(e => e.CodUnidadeEmpresa).HasColumnName("COD_UNIDADE_EMPRESA");

                entity.Property(e => e.CodUnidadeEmpresaSatelite).HasColumnName("COD_UNIDADE_EMPRESA_SATELITE");

                entity.Property(e => e.CodUsuarioAprovacao).HasColumnName("COD_USUARIO_APROVACAO");

                entity.Property(e => e.CodUsuarioAprovacaoFrete).HasColumnName("COD_USUARIO_APROVACAO_FRETE");

                entity.Property(e => e.CodUsuarioInclusao).HasColumnName("COD_USUARIO_INCLUSAO");

                entity.Property(e => e.CodUsuarioRegistro).HasColumnName("COD_USUARIO_REGISTRO");

                entity.Property(e => e.CodVeiculo).HasColumnName("COD_VEICULO");

                entity.Property(e => e.DatAprovacaoFrete)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_APROVACAO_FRETE");

                entity.Property(e => e.DatCriacao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DAT_CRIACAO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DatDesbloqueio)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_DESBLOQUEIO");

                entity.Property(e => e.DatEfetivaChegada)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_EFETIVA_CHEGADA");

                entity.Property(e => e.DatRegistroSaida)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_REGISTRO_SAIDA");

                entity.Property(e => e.DatSaida)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_SAIDA");

                entity.Property(e => e.DatSugestaoColeta)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_SUGESTAO_COLETA");

                entity.Property(e => e.DscJustificativa)
                    .HasColumnType("ntext")
                    .HasColumnName("DSC_JUSTIFICATIVA");

                entity.Property(e => e.DscJustificativaFrete)
                    .HasMaxLength(80)
                    .HasColumnName("DSC_JUSTIFICATIVA_FRETE");

                entity.Property(e => e.IndAberto).HasColumnName("IND_ABERTO");

                entity.Property(e => e.IndAprovado).HasColumnName("IND_APROVADO");

                entity.Property(e => e.IndAutorizacao).HasColumnName("IND_AUTORIZACAO");

                entity.Property(e => e.IndBloqueado).HasColumnName("IND_BLOQUEADO");

                entity.Property(e => e.NomAcessoDesbloqueio)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_ACESSO_DESBLOQUEIO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.NomMotorista)
                    .HasMaxLength(80)
                    .HasColumnName("NOM_MOTORISTA");

                entity.Property(e => e.NumExterno)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_EXTERNO");

                entity.Property(e => e.NumPlacaVeiculo)
                    .HasMaxLength(10)
                    .HasColumnName("NUM_PLACA_VEICULO");

                entity.Property(e => e.NumTelefoneMotorista)
                    .HasMaxLength(18)
                    .HasColumnName("NUM_TELEFONE_MOTORISTA");

                entity.Property(e => e.NumTipoRomaneio).HasColumnName("NUM_TIPO_ROMANEIO");

                entity.Property(e => e.QtdPesoTotal).HasColumnName("QTD_PESO_TOTAL");

                entity.Property(e => e.ValFreteSugestao)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VAL_FRETE_SUGESTAO");

                entity.Property(e => e.VlrFretePeso)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VLR_FRETE_PESO");

                entity.Property(e => e.VlrTaxaTotal)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VLR_TAXA_TOTAL");
            });

            modelBuilder.Entity<Transportadora>(entity =>
            {
                entity.HasKey(e => e.CodTransportadora)
                    .HasName("PK__TRANSPOR__5800D956492B4F36")
                    .IsClustered(false);

                entity.ToTable("TRANSPORTADORA");

                entity.Property(e => e.CodTransportadora).HasColumnName("COD_TRANSPORTADORA");

                entity.Property(e => e.CodCep)
                    .HasMaxLength(10)
                    .HasColumnName("COD_CEP");

                entity.Property(e => e.CodCgcTransportadora)
                    .HasMaxLength(18)
                    .HasColumnName("COD_CGC_TRANSPORTADORA");

                entity.Property(e => e.CodLocalidade).HasColumnName("COD_LOCALIDADE");

                entity.Property(e => e.CodMigSapNovo).HasColumnName("COD_MIG_SAP_NOVO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DscCalculoTarifa)
                    .HasMaxLength(10)
                    .HasColumnName("DSC_CALCULO_TARIFA");

                entity.Property(e => e.DscCondicaoPagamento)
                    .HasColumnType("ntext")
                    .HasColumnName("DSC_CONDICAO_PAGAMENTO");

                entity.Property(e => e.DscEndereco)
                    .HasMaxLength(60)
                    .HasColumnName("DSC_ENDERECO");

                entity.Property(e => e.DscObservacao)
                    .HasColumnType("ntext")
                    .HasColumnName("DSC_OBSERVACAO");

                entity.Property(e => e.DscRazaoSocial)
                    .HasMaxLength(60)
                    .HasColumnName("DSC_RAZAO_SOCIAL");

                entity.Property(e => e.EndWeb)
                    .HasMaxLength(100)
                    .HasColumnName("END_WEB");

                entity.Property(e => e.IndCalculaImposto).HasColumnName("IND_CALCULA_IMPOSTO");

                entity.Property(e => e.IndConsolidaRomaneio).HasColumnName("IND_CONSOLIDA_ROMANEIO");

                entity.Property(e => e.IndNaoParticipaSimulacao).HasColumnName("IND_NAO_PARTICIPA_SIMULACAO");

                entity.Property(e => e.IndNumeroObjeto).HasColumnName("IND_NUMERO_OBJETO");

                entity.Property(e => e.IndXmlConhecimentoFrete).HasColumnName("IND_XML_CONHECIMENTO_FRETE");

                entity.Property(e => e.IndXmlRemessa).HasColumnName("IND_XML_REMESSA");

                entity.Property(e => e.NomBairro)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_BAIRRO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.NomFantasia)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_FANTASIA");

                entity.Property(e => e.NomUsuario)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_USUARIO");

                entity.Property(e => e.NumFax)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_FAX");

                entity.Property(e => e.NumInscricaoEstadual)
                    .HasMaxLength(30)
                    .HasColumnName("NUM_INSCRICAO_ESTADUAL");

                entity.Property(e => e.NumPredio)
                    .HasMaxLength(12)
                    .HasColumnName("NUM_PREDIO");

                entity.Property(e => e.NumTelefone)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_TELEFONE");

                entity.Property(e => e.NumVersaoEdi)
                    .HasMaxLength(40)
                    .HasColumnName("NUM_VERSAO_EDI");

                entity.Property(e => e.QtdPesoAdvertencia).HasColumnName("QTD_PESO_ADVERTENCIA");

                entity.Property(e => e.QtdPesoMetroCubico).HasColumnName("QTD_PESO_METRO_CUBICO");

                entity.Property(e => e.QtdPesoMinimo).HasColumnName("QTD_PESO_MINIMO");

                entity.Property(e => e.SglTransportadora)
                    .HasMaxLength(4)
                    .HasColumnName("SGL_TRANSPORTADORA");

                entity.Property(e => e.ValFaturaMinimo)
                    .HasColumnType("decimal(14, 7)")
                    .HasColumnName("VAL_FATURA_MINIMO");
            });

            modelBuilder.Entity<UnidadeEmpresa>(entity =>
            {
                entity.HasKey(e => e.CodUnidadeEmpresa)
                    .HasName("PK__UNIDADE___DA5A88E4522D52A8")
                    .IsClustered(false);

                entity.ToTable("UNIDADE_EMPRESA");

                entity.Property(e => e.CodUnidadeEmpresa).HasColumnName("COD_UNIDADE_EMPRESA");

                entity.Property(e => e.CodCep)
                    .HasMaxLength(40)
                    .HasColumnName("COD_CEP");

                entity.Property(e => e.CodCnpjUnidadeEmpresa)
                    .HasMaxLength(20)
                    .HasColumnName("COD_CNPJ_UNIDADE_EMPRESA");

                entity.Property(e => e.CodEmpresa).HasColumnName("COD_EMPRESA");

                entity.Property(e => e.CodLocalidade).HasColumnName("COD_LOCALIDADE");

                entity.Property(e => e.CodMigSapNovo).HasColumnName("COD_MIG_SAP_NOVO");

                entity.Property(e => e.CodRegiaoAtendimento).HasColumnName("COD_REGIAO_ATENDIMENTO");

                entity.Property(e => e.CodUnidadeEmpresaExpedidora).HasColumnName("COD_UNIDADE_EMPRESA_EXPEDIDORA");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DscEndereco)
                    .HasMaxLength(80)
                    .HasColumnName("DSC_ENDERECO");

                entity.Property(e => e.HorarioColetaBringg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HORARIO_COLETA_BRINGG");

                entity.Property(e => e.IndCentroDistribuicao).HasColumnName("IND_CENTRO_DISTRIBUICAO");

                entity.Property(e => e.IndEstoqueCentral).HasColumnName("IND_ESTOQUE_CENTRAL");

                entity.Property(e => e.IndGeraRomaneio).HasColumnName("IND_GERA_ROMANEIO");

                entity.Property(e => e.IndGeraSolicitacao).HasColumnName("IND_GERA_SOLICITACAO");

                entity.Property(e => e.IndHorarioVerao).HasColumnName("IND_HORARIO_VERAO");

                entity.Property(e => e.IndLoja).HasColumnName("IND_LOJA");

                entity.Property(e => e.IndRegraFracionado).HasColumnName("IND_REGRA_FRACIONADO");

                entity.Property(e => e.IndRomaneioExclusivo).HasColumnName("IND_ROMANEIO_EXCLUSIVO");

                entity.Property(e => e.IndSugestaoColeta).HasColumnName("IND_SUGESTAO_COLETA");

                entity.Property(e => e.NomBairro)
                    .HasMaxLength(60)
                    .HasColumnName("NOM_BAIRRO");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.NomUnidadeEmpresa)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("NOM_UNIDADE_EMPRESA");

                entity.Property(e => e.NumFax)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_FAX");

                entity.Property(e => e.NumPredio)
                    .HasMaxLength(12)
                    .HasColumnName("NUM_PREDIO");

                entity.Property(e => e.NumTelefone)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_TELEFONE");

                entity.Property(e => e.QtdHoraFusoHorario).HasColumnName("QTD_HORA_FUSO_HORARIO");

                entity.Property(e => e.SglUnidadeEmpresa)
                    .HasMaxLength(5)
                    .HasColumnName("SGL_UNIDADE_EMPRESA");

                entity.Property(e => e.TagIdBringg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TAG_ID_BRINGG");

                entity.Property(e => e.TimeBringg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIME_BRINGG");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("PK__USUARIO__3868042222CF8493")
                    .IsClustered(false);

                entity.ToTable("USUARIO");

                entity.Property(e => e.CodUsuario).HasColumnName("COD_USUARIO");

                entity.Property(e => e.CodEmpresa).HasColumnName("COD_EMPRESA");

                entity.Property(e => e.CodMigSapNovo).HasColumnName("COD_MIG_SAP_NOVO");

                entity.Property(e => e.CodPerfilUsuario).HasColumnName("COD_PERFIL_USUARIO");

                entity.Property(e => e.CodTransportadora).HasColumnName("COD_TRANSPORTADORA");

                entity.Property(e => e.CodUnidadeEmpresa).HasColumnName("COD_UNIDADE_EMPRESA");

                entity.Property(e => e.CodUsuarioAgendamento).HasColumnName("COD_USUARIO_AGENDAMENTO");

                entity.Property(e => e.DatAlteraSenha)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_ALTERA_SENHA");

                entity.Property(e => e.DatBloqueio)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_BLOQUEIO");

                entity.Property(e => e.DatCtrInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CTR_INCLUSAO");

                entity.Property(e => e.DatExpiracaoSenha)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_EXPIRACAO_SENHA");

                entity.Property(e => e.DatTerminoBloqueio)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_TERMINO_BLOQUEIO");

                entity.Property(e => e.DatUltimoAcesso)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_ULTIMO_ACESSO");

                entity.Property(e => e.DscMotivoBloqueio)
                    .HasMaxLength(400)
                    .HasColumnName("DSC_MOTIVO_BLOQUEIO");

                entity.Property(e => e.DscSenha)
                    .HasMaxLength(50)
                    .HasColumnName("DSC_SENHA");

                entity.Property(e => e.EndEmail)
                    .HasMaxLength(100)
                    .HasColumnName("END_EMAIL");

                entity.Property(e => e.IndAcessoExterno).HasColumnName("IND_ACESSO_EXTERNO");

                entity.Property(e => e.IndAdministrador).HasColumnName("IND_ADMINISTRADOR");

                entity.Property(e => e.IndAlertaOcorrencia).HasColumnName("IND_ALERTA_OCORRENCIA");

                entity.Property(e => e.IndBloqueio).HasColumnName("IND_BLOQUEIO");

                entity.Property(e => e.IndConsultaGlobal).HasColumnName("IND_CONSULTA_GLOBAL");

                entity.Property(e => e.IndLiberaBloqueio)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("IND_LIBERA_BLOQUEIO")
                    .IsFixedLength(true);

                entity.Property(e => e.IndMonitoraAcesso).HasColumnName("IND_MONITORA_ACESSO");

                entity.Property(e => e.IndRecebeEmailLote).HasColumnName("IND_RECEBE_EMAIL_LOTE");

                entity.Property(e => e.NomAcesso)
                    .HasMaxLength(80)
                    .HasColumnName("NOM_ACESSO");

                entity.Property(e => e.NomArquivoAvatar)
                    .HasMaxLength(200)
                    .HasColumnName("NOM_ARQUIVO_AVATAR");

                entity.Property(e => e.NomCtrAcesso)
                    .HasMaxLength(20)
                    .HasColumnName("NOM_CTR_ACESSO");

                entity.Property(e => e.NomCtrProcesso)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_CTR_PROCESSO");

                entity.Property(e => e.NomImpressoraLaserjet)
                    .HasColumnType("ntext")
                    .HasColumnName("NOM_IMPRESSORA_LASERJET");

                entity.Property(e => e.NomImpressoraPadrao)
                    .HasColumnType("ntext")
                    .HasColumnName("NOM_IMPRESSORA_PADRAO");

                entity.Property(e => e.NomUsuario)
                    .HasMaxLength(40)
                    .HasColumnName("NOM_USUARIO");

                entity.Property(e => e.NumMatricula)
                    .HasMaxLength(20)
                    .HasColumnName("NUM_MATRICULA");

                entity.Property(e => e.QtdDiaTrocaSenha).HasColumnName("QTD_DIA_TROCA_SENHA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
