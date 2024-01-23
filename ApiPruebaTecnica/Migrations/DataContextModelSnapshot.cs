﻿// <auto-generated />
using System;
using ApiPruebaTecnica.DbModel.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiPruebaTecnica.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiPruebaTecnica.DbModel.Entities.Curso", b =>
                {
                    b.Property<string>("Cod_Curso")
                        .HasColumnType("Varchar(10)");

                    b.Property<string>("Cod_Linea_Negocio")
                        .HasColumnType("Char(1)");

                    b.Property<string>("Desc_Curso")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("Fecha_Modificacion")
                        .HasColumnType("Date");

                    b.Property<string>("Usuario_Creador")
                        .IsRequired()
                        .HasColumnType("Varchar(8)");

                    b.Property<string>("Usuario_Modificador")
                        .HasColumnType("Varchar(8)");

                    b.HasKey("Cod_Curso", "Cod_Linea_Negocio");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("ApiPruebaTecnica.DbModel.Entities.Det_Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Curso_Cod_Curso")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Curso_Linea_Negocio")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("Fecha_Modificacion")
                        .HasColumnType("Date");

                    b.Property<string>("Grupo")
                        .IsRequired()
                        .HasColumnType("Char(2)");

                    b.Property<int>("Matricula_Id_Matricula")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Seccion")
                        .IsRequired()
                        .HasColumnType("Varchar(5)");

                    b.Property<string>("Usuario_Creador")
                        .IsRequired()
                        .HasColumnType("Varchar(8)");

                    b.Property<string>("Usuario_Modificador")
                        .HasColumnType("Varchar(8)");

                    b.HasKey("Id");

                    b.ToTable("DetallesMatricula");
                });

            modelBuilder.Entity("ApiPruebaTecnica.DbModel.Entities.Matricula", b =>
                {
                    b.Property<int>("Id_Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Matricula"));

                    b.Property<string>("Cod_Alumno")
                        .IsRequired()
                        .HasColumnType("Varchar(9)");

                    b.Property<string>("Cod_Linea_Negocio")
                        .IsRequired()
                        .HasColumnType("Char(1)");

                    b.Property<string>("Cod_Modal_Est")
                        .IsRequired()
                        .HasColumnType("Char(2)");

                    b.Property<string>("Cod_Periodo")
                        .IsRequired()
                        .HasColumnType("Char(6)");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("Fecha_Modificacion")
                        .HasColumnType("Date");

                    b.Property<string>("Usuario_Creador")
                        .IsRequired()
                        .HasColumnType("Varchar(8)");

                    b.Property<string>("Usuario_Modificador")
                        .HasColumnType("Varchar(8)");

                    b.HasKey("Id_Matricula");

                    b.ToTable("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
