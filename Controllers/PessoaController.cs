using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_1.Data;
using api_1.Models;
using Microsoft.EntityFrameworkCore;

namespace api_1.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private DataContext db;
        
        public PessoaController(DataContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public async Task<ActionResult> listar()
        {
            var pessoas = await db.Pessoa.ToListAsync();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> listar(int id)
        {
            var pessoa = await db.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(pessoa);
        }

        [HttpPut]
        public async Task<ActionResult> editar([FromBody]Pessoa pessoa)
        {
            db.Pessoa.Update(pessoa);
            await db.SaveChangesAsync();
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> cadastrar([FromBody] Pessoa pessoa)
        {
            db.Pessoa.Add(pessoa);
            await db.SaveChangesAsync();
            return Created("Criado com sucesso!",pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deletar(int id)
        {
            var pessoa = await db.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
            db.Pessoa.Remove(pessoa);
            await db.SaveChangesAsync();
            return Ok(pessoa);
        }
    }
}