using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.DAL;

public class SistemaDeComprasDbContext : DbContext
{
   //TODO NOVA MIGRATION PARA O GESTOR E OS ADMINISTRADORES
   public SistemaDeComprasDbContext(DbContextOptions<SistemaDeComprasDbContext> options) : base(options)
   {
      
   }
   //========================================================
   
   /*/ ------------------------------- TABELAS DE DADOS ------------------------------- /*/
   //1) Clientes
   public DbSet<Cliente> Clientes { get; set; }
   //--------------------------------------------/------------------------------------------
   
   //2) Endereços
   public DbSet<Endereco> Enderecos { get; set; }
   //--------------------------------------------/------------------------------------------
   
   //3) Cartões de Crédito
   public DbSet<CartaoDeCredito> Cartoes { get; set; }
   //--------------------------------------------/------------------------------------------
   
   //4) Produtos
   public DbSet<Produto> Produtos { get; set; }
   //--------------------------------------------/------------------------------------------
   
   //5) Gestores
   public DbSet<Gestor> Gestores { get; set; }
   //--------------------------------------------/------------------------------------------
   
   //6) Adms de Pedidos
   public DbSet<AdmPedidos> AdmsPedidos { get; set; }
   //--------------------------------------------/------------------------------------------
   
   //7) Adms de Produtos
   public DbSet<AdmProdutos> AdmsProdutos { get; set; }
   //--------------------------------------------/------------------------------------------
   
   //8) Adms de Perfis
   public DbSet<AdmPerfis> AdmsPerfis { get; set; }
   //--------------------------------------------/------------------------------------------
   
   //9) Adms de Perfis
   public DbSet<Pedido> Pedidos { get; set; }
   //========================================================
   
   /*/ ------------------------------- MÉTODOS ------------------------------- /*/
   //1) Para sobrescrever o SaveChangesAsync do EF e fazer com que, além de salvar os novos dados no sistema, ele também registre a data do salvamento
   public override Task<int> SaveChangesAsync(CancellationToken sinalizador = default)
   {
      //•ETAPAS•//
      //1) Econtrando todos os dados pertencentes aos DbSets que foram adicionados ou alterados 
      var dados = ChangeTracker
         .Entries()
         .Where(d => d.Entity is Model && 
                     ( 
                      d.State == EntityState.Added 
                      ||
                      d.State == EntityState.Modified
                     ));
      //--------------------------------------------/------------------------------------------
      
      //2) Definindo a data de adição/alteração dos dados encontrados como a data no momento da modificação
      foreach (var dado in dados)
      {
         var abstractModelPai = (Model)dado.Entity;
         
         abstractModelPai.AtualizadoEm = DateTime.UtcNow;

         // Se a entidade está sendo ADICIONADA (um novo registro),
         // define também a data de criação.
         if (dado.State == EntityState.Added)
         {
            abstractModelPai.CriadoEm = DateTime.UtcNow;
         }
      }

      //--------------------------------------------/------------------------------------------
      //3) Chamando o SaveChangesAsync original (do EF) para fazer o salvamento padrão dos dados modificados no sistema se o sinalizador tiver o valor default 
      return base.SaveChangesAsync(sinalizador);
   }
}