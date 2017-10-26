using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MagicSquard
{
    public class Environment<T>
    {
        private List<Dude<T>> Dudes { get; set; }
        private readonly Func<Dude<T>, int> Fitness;
        private readonly Func<GenString<T>, GenString<T>> Radiation;

        public Environment(Dude<T> adam, Func<Dude<T>, int> Fitness, Func<GenString<T>, GenString<T>> Radiatio)
        {
            this.Dudes = new List<Dude<T>>();
            this.Fitness = Fitness;
            this.Radiation = Radiatio;

            Dudes.Add(adam);
        }

        public Dude<T> Life()
        {
            while (Fitness(Casanova()) > 0)
            {
                EveryoneWatchesPoorgle();
                BlackDeath();
                PrintCasanova();
                Console.WriteLine("Start next generation!");
           }

            return Casanova();
        }

        public void PrintCasanova()
        {
            var lookIntoDude = Casanova();
            var dna = lookIntoDude.HisGenes.Genes;
            var builder = new StringBuilder();
            for (int i = 0; i < dna.Length; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    builder.Append(Environment.NewLine);
                }

                builder.Append(dna[i]);
            }
            Console.WriteLine("-----Current Casnova-----");
            Console.WriteLine("Here is his DNA:");
            Console.WriteLine(builder.ToString());
            Console.WriteLine("----------------");
            Console.WriteLine("And he is as fit as a: " + Fitness(lookIntoDude));
        }

        private void BlackDeath()
        {
            var half = Dudes.Count / 2;
            var tobeKilled = Dudes.OrderBy(Fitness).TakeLast(half);
            foreach (var sick in tobeKilled)
            {
                Kill(sick);
            }

        }

        private void EveryoneWatchesPoorgle()
        {
            var amount = new Random().Next(2) + 1;
            for (int i = 0; i < amount; i++)
            {
                var babyDudes = new List<Dude<T>>();
                foreach(var dude in Dudes)
                {
                    babyDudes.Add(dude.Mutate(Radiation));   
                }
                Dudes.AddRange(babyDudes);
                babyDudes.Clear();
            }
            Debug.WriteLine(Dudes.Count);
        }

        private Dude<T> Casanova()
        {
            return Dudes.OrderBy(Fitness).First();
        }

        private void Kill(Dude<T> toBeKilled)
        {
            Dudes.Remove(toBeKilled);
        }

    }
}