using SistemaDeCompras.Models;

namespace SistemaDeCompras.Services.Adm.Pedidos;

public interface IAdmPedidosServices
{
    /*/ ------------------------------- MÉTODOS ------------------------------- /*/ 
    // # Usados pelo próprio AdmPedidos #
    //1) Para login do adm
    Task<AdmPedidos?> RealizarLoginAdmPedidosAsync
        (string nome, string senha);
    //--------------------------------------------/------------------------------------------
  
    //2) 
    //-------------#----------------#---------------#------------
  
    // # Usados por outras entidades #
    //1) Para cadastro do adm
     Task<AdmPedidos?> RealizarCadastroAdmPedidosAsync(string nome, string senha);
    //--------------------------------------------/------------------------------------------
}