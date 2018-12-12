﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThesisPrototype.DatabaseApis;

namespace ThesisPrototype.Migrations
{
    [DbContext(typeof(PrototypeContext))]
    partial class PrototypeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ThesisPrototype.DataModels.DataImportMeta", b =>
                {
                    b.Property<int>("DataImportMetaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ImportDate");

                    b.Property<long>("ShipId");

                    b.HasKey("DataImportMetaId");

                    b.ToTable("DataImportMetas");
                });

            modelBuilder.Entity("ThesisPrototype.DataModels.EfSensorValuesRow", b =>
                {
                    b.Property<long>("EfSensorValuesRowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ImportTimestamp");

                    b.Property<long>("RowTimestamp");

                    b.Property<long>("ShipId");

                    b.Property<double>("sensor1");

                    b.Property<double>("sensor10");

                    b.Property<double>("sensor100");

                    b.Property<double>("sensor101");

                    b.Property<double>("sensor102");

                    b.Property<double>("sensor103");

                    b.Property<double>("sensor104");

                    b.Property<double>("sensor105");

                    b.Property<double>("sensor106");

                    b.Property<double>("sensor107");

                    b.Property<double>("sensor108");

                    b.Property<double>("sensor109");

                    b.Property<double>("sensor11");

                    b.Property<double>("sensor110");

                    b.Property<double>("sensor111");

                    b.Property<double>("sensor112");

                    b.Property<double>("sensor113");

                    b.Property<double>("sensor114");

                    b.Property<double>("sensor115");

                    b.Property<double>("sensor116");

                    b.Property<double>("sensor117");

                    b.Property<double>("sensor118");

                    b.Property<double>("sensor119");

                    b.Property<double>("sensor12");

                    b.Property<double>("sensor120");

                    b.Property<double>("sensor121");

                    b.Property<double>("sensor122");

                    b.Property<double>("sensor123");

                    b.Property<double>("sensor124");

                    b.Property<double>("sensor125");

                    b.Property<double>("sensor126");

                    b.Property<double>("sensor127");

                    b.Property<double>("sensor128");

                    b.Property<double>("sensor129");

                    b.Property<double>("sensor13");

                    b.Property<double>("sensor130");

                    b.Property<double>("sensor131");

                    b.Property<double>("sensor132");

                    b.Property<double>("sensor133");

                    b.Property<double>("sensor134");

                    b.Property<double>("sensor135");

                    b.Property<double>("sensor136");

                    b.Property<double>("sensor137");

                    b.Property<double>("sensor138");

                    b.Property<double>("sensor139");

                    b.Property<double>("sensor14");

                    b.Property<double>("sensor140");

                    b.Property<double>("sensor141");

                    b.Property<double>("sensor142");

                    b.Property<double>("sensor143");

                    b.Property<double>("sensor144");

                    b.Property<double>("sensor145");

                    b.Property<double>("sensor146");

                    b.Property<double>("sensor147");

                    b.Property<double>("sensor148");

                    b.Property<double>("sensor149");

                    b.Property<double>("sensor15");

                    b.Property<double>("sensor150");

                    b.Property<double>("sensor151");

                    b.Property<double>("sensor16");

                    b.Property<double>("sensor17");

                    b.Property<double>("sensor18");

                    b.Property<double>("sensor19");

                    b.Property<double>("sensor2");

                    b.Property<double>("sensor20");

                    b.Property<double>("sensor21");

                    b.Property<double>("sensor22");

                    b.Property<double>("sensor23");

                    b.Property<double>("sensor24");

                    b.Property<double>("sensor25");

                    b.Property<double>("sensor26");

                    b.Property<double>("sensor27");

                    b.Property<double>("sensor28");

                    b.Property<double>("sensor29");

                    b.Property<double>("sensor3");

                    b.Property<double>("sensor30");

                    b.Property<double>("sensor31");

                    b.Property<double>("sensor32");

                    b.Property<double>("sensor33");

                    b.Property<double>("sensor34");

                    b.Property<double>("sensor35");

                    b.Property<double>("sensor36");

                    b.Property<double>("sensor37");

                    b.Property<double>("sensor38");

                    b.Property<double>("sensor39");

                    b.Property<double>("sensor4");

                    b.Property<double>("sensor40");

                    b.Property<double>("sensor41");

                    b.Property<double>("sensor42");

                    b.Property<double>("sensor43");

                    b.Property<double>("sensor44");

                    b.Property<double>("sensor45");

                    b.Property<double>("sensor46");

                    b.Property<double>("sensor47");

                    b.Property<double>("sensor48");

                    b.Property<double>("sensor49");

                    b.Property<double>("sensor5");

                    b.Property<double>("sensor50");

                    b.Property<double>("sensor51");

                    b.Property<double>("sensor52");

                    b.Property<double>("sensor53");

                    b.Property<double>("sensor54");

                    b.Property<double>("sensor55");

                    b.Property<double>("sensor56");

                    b.Property<double>("sensor57");

                    b.Property<double>("sensor58");

                    b.Property<double>("sensor59");

                    b.Property<double>("sensor6");

                    b.Property<double>("sensor60");

                    b.Property<double>("sensor61");

                    b.Property<double>("sensor62");

                    b.Property<double>("sensor63");

                    b.Property<double>("sensor64");

                    b.Property<double>("sensor65");

                    b.Property<double>("sensor66");

                    b.Property<double>("sensor67");

                    b.Property<double>("sensor68");

                    b.Property<double>("sensor69");

                    b.Property<double>("sensor7");

                    b.Property<double>("sensor70");

                    b.Property<double>("sensor71");

                    b.Property<double>("sensor72");

                    b.Property<double>("sensor73");

                    b.Property<double>("sensor74");

                    b.Property<double>("sensor75");

                    b.Property<double>("sensor76");

                    b.Property<double>("sensor77");

                    b.Property<double>("sensor78");

                    b.Property<double>("sensor79");

                    b.Property<double>("sensor8");

                    b.Property<double>("sensor80");

                    b.Property<double>("sensor81");

                    b.Property<double>("sensor82");

                    b.Property<double>("sensor83");

                    b.Property<double>("sensor84");

                    b.Property<double>("sensor85");

                    b.Property<double>("sensor86");

                    b.Property<double>("sensor87");

                    b.Property<double>("sensor88");

                    b.Property<double>("sensor89");

                    b.Property<double>("sensor9");

                    b.Property<double>("sensor90");

                    b.Property<double>("sensor91");

                    b.Property<double>("sensor92");

                    b.Property<double>("sensor93");

                    b.Property<double>("sensor94");

                    b.Property<double>("sensor95");

                    b.Property<double>("sensor96");

                    b.Property<double>("sensor97");

                    b.Property<double>("sensor98");

                    b.Property<double>("sensor99");

                    b.HasKey("EfSensorValuesRowId");

                    b.HasIndex("ShipId");

                    b.ToTable("SensorValuesRows");
                });

            modelBuilder.Entity("ThesisPrototype.DataModels.Kpi", b =>
                {
                    b.Property<int>("KpiId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KpiEnum");

                    b.Property<int>("KpiType");

                    b.HasKey("KpiId");

                    b.ToTable("Kpis");
                });

            modelBuilder.Entity("ThesisPrototype.DataModels.Ship", b =>
                {
                    b.Property<long>("ShipId")
                        .HasColumnName("ShipId");

                    b.Property<string>("CountryName");

                    b.Property<string>("ImageName");

                    b.Property<int>("ImoNumber");

                    b.Property<string>("Name");

                    b.Property<long>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("ShipId");

                    b.HasIndex("UserId1");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("ThesisPrototype.DataModels.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<long>("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ThesisPrototype.DataModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ThesisPrototype.DataModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ThesisPrototype.DataModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ThesisPrototype.DataModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ThesisPrototype.DataModels.EfSensorValuesRow", b =>
                {
                    b.HasOne("ThesisPrototype.DataModels.Ship", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ThesisPrototype.DataModels.Ship", b =>
                {
                    b.HasOne("ThesisPrototype.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
