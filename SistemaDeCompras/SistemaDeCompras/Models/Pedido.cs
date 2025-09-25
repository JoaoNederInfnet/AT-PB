using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeCompras.Models;

public class Pedido : Model
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    //1) Nome
    public decimal ValorTotal { get; set; }
    //========================================================
    
    /*/ ------------------------------- RELAÇÕES ------------------------------- /*/
    //1) Definindo a entidade com a qual o Endereço se relaciona (pertence)
    [ForeignKey("Cliente")]
    public long ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //2) Definindo a entidade com a qual o Endereço se relaciona (depende)
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Cheio
    public Pedido(ICollection<Produto> produtos, decimal valorTotal)
    {
        Produtos = produtos ?? new List<Produto>();
        ValorTotal = valorTotal;
    }
    //--------------------------------------------/------------------------------------------
    
    //2) Vazio (para o EF conseguir fazer a migration)
    public Pedido() {}
}