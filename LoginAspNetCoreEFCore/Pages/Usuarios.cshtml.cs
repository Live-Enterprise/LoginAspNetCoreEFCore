using LoginAspNetCoreEFCore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAspNetCoreEFCore.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<Usuario> Usuarios { get; set; }

        private readonly Contexto _contexto;

        public UsuariosModel(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void OnGet()
        {
            Usuarios = _contexto.Usuarios.ToList();
        }
    }
}
