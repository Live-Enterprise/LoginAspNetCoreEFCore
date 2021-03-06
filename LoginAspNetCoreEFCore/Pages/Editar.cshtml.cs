using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
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

        public async Task OnGet()
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;database=usuariosdb;uid=root;password=admin");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM usuarios WHERE id = '{Id}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (await reader.ReadAsync())
            {
                Nome = reader.GetString(1);
                Usuario = reader.GetString(2);
            }

            await mySqlConnection.CloseAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;database=usuariosdb;uid=root;password=admin");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"UPDATE usuarios SET username = '{Usuario}', nome = '{Nome}' WHERE id = {Id}";

            await mySqlCommand.ExecuteReaderAsync();

            return new JsonResult(new { Msg = "Usuário Editado com sucesso!" });
        }

        public async Task<IActionResult> OnGetApagar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;database=usuariosdb;uid=root;password=admin");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"DELETE FROM usuarios WHERE id = {Id}";

            await mySqlCommand.ExecuteReaderAsync();
            await mySqlConnection.CloseAsync();

            return new JsonResult(new { Msg = "Usuário Removido com sucesso!" });
        }
    }
}
