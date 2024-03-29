﻿// <auto-generated />
using System;
using JogosNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JogosNet.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("JogosNet.Models.Atendente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Atendentes");
                });

            modelBuilder.Entity("JogosNet.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("JogosNet.Models.Jogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassificacaoEtaria")
                        .HasColumnType("int");

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("JogosNet.Models.Locadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AtendenteId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AtendenteId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Locadoras");
                });

            modelBuilder.Entity("JogosNet.Models.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioDeEncerramento")
                        .HasColumnType("datetime");

                    b.Property<int>("JogoId")
                        .HasColumnType("int");

                    b.Property<int>("LocadoraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JogoId");

                    b.HasIndex("LocadoraId");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("JogosNet.Models.Locadora", b =>
                {
                    b.HasOne("JogosNet.Models.Atendente", "Atendente")
                        .WithMany("Locadoras")
                        .HasForeignKey("AtendenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JogosNet.Models.Endereco", "Endereco")
                        .WithOne("Locadora")
                        .HasForeignKey("JogosNet.Models.Locadora", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atendente");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("JogosNet.Models.Sessao", b =>
                {
                    b.HasOne("JogosNet.Models.Jogo", "Jogo")
                        .WithMany("Sessoes")
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JogosNet.Models.Locadora", "Locadora")
                        .WithMany("Sessoes")
                        .HasForeignKey("LocadoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jogo");

                    b.Navigation("Locadora");
                });

            modelBuilder.Entity("JogosNet.Models.Atendente", b =>
                {
                    b.Navigation("Locadoras");
                });

            modelBuilder.Entity("JogosNet.Models.Endereco", b =>
                {
                    b.Navigation("Locadora")
                        .IsRequired();
                });

            modelBuilder.Entity("JogosNet.Models.Jogo", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("JogosNet.Models.Locadora", b =>
                {
                    b.Navigation("Sessoes");
                });
#pragma warning restore 612, 618
        }
    }
}
