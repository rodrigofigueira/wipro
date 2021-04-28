using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace WiProAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilaController : Controller
    {
        private static List<Moeda> moedas = new List<Moeda>();

        [HttpPost]
        [Route("additemfila")]
        public HttpResponseMessage AddItemFila([FromBody] string fila)
        {

            if (!fila.StartsWith("[") && !fila.StartsWith("]")) 
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            try
            {
                List<Moeda> _moedas = JsonConvert.DeserializeObject<List<Moeda>>(fila);
                moedas.AddRange(_moedas);
            }
            catch(Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("getitemfila")]
        public JsonResult GetItemFila()
        {

            if (moedas.Count == 0)
            {
                Response.StatusCode = 400;
                return new JsonResult(new { message = "Lista está vazia" });
            }

            Moeda moeda = moedas.Last();
            moedas.Remove(moeda);
            
            return new JsonResult(new {
                moeda = moeda.moeda,
                data_inicio = moeda.data_inicio,
                data_fim = moeda.data_fim
            });            

        }

    }

}
