using System.ComponentModel.DataAnnotations;

namespace SistemaDeCompras.Models;

public abstract class Model
{
    /*/ ------------------------------- PROPRIEDADES ------------------------------- /*/
    //#) ID
    [Key] 
    public long Id { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //2) Created at
    public DateTime CriadoEm { get; set; }
    //--------------------------------------------/------------------------------------------
    
    //3) Updated at
    public DateTime AtualizadoEm { get; set; }
    //========================================================
    
    /*/ ------------------------------- CONSTRUTORES ------------------------------- /*/
    //1) Vazio 
    public Model() {}
    //========================================================
}