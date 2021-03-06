// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderSystem;

#nullable disable

namespace OrderSystem.Migrations
{
    [DbContext(typeof(OrderSystemDbContext))]
    [Migration("20220705190229_UserRelationUpdated")]
    partial class UserRelationUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OrderSystem.Models.EveEvent", b =>
                {
                    b.Property<Guid>("EveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EveEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EveStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EveId");

                    b.ToTable("EveEvents");
                });

            modelBuilder.Entity("OrderSystem.Models.OrdOrder", b =>
                {
                    b.Property<Guid>("OrdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OStStatusOStId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrdTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PerPersonPerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsrUserUsrId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrdId");

                    b.HasIndex("OStStatusOStId");

                    b.HasIndex("PerPersonPerId");

                    b.HasIndex("UsrUserUsrId");

                    b.ToTable("OrdOrders");
                });

            modelBuilder.Entity("OrderSystem.Models.OStOrderStatus", b =>
                {
                    b.Property<Guid>("OStId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OStColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OStIsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("OStTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OStId");

                    b.ToTable("OStOrderStatuses");
                });

            modelBuilder.Entity("OrderSystem.Models.PerPerson", b =>
                {
                    b.Property<Guid>("PerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsrUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PerId");

                    b.HasIndex("RoRoleId");

                    b.HasIndex("UsrUserId")
                        .IsUnique();

                    b.ToTable("PerPersons");
                });

            modelBuilder.Entity("OrderSystem.Models.ProOrd", b =>
                {
                    b.Property<Guid>("ProId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.HasKey("ProId", "OrdId");

                    b.HasIndex("OrdId");

                    b.ToTable("ProOrds");
                });

            modelBuilder.Entity("OrderSystem.Models.ProProduct", b =>
                {
                    b.Property<Guid>("ProId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProPrice")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ProPriceBuy")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("ProId");

                    b.ToTable("ProProducts");
                });

            modelBuilder.Entity("OrderSystem.Models.RoRole", b =>
                {
                    b.Property<Guid>("RoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isStaff")
                        .HasColumnType("bit");

                    b.HasKey("RoId");

                    b.ToTable("RoRoles");
                });

            modelBuilder.Entity("OrderSystem.Models.ShiShift", b =>
                {
                    b.Property<Guid>("ShiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PerPersonPerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ShiEndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ShiStaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ShiStartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiTitel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShiId");

                    b.HasIndex("PerPersonPerId");

                    b.HasIndex("ShiStaId");

                    b.ToTable("ShiShifts");
                });

            modelBuilder.Entity("OrderSystem.Models.StaStation", b =>
                {
                    b.Property<Guid>("StaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StaEveId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaId");

                    b.HasIndex("StaEveId");

                    b.ToTable("StaStations");
                });

            modelBuilder.Entity("OrderSystem.Models.UsrUser", b =>
                {
                    b.Property<Guid>("UsrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PerPersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShiShiftShiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsrPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsrId");

                    b.HasIndex("ShiShiftShiId");

                    b.ToTable("UsrUsers");
                });

            modelBuilder.Entity("ProProductStaStation", b =>
                {
                    b.Property<Guid>("ProProductsProId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StaStationsStaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProProductsProId", "StaStationsStaId");

                    b.HasIndex("StaStationsStaId");

                    b.ToTable("ProProductStaStation");
                });

            modelBuilder.Entity("OrderSystem.Models.OrdOrder", b =>
                {
                    b.HasOne("OrderSystem.Models.OStOrderStatus", "OStStatus")
                        .WithMany()
                        .HasForeignKey("OStStatusOStId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderSystem.Models.PerPerson", null)
                        .WithMany("OrdOrders")
                        .HasForeignKey("PerPersonPerId");

                    b.HasOne("OrderSystem.Models.UsrUser", "UsrUser")
                        .WithMany()
                        .HasForeignKey("UsrUserUsrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OStStatus");

                    b.Navigation("UsrUser");
                });

            modelBuilder.Entity("OrderSystem.Models.PerPerson", b =>
                {
                    b.HasOne("OrderSystem.Models.RoRole", "RoRole")
                        .WithMany("PerPersons")
                        .HasForeignKey("RoRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderSystem.Models.UsrUser", "UsrUser")
                        .WithOne("PerPerson")
                        .HasForeignKey("OrderSystem.Models.PerPerson", "UsrUserId");

                    b.Navigation("RoRole");

                    b.Navigation("UsrUser");
                });

            modelBuilder.Entity("OrderSystem.Models.ProOrd", b =>
                {
                    b.HasOne("OrderSystem.Models.OrdOrder", "Order")
                        .WithMany("ProProducts")
                        .HasForeignKey("OrdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderSystem.Models.ProProduct", "Product")
                        .WithMany("OrdOrders")
                        .HasForeignKey("ProId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OrderSystem.Models.ShiShift", b =>
                {
                    b.HasOne("OrderSystem.Models.PerPerson", null)
                        .WithMany("ShiShifts")
                        .HasForeignKey("PerPersonPerId");

                    b.HasOne("OrderSystem.Models.StaStation", "ShiSta")
                        .WithMany("ShiShifts")
                        .HasForeignKey("ShiStaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShiSta");
                });

            modelBuilder.Entity("OrderSystem.Models.StaStation", b =>
                {
                    b.HasOne("OrderSystem.Models.EveEvent", "StaEve")
                        .WithMany("StaStations")
                        .HasForeignKey("StaEveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaEve");
                });

            modelBuilder.Entity("OrderSystem.Models.UsrUser", b =>
                {
                    b.HasOne("OrderSystem.Models.ShiShift", null)
                        .WithMany("UsrUsers")
                        .HasForeignKey("ShiShiftShiId");
                });

            modelBuilder.Entity("ProProductStaStation", b =>
                {
                    b.HasOne("OrderSystem.Models.ProProduct", null)
                        .WithMany()
                        .HasForeignKey("ProProductsProId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderSystem.Models.StaStation", null)
                        .WithMany()
                        .HasForeignKey("StaStationsStaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderSystem.Models.EveEvent", b =>
                {
                    b.Navigation("StaStations");
                });

            modelBuilder.Entity("OrderSystem.Models.OrdOrder", b =>
                {
                    b.Navigation("ProProducts");
                });

            modelBuilder.Entity("OrderSystem.Models.PerPerson", b =>
                {
                    b.Navigation("OrdOrders");

                    b.Navigation("ShiShifts");
                });

            modelBuilder.Entity("OrderSystem.Models.ProProduct", b =>
                {
                    b.Navigation("OrdOrders");
                });

            modelBuilder.Entity("OrderSystem.Models.RoRole", b =>
                {
                    b.Navigation("PerPersons");
                });

            modelBuilder.Entity("OrderSystem.Models.ShiShift", b =>
                {
                    b.Navigation("UsrUsers");
                });

            modelBuilder.Entity("OrderSystem.Models.StaStation", b =>
                {
                    b.Navigation("ShiShifts");
                });

            modelBuilder.Entity("OrderSystem.Models.UsrUser", b =>
                {
                    b.Navigation("PerPerson");
                });
#pragma warning restore 612, 618
        }
    }
}
