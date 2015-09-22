using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using WebApplication1.Models;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7")
                .Annotation("SqlServer:ValueGeneration", "Identity");

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("ConcurrencyStamp")
                        .ConcurrencyToken()
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("Name")
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("NormalizedName")
                        .Annotation("OriginalValueIndex", 3);

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("ClaimType")
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("ClaimValue")
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("RoleId")
                        .Annotation("OriginalValueIndex", 3);

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("ClaimType")
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("ClaimValue")
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("UserId")
                        .Annotation("OriginalValueIndex", 3);

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("ProviderKey")
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("ProviderDisplayName")
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("UserId")
                        .Annotation("OriginalValueIndex", 3);

                    b.Key("LoginProvider", "ProviderKey");

                    b.Annotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("RoleId")
                        .Annotation("OriginalValueIndex", 1);

                    b.Key("UserId", "RoleId");

                    b.Annotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("WebApplication1.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<int>("AccessFailedCount")
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("ConcurrencyStamp")
                        .ConcurrencyToken()
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("Email")
                        .Annotation("OriginalValueIndex", 3);

                    b.Property<bool>("EmailConfirmed")
                        .Annotation("OriginalValueIndex", 4);

                    b.Property<bool>("LockoutEnabled")
                        .Annotation("OriginalValueIndex", 5);

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .Annotation("OriginalValueIndex", 6);

                    b.Property<string>("NormalizedEmail")
                        .Annotation("OriginalValueIndex", 7);

                    b.Property<string>("NormalizedUserName")
                        .Annotation("OriginalValueIndex", 8);

                    b.Property<string>("PasswordHash")
                        .Annotation("OriginalValueIndex", 9);

                    b.Property<string>("PhoneNumber")
                        .Annotation("OriginalValueIndex", 10);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .Annotation("OriginalValueIndex", 11);

                    b.Property<string>("SecurityStamp")
                        .Annotation("OriginalValueIndex", 12);

                    b.Property<bool>("TwoFactorEnabled")
                        .Annotation("OriginalValueIndex", 13);

                    b.Property<string>("UserName")
                        .Annotation("OriginalValueIndex", 14);

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Reference("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .InverseCollection()
                        .ForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Reference("WebApplication1.Models.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Reference("WebApplication1.Models.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Reference("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .InverseCollection()
                        .ForeignKey("RoleId");

                    b.Reference("WebApplication1.Models.ApplicationUser")
                        .InverseCollection()
                        .ForeignKey("UserId");
                });
        }
    }
}
