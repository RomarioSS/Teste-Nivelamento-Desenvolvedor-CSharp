using Questao5.Domain.SeedWork;

namespace Questao5.Domain.Entities
{
    public class CheckingAccount : Entity
    {
        /// <summary>
        /// Identificador da conta corrente
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Numero da conta corrente
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Titular da conta corrente
        /// </summary>
        public string Holder { get; set; }

        /// <summary>
        /// Status da conta corrente
        /// </summary>
        public bool IsActive { get; set; }
    }
}
