using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeCompras.Models;
using SistemaDeCompras.Services.AdmPerfisServices;

namespace SistemaDeCompras.Pages.Adm.Perfis;

public class Create : PageModel
{
    /* ------------------------------- CLASSE DE ENTRADA ------------------------------- */
    public class InputModel  
    {
        //1) Nome
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string? Nome { get; set; }
        //--------------------------------------------/------------------------------------------
    
        //2) Senha
        [Required(ErrorMessage = "A senha é obrigatória!")]
        public string? Senha { get; set; }
        //--------------------------------------------/------------------------------------------
    }
    //========================================================
    
    /* ------------------------------- PROPRIEDADES ------------------------------- */
    //1) Definindo a classe que será ligada aos dados do formulário no HTML e usada aqui no cs como propriedade nos handlers
    [BindProperty]  
    public InputModel Input { get; set; } = new();
    //========================================================
    
    /* ------------------------------- INJEÇÕES DE DEPENDÊNCIA ------------------------------- */
    //1) Criando os campo que usarei para injetar as dependências dentro da PageModel
    //A) Para conseguir usar o service
    private readonly IServices _admPerfisServices; //readonly para definir esse campo apenas no construtor
    //--------------------------------------------/------------------------------------------
    
    //B) Para conseguir usar minhas classes FluentValidation
     //readonly para definir esse campo apenas no construtor
    //----------------------------------//--------------------------------
    
    //2) Criando um construtor para injetar a classe service e o validador registrado na linha () do Program.cs
    public Create(IServices admPerfisServices)
    {
        _admPerfisServices = admPerfisServices;
    }
    //========================================================
    
    /* ------------------------------- HANDLERS DE REQUISIÇÃO ------------------------------- */
    //# GET -> Preparação para primeira exibição da página
    //Inicializando 
    public void OnGet() 
    {
        new InputModel();
    }
    //========================================================
    
    //# POST -> Processamento dos dados enviados pelo formulário
    public async Task<IActionResult> OnPostAsync()
    {
        /* Fazendo a validação manual com FluentValidation */
        //1) Laço for para validar cada objeto input do formulário
        
        
            //2) Instanciando um objeto ValidationResult, que devolve o resultado da validação de um Input com minhas validações no pacote Validators
            

            //3) Conferindo o objeto ValidationResult para registrar os erros no ModelState 
            
            
                //4) foreach para usar cada erro encontrado no Input
                
                
                    //5) Adicionando o erro dentro do ModelState, para a propriedade específica
                    
                    
        
        //6)Carregando o formulário de novo com as mensagens de erro 
        if (!ModelState.IsValid)
        {
            return Page();
        }
        //========================================================
        
        
        /* Para formulário preenchido corretamente */
        //# Preparando os dados para o armazenamento no sistema
        //1) Tentando armazenar e redirecionando para página de sucesso
        try
        {
            await _admPerfisServices.RealizarCadastroAdmPerfisAsync(Input.Nome, Input.Senha);
            return RedirectToPage("/CadastroSucesso"); //TODO
        }
        //2) Exibindo erro no formulário caso os dados não passem nas validações das lógicas de négocio nos Services:
        //A) o e-mail não seja válido
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError("Input.Nome", ex.Message);
            return Page();
        }
        //-------------------------///-----------------------
        //B) Caso ocorra algum erro inesperado
        catch (Exception ex) // Um catch genérico para outros erros inesperados
        {
            ModelState.AddModelError(string.Empty, "Ocorreu um erro inesperado. Tente novamente.");
            return Page();
        }
    }
}