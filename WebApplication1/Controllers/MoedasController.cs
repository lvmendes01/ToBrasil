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
        [Route("api/Moedas/Salvar")]
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
        /// Moedas
        /// </summary>
        /// <remarks>
        /// Atualizar moedas
        /// </remarks>
        [HttpPost]
        [Route("api/Moedas/Atualizar")]
        public virtual RetornoApi Atualizar(Moedas value)
        {
            var retorno = _servico.Atualizar(value);
            return new RetornoApi
            {
                resultado = retorno == "1",
                valor = retorno

            };
        }

        /// <summary>
        /// Moedas
        /// </summary>
        /// <remarks>
        /// Deletar moedas
        /// </remarks>
        [HttpPost]
        [Route("api/Moedas/Deletar")]
        public virtual RetornoApi Deletar(Moedas value)
        {


            var retorno = _servico.Delete(value);

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
        [Route("api/Moedas/Listar")]
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
        
        
        [HttpGet]
        [Route("api/Moedas/{Id}")]
        [SwaggerOperation("")]
        public RetornoApi Carregar(Int64 Id)
        {
            var item = _servico.Carregar(Id);

            RetornoApi retornoApi = new RetornoApi
            {
                resultado = (item != null),
                valor = (item != null) ? item : null

            };
            return retornoApi;
        }
    }
}
