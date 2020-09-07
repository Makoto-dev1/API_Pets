﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pets.Domains;
using API_Pets.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPetController : ControllerBase
    {
        //Chamando o repositório
        TipoPetRepository repo = new TipoPetRepository();  

        // GET: api/<TipoPetController>
        [HttpGet]
        public List<TipoPet> Get()
        {
            return repo.LerTodos();
        }

        // GET api/<TipoPetController>/5
        [HttpGet("{id}")]
        public TipoPet Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST api/<TipoPetController>
        [HttpPost]
        public TipoPet Post([FromBody] TipoPet a)
        {
            return repo.Cadastrar(a);
        }

        // PUT api/<TipoPetController>/5
        [HttpPut("{id}")]
        public TipoPet Put(int id, [FromBody] TipoPet a)
        {
            return repo.Alterar(id, a);
        }

        // DELETE api/<TipoPetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Deletar(id);
        }
    }
}
