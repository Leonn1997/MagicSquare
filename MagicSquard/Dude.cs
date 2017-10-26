using System;

namespace MagicSquard
{
    public class Dude<T>
    {
        public Dude(GenString<T> hisGenes)
        {
            HisGenes = hisGenes;
        }

        public Dude<T> Mutate(Func<GenString<T>, GenString<T>> mutationFunc)
        {
            return new Dude<T>(mutationFunc(HisGenes));
        }

        public GenString<T> HisGenes { get; set; }

    }
}