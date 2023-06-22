using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplicationPracticeOnes.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acdegree> Acdegrees { get; set; }

    public virtual DbSet<Ackbook> Ackbooks { get; set; }

    public virtual DbSet<Dolznost> Dolznosts { get; set; }

    public virtual DbSet<Ekzaman> Ekzamen { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Gruppa> Gruppas { get; set; }

    public virtual DbSet<Kafedra> Kafedras { get; set; }

    public virtual DbSet<Kur> Kurs { get; set; }

    public virtual DbSet<Oblast> Oblasts { get; set; }

    public virtual DbSet<Pol> Pols { get; set; }

    public virtual DbSet<Prepod> Prepods { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Semestr> Semestrs { get; set; }

    public virtual DbSet<Specialnost> Specialnosts { get; set; }

    public virtual DbSet<Stud> Studs { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Typeoch> Typeoches { get; set; }

    public virtual DbSet<Uroven> Urovens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;\nUsername=postgres;Password=62......w");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Acdegree>(entity =>
        {
            entity.HasKey(e => e.AcdegreeId).HasName("acdegree_pkey");

            entity.ToTable("acdegree");

            entity.Property(e => e.AcdegreeId)
                .ValueGeneratedNever()
                .HasColumnName("acdegree_id");
            entity.Property(e => e.Acdegree1)
                .HasMaxLength(50)
                .HasColumnName("acdegree");
            entity.Property(e => e.Acdegreeshort)
                .HasMaxLength(10)
                .HasColumnName("acdegreeshort");
            entity.Property(e => e.FkOblastId).HasColumnName("fk_oblast_id");
            entity.Property(e => e.FkUrovenId)
                .HasMaxLength(1)
                .HasColumnName("fk_uroven_id");

            entity.HasOne(d => d.FkOblast).WithMany(p => p.Acdegrees)
                .HasForeignKey(d => d.FkOblastId)
                .HasConstraintName("acdegree_fk_oblast_id_fkey");

            entity.HasOne(d => d.FkUroven).WithMany(p => p.Acdegrees)
                .HasForeignKey(d => d.FkUrovenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("acdegree_fk_uroven_id_fkey");
        });

        modelBuilder.Entity<Ackbook>(entity =>
        {
            entity.HasKey(e => e.AckbookId).HasName("ackbook_pkey");

            entity.ToTable("ackbook");

            entity.Property(e => e.AckbookId)
                .ValueGeneratedNever()
                .HasColumnName("ackbook_id");
            entity.Property(e => e.Datarec).HasColumnName("datarec");
            entity.Property(e => e.FkEkzamenId).HasColumnName("fk_ekzamen_id");
            entity.Property(e => e.FkStudId).HasColumnName("fk_stud_id");
            entity.Property(e => e.FkTypeochId).HasColumnName("fk_typeoch_id");

            entity.HasOne(d => d.FkEkzamen).WithMany(p => p.Ackbooks)
                .HasForeignKey(d => d.FkEkzamenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ackbook_fk_ekzamen_id_fkey");
        });

        modelBuilder.Entity<Dolznost>(entity =>
        {
            entity.HasKey(e => e.DolznostId).HasName("dolznost_pkey");

            entity.ToTable("dolznost");

            entity.Property(e => e.DolznostId)
                .ValueGeneratedNever()
                .HasColumnName("dolznost_id");
            entity.Property(e => e.Dolznost1)
                .HasMaxLength(20)
                .HasColumnName("dolznost");
        });

        modelBuilder.Entity<Ekzaman>(entity =>
        {
            entity.HasKey(e => e.EkzamenId).HasName("ekzamen_pkey");

            entity.ToTable("ekzamen");

            entity.Property(e => e.EkzamenId)
                .ValueGeneratedNever()
                .HasColumnName("ekzamen_id");
            entity.Property(e => e.FkPrepodId).HasColumnName("fk_prepod_id");
            entity.Property(e => e.FkSemestrId).HasColumnName("fk_semestr_id");
            entity.Property(e => e.FkSpecialnostId).HasColumnName("fk_specialnost_id");
            entity.Property(e => e.FkSubjectId).HasColumnName("fk_subject_id");

            entity.HasOne(d => d.FkSemestr).WithMany(p => p.Ekzamen)
                .HasForeignKey(d => d.FkSemestrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ekzamen_fk_semestr_id_fkey");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.FacultyId).HasName("faculty_pkey");

            entity.ToTable("faculty");

            entity.Property(e => e.FacultyId)
                .ValueGeneratedNever()
                .HasColumnName("faculty_id");
            entity.Property(e => e.Facshort)
                .HasMaxLength(6)
                .HasColumnName("facshort");
            entity.Property(e => e.Faculty1)
                .HasMaxLength(40)
                .HasColumnName("faculty");
        });

        modelBuilder.Entity<Gruppa>(entity =>
        {
            entity.HasKey(e => e.GruppaId).HasName("gruppa_pkey");

            entity.ToTable("gruppa");

            entity.Property(e => e.GruppaId)
                .ValueGeneratedNever()
                .HasColumnName("gruppa_id");
            entity.Property(e => e.FkFacultyId).HasColumnName("fk_faculty_id");
            entity.Property(e => e.FkKursId).HasColumnName("fk_kurs_id");
            entity.Property(e => e.FkSpecialnostId).HasColumnName("fk_specialnost_id");
            entity.Property(e => e.Gruppa1)
                .HasMaxLength(10)
                .HasColumnName("gruppa");

            entity.HasOne(d => d.FkKurs).WithMany(p => p.Gruppas)
                .HasForeignKey(d => d.FkKursId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gruppa_fk_kurs_id_fkey");
        });

        modelBuilder.Entity<Kafedra>(entity =>
        {
            entity.HasKey(e => e.KafedraId).HasName("kafedra_pkey");

            entity.ToTable("kafedra");

            entity.Property(e => e.KafedraId)
                .ValueGeneratedNever()
                .HasColumnName("kafedra_id");
            entity.Property(e => e.Kafedra1)
                .HasMaxLength(50)
                .HasColumnName("kafedra");
            entity.Property(e => e.Kafedrashort)
                .HasMaxLength(10)
                .HasColumnName("kafedrashort");
        });

        modelBuilder.Entity<Kur>(entity =>
        {
            entity.HasKey(e => e.KursId).HasName("kurs_pkey");

            entity.ToTable("kurs");

            entity.Property(e => e.KursId)
                .ValueGeneratedNever()
                .HasColumnName("kurs_id");
        });

        modelBuilder.Entity<Oblast>(entity =>
        {
            entity.HasKey(e => e.OblastId).HasName("oblast_pkey");

            entity.ToTable("oblast");

            entity.Property(e => e.OblastId)
                .ValueGeneratedNever()
                .HasColumnName("oblast_id");
            entity.Property(e => e.Oblast1)
                .HasMaxLength(30)
                .HasColumnName("oblast");
        });

        modelBuilder.Entity<Pol>(entity =>
        {
            entity.HasKey(e => e.PolId).HasName("pol_pkey");

            entity.ToTable("pol");

            entity.Property(e => e.PolId)
                .ValueGeneratedNever()
                .HasColumnName("pol_id");
            entity.Property(e => e.Pol1)
                .HasMaxLength(7)
                .HasColumnName("pol");
            entity.Property(e => e.PolShort)
                .HasMaxLength(1)
                .HasColumnName("pol_short");
        });

        modelBuilder.Entity<Prepod>(entity =>
        {
            entity.HasKey(e => e.PrepodId).HasName("prepod_pkey");

            entity.ToTable("prepod");

            entity.Property(e => e.PrepodId)
                .ValueGeneratedNever()
                .HasColumnName("prepod_id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.FkAcdegreeId).HasColumnName("fk_acdegree_id");
            entity.Property(e => e.FkDolznostId).HasColumnName("fk_dolznost_id");
            entity.Property(e => e.FkKafedraId).HasColumnName("fk_kafedra_id");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("lname");
            entity.Property(e => e.Mname)
                .HasMaxLength(50)
                .HasColumnName("mname");

            entity.HasOne(d => d.FkAcdegree).WithMany(p => p.Prepods)
                .HasForeignKey(d => d.FkAcdegreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prepod_fk_acdegree_id_fkey");

            entity.HasOne(d => d.FkDolznost).WithMany(p => p.Prepods)
                .HasForeignKey(d => d.FkDolznostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prepod_fk_dolznost_id_fkey");

            entity.HasOne(d => d.FkKafedra).WithMany(p => p.Prepods)
                .HasForeignKey(d => d.FkKafedraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prepod_fk_kafedra_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Semestr>(entity =>
        {
            entity.HasKey(e => e.SemestrId).HasName("semestr_pkey");

            entity.ToTable("semestr");

            entity.Property(e => e.SemestrId)
                .ValueGeneratedNever()
                .HasColumnName("semestr_id");
            entity.Property(e => e.FkKursId).HasColumnName("fk_kurs_id");
            entity.Property(e => e.Semestr1).HasColumnName("semestr");

            entity.HasOne(d => d.FkKurs).WithMany(p => p.Semestrs)
                .HasForeignKey(d => d.FkKursId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("semestr_fk_kurs_id_fkey");
        });

        modelBuilder.Entity<Specialnost>(entity =>
        {
            entity.HasKey(e => e.SpecialnostId).HasName("specialnost_pkey");

            entity.ToTable("specialnost");

            entity.Property(e => e.SpecialnostId)
                .ValueGeneratedNever()
                .HasColumnName("specialnost_id");
            entity.Property(e => e.Codocso)
                .HasMaxLength(10)
                .HasColumnName("codocso");
            entity.Property(e => e.Specialnost1)
                .HasMaxLength(100)
                .HasColumnName("specialnost");
        });

        modelBuilder.Entity<Stud>(entity =>
        {
            entity.HasKey(e => e.StudId).HasName("stud_pkey");

            entity.ToTable("stud");

            entity.Property(e => e.StudId)
                .ValueGeneratedNever()
                .HasColumnName("stud_id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.FkGruppaId).HasColumnName("fk_gruppa_id");
            entity.Property(e => e.FkPolId).HasColumnName("fk_pol_id");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("lname");
            entity.Property(e => e.Mname)
                .HasMaxLength(50)
                .HasColumnName("mname");
            entity.Property(e => e.Nozach)
                .HasMaxLength(10)
                .HasColumnName("nozach");
            entity.Property(e => e.Rost)
                .HasPrecision(7, 2)
                .HasColumnName("rost");
            entity.Property(e => e.Stipendia).HasColumnName("stipendia");
            entity.Property(e => e.Ves).HasColumnName("ves");

            entity.HasOne(d => d.FkGruppa).WithMany(p => p.Studs)
                .HasForeignKey(d => d.FkGruppaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stud_fk_gruppa_id_fkey");

            entity.HasOne(d => d.FkPol).WithMany(p => p.Studs)
                .HasForeignKey(d => d.FkPolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stud_fk_pol_id_fkey");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("subject_pkey");

            entity.ToTable("subject");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedNever()
                .HasColumnName("subject_id");
            entity.Property(e => e.Shortsubject)
                .HasMaxLength(10)
                .HasColumnName("shortsubject");
            entity.Property(e => e.Subject1)
                .HasMaxLength(50)
                .HasColumnName("subject");
        });

        modelBuilder.Entity<Typeoch>(entity =>
        {
            entity.HasKey(e => e.TypeochId).HasName("typeoch_pkey");

            entity.ToTable("typeoch");

            entity.Property(e => e.TypeochId)
                .ValueGeneratedNever()
                .HasColumnName("typeoch_id");
            entity.Property(e => e.Coment)
                .HasMaxLength(20)
                .HasColumnName("coment");
            entity.Property(e => e.Typeoch1).HasColumnName("typeoch");
        });

        modelBuilder.Entity<Uroven>(entity =>
        {
            entity.HasKey(e => e.UrovenId).HasName("uroven_pkey");

            entity.ToTable("uroven");

            entity.Property(e => e.UrovenId)
                .HasMaxLength(1)
                .HasColumnName("uroven_id");
            entity.Property(e => e.Uroven1)
                .HasMaxLength(50)
                .HasColumnName("uroven");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(150)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
