namespace Questao5.Domain.Entities
{
    public class Idempotency
    {
        
        /// <summary>
        /// Chave de idempotencia
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Requisicao realizada
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Resposta recebida
        /// </summary>
        public string Response { get; set; }
    }
}
