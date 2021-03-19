using LoginAspNetCoreEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LoginAspNetCoreEFCore.Pages
{
    public class CadastrarModel : PageModel
    {
        [Required(ErrorMessage = "� obrigat�rio informar o Nome!")]
        [BindProperty(SupportsGet = true)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "� obrigat�rio informar o Usu�rio!")]
        [BindProperty(SupportsGet = true)]
        public string Usuario { get; set; }


        [Required(ErrorMessage = "� obrigat�rio informar a Senha!")]
        [DataType(DataType.Password)]
        [BindProperty(SupportsGet = true)]
        public string Senha { get; set; }

        private readonly Contexto _contexto;

        public CadastrarModel(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _contexto.Add(new Usuario
            {
                Nome = Nome,
                Username = Usuario,
                Senha = Senha
            });
            _contexto.SaveChanges();

            return new JsonResult(new { Msg = "Usu�rio cadastrado com sucesso!" });
        }
    }
}
