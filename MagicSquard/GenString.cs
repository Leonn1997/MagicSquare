using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagicSquard
{
    public class GenString<T> 
    {
        public GenString()
        {
            this.Genes = new T[0];
        }

        public T[] Genes { get; set; }

    }
}