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
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoServico _servico;
        private readonly ITrocoServico _servicoTroco ;

        
        public TransacaoController(ITransacaoServico servico, ITrocoServico servicoTroco)
        {
            _servico = servico;
            _servicoTroco = servicoTroco;
        }

        /// <summary>
        /// Transacao
        /// </summary>
        /// <remarks>
        /// Salvar Transacao
        /// </remarks>
        [HttpPost]
        [Route("api/Transacao/Salvar")]
        public virtual RetornoApi Salvar(Transacao value)
        {

            value = _servicoTroco.ObterTroco(value);


            return new RetornoApi
            {
                resultado = true,
                valor = value.Observacao

            };
        }

        /// <summary>
        /// Transacao
        /// </summary>
        /// <remarks>
        /// Atualizar Transacao
        /// </remarks>
        [HttpPost]
        [Route("api/Transacao/Atualizar")]
        public virtual RetornoApi Atualizar(Transacao value)
        {
            var retorno = _servico.Atualizar(value);
            return new RetornoApi
            {
                resultado = retorno == "1",
                valor = retorno

            };
        }

        /// <summary>
        /// Transacao
        /// </summary>
        /// <remarks>
        /// Deletar Transacao
        /// </remarks>
        [HttpPost]
        [Route("api/Transacao/Deletar")]
        public virtual RetornoApi Deletar(Transacao value)
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
        [Route("api/Transacao/Listar")]
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
        [Route("api/Transacao/{Id}")]
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
