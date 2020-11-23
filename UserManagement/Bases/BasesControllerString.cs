using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Repositories.Interface;

namespace UserManagement.Bases
{
    public class BasesControllerString<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntityString
        where TRepository : IRepositoryString<TEntity>
    {
        private readonly TRepository _repository;

        public BasesControllerString(TRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<TEntity>> Get()
        {
            var result = await _repository.Get();
            return Ok(new { data = result });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(string id)
        {
            var get = await _repository.Get(id);
            if (get == null)
            {
                return NotFound();
            }
            return Ok(new { data = get });
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await _repository.Post(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            var update = await _repository.Put(entity);
            return Ok(update);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(string id)
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
