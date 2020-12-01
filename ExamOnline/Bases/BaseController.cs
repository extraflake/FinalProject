using ExamOnline.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Bases
{
    public class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<TEntity>> Get()
        {
            var result = await this.repository.Get();
            if(result != null)
            {
                return Ok(new { data = result });
            }
            return NotFound("Data masih kosong");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var result = await this.repository.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound( "Id : " + id + " tidak ditemukan");
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            var result =  await this.repository.Post(entity);
            if (result != null)
            {
                return CreatedAtAction("Get", new { id = entity.Id }, entity);
            }
            return NotFound("Gagal menambahkan data baru");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return NotFound("Id : " +id+ " tidak dapat diupdate");
            }
            await this.repository.Put(entity);
            return Ok();
        }
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<TEntity>> Delete(int id)
        //{
        //    var result = await this.repository.Delete(id);
        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    return NotFound();
        //}
    }
}
