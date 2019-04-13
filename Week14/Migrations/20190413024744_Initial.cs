using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week14.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bishopric",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bishopric", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HymnNumber = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ConductingID = table.Column<int>(nullable: false),
                    OpeningHymnID = table.Column<int>(nullable: false),
                    SacramentHymnID = table.Column<int>(nullable: false),
                    InterHymnID = table.Column<int>(nullable: false),
                    ClosingHymnID = table.Column<int>(nullable: false),
                    InvocationID = table.Column<int>(nullable: false),
                    BenedictionID = table.Column<int>(nullable: false),
                    IsFastSunday = table.Column<bool>(nullable: false),
                    FirstTopic = table.Column<string>(nullable: true),
                    SecondTopic = table.Column<string>(nullable: true),
                    ThirdTopic = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    MiddleSpeakerID = table.Column<int>(nullable: false),
                    LastSpeakerID = table.Column<int>(nullable: false),
                    FirstSpeakerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meeting_Member_BenedictionID",
                        column: x => x.BenedictionID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_ClosingHymnID",
                        column: x => x.ClosingHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Bishopric_ConductingID",
                        column: x => x.ConductingID,
                        principalTable: "Bishopric",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Member_FirstSpeakerID",
                        column: x => x.FirstSpeakerID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_InterHymnID",
                        column: x => x.InterHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Member_InvocationID",
                        column: x => x.InvocationID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Member_LastSpeakerID",
                        column: x => x.LastSpeakerID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Member_MiddleSpeakerID",
                        column: x => x.MiddleSpeakerID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_OpeningHymnID",
                        column: x => x.OpeningHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_SacramentHymnID",
                        column: x => x.SacramentHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_BenedictionID",
                table: "Meeting",
                column: "BenedictionID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ClosingHymnID",
                table: "Meeting",
                column: "ClosingHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ConductingID",
                table: "Meeting",
                column: "ConductingID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_FirstSpeakerID",
                table: "Meeting",
                column: "FirstSpeakerID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_InterHymnID",
                table: "Meeting",
                column: "InterHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_InvocationID",
                table: "Meeting",
                column: "InvocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_LastSpeakerID",
                table: "Meeting",
                column: "LastSpeakerID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_MiddleSpeakerID",
                table: "Meeting",
                column: "MiddleSpeakerID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_OpeningHymnID",
                table: "Meeting",
                column: "OpeningHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_SacramentHymnID",
                table: "Meeting",
                column: "SacramentHymnID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "Bishopric");
        }
    }
}
