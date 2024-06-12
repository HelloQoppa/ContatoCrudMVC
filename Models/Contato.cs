using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetomvc.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}