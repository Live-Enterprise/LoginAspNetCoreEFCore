using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAspNetCoreEFCore.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<UsuarioViewModel> Usuarios { get; set; }

        public async Task OnGet()
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;database=usuariosdb;uid=root;password=admin");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM usuarios";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            Usuarios = new List<UsuarioViewModel>();

            while (await reader.ReadAsync())
            {
                Usuarios.Add(new UsuarioViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Usuario = reader.GetString(2)
                });
            }
        
            await mySqlConnection.CloseAsync();
        }
    }

    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
    }
}
