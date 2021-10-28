using System.Threading.Tasks;
using api_1.Data;
using api_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_1.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private DataContext db;
        public EmpresaController(DataContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await db.Empresa.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Listar(int id)
        {
            var empresa = await db.Empresa.FirstOrDefaultAsync(x => x.Id == id);
            if (empresa == null)
                return NotFound();
            return Ok(empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Empresa empresa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (empresa.Id != id)
                return NotFound();
            
            db.Empresa.Update(empresa);
            await db.SaveChangesAsync();
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Empresa empresa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Empresa.Add(empresa);
            await db.SaveChangesAsync();
            return Ok(empresa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var empresa = await db.Empresa.FirstOrDefaultAsync(x => x.Id == id);
            if (empresa == null)
                return NotFound();
            db.Empresa.Remove(empresa);
            await db.SaveChangesAsync();
            return Ok(empresa);
        }
        
    }
}