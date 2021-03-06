using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;database=usuariosdb;uid=root;password=admin");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"INSERT INTO usuarios (nome, username, senha) VALUES ('{Nome}', '{Usuario}', '{Senha}')";

            await mySqlCommand.ExecuteReaderAsync();

            return new JsonResult(new { Msg = "Usu�rio cadastrado com sucesso!" });
        }
    }
}
