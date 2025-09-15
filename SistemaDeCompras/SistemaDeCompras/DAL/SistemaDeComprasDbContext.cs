using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.DAL;

public class SistemaDeComprasDbContext : DbContext
{
   public SistemaDeComprasDbContext(DbContextOptions<SistemaDeComprasDbContext> options) : base(options)
   {
      
   }
   //========================================================
   
   /*/ ------------------------------- TABELAS DE DADOS ------------------------------- /*/
   //1) Clientes
   public DbSet<Cliente> Clientes { get; set; }
   //--------------------------------------------/------------------------------------------
   
   //2)
   //--------------------------------------------/------------------------------------------
   
   //3)
   //--------------------------------------------/------------------------------------------
   
   //4)
   //--------------------------------------------/------------------------------------------
   
   //5)
   //--------------------------------------------/------------------------------------------
   
   //6)
   //========================================================
}