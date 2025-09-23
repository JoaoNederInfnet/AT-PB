using SistemaDeCompras.Models;

namespace SistemaDeCompras.Services.Adm.Perfis;

public interface IAdmPerfisServices
{
    /*/ ------------------------------- MÉTODOS ------------------------------- /*/ 
    // # Usados pelo próprio AdmPerfis #
    //1) Para login do adm 
    Task<AdmPerfis?> RealizarLoginAdmPerfisAsync
        (string nome, string senha);
    //--------------------------------------------/------------------------------------------
  
    //2) 
    //-------------#----------------#---------------#------------
  
    // # Usados por outras entidades #
    //1) Para cadastro do adm 
    Task<AdmPerfis?> RealizarCadastroAdmPerfisAsync(string nome, string senha);
    //--------------------------------------------/------------------------------------------
}