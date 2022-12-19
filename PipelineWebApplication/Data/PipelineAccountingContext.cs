using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PipelineWebApplication;

public partial class PipelineAccountingContext : DbContext
{
    public PipelineAccountingContext()
    {
    }

    public PipelineAccountingContext(DbContextOptions<PipelineAccountingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brigade> Brigades { get; set; }

    public virtual DbSet<BuildingСompany> BuildingСompanies { get; set; }

    public virtual DbSet<DiagnosticsRevisionPipeline> DiagnosticsRevisionPipelines { get; set; }

    public virtual DbSet<ExpertOrganization> ExpertOrganizations { get; set; }

    public virtual DbSet<Factory> Factories { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<InternalСoating> InternalСoatings { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<PipeType> PipeTypes { get; set; }

    public virtual DbSet<PipelineDatum> PipelineData { get; set; }

    public virtual DbSet<PipelinePassport> PipelinePassports { get; set; }

    public virtual DbSet<ReasonsDiagnostic> ReasonsDiagnostics { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Study> Studies { get; set; }

    public virtual DbSet<StudyControl> StudyControls { get; set; }

    public virtual DbSet<TypeControl> TypeControls { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PipelineAccounting;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brigade>(entity =>
        {
            entity.ToTable("Brigade");

            entity.HasIndex(e => e.UnitId, "IX_Brigade_UnitId");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Unit).WithMany(p => p.Brigades)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Brigade_Unit");
        });

        modelBuilder.Entity<BuildingСompany>(entity =>
        {
            entity.ToTable("BuildingСompany");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<DiagnosticsRevisionPipeline>(entity =>
        {
            entity.HasIndex(e => e.ExpertOrganizationId, "IX_DiagnosticsRevisionPipelines_ExpertOrganizationId");

            entity.HasIndex(e => e.PipelineDataId, "IX_DiagnosticsRevisionPipelines_PipelineDataId");

            entity.HasIndex(e => e.StudyId, "IX_DiagnosticsRevisionPipelines_StudyId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Conclusion).HasComment("Заключение");
            entity.Property(e => e.LetterNumber).HasMaxLength(50);
            entity.Property(e => e.PathFile).HasMaxLength(50);
            entity.Property(e => e.RegNumberOfRostekhnadzor).HasMaxLength(20);
            entity.Property(e => e.Salary).HasColumnType("money");

            entity.HasOne(d => d.ExpertOrganization).WithMany(p => p.DiagnosticsRevisionPipelines)
                .HasForeignKey(d => d.ExpertOrganizationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DiagnosticsRevisionPipelines_ExpertOrganization");

            entity.HasOne(d => d.PipelineData).WithMany(p => p.DiagnosticsRevisionPipelines)
                .HasForeignKey(d => d.PipelineDataId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DiagnosticsRevisionPipelines_PipelineData");

            entity.HasOne(d => d.Study).WithMany(p => p.DiagnosticsRevisionPipelines)
                .HasForeignKey(d => d.StudyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DiagnosticsRevisionPipelines_Study");
        });

        modelBuilder.Entity<ExpertOrganization>(entity =>
        {
            entity.ToTable("ExpertOrganization");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Factory>(entity =>
        {
            entity.ToTable("Factory");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.ToTable("Field");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<InternalСoating>(entity =>
        {
            entity.ToTable("InternalСoating");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.ToTable("Material");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.ToTable("Owner");
        });

        modelBuilder.Entity<PipeType>(entity =>
        {
            entity.ToTable("PipeType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PipelineDatum>(entity =>
        {
            entity.HasIndex(e => e.BrigadeId, "IX_PipelineData_BrigadeId");

            entity.HasIndex(e => e.FieldId, "IX_PipelineData_FieldId");

            entity.HasIndex(e => e.RegionControlId, "IX_PipelineData_RegionControlId");

            entity.HasIndex(e => e.RegionEndId, "IX_PipelineData_RegionEndId");

            entity.HasIndex(e => e.RegionStartId, "IX_PipelineData_RegionStartId");

            entity.Property(e => e.Category).HasMaxLength(1);
            entity.Property(e => e.FlowsheetNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PCalculated).HasColumnName("P_calculated");
            entity.Property(e => e.PFact).HasColumnName("P_fact");
            entity.Property(e => e.Purpose).HasMaxLength(50);
            entity.Property(e => e.State)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.TieInPlace)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TransportedMedium).HasMaxLength(50);

            entity.HasOne(d => d.Brigade).WithMany(p => p.PipelineData)
                .HasForeignKey(d => d.BrigadeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelineData_Brigade");

            entity.HasOne(d => d.Field).WithMany(p => p.PipelineData)
                .HasForeignKey(d => d.FieldId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelineData_Field");

            entity.HasOne(d => d.RegionControl).WithMany(p => p.PipelineDatumRegionControls)
                .HasForeignKey(d => d.RegionControlId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelineData_Region2");

            entity.HasOne(d => d.RegionEnd).WithMany(p => p.PipelineDatumRegionEnds)
                .HasForeignKey(d => d.RegionEndId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelineData_Region1");

            entity.HasOne(d => d.RegionStart).WithMany(p => p.PipelineDatumRegionStarts)
                .HasForeignKey(d => d.RegionStartId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelineData_Region");
        });

        modelBuilder.Entity<PipelinePassport>(entity =>
        {
            entity.ToTable("PipelinePassport");

            entity.HasIndex(e => e.BuildingCompanyId, "IX_PipelinePassport_BuildingCompanyId");

            entity.HasIndex(e => e.FactoryMptid, "IX_PipelinePassport_FactoryMPTId");

            entity.HasIndex(e => e.FactoryPipeId, "IX_PipelinePassport_FactoryPipeId");

            entity.HasIndex(e => e.InternalCoatingId, "IX_PipelinePassport_InternalCoatingId");

            entity.HasIndex(e => e.MaterialId, "IX_PipelinePassport_MaterialId");

            entity.HasIndex(e => e.PipeTypeId, "IX_PipelinePassport_PipeTypeId");

            entity.HasIndex(e => e.PipelineDataId, "IX_PipelinePassport_PipelineDataId");

            entity.Property(e => e.ConstructionCost).HasColumnType("money");
            entity.Property(e => e.FactoryMptid).HasColumnName("FactoryMPTId");
            entity.Property(e => e.OutdoorCoating)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PlotEnd).HasMaxLength(50);
            entity.Property(e => e.PlotStart).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TypeOfConstruction)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.BuildingCompany).WithMany(p => p.PipelinePassports)
                .HasForeignKey(d => d.BuildingCompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelinePassport_BuildingСompany");

            entity.HasOne(d => d.FactoryMpt).WithMany(p => p.PipelinePassportFactoryMpts)
                .HasForeignKey(d => d.FactoryMptid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelinePassport_Factory1");

            entity.HasOne(d => d.FactoryPipe).WithMany(p => p.PipelinePassportFactoryPipes)
                .HasForeignKey(d => d.FactoryPipeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelinePassport_Factory");

            entity.HasOne(d => d.InternalCoating).WithMany(p => p.PipelinePassports)
                .HasForeignKey(d => d.InternalCoatingId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelinePassport_InternalСoating");

            entity.HasOne(d => d.Material).WithMany(p => p.PipelinePassports)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelinePassport_Material");

            entity.HasOne(d => d.PipeType).WithMany(p => p.PipelinePassports)
                .HasForeignKey(d => d.PipeTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelinePassport_PipeType");

            entity.HasOne(d => d.PipelineData).WithMany(p => p.PipelinePassports)
                .HasForeignKey(d => d.PipelineDataId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PipelinePassport_PipelineData");
        });

        modelBuilder.Entity<ReasonsDiagnostic>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("Region");

            entity.HasIndex(e => e.OwnerId, "IX_Region_OwnerId");

            entity.HasOne(d => d.Owner).WithMany(p => p.Regions)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Region_Owner");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("Role");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Study>(entity =>
        {
            entity.ToTable("Study");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StudyControl>(entity =>
        {
            entity.HasIndex(e => e.TypeControlsId, "IX_StudyControls_TypeControlsId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.TypeControls).WithMany(p => p.StudyControls)
                .HasForeignKey(d => d.TypeControlsId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StudyControls_TypeControls");
        });

        modelBuilder.Entity<TypeControl>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit");

            entity.HasIndex(e => e.OwnerId, "IX_Unit_OwnerId");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Owner).WithMany(p => p.Units)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Unit_Owner");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Pass).HasMaxLength(256);
            entity.Property(e => e.SurName).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
