using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyTasks.Migrations
{
    /// <inheritdoc />
    public partial class add_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into TaskItems (Title, Description, DeadLine, Logo) values ('Mr', 'Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.', '2026-02-15 04:43:32', 'Vitae.mp3');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Mr', 'Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.', '2025-11-10 21:39:17', 'SemperPorta.xls');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Mrs', 'Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.', '2025-08-06 19:11:37', 'Ullamcorper.pdf');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Dr', 'Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.', '2026-07-01 18:19:06', 'ConvallisNullaNeque.ppt');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Honorable', 'Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti.', '2026-08-19 01:38:18', 'Aenean.ppt');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Honorable', 'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.', '2026-01-10 14:35:50', 'VestibulumSagittis.tiff');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Ms', 'Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.', '2027-11-05 19:05:30', 'Est.mp3');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Mrs', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.', '2027-05-16 16:10:15', 'InterdumEu.xls');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Honorable', 'Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.', '2026-10-30 10:43:55', 'AmetCursus.gif');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Honorable', 'Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.', '2026-09-18 15:30:18', 'Id.jpeg');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Honorable', 'Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.', '2025-08-22 17:50:58', 'DiamVitaeQuam.avi');insert into TaskItems (Title, Description, DeadLine, Logo) values ('Honorable', 'Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.', '2026-11-07 14:26:34', 'MorbiUt.ppt');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TaskItems");
        }
    }
}
