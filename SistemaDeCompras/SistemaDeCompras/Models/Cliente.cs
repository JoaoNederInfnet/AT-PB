using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeCompras.Models;

public class Cliente
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    //#) ID
    [Key] 
    public long Id { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //1) Email
    [Required(ErrorMessage = "O e-mail é obrigatório!")]
    public string ClienteEmail { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //2) Senha
    [Required(ErrorMessage = "A senha é obrigatória!")]
    public string ClientePassword { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //3) CEP
    public int? ClienteCep { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //4) Numero do imóvel
    public int? ClienteImovelNumber { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //5) Titular Cartao
    public string? ClienteCreditCardOwnerName { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //6) Numero Cartao
    public string? ClienteCreditCardNumber { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //7) CVV Cartao
    public int? ClienteCreditCardCvv { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //8) Validade Cartao
    public DateTime? ClienteCreditCardExpireDate { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //9) Bandeira Cartao
    public string? ClienteCreditCardFlag { get; set; }
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Cheio
    public Cliente
    (
        string email, 
        string senha, 
        int cep, 
        int imovelNumber, 
        string creditCardOwnerName, 
        string creditCardNumber, 
        int creditCardCvv, 
        DateTime creditCardExpireDate, 
        string creditCardFlag
    )
    {
        ClienteEmail = email;
        ClientePassword = senha;
        ClienteCep = cep;
        ClienteImovelNumber = imovelNumber;
        ClienteCreditCardOwnerName = creditCardOwnerName;
        ClienteCreditCardNumber = creditCardNumber;
        ClienteCreditCardCvv = creditCardCvv;
        ClienteCreditCardExpireDate = creditCardExpireDate;
        ClienteCreditCardFlag = creditCardFlag;
    }
    //--------------------------------------------/------------------------------------------
    
    //2) Vazio 
     public Cliente() {}
    //--------------------------------------------/------------------------------------------
    
    //3) Required (login e cadastro)
    public Cliente(string email, string senha)
    {
        ClienteEmail = email;
        ClientePassword = senha;
    }
    //========================================================
}