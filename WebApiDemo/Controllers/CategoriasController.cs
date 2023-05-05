using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiDemo.Controllers
{
    public class CategoriasController : ApiController
    {

        private string connectionString = "workstation id=videoclubevc.mssql.somee.com;packet size=4096;user id=vitormestre_SQLLogin_1;pwd=ttmii23vsp;data source=videoclubevc.mssql.somee.com;persist security info=False;initial catalog=videoclubevc";
        private DataClasses1DataContext dc;

        public CategoriasController()
        {
            dc = new DataClasses1DataContext(connectionString);
        }

        // GET: api/Categorias
        public List<Categoria> Get()
        {
            var lista = from Categoria in dc.Categorias select Categoria;

            return lista.ToList();  
        }

        // GET: api/Categorias/AC
        [Route("api/categorias/{sigla}")]
        public IHttpActionResult Get(string sigla)
        {
            var categoria = dc.Categorias.SingleOrDefault(c => c.Sigla == sigla);

            if(categoria != null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, categoria));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "categoria não existe"));
        }

        // POST: api/Categorias
        public IHttpActionResult Post([FromBody]Categoria novaCategoria)
        {
            Categoria categoria = dc.Categorias.FirstOrDefault(c => c.Sigla == novaCategoria.Sigla);

            if(categoria != null) 
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Conflict, "já existe categoria com essa sigla"));
            }

            dc.Categorias.InsertOnSubmit(novaCategoria);

            try
            {
                dc.SubmitChanges();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.ServiceUnavailable, e));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            
        }

        // PUT: api/Categorias/5
        public IHttpActionResult Put([FromBody]Categoria novaCategoria)
        {
            Categoria categoria = dc.Categorias.FirstOrDefault(c => c.Sigla == novaCategoria.Sigla);

            if(categoria == null) 
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Não existe nenhuma categoria com essa sigl para poder alterar"));
            }

            categoria.Sigla = novaCategoria.Sigla;
            categoria.Categoria1 = novaCategoria.Categoria1;

            try
            {
                dc.SubmitChanges();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.ServiceUnavailable, e));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
        }

        // DELETE: api/Categorias/CM
        [Route("api/categorias/{sigla}")]
        public IHttpActionResult Delete(String sigla)
        {
            Categoria categoria = dc.Categorias.FirstOrDefault(c => c.Sigla == sigla);

            if(categoria != null)
            {
                dc.Categorias.DeleteOnSubmit(categoria);

                try
                {
                    dc.SubmitChanges();
                }
                catch (Exception e)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.ServiceUnavailable, e));
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Não existe nenhuma categoria com essa sigla para poder eliminar"));

        }
    }
}
