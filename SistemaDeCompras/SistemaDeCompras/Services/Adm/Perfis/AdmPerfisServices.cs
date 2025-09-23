using Microsoft.EntityFrameworkCore;
using SistemaDeCompras.DAL;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Services.Adm.Perfis;

public class AdmPerfisServices : IAdmPerfisServices
{
    /*/ ------------------------------- CONFIGURANDO INJEÇÃO DE DEPENDÊNCIA ------------------------------- /*/
  private readonly SistemaDeComprasDbContext _context;

  public AdmPerfisServices(SistemaDeComprasDbContext context)
  {
    _context = context;
  }
  //========================================================
  
  /*/ ------------------------------- MÉTODOS ------------------------------- /*/
  // # Usados pelo próprio AdmPerfis #
  //#1) Para login do admPerfis
  public async Task<AdmPerfis?> RealizarLoginAdmPerfisAsync(string nome, string senha)
   {
       // throw new NotImplementedException();
        //•ETAPAS•//
        //1) Validação dos dados
        //A) Descobrindo se o nome de entrada já está cadastrado no sistema
        var nomeCadastradoNoSistema = await _context.AdmsPerfis.FirstOrDefaultAsync(a => a.Nome == nome);
        
        //Caso não esteja
        if (nomeCadastradoNoSistema == null)
        {
          throw new InvalidOperationException("O nome informado não está cadastrado!");
        }
        //----------------------------------//--------------------------------
        //B) Descobrindo se a senha está correta para o nome cadastrado
        var admPerfis = nomeCadastradoNoSistema;
  
        string senhaCorrespondente = admPerfis.Senha;
  
        //Caso não esteja
        if (senha != senhaCorrespondente)
        {
          throw new InvalidOperationException("A senha está incorreta!");
        }
        //--------------------------------------------/------------------------------------------
        
        //3) Retornando o admPerfis cadastrado no sistema
        return admPerfis;
   }  
  //-------------#----------------#---------------#------------
  
  // # Usados por outras entidades #
  //#1) Para cadastro do adm
  public async Task<AdmPerfis?> RealizarCadastroAdmPerfisAsync(string nome, string senha)
  {
    //•ETAPAS•//
    //1) Validação dos dados
    //A) Descobrindo se o nome de entrada já está cadastrado no sistema
    bool nomeCadastradoNoSistema = await _context.AdmsPerfis.AnyAsync(c => c.Nome == nome);

    //Caso esteja
    if (nomeCadastradoNoSistema)
    {
      throw new InvalidOperationException("O nome informado já está cadastrado!");
    }
    //--------------------------------------------/------------------------------------------
    
    //2) Registro dos dados no sistema (banco de dados)
    //A) Instanciando um objeto admPerfis com os dados
    AdmPerfis admPerfis = new AdmPerfis(nome, senha);
    //----------------------------------//--------------------------------
    //B) Adicionando no DbSet<AdmPerfis>
    _context.AdmsPerfis.Add(admPerfis);
    //----------------------------------//--------------------------------
    //C) Salvando as mudanças no sistema
    await _context.SaveChangesAsync();
    //--------------------------------------------/------------------------------------------
    
    //3) Retornando o admPerfis cadastrado no sistema
    return admPerfis;
  } 
  //--------------------------------------------/------------------------------------------
}