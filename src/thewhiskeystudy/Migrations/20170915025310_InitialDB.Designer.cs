﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using thewhiskeystudy.DAL;
using thewhiskeystudy.Enums;

namespace thewhiskeystudy.Migrations
{
    [DbContext(typeof(DBFactory))]
    [Migration("20170915025310_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("thewhiskeystudy.DAL.Tables.Reviews", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Body");

                    b.Property<int>("Category");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<double>("OverallScore");

                    b.Property<string>("Title");

                    b.Property<string>("URL");

                    b.HasKey("ID");

                    b.ToTable("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
