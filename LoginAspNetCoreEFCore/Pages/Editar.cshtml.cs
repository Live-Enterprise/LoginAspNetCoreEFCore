using LoginAspNetCoreEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAspNetCoreEFCore.Pages
{
    public class EditarModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }


        [Required(ErrorMessage = "É obrigatório informar o Nome!")]
        [BindProperty(SupportsGet = true)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "É obrigatório informar o Usuário!")]
        [BindProperty(SupportsGet = true)]
        public string Usuario { get; set; }

        private readonly Contexto _contexto;

        public EditarModel(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void OnGet()
        {
            Usuario usuario = _contexto.Usuarios.AsNoTracking().FirstOrDefault(x => x.UsuarioId == Id);
            Nome = usuario.Nome;
            Usuario = usuario.Username;
        }

        public IActionResult OnPost()
        {
            Usuario usuario = _contexto.Usuarios.FirstOrDefault(x => x.UsuarioId == Id);

            usuario.Username = Usuario;
            usuario.Nome = Nome;

            _contexto.Update(usuario);
            _contexto.SaveChanges();

            return new JsonResult(new { Msg = "Usuário Editado com sucesso!" });
        }

        public IActionResult OnGetApagar()
        {
            Usuario usuario = _contexto.Usuarios.FirstOrDefault(x => x.UsuarioId == Id);

            _contexto.Remove(usuario);
            _contexto.SaveChanges();

            return new JsonResult(new { Msg = "Usuário Removido com sucesso!" });
        }
    }
}
