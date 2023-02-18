using Microsoft.AspNetCore.Mvc;
using SuaSaudeService.Dto;
using SuaSaudeService.Interface;
using System.ComponentModel.DataAnnotations;

namespace SuaSaude.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SuaSaudeController : ControllerBase
    {

        private readonly ISuaSaudeService _suasaudeservice;  

        public SuaSaudeController(ISuaSaudeService suasaudeservice)
        {
            _suasaudeservice = suasaudeservice;
        }

        [HttpGet("imc")]
        [ProducesResponseType(typeof(double), StatusCodes.Status202Accepted)]
        public ActionResult<double> GetIMC([Range(1, double.MaxValue)] double peso, [Range(0.01, 3.0)] double altura)
        {
            if (peso == null || altura == null)
            {
                ModelState.AddModelError("peso", "Nenhum valor pode ser nulo.");
                return BadRequest(ModelState);
            }
            double result = _suasaudeservice.CalcularIMC(peso, altura);
            return Accepted(result);
        }
         
        
        [HttpGet("classificacaoImc")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public ActionResult<string> GetResultado(double imc)
        {
            if(imc == null)
            {
                ModelState.AddModelError("imc", "Digite um imc, cara!");
                return BadRequest(ModelState);
            }
            string result = _suasaudeservice.ClassificarIMC(imc);
            return Ok(result);
        }

        [HttpGet("calculoCompleto")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public ActionResult<InfoIMCDTO> GetCalculoCompleto(double peso, double altura)
        {
            if (peso == null || altura == null)
            {
                ModelState.AddModelError("peso", "Nenhum valor pode ser nulo.");
                return BadRequest(ModelState);
            }
            InfoIMCDTO result = _suasaudeservice.ClassificacaoComCategoria(peso, altura);
            return Ok(result);
        }
    }

}   