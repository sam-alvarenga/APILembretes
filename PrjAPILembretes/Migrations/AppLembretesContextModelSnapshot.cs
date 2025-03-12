﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrjAPILembretes.Context;

#nullable disable

namespace PrjAPILembretes.Migrations
{
    [DbContext(typeof(AppLembretesContext))]
    partial class AppLembretesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PrjAPILembretes.Entities.Lembrete", b =>
                {
                    b.Property<int>("LembreteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CorpoLembrente")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("StatusLembrete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Titulolembrete")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("LembreteId");

                    b.ToTable("Lembretes");
                });
#pragma warning restore 612, 618
        }
    }
}
