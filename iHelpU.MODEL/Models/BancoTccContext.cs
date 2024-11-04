using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace iHelpU.MODEL.Models;

public partial class BancoTccContext : DbContext
{
    public BancoTccContext()
    {
    }

    public BancoTccContext(DbContextOptions<BancoTccContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnuncioServico> AnuncioServicos { get; set; }

    public virtual DbSet<Avaliacao> Avaliacaos { get; set; }

    public virtual DbSet<Competencia> Competencias { get; set; }

    public virtual DbSet<ContratacaoServico> ContratacaoServicos { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TipoServico> TipoServicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioCompetencium> UsuarioCompetencia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnuncioServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__anuncio___3213E83F0AD04B82");

            entity.ToTable("anuncio_servico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CoordenadaX)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("coordenada_x");
            entity.Property(e => e.CoordenadaY)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("coordenada_y");
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.NomeServico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome_servico");
            entity.Property(e => e.TipoServicoId).HasColumnName("tipo_servico_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.AnuncioServicos)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK_anuncio_servico_Status");

            entity.HasOne(d => d.TipoServico).WithMany(p => p.AnuncioServicos)
                .HasForeignKey(d => d.TipoServicoId)
                .HasConstraintName("FK__anuncio_s__tipo___2F10007B");

            entity.HasOne(d => d.Usuario).WithMany(p => p.AnuncioServicos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__anuncio_s__usuar__300424B4");
        });

        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__avaliaca__3213E83FF7D28870");

            entity.ToTable("avaliacao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContratacaoServicoId).HasColumnName("contratacao_servico_id");
            entity.Property(e => e.DescricaoServico)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao_servico");
            entity.Property(e => e.Nota).HasColumnName("nota");

            entity.HasOne(d => d.ContratacaoServico).WithMany(p => p.Avaliacaos)
                .HasForeignKey(d => d.ContratacaoServicoId)
                .HasConstraintName("FK__avaliacao__contr__36B12243");
        });

        modelBuilder.Entity<Competencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__competen__3213E83F2D230B20");

            entity.ToTable("competencias");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.NomeCompetencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome_competencia");
            entity.Property(e => e.TipoServicoId).HasColumnName("tipo_servico_id");

            entity.HasOne(d => d.TipoServico).WithMany(p => p.Competencia)
                .HasForeignKey(d => d.TipoServicoId)
                .HasConstraintName("FK__competenc__tipo___286302EC");
        });

        modelBuilder.Entity<ContratacaoServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contrata__3213E83F29628FE9");

            entity.ToTable("contratacao_servico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnuncioServicoId).HasColumnName("anuncio_servico_id");
            entity.Property(e => e.DataContratacao)
                .HasColumnType("datetime")
                .HasColumnName("data_contratacao");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.AnuncioServico).WithMany(p => p.ContratacaoServicos)
                .HasForeignKey(d => d.AnuncioServicoId)
                .HasConstraintName("FK__contratac__anunc__32E0915F");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ContratacaoServicos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__contratac__usuar__33D4B598");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descricao");
        });

        modelBuilder.Entity<TipoServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipo_ser__3213E83F91051D59");

            entity.ToTable("tipo_servico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descricao");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83F40AC3B42");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PrimeiroNome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("primeiro_nome");
            entity.Property(e => e.SegundoNome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("segundo_nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senha");
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<UsuarioCompetencium>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioCompetencia).HasName("PK__usuario___7E1CEABC5C2887C7");

            entity.ToTable("usuario_competencia");

            entity.Property(e => e.IdUsuarioCompetencia)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_usuario_competencia");
            entity.Property(e => e.CompetenciaId).HasColumnName("competencia_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Competencia).WithMany(p => p.UsuarioCompetencia)
                .HasForeignKey(d => d.CompetenciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario_c__compe__2C3393D0");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioCompetencia)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario_c__usuar__2B3F6F97");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}