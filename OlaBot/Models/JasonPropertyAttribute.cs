using System;

namespace OlaBot.Models
{
    internal class JasonPropertyAttribute : Attribute
    {
        private string v;

        public JasonPropertyAttribute(string v)
        {
            this.v = v;
        }
    }
}