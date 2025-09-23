using SistemaDeCompras.Models;

namespace SistemaDeCompras.Services.ClienteServices;

public interface IClienteServices
{
  /*/ ------------------------------- MÉTODOS ------------------------------- /*/ 
  // # Usados pelo próprio Cliente #
  //1) Para cadastro do cliente 
  Task<Cliente?> RealizarCadastroClienteAsync(string email, string senha);
  //--------------------------------------------/------------------------------------------
  
  //2) Para login do cliente 
  Task<Cliente?> RealizarLoginClienteAsync
    (string email, string senha); 
  //-------------#----------------#---------------#------------
  
  // # Usados por outras entidades #
  //1)
  //--------------------------------------------/------------------------------------------
}