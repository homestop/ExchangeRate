﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(CurrencyDbContext))]
    [Migration("20200106140744_Initial_migration")]
    partial class Initial_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("CurrencyMonthlyId")
                        .HasColumnType("int");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("CurrencyRateId")
                        .HasColumnType("int");

                    b.HasKey("CurrencyId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CurrencyMonthlyId");

                    b.HasIndex("CurrencyRateId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Domain.Entities.CurrencyMonthly", b =>
                {
                    b.Property<int>("CurrencyMonthlyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastRefreshed")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("CurrencyMonthlyId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("CurrencyMonthlies");
                });

            modelBuilder.Entity("Domain.Entities.CurrencyRate", b =>
                {
                    b.Property<int>("CurrencyRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AskPrice")
                        .HasColumnType("real")
                        .HasMaxLength(40);

                    b.Property<float>("BidPrice")
                        .HasColumnType("real")
                        .HasMaxLength(40);

                    b.Property<string>("LastRefreshed")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("ToCurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrencyRateId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("CurrencyRates");
                });

            modelBuilder.Entity("Domain.Entities.Monthly", b =>
                {
                    b.Property<int>("MonthlyId")
                        .HasColumnType("int");

                    b.Property<string>("Published")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<float>("Close")
                        .HasColumnType("real")
                        .HasMaxLength(40);

                    b.Property<float>("High")
                        .HasColumnType("real")
                        .HasMaxLength(40);

                    b.Property<float>("Low")
                        .HasColumnType("real")
                        .HasMaxLength(40);

                    b.Property<float>("Open")
                        .HasColumnType("real")
                        .HasMaxLength(40);

                    b.HasKey("MonthlyId", "Published")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Monthlies");
                });

            modelBuilder.Entity("Domain.Entities.Currency", b =>
                {
                    b.HasOne("Domain.Entities.CurrencyMonthly", "CurrencyMonthly")
                        .WithMany("Currency")
                        .HasForeignKey("CurrencyMonthlyId")
                        .HasConstraintName("FK_Currency_CurrencyMonthly")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CurrencyRate", "CurrencyRate")
                        .WithMany("Currency")
                        .HasForeignKey("CurrencyRateId")
                        .HasConstraintName("FK_Currency_CurrencyRate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Monthly", b =>
                {
                    b.HasOne("Domain.Entities.CurrencyMonthly", "CurrencyMonthly")
                        .WithMany("Monthly")
                        .HasForeignKey("MonthlyId")
                        .HasConstraintName("FK_Montly_CurrencyMontly")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
