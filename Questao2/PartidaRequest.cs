using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    internal class PartidaRequest
    {
        public int? Year { get; set; }

        public string? Team1 { get; set; }

        public string? Team2 { get; set; }

        public int? Page { get; set; }
    }
}
