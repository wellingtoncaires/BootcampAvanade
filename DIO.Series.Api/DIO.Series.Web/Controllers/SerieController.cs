using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Series.Interfaces;

namespace DIO.Series.Web.Controllers
{
    [Route("[controller]")]
    public class SerieController : Controller
    {
        //static SerieRepository repository = new SerieRepository();
        private readonly IRepository<Series> _repositorySerie;

        public SerieController(IRepository<Series> repositorySerie)
        {
            _repositorySerie = repositorySerie;
        }

        [HttpGet("")]
        public IActionResult Lista()
        {
            return Ok(_repositorySerie.Lista().Select(s => new SerieModel(s)));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]SerieModel model)
        {
            _repositorySerie.Update(id, model.ToSerie());
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorySerie.Delete(id);
            return NoContent();
        }

        [HttpPost("")]
        public IActionResult Insert([FromBody] SerieModel model)
        {
            model.Id = _repositorySerie.NextId();

            Series series = model.ToSerie();

            _repositorySerie.Insert(series);
            return Created("", series);
        }

        [HttpGet("{id}")]
        public IActionResult ReturnById(int id)
        {
            return Ok(new SerieModel(_repositorySerie.ReturnById(id)));
        }


    }
}
