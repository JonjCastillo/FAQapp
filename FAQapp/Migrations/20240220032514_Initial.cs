using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAQapp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Answer", "Category", "QuestionText", "Topic" },
                values: new object[,]
                {
                    { 1, "A general purpose object oriented language that uses a concise, java-like syntax", "General", "What is C#?", "C#" },
                    { 2, "A CSS framework for creating resposive web apps for multiple screen sizes", "General", "What is Bootstrap?", "Bootstrap" },
                    { 3, "A general purpose scripting language that executes in a web browser", "General", "What is JavaScript?", "JavaScript" },
                    { 4, "In 2011", "History", "When was Bootstrap first released?", "Bootstrap" },
                    { 5, "In 2002.", "History", "When was C# frist released?", "C#" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
