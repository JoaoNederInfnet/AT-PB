using Microsoft.EntityFrameworkCore;
using SistemaDeCompras.DAL;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Services.ClienteServices;

public class ClienteServices : IClienteServices
{
  /*/ ------------------------------- CONFIGURANDO INJEÇÃO DE DEPENDÊNCIA ------------------------------- /*/
  private readonly SistemaDeComprasDbContext _context;

  public ClienteServices(SistemaDeComprasDbContext context)
  {
    _context = context;
  }
  //========================================================
  
  /*/ ------------------------------- MÉTODOS ------------------------------- /*/
  // # Usados pelo próprio Cliente #
  //#1) Para cadastro do cliente
  public async Task<Cliente?> RealizarCadastroClienteAsync(string email, string senha)
  {
    //•ETAPAS•//
    //1) Validação dos dados
    //A) Descobrindo se o email de entrada já está cadastrado no sistema
    bool emailCadastradoNoSistema = await _context.Clientes.AnyAsync(c => c.Email == email);

    //Caso esteja
    if (emailCadastradoNoSistema)
    {
      throw new InvalidOperationException("O e-mail informado já está cadastrado!");
    }
    //--------------------------------------------/------------------------------------------
    
    //2) Registro dos dados no sistema (banco de dados)
    //A) Instanciando um objeto cliente com os dados
    Cliente cliente = new Cliente(email, senha);
    //----------------------------------//--------------------------------
    //B) Adicionando no DbSet<Clientes>
    _context.Clientes.Add(cliente);
    //----------------------------------//--------------------------------
    //C) Salvando as mudanças no sistema
    await _context.SaveChangesAsync();
    //--------------------------------------------/------------------------------------------
    
    //3) Retornando o cliente cadastrado no sistema
    return cliente;
  } 
  //--------------------------------------------/------------------------------------------
  
  //#2) Para login do cliente
  public async Task<Cliente?> RealizarLoginClienteAsync(string email, string senha)
   {
        throw new NotImplementedException();
  //   //•ETAPAS•//
  //   //1) Validação dos dados
  //   //A) Descobrindo se o email de entrada já está cadastrado no sistema
  //   var emailCadastradoNoSistema = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
  //   
  //   //Caso não esteja
  //   if (emailCadastradoNoSistema == null)
  //   {
  //     throw new InvalidOperationException("O e-mail informado não está cadastrado!");
  //   }
  //   //----------------------------------//--------------------------------
  //   //B) Descobrindo se a senha está correta para o email cadastrado
  //   var cliente = emailCadastradoNoSistema;
  //
  //   string senhaCorrespondente = cliente.Password;
  //
  //   //Caso não esteja
  //   if (senha != senhaCorrespondente)
  //   {
  //     throw new InvalidOperationException("A senha está incorreta!");
  //   }
  //   //--------------------------------------------/------------------------------------------
  //   
  //   //3) Retornando o cliente cadastrado no sistema
  //   return cliente;
   }
  //--------------------------------------------/------------------------------------------
  
  //#3) Para retornar todos os clientes registrados no sistema
  public async Task<List<Cliente>> GetAllAsync()
  {
    return await _context.Clientes
      .ToListAsync();
  }
}