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
    public class NotasController : ControllerBase
    {
        private readonly INotasServico _servico;
        public NotasController(INotasServico servico)
        {
            _servico = servico;
        }

        /// <summary>
        /// Notas
        /// </summary>
        /// <remarks>
        /// Salvar Notas
        /// </remarks>
        [HttpPost]
        [Route("api/Notas/Salvar")]
        public virtual RetornoApi Salvar(Notas value)
        {


            var retorno = _servico.Salvar(value);

            return new RetornoApi
            {
                resultado = retorno == "Ok",
                valor = retorno

            };
        }

        /// <summary>
        /// Notas
        /// </summary>
        /// <remarks>
        /// Atualizar Notas
        /// </remarks>
        [HttpPost]
        [Route("api/Notas/Atualizar")]
        public virtual RetornoApi Atualizar(Notas value)
        {
            var retorno = _servico.Atualizar(value);
            return new RetornoApi
            {
                resultado = retorno == "1",
                valor = retorno

            };
        }

        /// <summary>
        /// Notas
        /// </summary>
        /// <remarks>
        /// Deletar Notas
        /// </remarks>
        [HttpPost]
        [Route("api/Notas/Deletar")]
        public virtual RetornoApi Deletar(Notas value)
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
        [Route("api/Notas/Listar")]
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
        [Route("api/Notas/{Id}")]
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
