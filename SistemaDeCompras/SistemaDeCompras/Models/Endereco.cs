using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeCompras.Models;

public class Endereco : Model
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    //1) CEP
    [Required(ErrorMessage = "O CEP é obrigatório!")]
    public int Cep { get; set; }
    //--------------------------------------------/------------------------------------------
    
    [Required(ErrorMessage = "O número do imóvel é obrigatório!")]
    //2) Numero do imóvel
    public int Numero { get; set; }
    //========================================================
    
    /*/ ------------------------------- RELAÇÕES ------------------------------- /*/
    //#) Definindo a entidade com a qual o Endereço se relaciona (pertence)
    [ForeignKey("Cliente")]
    public long ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Cheio
    public Endereco(int cep, int numero)
    {
        Cep = cep;
        Numero = numero;
    }
    //========================================================
}