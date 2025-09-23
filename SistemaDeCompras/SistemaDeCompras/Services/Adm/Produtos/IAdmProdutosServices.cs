using SistemaDeCompras.Models;

namespace SistemaDeCompras.Services.Adm.Produtos;

public interface IAdmProdutosServices
{
    /*/ ------------------------------- MÉTODOS ------------------------------- /*/ 
    // # Usados pelo próprio AdmProdutos #
    //1) Para login do adm 
    Task<AdmProdutos?> RealizarLoginAdmProdutosAsync
        (string nome, string senha);
    //--------------------------------------------/------------------------------------------
  
    //2) 
    //-------------#----------------#---------------#------------
  
    // # Usados por outras entidades #
    //1) Para cadastro do adm 
    Task<AdmProdutos?> RealizarCadastroAdmProdutosAsync(string nome, string senha);
    //--------------------------------------------/------------------------------------------
}