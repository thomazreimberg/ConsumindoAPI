using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consumindo_API.API
{
    class FilmeAPI
    {
        public void Inserir(Models.FilmeModel filme)
        {
            HttpClient client = new HttpClient();

            string json = JsonConvert.SerializeObject(filme);
            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = client.PostAsync("http://localhost:5000/Filme/", body).Result;
        }

        public List<Models.FilmeModel> ListarTodos()
        {
            HttpClient client = new HttpClient();

            string json = client.GetAsync("http://localhost:5000/Filme/ConsultarTodos")
                                .Result
                                .Content
                                .ReadAsStringAsync()
                                .Result;

            List<Models.FilmeModel> lista = JsonConvert.DeserializeObject<List<Models.FilmeModel>>(json);
            return lista;
        }

        public List<Models.FilmeModel> ListarPorCategoria(string categoria)
        {
            HttpClient client = new HttpClient();

            string json = client.GetAsync("http://localhost:5000/Filme/ConsultarCategoria/" + categoria)
                                .Result
                                .Content
                                .ReadAsStringAsync()
                                .Result;

            List<Models.FilmeModel> lista = JsonConvert.DeserializeObject<List<Models.FilmeModel>>(json);
            return lista;
        }

        public void Alterar(Models.FilmeModel filme)
        {
            HttpClient client = new HttpClient();

            string json = JsonConvert.SerializeObject(filme);
            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = client.PutAsync("http://localhost:5000/Filme/", body).Result;
        }

        public void Remover(int id)
        {
            HttpClient client = new HttpClient();

            var resp = client.DeleteAsync("http://localhost:5000/Filme/" + id).Result;
        }
    }
}
