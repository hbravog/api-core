using System;
using System.Collections.Generic;
using IntegracionSistemas.Model;
using IntegracionSistemas.Service;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public Persona GetById(int id)
        {
            PersonaService service = new PersonaService();
            return service.GetPersona().Find(o => o.IdPersona == id);
        }

        [HttpGet]
        public List<Persona> GetAll()
        {
            PersonaService service = new PersonaService();
            return service.GetPersona();
        }

        // POST api/values
        [HttpPost]
        public String AddPersona([FromBody] Persona p)
        {
            PersonaService service = new PersonaService();
            return service.Insert(p);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] Persona p)
        {
            PersonaService service = new PersonaService();
            return service.Update(id, p);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            PersonaService service = new PersonaService();
            return service.Delete(id);
        }
    }
}
