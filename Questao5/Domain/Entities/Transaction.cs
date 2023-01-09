using Questao5.Domain.Enumerators;
using Questao5.Domain.SeedWork;

namespace Questao5.Domain.Entities
{
    public class Transaction : Entity
    {
        /// <summary>
        /// Identificador de movimento
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador de conta corrente
        /// </summary>

        public string CheckingAccountId { get; set; }

        /// <summary>
        /// Data de movimento
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Tipo de transacao
        /// </summary>
        public TransactionTypeEnum TransactionType { get; set; }

        /// <summary>
        /// Valor de movimento
        /// </summary>
        public decimal Value { get; set; }
    }
}
