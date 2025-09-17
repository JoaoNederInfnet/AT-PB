namespace SistemaDeCompras.Models;

public class Produto : Model
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    //1) Nome
    public String Nome{ get; set; } 
    //--------------------------------------------/------------------------------------------
    
    //2) Preço
    public String Preco{ get; set; } 
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Cheio
    public Produto(string nome, string preco)
    {
        Nome = nome;
        Preco = preco;
    }
    //========================================================
}