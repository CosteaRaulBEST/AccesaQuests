using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesaQuests.Web.Migrations
{
    /// <inheritdoc />
    public partial class FirstAuthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9df08927-dbc3-49c3-bc7c-c2dbce444561", "AQAAAAIAAYagAAAAELO+GXoFq+YcM0L/M1A2fgAzobHidYA24x/9HzP31Mw9Yve4oXJjda/hlpeqtOjHJA==", "a97259fb-d836-46e9-aad0-b54465821459" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdd5efd5-325a-4d09-89d5-9ecba63a8038", "AQAAAAIAAYagAAAAEPmLimW7N9jteHPAR4+90Ih1kBVgSkF5ttRc9p7R7iOfu4+OzO06QrUHSOg6Tc55Eg==", "8e6304e2-277e-4f5d-ae74-ef352a56c2f0" });
        }
    }
}
