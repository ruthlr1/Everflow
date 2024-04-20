using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Everflow.EventPlanner.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    EventDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDetailDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EventDetailDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDetailStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EventDetailEndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.EventDetailId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "EventPerson",
                columns: table => new
                {
                    EventPersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDetailId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPerson", x => x.EventPersonId);
                    table.ForeignKey(
                        name: "FK_EventPerson_EventDetails_EventDetailId",
                        column: x => x.EventDetailId,
                        principalTable: "EventDetails",
                        principalColumn: "EventDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPerson_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "CreatedDateTime", "EmailAddress", "FirstName", "LastName", "Password" },
                values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john_doe@gmail.com", "John", "Doe", "johnDoe1" });

            migrationBuilder.CreateIndex(
                name: "IX_EventPerson_EventDetailId",
                table: "EventPerson",
                column: "EventDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPerson_PersonId",
                table: "EventPerson",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPerson");

            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
