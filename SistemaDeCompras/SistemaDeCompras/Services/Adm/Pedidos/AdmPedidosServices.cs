using Microsoft.EntityFrameworkCore;
using SistemaDeCompras.DAL;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Services.Adm.Pedidos;

public class AdmPedidosServices : IAdmPedidosServices
{
  /*/ ------------------------------- CONFIGURANDO INJEÇÃO DE DEPENDÊNCIA ------------------------------- /*/
  private readonly SistemaDeComprasDbContext _context;

  public AdmPedidosServices(SistemaDeComprasDbContext context)
  {
    _context = context;
  }
  //========================================================
  
  /*/ ------------------------------- MÉTODOS ------------------------------- /*/
  // # Usados pelo próprio AdmPedidos #
  //#1) Para login do admPedidos
  public async Task<AdmPedidos?> RealizarLoginAdmPedidosAsync(string nome, string senha)
   {
       // throw new NotImplementedException();
        //•ETAPAS•//
        //1) Validação dos dados
        //A) Descobrindo se o nome de entrada já está cadastrado no sistema
        var nomeCadastradoNoSistema = await _context.AdmsPedidos.FirstOrDefaultAsync(a => a.Nome == nome);
        
        //Caso não esteja
        if (nomeCadastradoNoSistema == null)
        {
          throw new InvalidOperationException("O nome informado não está cadastrado!");
        }
        //----------------------------------//--------------------------------
        //B) Descobrindo se a senha está correta para o nome cadastrado
        var admPedidos = nomeCadastradoNoSistema;
  
        string senhaCorrespondente = admPedidos.Senha;
  
        //Caso não esteja
        if (senha != senhaCorrespondente)
        {
          throw new InvalidOperationException("A senha está incorreta!");
        }
        //--------------------------------------------/------------------------------------------
        
        //3) Retornando o admPedidos cadastrado no sistema
        return admPedidos;
   }  
  //-------------#----------------#---------------#------------
  
  // # Usados por outras entidades #
  //#1) Para cadastro do adm
  public async Task<AdmPedidos?> RealizarCadastroAdmPedidosAsync(string nome, string senha)
  {
    //•ETAPAS•//
    //1) Validação dos dados
    //A) Descobrindo se o nome de entrada já está cadastrado no sistema
    bool nomeCadastradoNoSistema = await _context.AdmsPedidos.AnyAsync(c => c.Nome == nome);

    //Caso esteja
    if (nomeCadastradoNoSistema)
    {
      throw new InvalidOperationException("O nome informado já está cadastrado!");
    }
    //--------------------------------------------/------------------------------------------
    
    //2) Registro dos dados no sistema (banco de dados)
    //A) Instanciando um objeto admPedidos com os dados
    AdmPedidos admPedidos = new AdmPedidos(nome, senha);
    //----------------------------------//--------------------------------
    //B) Adicionando no DbSet<AdmPedidos>
    _context.AdmsPedidos.Add(admPedidos);
    //----------------------------------//--------------------------------
    //C) Salvando as mudanças no sistema
    await _context.SaveChangesAsync();
    //--------------------------------------------/------------------------------------------
    
    //3) Retornando o admPedidos cadastrado no sistema
    return admPedidos;
  } 
  //--------------------------------------------/------------------------------------------
}