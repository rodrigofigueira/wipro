using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class DadosCotacao
    {
        public string IdMoeda { set; get; }
        public int CodCotacao { set; get; } 
        public DateTime DataReferencia { set; get; }
        public decimal VlrCotacao { set; get; }
    }
}
