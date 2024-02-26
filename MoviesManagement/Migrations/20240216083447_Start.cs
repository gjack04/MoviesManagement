using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesManagement.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityRoles",
                columns: table => new
                {
                    ActivityRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityRoles", x => x.ActivityRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AgeLimits",
                columns: table => new
                {
                    AgeLimitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeLimits", x => x.AgeLimitId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleanTimeMins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnologyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImdbId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeLimitId = table.Column<int>(type: "int", nullable: false),
                    DurationMins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_AgeLimits_AgeLimitId",
                        column: x => x.AgeLimitId,
                        principalTable: "AgeLimits",
                        principalColumn: "AgeLimitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomTechnology",
                columns: table => new
                {
                    RoomsRoomId = table.Column<int>(type: "int", nullable: false),
                    TechnologiesTechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTechnology", x => new { x.RoomsRoomId, x.TechnologiesTechnologyId });
                    table.ForeignKey(
                        name: "FK_RoomTechnology_Rooms_RoomsRoomId",
                        column: x => x.RoomsRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomTechnology_Technologies_TechnologiesTechnologyId",
                        column: x => x.TechnologiesTechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTechnology",
                columns: table => new
                {
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false),
                    TechnologiesTechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTechnology", x => new { x.MoviesMovieId, x.TechnologiesTechnologyId });
                    table.ForeignKey(
                        name: "FK_MovieTechnology_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTechnology_Technologies_TechnologiesTechnologyId",
                        column: x => x.TechnologiesTechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projections",
                columns: table => new
                {
                    ProjectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreeBy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projections", x => x.ProjectionId);
                    table.ForeignKey(
                        name: "FK_Projections_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projections_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectionActivities",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ActivityRoleId = table.Column<int>(type: "int", nullable: false),
                    ProjectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectionActivities", x => new { x.EmployeeId, x.ActivityRoleId, x.ProjectionId });
                    table.ForeignKey(
                        name: "FK_ProjectionActivities_ActivityRoles_ActivityRoleId",
                        column: x => x.ActivityRoleId,
                        principalTable: "ActivityRoles",
                        principalColumn: "ActivityRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectionActivities_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectionActivities_Projections_ProjectionId",
                        column: x => x.ProjectionId,
                        principalTable: "Projections",
                        principalColumn: "ProjectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_AgeLimitId",
                table: "Movies",
                column: "AgeLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTechnology_TechnologiesTechnologyId",
                table: "MovieTechnology",
                column: "TechnologiesTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionActivities_ActivityRoleId",
                table: "ProjectionActivities",
                column: "ActivityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionActivities_ProjectionId",
                table: "ProjectionActivities",
                column: "ProjectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Projections_MovieId",
                table: "Projections",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Projections_RoomId",
                table: "Projections",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTechnology_TechnologiesTechnologyId",
                table: "RoomTechnology",
                column: "TechnologiesTechnologyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTechnology");

            migrationBuilder.DropTable(
                name: "ProjectionActivities");

            migrationBuilder.DropTable(
                name: "RoomTechnology");

            migrationBuilder.DropTable(
                name: "ActivityRoles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projections");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AgeLimits");
        }
    }
}
