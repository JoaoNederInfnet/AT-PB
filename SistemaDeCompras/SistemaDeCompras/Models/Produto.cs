using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeCompras.Models;

public class Produto : Model
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    //1) Nome
    public string Nome{ get; set; } 
    //--------------------------------------------/------------------------------------------
    
    //2) Preço
    public decimal Preco{ get; set; } 
    //========================================================
    
    /*/ ------------------------------- RELAÇÕES ------------------------------- /*/
    //#) Definindo a entidade com a qual o Endereço se relaciona (pertence)
    [ForeignKey("AdmProdutos")]
    public long AdmProdutosId { get; set; }
    public AdmProdutos AdmProdutos { get; set; }
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Cheio
    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
    //========================================================
}