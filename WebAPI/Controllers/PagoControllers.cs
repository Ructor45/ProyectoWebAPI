using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Data;
using WebAPI.Models;

namespace WebApi.Controllers
{
    public class PagoController : ApiController
    {
        // GET api/<controller>
        public List<Pago> Get()
        {
            return PagoData.Listar();
        }

        // GET api/<controller>/5
        public Pago Get(int id)
        {
            return PagoData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Pago oPago)
        {
            return PagoData.Registrar(oPago);
        }

        // PUT api/<controller>/5
        public bool Put(int id, [FromBody] Pago oPago)
        {
            oPago.IdPago = id;
            return PagoData.Modificar(oPago);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return PagoData.Eliminar(id);
        }
    }
}
