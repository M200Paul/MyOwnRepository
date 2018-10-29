using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProvaAnagrafica.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Anagrafica> Anagrafiche { get; set; }
        public DbSet<Indirizzo> Indirizzi { get; set; }


    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Anagrafica
    {
        public int AnagraficaId { get; set; } //Chiave primaria <type name>Id
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int AnnoNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }

        public List<Indirizzo> Indirizzi { get; set; } //Relazione con la tabella Indirizzo
    }

        public class Indirizzo
    {
        public int IndirizzoId { get; set; } //Chiave primaria <type name>Id
        public string NomeIndirizzo { get; set; }
        public string Città { get; set; }
        public string Nazione { get; set; }
        public int CAP { get; set; }

        public int AnagraficaId { get; set; } //Foreign Key
        public Anagrafica Anagrafica { get; set; } //Collegamento con la tabella Anagrafica (Tipo di relazione)



        public List<Post> Posts { get; set; }
    }
}