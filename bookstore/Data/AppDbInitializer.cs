using bookstore.Data.Static;
using bookstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                if (!context.Edituri.Any())
                {
                    context.Edituri.AddRange(new List<Editura>()
                    {
                        new Editura()
                        {
                            Name = "Kerigma",
                            logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "Aceasta este descrierea editurii Gramar"
                        },
                        new Editura()
                        {
                            Name = "Stephanus",
                            logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "Aceasta este descrierea editurii Stephanus"
                        },
                        new Editura()
                        {
                            
                            logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Name = "Casa Cartii",
                            Description = "Aceasta este descrierea editurii Casa Cartii"
                        },
                        new Editura()
                        {
                            Name = "Libris",
                            logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "Aceasta este descrierea editurii Libris"
                        },
                        new Editura()
                        {
                            Name = "Scriptum",
                            logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "Aceasta este descrierea editurii Scriptum"
                        },
                    });
                    context.SaveChanges();
                }
            if (!context.Autori.Any())
                {
                    context.Autori.AddRange(new List<Autor>()
                    {
                        new Autor()
                        {
                            FullName = "David Wilkerson",

                            Bio = "David Wilkerson was born in 1931 in Indiana. He was the second son " +
                            "of a family of Pentecostal Christian preachers, and he was raised in Barnesboro, " +
                            "Pennsylvania, in a house full of Bibles. His paternal grandfather and his father, Kenneth, were ministers. " +
                            "According to Wilkerson's own testimony, he was baptized with the Holy Spirit at the age of eight." +
                            "He was an American Christian evangelist, best known for his book The Cross and the Switchblade. " +
                            "He was the founder of the addiction recovery program Teen Challenge, and founding pastor " +
                            "of the non-denominational Times Square Church in New York City.",

                            ProfilePictureURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.librariamaranatha.ro%2Fblog%2Fdavid-wilkerson-carti&psig=AOvVaw0enOpXwOw6b0W0Tjv3naqk&ust=1651231596602000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCJja5ZrTtvcCFQAAAAAdAAAAABAG"

                        },
                        new Autor()
                        {
                            FullName = "A. W. Tozer",

                            Bio = "Aiden Wilson Tozer (April 21, 1897 – May 12, 1963) was an American Christian pastor, " +
                            "author, magazine editor, and spiritual mentor. For his accomplishments, " +
                            "he received honorary doctorates from Wheaton and Houghton colleges.Tozer began writing in 1931 for the denominational magazine " +
                            "of the Christian and Missionary Alliance, Alliance Weekly (now Alliance Life), " +
                            "which became the platform from which his writing career emerged. " +
                            "He later wrote the monthly column “There’s Truth in It” (1936–37) and “A Word in Season” (1944–46). " +
                            "In May 1950, he became the editor of the Alliance Weekly, a position he filled until his death in 1963.",

                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Autor()
                        {
                            FullName = "John Bunyan",

                            Bio = "John Bunyan (n. 28 noiembrie 1628 - d. 31 august 1688) a fost un scriitor și predicator " +
                            "baptist englez, tinichigiu de meserie, care a fost prigonit pentru vederile sale religioase," +
                            " și făcut 13 ani de închisoare, timp în care a scris Calatoria pelerinului." +
                            " Ulterior Biserica Anglicană i-a recunoscut meritele și îl comemorează în fiecare an, " +
                            "în cadrul unei sărbători minore (Lesser Festival) pe 30 august. Este comemorat și în calendarul Bisericii evanghelice.",

                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Autor()
                        {
                            FullName = "Charles Spurgeon",

                            Bio = "Charles Haddon Spurgeon (19 June 1834[1] – 31 January 1892) was an English Particular " +
                            "Baptist preacher. Spurgeon remains highly influential among Christians of various " +
                            "denominations, among whom he is known as the Prince of Preachers." +
                            " He was a strong figure in the Reformed Baptist tradition, defending the 1689 London Baptist Confession of Faith, " +
                            "and opposing the liberal and pragmatic theological tendencies in the Church of his day.",

                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Autor()
                        {
                            FullName = "John Wesley",

                            Bio = "John Wesley (n. 17 iunie 1703 - d. 2 martie 1791) a fost un pastor anglican și " +
                            "un teolog creștin care a fost un lider de început al mișcării metodiste." +
                            "Cea mai mare realizare teologică a sa a fost promovarea a ceea ce el a" +
                            " numit perfecțiunea creștină, sau sfințenia inimii și vieții." +
                            " Wesley a insistat asupra faptului că în viața lui, creștinul ar putea" +
                            " ajunge la un stadiu în care dragostea lui pentru Dumnezeu, sau dragostea " +
                            "lui perfectă, va ajunge să-i stăpânească inima în mod suprem.",

                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Carti.Any())
                {
                    context.Carti.AddRange(new List<Carte>()
                    {
                        new Carte()
                        {

                            Name = "Calatoria Crestinului",
                            Description = "Cartea Calatoria crestinului incepe cu un tanar care a primit o educatie modesta, " +
                            "iar pe urma fiind marcat de anturajul lui vicios. Calatoria crestinului ne arata ca in cele " +
                            "din urma acest barbat ajunge la picioarele Domnului Isus. Calatoria crestinului este o alegoria " +
                            "tradusa in peste 120 de limbi si raspandita in lumea intreaga. " +
                            "Cartea Calatoria crestinului are un autor cunoscut pe numele John Bunyan, " +
                            "la care se adunau oamenii cu miile sa asculte predicile lui.",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now,
                            EdituraId=1,
                            BookCategory = BookCategory.Diverse

                        },
                        new Carte()
                        {
                            Name = "Dece intarie trezirea? ",

                            Description = "La ora aceasta tristă, lumea doarme în întuneric, iar Biserica doarme în lumina; " +
                            "aşa că Isus este rănit în casa celor ce-L iubeau.Biserica luptatoare şchioapătează şi este luată " +
                            "în râs şi numită impotentă. În fiecare an folosim munţi de hârtie şi râuri de cerneala ca să " +
                            "retipărim scrierile unor oameni de mult morţi, în timp ce Duhul Sfant, care este viu, " +
                            "caută oameni care să fie gata să calce ştiinţa lor sub picioare, să spargă balonul umflat " +
                            "al egoismului lor şi să recunoască deschis că, deşi au ochi, sunt totuşi orbi. " +
                            "Astfel de oameni, cu preţul inimii zdrobite şi al lacrimilor vărsate, caută să " +
                            "primească uleiul sfant al doctoriei pentru ochi, care se cumpară numai cu preţul " +
                            "recunoaşterii sărăciei sufleteşti. " +
                            "la care se adunau oamenii cu miile sa asculte predicile lui.",

                            Price = 20.50,

                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",

                            StartDate =DateTime.Now ,
                            EdituraId=1,
                            BookCategory = BookCategory.Diverse

                        },
                        new Carte()
                        {
                            Name = "Calatoria ",
                            Description = "Cartea Calatoria crestinului incepe cu un tanar care a primit o educatie modesta, " +
                            "iar pe urma fiind marcat de anturajul lui vicios. Calatoria crestinului ne arata ca in cele " +
                            "din urma acest barbat ajunge la picioarele Domnului Isus. Calatoria crestinului este o alegoria " +
                            "tradusa in peste 120 de limbi si raspandita in lumea intreaga. " +
                            "Cartea Calatoria crestinului are un autor cunoscut pe numele John Bunyan, " +
                            "la care se adunau oamenii cu miile sa asculte predicile lui.",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now,
                            EdituraId=1,
                            BookCategory = BookCategory.Diverse

                        },
                        new Carte()
                        {
                            Name = "Crucea si Pumnalul",
                            Description = "Crucea si pumnalul este autobiografia remarcabila a pastorului de la tara, " +
                            "David Wilkerson, un om inspirat de credinta, care a facut o minune dupa alta in recuperarea " +
                            "tinerilor dependenti de droguri din orasul New York. Conflictul stravechi dintre bine " +
                            "si rau este dramatizat aici in relatarea vietii lui David Wilkerson, care, in 1958, " +
                            "a fost desemnat de Duhul Sfant sa incerce sa ajute sapte tineri condamnati in orasul New York" +
                            " pentru uciderea lui Michael Farmer, un baiat olog. Acum, cei sapte sunt in inchisoare " +
                            "si David nu-i mai poate ajuta, insa eforturile sale au dus la aparitia miscarii " +
                            "Teen Challenge, care a salvat mii de tineri si tinere de la crima si dependenta de alcool si droguri.",
                            Price = 30.00,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now,
                            EdituraId=1,
                            BookCategory = BookCategory.Povestire

                        },
                new Carte()
                {
                    Name = "O credinta tulburatoare",
                    Description = "O credinta tulburatoare este invatatura lui A.W. Tozer cu privire la ceea " +
                            "ce el a numite „credinta care nelinisteste” – o credinta care il contrazice pe cel " +
                            "necredincios si ameninta multumirea de sine a crestinului. Pe aceste pagini " +
                            "renumitul pastor si teolog arata cum credinta veritabila naste, pentru ca asa " +
                            "a randuit Dumnezeu, nemultumire fata de aceasta viata, dezvatandu-i pe crestini " +
                            "de dependenta de lucrurile pamantesti pentru a-i pregati pentru slavita si vesnica " +
                            "viata viitoare. In felul acesta, fiecare dintre noi ar trebui sa fie incurajat " +
                            "sa-si aprofundeze credinta pana in punctul unei sfinte insatisfactii – si sa-si " +
                            "cunoasca noua speranta in vesnicia cu Dumnezeul Atotputernic!",
                    Price = 15.00,
                    ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                    StartDate = DateTime.Now,
                    EdituraId = 1,
                    BookCategory = BookCategory.Diverse


                },
                        new Carte()
                        {
                            Name = "Seara de Seara",
                            Description = "Mesajele inaltatoare ale lui Charles Spurgeon pentru fiecare zi a anului " +
                            "te vor mangaia si intari in umblarea ta cu Dumnezeu. Timpul petrecut alaturi de Dumnezeu " +
                            "la inceputul si sfarsitul fiecarei zile va aduce o bucurie noua in viata ta. " +
                            "Insotite de versete cheie din Scriptura, aceste meditatii te vor ajuta sa:experimentezi " +
                            "iertarea lui Dumnezeu ramai in prezenta lui Dumnezeuobtii victoria prin Cristos primesti " +
                            "ajutor in orice necaz dezvolti o viata puternica de rugaciune ai orice nevoie implinita " +
                            "de Dumnezeu descoperi indrumarea lui Dumnezeu",
                            Price = 25.00,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now,
                            EdituraId=1,
                            BookCategory = BookCategory.Diverse
                        }
                    });
                    context.SaveChanges();
                }




                if (!context.Autori_Carti.Any())
                {
                    context.Autori_Carti.AddRange(new List<Autor_Carte>()
                    {
                        new Autor_Carte()
                        {
                            AutorId = 1,
                            CarteId = 11
                        },
                        new Autor_Carte()
                        {
                            AutorId = 3,
                            CarteId = 11
                        },
                        new Autor_Carte()
                        {
                            AutorId = 1,
                            CarteId = 12
                        },
                        new Autor_Carte()
                        {
                            AutorId = 4,
                            CarteId = 12
                        },
                        new Autor_Carte()
                        {
                            AutorId = 1,
                            CarteId = 13
                        },
                        new Autor_Carte()
                        {
                            AutorId = 2,
                            CarteId = 13
                        },
                        new Autor_Carte()
                        {
                            AutorId = 5,
                            CarteId = 13
                        },
                        new Autor_Carte()
                        {
                            AutorId = 2,
                            CarteId = 14
                        },
                        new Autor_Carte()
                        {
                            AutorId = 3,
                            CarteId = 14
                        },
                        new Autor_Carte()
                        {
                            AutorId = 4,
                            CarteId = 14
                        },
                        new Autor_Carte()
                        {
                            AutorId = 2,
                            CarteId = 15
                        },
                        new Autor_Carte()
                        {
                            AutorId = 3,
                            CarteId = 15
                        },
                        new Autor_Carte()
                        {
                            AutorId = 4,
                            CarteId = 15
                        },
                        new Autor_Carte()
                        {
                            AutorId = 5,
                            CarteId = 15
                        },
                        new Autor_Carte()
                        {
                            AutorId = 3,
                            CarteId = 16
                        },
                        new Autor_Carte()
                        {
                            AutorId = 4,
                            CarteId = 16
                        },
                        new Autor_Carte()
                        {
                            AutorId = 5,
                            CarteId = 16
                        },


                    });
                    context.SaveChanges();

                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                
                if(!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@bookstore.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser==null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true

                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                string appUserEmail = "user@bookstore.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newappUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app_user",
                        Email = appUserEmail,
                        EmailConfirmed = true

                    };
                    await userManager.CreateAsync(newappUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newappUser, UserRoles.User);
                }
            }
        }
    }
}
