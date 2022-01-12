using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Prueb_GitHub.Entity;
using System.Linq;


namespace Prueb_GitHub.UserAPI
{
    public class UsersApiClient
    {
        string BaseUri;

        public  UsersApiClient()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"];
        }

        /// <summary>
        /// Obté una tasca a partir del Id
        /// </summary>
        /// <param name="Tasca">Codi de Tasca</param>
        /// <returns>Tasca o null si no el troba</returns>
        //Funció per poder fer un select de totes les nostres tasques.
        public async Task<Tasca> GetUserAsync(int Id)
        {
            Tasca tasca = new Tasca();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tasca/{Id}
                HttpResponseMessage response = await client.GetAsync($"tasca/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    //Reposta 204 quan no ha trobat dades
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        tasca = null;
                    }
                    else
                    {
                        //Obtenim el resultat i el carreguem al Objecte Tasca
                        tasca = await response.Content.ReadAsAsync<Tasca>();
                        response.Dispose();
                    }
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? 
                }
            }
            return tasca;
        }

        /// <summary>
        /// Obté una llista de totes les tasques de la base de dades
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tasca>> GetUsersAsync()
        {
            List<Tasca> tasca = new List<Tasca>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /tasca}
                HttpResponseMessage response = await client.GetAsync("tasca");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista de tasques
                    tasca = await response.Content.ReadAsAsync<List<Tasca>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return tasca;
        }

        /// <summary>
        /// Afegeix una nova tasca
        /// </summary>
        /// <param name="tasca">Tasca que volem afegir</param>
        /// <returns></returns>
        public async Task AddAsync(Tasca tasca)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició POST al endpoint /users}
                HttpResponseMessage response = await client.PostAsJsonAsync("tasca", tasca);
                response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Modificar una tasca
        /// </summary>
        /// <param name="tasca">Tasca que volem modificar</param>
        /// <returns></returns>
        public async Task UpdateAsync(Tasca tasca)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició PUT al endpoint /users/Id
                HttpResponseMessage response = await client.PutAsJsonAsync($"tasca/{tasca.Id}", tasca);
                response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Modificar una tasca
        /// </summary>
        /// <param name="tasca">Tasca que volem modificar</param>
        /// <returns></returns>
        public async Task DeleteAsync(int Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició DELETE al endpoint /users/Id
                HttpResponseMessage response = await client.DeleteAsync($"tasca/{Id}");
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
