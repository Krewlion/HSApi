using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HSApi.EF
{
    public partial class HSContext : DbContext
    {
        public HSContext()
        {
        }

        public HSContext(DbContextOptions<HSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bairros> Bairros { get; set; }
        public virtual DbSet<Cidades> Cidades { get; set; }
        public virtual DbSet<Logradouros> Logradouros { get; set; }
        public virtual DbSet<Tbcliente> Tbcliente { get; set; }
        public virtual DbSet<Tbempresa> Tbempresa { get; set; }
        public virtual DbSet<Tbpagamento> Tbpagamento { get; set; }
        public virtual DbSet<Tbproduto> Tbproduto { get; set; }
        public virtual DbSet<Tbprodutoreserva> Tbprodutoreserva { get; set; }
        public virtual DbSet<Tbquarto> Tbquarto { get; set; }
        public virtual DbSet<Tbquartofoto> Tbquartofoto { get; set; }
        public virtual DbSet<Tbreserva> Tbreserva { get; set; }
        public virtual DbSet<Tbstatus> Tbstatus { get; set; }
        public virtual DbSet<Tbtipopagamento> Tbtipopagamento { get; set; }
        public virtual DbSet<Tbusuario> Tbusuario { get; set; }
        public virtual DbSet<Uf> Uf { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bairros>(entity =>
            {
                entity.HasKey(e => e.CdBairro);

                entity.ToTable("BAIRROS");

                entity.Property(e => e.CdBairro)
                    .HasColumnName("CD_BAIRRO")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdCidade).HasColumnName("CD_CIDADE");

                entity.Property(e => e.DsBairroNome)
                    .IsRequired()
                    .HasColumnName("DS_BAIRRO_NOME")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdCidadeNavigation)
                    .WithMany(p => p.Bairros)
                    .HasForeignKey(d => d.CdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BAIRROS_CIDADES");
            });

            modelBuilder.Entity<Cidades>(entity =>
            {
                entity.HasKey(e => e.CdCidade);

                entity.ToTable("CIDADES");

                entity.Property(e => e.CdCidade)
                    .HasColumnName("CD_CIDADE")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdUf).HasColumnName("CD_UF");

                entity.Property(e => e.DsCidadeNome)
                    .IsRequired()
                    .HasColumnName("DS_CIDADE_NOME")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdUfNavigation)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.CdUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CIDADES_UF");
            });

            modelBuilder.Entity<Logradouros>(entity =>
            {
                entity.HasKey(e => e.CdLogradouro);

                entity.ToTable("LOGRADOUROS");

                entity.Property(e => e.CdLogradouro)
                    .HasColumnName("CD_LOGRADOURO")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdBairro).HasColumnName("CD_BAIRRO");

                entity.Property(e => e.CdTipoLogradouros).HasColumnName("CD_TIPO_LOGRADOUROS");

                entity.Property(e => e.DsLogradouroNome)
                    .IsRequired()
                    .HasColumnName("DS_LOGRADOURO_NOME")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.NoLogradouroCep)
                    .IsRequired()
                    .HasColumnName("NO_LOGRADOURO_CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdBairroNavigation)
                    .WithMany(p => p.Logradouros)
                    .HasForeignKey(d => d.CdBairro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOGRADOUROS_BAIRROS");
            });

            modelBuilder.Entity<Tbcliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente);

                entity.ToTable("TBCLIENTE");

                entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("COMPLEMENTO")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Datanascimento)
                    .HasColumnName("DATANASCIMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nomecliente)
                    .HasColumnName("NOMECLIENTE")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("NUMERO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rgcliente)
                    .HasColumnName("RGCLIENTE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha).HasColumnName("SENHA");

                entity.Property(e => e.Telefonecelular)
                    .HasColumnName("TELEFONECELULAR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Telefonefixo)
                    .HasColumnName("TELEFONEFIXO")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbempresa>(entity =>
            {
                entity.HasKey(e => e.Idempresa);

                entity.ToTable("TBEMPRESA");

                entity.Property(e => e.Idempresa).HasColumnName("IDEMPRESA");

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Complemente)
                    .HasColumnName("COMPLEMENTE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Datacadastro)
                    .HasColumnName("DATACADASTRO")
                    .HasColumnType("date");

                entity.Property(e => e.Nomeempresa)
                    .HasColumnName("NOMEEMPRESA")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("NUMERO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Razaosocial)
                    .HasColumnName("RAZAOSOCIAL")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbpagamento>(entity =>
            {
                entity.HasKey(e => e.Idpagamento);

                entity.ToTable("TBPAGAMENTO");

                entity.Property(e => e.Idpagamento).HasColumnName("IDPAGAMENTO");

                entity.Property(e => e.Chavepagamento)
                    .IsRequired()
                    .HasColumnName("CHAVEPAGAMENTO")
                    .IsUnicode(false);

                entity.Property(e => e.Datapagamento)
                    .HasColumnName("DATAPAGAMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idreserva).HasColumnName("IDRESERVA");

                entity.Property(e => e.Idtipopagamento).HasColumnName("IDTIPOPAGAMENTO");

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.HasOne(d => d.IdreservaNavigation)
                    .WithMany(p => p.Tbpagamento)
                    .HasForeignKey(d => d.Idreserva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBPAGAMENTO_TBRESERVA");

                entity.HasOne(d => d.IdtipopagamentoNavigation)
                    .WithMany(p => p.Tbpagamento)
                    .HasForeignKey(d => d.Idtipopagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBPAGAMENTO_TBTIPOPAGAMENTO");
            });

            modelBuilder.Entity<Tbproduto>(entity =>
            {
                entity.HasKey(e => e.Idproduto);

                entity.ToTable("TBPRODUTO");

                entity.Property(e => e.Idproduto).HasColumnName("IDPRODUTO");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("VALOR");
            });

            modelBuilder.Entity<Tbprodutoreserva>(entity =>
            {
                entity.HasKey(e => e.Idprodutocheckout);

                entity.ToTable("TBPRODUTORESERVA");

                entity.Property(e => e.Idprodutocheckout).HasColumnName("IDPRODUTOCHECKOUT");

                entity.Property(e => e.Idproduto).HasColumnName("IDPRODUTO");

                entity.Property(e => e.Idreserva).HasColumnName("IDRESERVA");

                entity.Property(e => e.Quantidade).HasColumnName("QUANTIDADE");

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Tbprodutoreserva)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("FK_TBPRODUTORESERVA_TBPRODUTO");

                entity.HasOne(d => d.IdreservaNavigation)
                    .WithMany(p => p.Tbprodutoreserva)
                    .HasForeignKey(d => d.Idreserva)
                    .HasConstraintName("FK_TBPRODUTORESERVA_TBRESERVA");
            });

            modelBuilder.Entity<Tbquarto>(entity =>
            {
                entity.HasKey(e => e.Idquarto);

                entity.ToTable("TBQUARTO");

                entity.Property(e => e.Idquarto).HasColumnName("IDQUARTO");

                entity.Property(e => e.Andar)
                    .HasColumnName("ANDAR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Arcondicionado).HasColumnName("ARCONDICIONADO");

                entity.Property(e => e.Camacasal).HasColumnName("CAMACASAL");

                entity.Property(e => e.Camasolteiro).HasColumnName("CAMASOLTEIRO");

                entity.Property(e => e.Idempresa).HasColumnName("IDEMPRESA");

                entity.Property(e => e.Quarto)
                    .HasColumnName("QUARTO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.Property(e => e.Varanda).HasColumnName("VARANDA");

                entity.HasOne(d => d.IdempresaNavigation)
                    .WithMany(p => p.Tbquarto)
                    .HasForeignKey(d => d.Idempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBQUARTO_TBEMPRESA");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Tbquarto)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_TBQUARTO_TBSTATUS");
            });

            modelBuilder.Entity<Tbquartofoto>(entity =>
            {
                entity.HasKey(e => e.Idquartoimagem);

                entity.ToTable("TBQUARTOFOTO");

                entity.Property(e => e.Idquartoimagem).HasColumnName("IDQUARTOIMAGEM");

                entity.Property(e => e.Dataatualizacao)
                    .HasColumnName("DATAATUALIZACAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idquarto).HasColumnName("IDQUARTO");

                entity.Property(e => e.Idusuarioatualizacao).HasColumnName("IDUSUARIOATUALIZACAO");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .HasColumnName("IMAGEM")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbreserva>(entity =>
            {
                entity.HasKey(e => e.Idreserva);

                entity.ToTable("TBRESERVA");

                entity.Property(e => e.Idreserva).HasColumnName("IDRESERVA");

                entity.Property(e => e.Checkout).HasColumnName("CHECKOUT");

                entity.Property(e => e.Datacadastro)
                    .HasColumnName("DATACADASTRO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datacancelamento)
                    .HasColumnName("DATACANCELAMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Dataentrada)
                    .HasColumnName("DATAENTRADA")
                    .HasColumnType("date");

                entity.Property(e => e.Datafinalizacao)
                    .HasColumnName("DATAFINALIZACAO")
                    .HasColumnType("date");

                entity.Property(e => e.Datasaida)
                    .HasColumnName("DATASAIDA")
                    .HasColumnType("date");

                entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");

                entity.Property(e => e.Idquarto).HasColumnName("IDQUARTO");

                entity.Property(e => e.Motivocancelamento)
                    .HasColumnName("MOTIVOCANCELAMENTO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Tbreserva)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBRESERVA_TBCLIENTE");

                entity.HasOne(d => d.IdquartoNavigation)
                    .WithMany(p => p.Tbreserva)
                    .HasForeignKey(d => d.Idquarto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBRESERVA_TBQUARTO");
            });

            modelBuilder.Entity<Tbstatus>(entity =>
            {
                entity.HasKey(e => e.Idstatus);

                entity.ToTable("TBSTATUS");

                entity.Property(e => e.Idstatus).HasColumnName("IDSTATUS");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbtipopagamento>(entity =>
            {
                entity.HasKey(e => e.Idtipopagamento);

                entity.ToTable("TBTIPOPAGAMENTO");

                entity.Property(e => e.Idtipopagamento).HasColumnName("IDTIPOPAGAMENTO");

                entity.Property(e => e.Tipopagamento)
                    .HasColumnName("TIPOPAGAMENTO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbusuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("TBUSUARIO");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Datanascimento)
                    .HasColumnName("DATANASCIMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Idempresa).HasColumnName("IDEMPRESA");

                entity.Property(e => e.Loginusuario)
                    .HasColumnName("LOGINUSUARIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nomeusuario)
                    .IsRequired()
                    .HasColumnName("NOMEUSUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha).HasColumnName("SENHA");
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.HasKey(e => e.CdUf);

                entity.ToTable("UF");

                entity.Property(e => e.CdUf)
                    .HasColumnName("CD_UF")
                    .ValueGeneratedNever();

                entity.Property(e => e.DsUfNome)
                    .IsRequired()
                    .HasColumnName("DS_UF_NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DsUfSigla)
                    .IsRequired()
                    .HasColumnName("DS_UF_SIGLA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
