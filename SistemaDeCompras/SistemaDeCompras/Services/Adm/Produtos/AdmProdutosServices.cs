using Microsoft.EntityFrameworkCore;
using SistemaDeCompras.DAL;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Services.Adm.Produtos;

public class AdmProdutosServices : IAdmProdutosServices
{
  /*/ ------------------------------- CONFIGURANDO INJEÇÃO DE DEPENDÊNCIA ------------------------------- /*/
  private readonly SistemaDeComprasDbContext _context;

  public AdmProdutosServices(SistemaDeComprasDbContext context)
  {
    _context = context;
  }
  //========================================================
  
  /*/ ------------------------------- MÉTODOS ------------------------------- /*/
  // # Usados pelo próprio AdmProdutos #
  //#1) Para login do admProdutos
  public async Task<AdmProdutos?> RealizarLoginAdmProdutosAsync(string nome, string senha)
   {
       // throw new NotImplementedException();
        //•ETAPAS•//
        //1) Validação dos dados
        //A) Descobrindo se o nome de entrada já está cadastrado no sistema
        var nomeCadastradoNoSistema = await _context.AdmsProdutos.FirstOrDefaultAsync(a => a.Nome == nome);
        
        //Caso não esteja
        if (nomeCadastradoNoSistema == null)
        {
          throw new InvalidOperationException("O nome informado não está cadastrado!");
        }
        //----------------------------------//--------------------------------
        //B) Descobrindo se a senha está correta para o nome cadastrado
        var admProdutos = nomeCadastradoNoSistema;
  
        string senhaCorrespondente = admProdutos.Senha;
  
        //Caso não esteja
        if (senha != senhaCorrespondente)
        {
          throw new InvalidOperationException("A senha está incorreta!");
        }
        //--------------------------------------------/------------------------------------------
        
        //3) Retornando o admProdutos cadastrado no sistema
        return admProdutos;
   }  
  //-------------#----------------#---------------#------------
  
  // # Usados por outras entidades #
  //#1) Para cadastro do adm
  public async Task<AdmProdutos?> RealizarCadastroAdmProdutosAsync(string nome, string senha)
  {
    //•ETAPAS•//
    //1) Validação dos dados
    //A) Descobrindo se o nome de entrada já está cadastrado no sistema
    bool nomeCadastradoNoSistema = await _context.AdmsProdutos.AnyAsync(c => c.Nome == nome);

    //Caso esteja
    if (nomeCadastradoNoSistema)
    {
      throw new InvalidOperationException("O nome informado já está cadastrado!");
    }
    //--------------------------------------------/------------------------------------------
    
    //2) Registro dos dados no sistema (banco de dados)
    //A) Instanciando um objeto admProdutos com os dados
    AdmProdutos admProdutos = new AdmProdutos(nome, senha);
    //----------------------------------//--------------------------------
    //B) Adicionando no DbSet<AdmProdutos>
    _context.AdmsProdutos.Add(admProdutos);
    //----------------------------------//--------------------------------
    //C) Salvando as mudanças no sistema
    await _context.SaveChangesAsync();
    //--------------------------------------------/------------------------------------------
    
    //3) Retornando o admProdutos cadastrado no sistema
    return admProdutos;
  } 
  //--------------------------------------------/------------------------------------------
}