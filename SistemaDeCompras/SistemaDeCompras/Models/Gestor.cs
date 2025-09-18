using System.ComponentModel.DataAnnotations;

namespace SistemaDeCompras.Models;

public class Gestor : Model
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    //1) Nome
    [Required(ErrorMessage = "O nome de usuário é obrigatório!")]
    public string Nome { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //2) Senha
    [Required(ErrorMessage = "A senha é obrigatória!")]
    public string Senha { get; set; }
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Cheio
    public Gestor(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }
    //======================================================== 
}