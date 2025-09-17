using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeCompras.Models;

public class CartaoDeCredito : Model
{
  /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
  //1) Titular Cartao
  [Required(ErrorMessage = "O nome é obrigatório!")]
  public string NomeDoTitular { get; set; }
  //--------------------------------------------/------------------------------------------
  
  [Required(ErrorMessage = "O número é obrigatório!")]  
  //2) Numero Cartao
  public string Numero { get; set; }
  //--------------------------------------------/------------------------------------------
  
  [Required(ErrorMessage = "O CVVé obrigatório!")]  
  //3) CVV Cartao
  public int Cvv { get; set; }
  //--------------------------------------------/------------------------------------------
  
  [Required(ErrorMessage = "A data de validade é obrigatória!")]  
  //4) Validade Cartao
  public DateTime DataDeValidade { get; set; }
  //--------------------------------------------/------------------------------------------
  
  [Required(ErrorMessage = "A bandeira é obrigatória!")]  
  //5) Bandeira Cartao
  public string Bandeira { get; set; }
  //========================================================
  
  /*/ ------------------------------- RELAÇÕES ------------------------------- /*/
  //#) Definindo a entidade com a qual o Cartao de Credito se relaciona (pertence)
  [ForeignKey("Cliente")]
  public long ClienteId { get; set; }
  public Cliente Cliente { get; set; }
  //========================================================
  
  /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
  //1) Cheio
  public CartaoDeCredito(string nomeDoTitular, string numero, int cvv, DateTime dataDeValidade, string bandeira)
  {
    NomeDoTitular = nomeDoTitular;
    Numero = numero;
    Cvv = cvv;
    DataDeValidade = dataDeValidade;
    Bandeira = bandeira;
  }
  //========================================================
}