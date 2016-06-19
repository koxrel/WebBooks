using System.Collections.Generic;
using WebBooks.Entities;

namespace WebBooks.BookContextMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebBooks.Models.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"BookContextMigrations";
        }

        protected override void Seed(WebBooks.Models.BookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var authors = new List<Author>
            {
                new Author
                {
                    LastName = "Остин",
                    FirstName = "Джейн"
                },
                new Author
                {
                    LastName = "Фицджеральд",
                    FirstName = "Фрэнсис Скотт"
                },
                new Author
                {
                    LastName = "Бронте",
                    FirstName = "Эмили"
                },
                new Author
                {
                    LastName = "Пушкин",
                    FirstName = "Александр",
                    MiddleName = "Сергеевич"
                }
            };

            context.Authors.AddOrUpdate(a => a.LastName, authors.ToArray());

            var genres = new List<Genre>
            {
                new Genre
                {
                    Name = "Роман"
                },
                new Genre
                {
                    Name = "История"
                },
                new Genre
                {
                    Name = "Проза"
                },
                new Genre
                {
                    Name = "Романтика"
                },
                new Genre
                {
                    Name = "Трагедия"
                },
                new Genre
                {
                    Name = "Повесть"
                },
            };

            context.Genres.AddOrUpdate(g => g.Name, genres.ToArray());

            context.SaveChanges();

            var books = new List<Book>
            {
                new Book
                {
                    Authors = new List<Author> {authors[0] },
                    Description = "Роман начинается с беседы мистера и миссис Беннет о приезде молодого джентльмена мистера Бингли в Незерфилд-парк. Жена уговаривает мужа навестить соседа и завести с ним более тесное знакомство. Она полагает, что мистеру Бингли непременно понравится одна из их дочерей, и он сделает ей предложение. Мистер Беннет наносит визит молодому человеку, и через какое-то время тот отвечает ему тем же.",
                    Genres = new List<Genre> {genres[0], genres[3] },
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41PmzYduVRL._SX309_BO1,204,203,200_.jpg",
                    Isbn = "978-0007350773",
                    Popularity = 3,
                    Quantity = 3,
                    Title = "Гордость и предубеждение",
                    FullTitle = "джейн остин гордость и предубеждение"
                },
                new Book
                {
                    Authors = new List<Author> {authors[2] },
                    Description = "Единственный роман английской писательницы и поэтессы XIX века Эмили Бронте и самое известное её произведение. Образцово продуманный сюжет, новаторское использование нескольких повествователей, внимание к подробностям сельской жизни в сочетании с романтическим истолкованием природных явлений, ярким образным строем и переработкой условностей готического романа делают «Грозовой перевал» эталоном романа позднего романтизма и классическим произведением ранневикторианской литературы.",
                    Genres = new List<Genre> {genres[0], genres[4] },
                    ImageUrl = "http://femilia.ru/wp-content/uploads/2013/11/0.jpg",
                    Isbn = "978-0007350773",
                    Popularity = 4,
                    Quantity = 3,
                    FullTitle = "эмили бронте грозовой перевал",
                    Title = "Грозовой перевал"
                },
                new Book
                {
                    Authors = new List<Author> {authors[1] },
                    Description = "Классический роман американского писателя Фрэнсиса Скотта Фицджеральда. Опубликован в 1934 году. Название романа и эпиграф взяты из «Оды соловью» Джона Китса.",
                    Genres = new List<Genre> {genres[0], genres[4] },
                    ImageUrl = "http://knijky.ru/sites/default/files/styles/264x390/public/frensis_skott_fitsdzherald_noch_nezhna.jpg?itok=n2H5AKSD",
                    Isbn = "978-0007350773",
                    Popularity = 2,
                    Quantity = 2,
                    FullTitle = "фрэнсис скотт фицджеральд ночь нежна",
                    Title = "Ночь нежна"
                },
                new Book
                {
                    Authors = new List<Author> {authors[3] },
                    Description = "Александра Сергеевича Пушкина (1799-1833) по праву считают одним из величайших поэтов, сумевшим своим творчеством радикально изменить русскую литературу. Его произведения, как поэзия, так и проза, принадлежат к шедеврам мировой литературы, к которым каждое поколение возвращается вновь и вновь. В сборник вошли знаменитые прозаические и драматические произведения А. С. Пушкина и сопровождены статьями Ю. М. Лотмана, помогающими разобраться в идейных исканиях поэта.",
                    Genres = new List<Genre> {genres[0], genres[1], genres[5] },
                    ImageUrl = "http://www.bgshop.ru/PreviewImageHandler.ashx?fileName=10284926.jpg&width=207",
                    Isbn = "978-0007350773",
                    Popularity = 6,
                    Quantity = 2,
                    Title = "Капитанская дочка",
                    FullTitle = "александр сергеевич пушкин капитанская дочка"
                },
            };

            context.Books.AddOrUpdate(b => b.Title, books.ToArray());

            context.SaveChanges();
        }
    }
}
