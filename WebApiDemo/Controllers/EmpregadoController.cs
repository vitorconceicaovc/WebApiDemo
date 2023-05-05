using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class EmpregadoController : ApiController
    {

        private List<Empregado> Funcionarios;

        public EmpregadoController() { 
            Funcionarios = new List<Empregado> 
            { 
                new Empregado { Id = 1, Nome = "Joana", Apelido = "Matos"},
                new Empregado { Id = 2, Nome = "Carlota", Apelido = "orais"},
                new Empregado { Id = 3, Nome = "Rui", Apelido = "Santos"}
            };
        }

        // GET: api/Empregado
        public List<Empregado> Get()
        {
            return Funcionarios;
        }

        // GET: api/Empregado/5
        /// <summary>
        /// Dados completos do empregado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna empregado</returns>
        public Empregado Get(int id)
        {
            return Funcionarios.FirstOrDefault(x => x.Id == id);    
        }

        // GET: api/Empregado/GetNomes
        /// <summary>
        /// Nomes próprio de todos os empregados 
        /// </summary>
        /// <returns>lista com os nomes de todos os epregados</returns>
        [Route("api/empregado/getnomes")]

        public List<string> GetNomes() 
        { 
            List<string> output = new List<string>();

            foreach (var e in Funcionarios)
            {
                output.Add(e.Nome);
            }
            return output;
        }

        // POST: api/Empregado
        /// <summary>
        /// registo de novo empregado
        /// </summary>
        /// <param name="value">Empregado</param>
        public void Post([FromBody]Empregado value)
        {
            Funcionarios.Add(value);
        }

        // DELETE: api/Empregado/5
        /// <summary>
        /// Apagar Empregado
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            
        }
    }
}
