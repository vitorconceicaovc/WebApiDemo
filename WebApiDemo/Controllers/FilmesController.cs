using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiDemo.Controllers
{
    public class FilmesController : ApiController
    {

        private string connectionString = "workstation id=videoclubevc.mssql.somee.com;packet size=4096;user id=vitormestre_SQLLogin_1;pwd=ttmii23vsp;data source=videoclubevc.mssql.somee.com;persist security info=False;initial catalog=videoclubevc";
        private DataClasses1DataContext dc;

        public FilmesController()
        {
            dc = new DataClasses1DataContext(connectionString);
        }

        // GET: api/Filmes
        public List<Filme> Get()
        {
            var lista = from Filme in dc.Filmes orderby Filme.Titulo select Filme;

            return lista.ToList();
        }

        // GET: api/Filmes/5
        public IHttpActionResult Get(int id)
        {
            var filme = dc.Filmes.SingleOrDefault(f => f.Id == id);

            if(filme != null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, filme));   
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Filme não existe"));    
        }

        // POST: api/Filmes
        public IHttpActionResult Post([FromBody]Filme novoFilme)
        {
            Filme filme = dc.Filmes.FirstOrDefault(f => f.Id == novoFilme.Id);

            if (filme != null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Conflict, "Já existe um fime com esse ID"));
            }

            Categoria categoria = dc.Categorias.FirstOrDefault(c => c.Sigla == novoFilme.Categoria);

            if (categoria == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Não existe ainda essa categoria, va a categorias primeiro"));
            }

            dc.Filmes.InsertOnSubmit(novoFilme);

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

        // PUT: api/Filmes/5
        public IHttpActionResult Put([FromBody]Filme filmeAlterado)
        {
            Filme filme = dc.Filmes.FirstOrDefault(f => f.Id == filmeAlterado.Id);

            if (filme == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Não existe nenhum filme com esse id para poder alterar"));
            }

            Categoria categoria = dc.Categorias.FirstOrDefault(c => c.Sigla == filmeAlterado.Categoria);

            if (categoria == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Não existe ainda essa categoria, va a categorias primeiro"));
            }

            filme.Titulo = filmeAlterado.Titulo;
            filme.Categoria = filmeAlterado.Categoria;

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

        // DELETE: api/Filmes/5
        public IHttpActionResult Delete(int id)
        {
            Filme filme = dc.Filmes.FirstOrDefault(f => f.Id == id);    

            if (filme != null)
            {
                dc.Filmes.DeleteOnSubmit(filme);

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

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Não existe nenhum filme com esse id para poder eliminar"));
        }
    }
}
