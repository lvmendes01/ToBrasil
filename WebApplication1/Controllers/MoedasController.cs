using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Totvs.Entidade;
using Totvs.Servico.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoedasController : ControllerBase
    {
        private readonly IMoedaServico _servico;
        public MoedasController(IMoedaServico servico)
        {
            _servico = servico;
        }

        /// <summary>
        /// Moedas
        /// </summary>
        /// <remarks>
        /// Salvar moedas
        /// </remarks>
        [HttpPost]
        [Route("api")]
        public virtual RetornoApi Salvar(Moedas value)
        {


            var retorno = _servico.Salvar(value);

            return new RetornoApi
            {
                resultado = retorno == "Ok",
                valor = retorno

            };
        }
        /// <summary>
        /// Carregar Perfil
        /// </summary>
        [HttpGet]
        [Route("api")]
        [SwaggerOperation("")]
        public RetornoApi Listar()
        {
            var item = _servico.Listar();

            RetornoApi retornoApi = new RetornoApi
            {
                resultado = (item != null),
                valor = (item != null) ? item : null

            };
            return retornoApi;
        }

    }
}
