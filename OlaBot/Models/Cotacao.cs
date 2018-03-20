using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlaBot.Models
{
    public class Resultado
    {

        public Cotacao[] Cotacoes { get; set; }
    }

    public class Cotacao
    {
        [JasonProperty("nome")]
        public string Nome { get; set; }

        [JasonProperty("sigla")]
        public string Sigla { get; set; }

        [JasonProperty("valor")]
        public float Valor { get; set; }

    }

}