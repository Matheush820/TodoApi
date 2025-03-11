using Microsoft.EntityFrameworkCore;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeando a tabela existente 'Todo' no banco de dados
            modelBuilder.Entity<TodoItem>().ToTable("Todo");

            // Configura a chave primária
            modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);

            // Configura as propriedades da classe
            modelBuilder.Entity<TodoItem>()
                .Property(x => x.User)
                .HasMaxLength(120) // Configura o tamanho do campo User
                .HasColumnType("varchar(120)"); // Tipo de dado no banco

            modelBuilder.Entity<TodoItem>()
                .Property(x => x.Title)
                .HasMaxLength(160) // Configura o tamanho do campo Title
                .HasColumnType("varchar(160)"); // Tipo de dado no banco

            modelBuilder.Entity<TodoItem>()
                .Property(x => x.Done)
                .HasColumnType("bit"); // Tipo de dado no banco

            modelBuilder.Entity<TodoItem>()
                .Property(x => x.Date)
                .HasColumnType("datetime"); // Tipo de dado no banco

            // Configura o índice na coluna 'User'
            modelBuilder.Entity<TodoItem>()
                .HasIndex(b => b.User)
                .IsUnique(false); // O índice na coluna User não é único
        }
    }
}
