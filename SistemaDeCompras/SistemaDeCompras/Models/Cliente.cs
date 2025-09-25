using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeCompras.Models;

public class Cliente : Model
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    //1) Email
    [Required(ErrorMessage = "O e-mail é obrigatório!")]
    public string Email { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //2) Senha
    [Required(ErrorMessage = "A senha é obrigatória!")]
    public string Senha { get; set; }
    //========================================================
    
    /*/ ------------------------------- RELAÇÕES ------------------------------- /*/
    //Para carregar 
    //1) O endereço pertencente
    public Endereco? Endereco { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //2) O cartão de crédito pertencente
    public CartaoDeCredito? CartaoDeCredito { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //3) Os pedidos pertencentes
    public ICollection<Pedido>? Pedido { get; set; }
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Cheio
    public Cliente(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }
    //========================================================
}