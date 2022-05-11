using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsultorioSolidario.Models
{
    public partial class bdConsultaMedicaSolidariaContext : DbContext
    {
        public bdConsultaMedicaSolidariaContext()
        {
        }

        public bdConsultaMedicaSolidariaContext(DbContextOptions<bdConsultaMedicaSolidariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Centro> Centros { get; set; } = null!;
        public virtual DbSet<Ciudad> Ciudades { get; set; } = null!;
        public virtual DbSet<Colaborador> Colaboradores { get; set; } = null!;
        public virtual DbSet<Consulta> Consultas { get; set; } = null!;
        public virtual DbSet<ConsultaMedicamento> ConsultaMedicamentos { get; set; } = null!;
        public virtual DbSet<ConsultaPrueba> ConsultaPruebas { get; set; } = null!;
        public virtual DbSet<Documento> Documentos { get; set; } = null!;
        public virtual DbSet<Especialista> Especialistas { get; set; } = null!;
        public virtual DbSet<EstadosConsulta> EstadosConsulta { get; set; } = null!;
        public virtual DbSet<EstadosUsuario> EstadosUsuarios { get; set; } = null!;
        public virtual DbSet<HistorialPaciente> HistorialPacientes { get; set; } = null!;
        public virtual DbSet<Idioma> Idiomas { get; set; } = null!;
        public virtual DbSet<Medicamento> Medicamentos { get; set; } = null!;
        public virtual DbSet<Mensaje> Mensajes { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Pagina> Paginas { get; set; } = null!;
        public virtual DbSet<Pais> Paises { get; set; } = null!;
        public virtual DbSet<Provincia> Provincias { get; set; } = null!;
        public virtual DbSet<Prueba> Pruebas { get; set; } = null!;
        public virtual DbSet<Rol> Roles { get; set; } = null!;
        public virtual DbSet<Sanitario> Sanitarios { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<TipoHistorial> TipoHistorials { get; set; } = null!;
        public virtual DbSet<TiposColaborador> TiposColaboradors { get; set; } = null!;
        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; } = null!;
        public virtual DbSet<TiposEspecialista> TiposEspecialista { get; set; } = null!;
        public virtual DbSet<TiposSanitario> TiposSanitarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LMLRFT7\\SQLEXPRESS; Database=bdConsultaMedicaSolidaria; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Centro>(entity =>
            {
                entity.HasKey(e => e.CenUsu);

                entity.ToTable("CENTROS");

                entity.Property(e => e.CenUsu)
                    .ValueGeneratedNever()
                    .HasColumnName("cen_usu");

                entity.Property(e => e.CenDes)
                    .HasMaxLength(255)
                    .HasColumnName("cen_des")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CenNom)
                    .HasMaxLength(100)
                    .HasColumnName("cen_nom")
                    .IsFixedLength();

                entity.HasOne(d => d.CenUsuNavigation)
                    .WithOne(p => p.Centro)
                    .HasForeignKey<Centro>(d => d.CenUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CENTROS_USUARIOS");

                entity.HasMany(d => d.SceSvcs)
                    .WithMany(p => p.SceCens)
                    .UsingEntity<Dictionary<string, object>>(
                        "ServiciosCentro",
                        l => l.HasOne<Servicio>().WithMany().HasForeignKey("SceSvc").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SERVICIOS_CENTRO_SERVICIOS"),
                        r => r.HasOne<Centro>().WithMany().HasForeignKey("SceCen").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SERVICIOS_CENTRO_CENTROS"),
                        j =>
                        {
                            j.HasKey("SceCen", "SceSvc").HasName("PK_SERVICIOSCENTRO");

                            j.ToTable("SERVICIOS_CENTRO");

                            j.IndexerProperty<int>("SceCen").HasColumnName("sce_cen");

                            j.IndexerProperty<int>("SceSvc").HasColumnName("sce_svc");
                        });
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.CiuCod);

                entity.ToTable("CIUDADES");

                entity.Property(e => e.CiuCod).HasColumnName("ciu_cod");

                entity.Property(e => e.CiuNom)
                    .HasMaxLength(256)
                    .HasColumnName("ciu_nom");

                entity.Property(e => e.CiudPro).HasColumnName("ciud_pro");

                entity.HasOne(d => d.CiudProNavigation)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.CiudPro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CIUDADES_PROVINCIAS");
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.HasKey(e => e.ColUsu);

                entity.ToTable("COLABORADORES");

                entity.Property(e => e.ColUsu)
                    .ValueGeneratedNever()
                    .HasColumnName("col_usu");

                entity.Property(e => e.ColDes)
                    .HasMaxLength(255)
                    .HasColumnName("col_des");

                entity.Property(e => e.ColNco)
                    .HasMaxLength(100)
                    .HasColumnName("col_nco");

                entity.Property(e => e.ColTco).HasColumnName("col_tco");

                entity.HasOne(d => d.ColTcoNavigation)
                    .WithMany(p => p.Colaboradores)
                    .HasForeignKey(d => d.ColTco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COLABORADORES_TIPOS_COLABORADOR");

                entity.HasOne(d => d.ColUsuNavigation)
                    .WithOne(p => p.Colaboradore)
                    .HasForeignKey<Colaborador>(d => d.ColUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COLABORADORES_USUARIOS");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.ConCod);

                entity.ToTable("CONSULTAS");

                entity.Property(e => e.ConCod).HasColumnName("con_cod");

                entity.Property(e => e.ConEco).HasColumnName("con_eco");

                entity.Property(e => e.ConEsp).HasColumnName("con_esp");

                entity.Property(e => e.ConFch)
                    .HasColumnType("date")
                    .HasColumnName("con_fch");

                entity.Property(e => e.ConMot)
                    .HasMaxLength(256)
                    .HasColumnName("con_mot");

                entity.Property(e => e.ConPac).HasColumnName("con_pac");

                entity.Property(e => e.ConPat)
                    .HasMaxLength(256)
                    .HasColumnName("con_pat");

                entity.Property(e => e.ConSan).HasColumnName("con_san");

                entity.Property(e => e.ConTes).HasColumnName("con_tes");

                entity.Property(e => e.ConTra).HasColumnName("con_tra");

                entity.HasOne(d => d.ConEcoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.ConEco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSULTAS_ESTADOS_CONSULTA");

                entity.HasOne(d => d.ConEspNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.ConEsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSULTAS_ESPECIALISTAS");

                entity.HasOne(d => d.ConPacNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.ConPac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSULTAS_PACIENTES");

                entity.HasOne(d => d.ConSanNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.ConSan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSULTAS_SANITARIOS");

                entity.HasOne(d => d.ConTesNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.ConTes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSULTAS_TIPOS_ESPECIALISTA");
            });

            modelBuilder.Entity<ConsultaMedicamento>(entity =>
            {
                entity.HasKey(e => new { e.CmeCon, e.CmeMed });

                entity.ToTable("CONSULTA_MEDICAMENTOS");

                entity.Property(e => e.CmeCon).HasColumnName("cme_con");

                entity.Property(e => e.CmeMed).HasColumnName("cme_med");

                entity.Property(e => e.CmeDes)
                    .HasMaxLength(500)
                    .HasColumnName("cme_des");

                entity.Property(e => e.CmeFch)
                    .HasColumnType("datetime")
                    .HasColumnName("cme_fch");

                entity.HasOne(d => d.CmeConNavigation)
                    .WithMany(p => p.ConsultaMedicamentos)
                    .HasForeignKey(d => d.CmeCon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSULTA_MEDICAMENTOS_CONSULTAS");

                entity.HasOne(d => d.CmeMedNavigation)
                    .WithMany(p => p.ConsultaMedicamentos)
                    .HasForeignKey(d => d.CmeMed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSULTA_MEDICAMENTOS_MEDICAMENTOS");
            });

            modelBuilder.Entity<ConsultaPrueba>(entity =>
            {
                entity.HasKey(e => new { e.CprCon, e.CprPru })
                    .HasName("PK_PRUEBAS_CONSULTA");

                entity.ToTable("CONSULTA_PRUEBAS");

                entity.Property(e => e.CprCon).HasColumnName("cpr_con");

                entity.Property(e => e.CprPru).HasColumnName("cpr_pru");

                entity.Property(e => e.CprDes)
                    .HasMaxLength(500)
                    .HasColumnName("cpr_des");

                entity.Property(e => e.CprFch)
                    .HasColumnType("datetime")
                    .HasColumnName("cpr_fch");

                entity.HasOne(d => d.CprConNavigation)
                    .WithMany(p => p.ConsultaPruebas)
                    .HasForeignKey(d => d.CprCon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSULTA_PRUEBAS_CONSULTAS");

                entity.HasOne(d => d.CprPruNavigation)
                    .WithMany(p => p.ConsultaPruebas)
                    .HasForeignKey(d => d.CprPru)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSULTA_PRUEBAS_PRUEBAS");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.DocCod);

                entity.ToTable("DOCUMENTOS");

                entity.Property(e => e.DocCod)
                    .ValueGeneratedNever()
                    .HasColumnName("doc_cod");

                entity.Property(e => e.DocAce).HasColumnName("doc_ace");

                entity.Property(e => e.DocDes)
                    .HasMaxLength(1000)
                    .HasColumnName("doc_des");

                entity.Property(e => e.DocFch)
                    .HasColumnType("date")
                    .HasColumnName("doc_fch");

                entity.Property(e => e.DocTdc).HasColumnName("doc_tdc");

                entity.Property(e => e.DocUsu).HasColumnName("doc_usu");

                entity.HasOne(d => d.DocTdcNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.DocTdc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCUMENTOS_TIPOS_DOCUMENTO");

                entity.HasOne(d => d.DocUsuNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.DocUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DOCUMENTOS_USUARIOS");
            });

            modelBuilder.Entity<Especialista>(entity =>
            {
                entity.HasKey(e => e.EspUsu);

                entity.ToTable("ESPECIALISTAS");

                entity.Property(e => e.EspUsu)
                    .ValueGeneratedNever()
                    .HasColumnName("esp_usu");

                entity.Property(e => e.EspDes)
                    .HasMaxLength(256)
                    .HasColumnName("esp_des");

                entity.Property(e => e.EspNco)
                    .HasMaxLength(100)
                    .HasColumnName("esp_nco")
                    .IsFixedLength();

                entity.Property(e => e.EspTes).HasColumnName("esp_tes");

                entity.Property(e => e.EspTri).HasColumnName("esp_tri");

                entity.HasOne(d => d.EspTesNavigation)
                    .WithMany(p => p.Especialista)
                    .HasForeignKey(d => d.EspTes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESPECIALISTAS_TIPOS_ESPECIALISTA");

                entity.HasOne(d => d.EspUsuNavigation)
                    .WithOne(p => p.Especialista)
                    .HasForeignKey<Especialista>(d => d.EspUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESPECIALISTAS_USUARIOS");
            });

            modelBuilder.Entity<EstadosConsulta>(entity =>
            {
                entity.HasKey(e => e.EcoCod);

                entity.ToTable("ESTADOS_CONSULTA");

                entity.Property(e => e.EcoCod).HasColumnName("eco_cod");

                entity.Property(e => e.EcoDes)
                    .HasMaxLength(50)
                    .HasColumnName("eco_des")
                    .IsFixedLength();
            });

            modelBuilder.Entity<EstadosUsuario>(entity =>
            {
                entity.HasKey(e => e.EusCod);

                entity.ToTable("ESTADOS_USUARIO");

                entity.Property(e => e.EusCod).HasColumnName("eus_cod");

                entity.Property(e => e.EusDes)
                    .HasMaxLength(100)
                    .HasColumnName("eus_des")
                    .IsFixedLength();
            });

            modelBuilder.Entity<HistorialPaciente>(entity =>
            {
                entity.HasKey(e => e.HpaCod);

                entity.ToTable("HISTORIAL_PACIENTE");

                entity.Property(e => e.HpaCod)
                    .HasColumnName("hpa_cod")
                    .HasComment("clave primaria");

                entity.Property(e => e.HpaDes)
                    .HasColumnName("hpa_des")
                    .HasComment("Descripción  de la prueba");

                entity.Property(e => e.HpaFch)
                    .HasColumnType("datetime")
                    .HasColumnName("hpa_fch")
                    .HasComment("fecha de realización de la prueba");

                entity.Property(e => e.HpaPac)
                    .HasColumnName("hpa_pac")
                    .HasComment("clave foránea al paciente");

                entity.Property(e => e.HpaThi)
                    .HasColumnName("hpa_thi")
                    .HasComment("cf al tipo de historial ( analítica, informe, resonancia ..)");

                entity.HasOne(d => d.HpaPacNavigation)
                    .WithMany(p => p.HistorialPacientes)
                    .HasForeignKey(d => d.HpaPac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORIAL_PACIENTE_PACIENTES");

                entity.HasOne(d => d.HpaThiNavigation)
                    .WithMany(p => p.HistorialPacientes)
                    .HasForeignKey(d => d.HpaThi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORIAL_PACIENTE_TIPO_HISTORIAL");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdiCod);

                entity.ToTable("IDIOMAS");

                entity.Property(e => e.IdiCod).HasColumnName("idi_cod");

                entity.Property(e => e.IdiNom)
                    .HasMaxLength(50)
                    .HasColumnName("idi_nom")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.MedCod);

                entity.ToTable("MEDICAMENTOS");

                entity.Property(e => e.MedCod).HasColumnName("med_cod");

                entity.Property(e => e.MedFor)
                    .HasMaxLength(100)
                    .HasColumnName("med_for");

                entity.Property(e => e.MedNom)
                    .HasMaxLength(100)
                    .HasColumnName("med_nom");

                entity.Property(e => e.MedPos)
                    .HasMaxLength(100)
                    .HasColumnName("med_pos");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.HasKey(e => e.MenCod);

                entity.ToTable("MENSAJES");

                entity.Property(e => e.MenCod)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("men_cod");

                entity.Property(e => e.MenFch)
                    .HasColumnType("datetime")
                    .HasColumnName("men_fch");

                entity.Property(e => e.MenLee).HasColumnName("men_lee");

                entity.Property(e => e.MenTxt).HasColumnName("men_txt");

                entity.Property(e => e.MenUde).HasColumnName("men_ude");

                entity.Property(e => e.MenUor).HasColumnName("men_uor");

                entity.HasOne(d => d.MenCodNavigation)
                    .WithOne(p => p.MensajeMenCodNavigation)
                    .HasForeignKey<Mensaje>(d => d.MenCod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENSAJES_USUARIOS");

                entity.HasOne(d => d.MenUdeNavigation)
                    .WithMany(p => p.MensajeMenUdeNavigations)
                    .HasForeignKey(d => d.MenUde)
                    .HasConstraintName("FK_MENSAJES_USUARIOS1");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.PacUsu);

                entity.ToTable("PACIENTES");

                entity.Property(e => e.PacUsu)
                    .ValueGeneratedNever()
                    .HasColumnName("pac_usu");

                entity.Property(e => e.PacFch)
                    .HasColumnType("date")
                    .HasColumnName("pac_fch");

                entity.Property(e => e.PacSan)
                    .HasMaxLength(10)
                    .HasColumnName("pac_san")
                    .IsFixedLength()
                    .HasComment("Grupo sanguineo");

                entity.Property(e => e.PacSex)
                    .HasMaxLength(10)
                    .HasColumnName("pac_sex")
                    .IsFixedLength();

                entity.HasOne(d => d.PacUsuNavigation)
                    .WithOne(p => p.Paciente)
                    .HasForeignKey<Paciente>(d => d.PacUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PACIENTES_USUARIOS");
            });

            modelBuilder.Entity<Pagina>(entity =>
            {
                entity.HasKey(e => e.PagCod);

                entity.ToTable("PAGINAS");

                entity.Property(e => e.PagCod).HasColumnName("pag_cod");

                entity.Property(e => e.PagNom)
                    .HasMaxLength(256)
                    .HasColumnName("pag_nom");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.PaiCod);

                entity.ToTable("PAISES");

                entity.Property(e => e.PaiCod).HasColumnName("pai_cod");

                entity.Property(e => e.PaiNom)
                    .HasMaxLength(100)
                    .HasColumnName("pai_nom");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.ProCod);

                entity.ToTable("PROVINCIAS");

                entity.Property(e => e.ProCod).HasColumnName("pro_cod");

                entity.Property(e => e.ProNom)
                    .HasMaxLength(100)
                    .HasColumnName("pro_nom");

                entity.Property(e => e.ProPai).HasColumnName("pro_pai");

                entity.HasOne(d => d.ProPaiNavigation)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.ProPai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROVINCIAS_PAISES");
            });

            modelBuilder.Entity<Prueba>(entity =>
            {
                entity.HasKey(e => e.PruCod);

                entity.ToTable("PRUEBAS");

                entity.Property(e => e.PruCod)
                    .ValueGeneratedNever()
                    .HasColumnName("pru_cod");

                entity.Property(e => e.PruDes)
                    .HasMaxLength(500)
                    .HasColumnName("pru_des");

                entity.Property(e => e.PruNom)
                    .HasMaxLength(100)
                    .HasColumnName("pru_nom");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.RolCod);

                entity.ToTable("ROLES");

                entity.Property(e => e.RolCod).HasColumnName("rol_cod");

                entity.Property(e => e.RolDes)
                    .HasMaxLength(256)
                    .HasColumnName("rol_des");

                entity.HasMany(d => d.RpaPags)
                    .WithMany(p => p.RpaRols)
                    .UsingEntity<Dictionary<string, object>>(
                        "RolPagina",
                        l => l.HasOne<Pagina>().WithMany().HasForeignKey("RpaPag").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ROL_PAGINAS_PAGINAS"),
                        r => r.HasOne<Rol>().WithMany().HasForeignKey("RpaRol").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ROL_PAGINAS_ROLES"),
                        j =>
                        {
                            j.HasKey("RpaRol", "RpaPag");

                            j.ToTable("ROL_PAGINAS");

                            j.IndexerProperty<int>("RpaRol").HasColumnName("rpa_rol");

                            j.IndexerProperty<int>("RpaPag").HasColumnName("rpa_pag");
                        });
            });

            modelBuilder.Entity<Sanitario>(entity =>
            {
                entity.HasKey(e => e.SanUsu);

                entity.ToTable("SANITARIOS");

                entity.Property(e => e.SanUsu)
                    .ValueGeneratedNever()
                    .HasColumnName("san_usu");

                entity.Property(e => e.SanDes)
                    .HasMaxLength(100)
                    .HasColumnName("san_des");

                entity.Property(e => e.SanNco)
                    .HasMaxLength(50)
                    .HasColumnName("san_nco");

                entity.Property(e => e.SanTsa).HasColumnName("san_tsa");

                entity.HasOne(d => d.SanTsaNavigation)
                    .WithMany(p => p.Sanitarios)
                    .HasForeignKey(d => d.SanTsa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SANITARIOS_TIPOS_SANITARIO");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.SvcCod);

                entity.ToTable("SERVICIOS");

                entity.Property(e => e.SvcCod).HasColumnName("svc_cod");

                entity.Property(e => e.SvcDes)
                    .HasMaxLength(256)
                    .HasColumnName("svc_des");
            });

            modelBuilder.Entity<TipoHistorial>(entity =>
            {
                entity.HasKey(e => e.ThiCod);

                entity.ToTable("TIPO_HISTORIAL");

                entity.Property(e => e.ThiCod).HasColumnName("thi_cod");

                entity.Property(e => e.ThiDes)
                    .HasMaxLength(100)
                    .HasColumnName("thi_des")
                    .HasComment("alergia, vacuna, implante, operacion, medicacion, diagnostico, informe, peso, altura..");
            });

            modelBuilder.Entity<TiposColaborador>(entity =>
            {
                entity.HasKey(e => e.TcoCod);

                entity.ToTable("TIPOS_COLABORADOR");

                entity.Property(e => e.TcoCod).HasColumnName("tco_cod");

                entity.Property(e => e.TcoDes)
                    .HasMaxLength(256)
                    .HasColumnName("tco_des");
            });

            modelBuilder.Entity<TiposDocumento>(entity =>
            {
                entity.HasKey(e => e.TdcCod);

                entity.ToTable("TIPOS_DOCUMENTO");

                entity.Property(e => e.TdcCod).HasColumnName("tdc_cod");

                entity.Property(e => e.TdcNom)
                    .HasMaxLength(100)
                    .HasColumnName("tdc_nom")
                    .HasComment("documento acreditacion, politica privacidad, aviso legal...");
            });

            modelBuilder.Entity<TiposEspecialista>(entity =>
            {
                entity.HasKey(e => e.TesCod);

                entity.ToTable("TIPOS_ESPECIALISTA");

                entity.Property(e => e.TesCod).HasColumnName("tes_cod");

                entity.Property(e => e.TesDes)
                    .HasMaxLength(100)
                    .HasColumnName("tes_des");
            });

            modelBuilder.Entity<TiposSanitario>(entity =>
            {
                entity.HasKey(e => e.TsaCod);

                entity.ToTable("TIPOS_SANITARIO");

                entity.Property(e => e.TsaCod).HasColumnName("tsa_cod");

                entity.Property(e => e.TsaDes)
                    .HasMaxLength(200)
                    .HasColumnName("tsa_des");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuCod);

                entity.ToTable("USUARIOS");

                entity.Property(e => e.UsuCod).HasColumnName("usu_cod");

                entity.Property(e => e.UsuApe)
                    .HasMaxLength(100)
                    .HasColumnName("usu_ape");

                entity.Property(e => e.UsuCiu).HasColumnName("usu_ciu");

                entity.Property(e => e.UsuCpo)
                    .HasMaxLength(50)
                    .HasColumnName("usu_cpo")
                    .IsFixedLength();

                entity.Property(e => e.UsuDid)
                    .HasMaxLength(100)
                    .HasColumnName("usu_did");

                entity.Property(e => e.UsuDir)
                    .HasMaxLength(256)
                    .HasColumnName("usu_dir");

                entity.Property(e => e.UsuEma)
                    .HasMaxLength(256)
                    .HasColumnName("usu_ema");

                entity.Property(e => e.UsuEus).HasColumnName("usu_eus");

                entity.Property(e => e.UsuIdi).HasColumnName("usu_idi");

                entity.Property(e => e.UsuNem)
                    .HasMaxLength(256)
                    .HasColumnName("usu_nem");

                entity.Property(e => e.UsuNom)
                    .HasMaxLength(100)
                    .HasColumnName("usu_nom");

                entity.Property(e => e.UsuPai).HasColumnName("usu_pai");

                entity.Property(e => e.UsuPro).HasColumnName("usu_pro");

                entity.Property(e => e.UsuPwh).HasColumnName("usu_pwh");

                entity.Property(e => e.UsuRol).HasColumnName("usu_rol");

                entity.Property(e => e.UsuTfn)
                    .HasMaxLength(50)
                    .HasColumnName("usu_tfn")
                    .IsFixedLength();

                entity.HasOne(d => d.UsuCiuNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UsuCiu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIOS_CIUDADES");

                entity.HasOne(d => d.UsuEusNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UsuEus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIOS_ESTADOS_USUARIO");

                entity.HasOne(d => d.UsuIdiNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UsuIdi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIOS_IDIOMAS");

                entity.HasOne(d => d.UsuPaiNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UsuPai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIOS_PAISES");

                entity.HasOne(d => d.UsuProNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UsuPro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIOS_PROVINCIAS");

                entity.HasOne(d => d.UsuRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UsuRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIOS_ROLES");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
