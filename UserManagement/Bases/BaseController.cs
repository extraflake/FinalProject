using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Repositories.Interface;

namespace UserManagement.Bases
{
    public class BaseController <TEntity, TRepositories> : ControllerBase
        where TEntity : class, IEntity
        where TRepositories : IRepositories<TEntity>
    {
        private readonly TRepositories _repository;

        public BaseController(TRepositories repository) { this._repository = repository; }

        [HttpGet]
        public async Task<IEnumerable<TEntity>> Get() => await _repository.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var get = await _repository.Get(id);
            if (get == null)
            {
                return NotFound();
            }
            return Ok(get);
        }
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await _repository.Post(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            var result = await _repository.Put(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var delete = await _repository.Delete(id);
            if (delete == null)
            {
                return NotFound();
            }
            return delete;
        }
    }
}
