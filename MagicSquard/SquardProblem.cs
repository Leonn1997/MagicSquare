using System;
using System.Linq;

namespace MagicSquard
{
    public class SquardProblem
    {

        private readonly Environment<int> environment;

        public SquardProblem()
        {
            this.environment = new Environment<int>(MakeAdam(),Fitness,Radiation);
        }

        public Dude<int> BestDude()
        {
            return environment.Life();
        }

        public Environment<int> Envo => environment;


        private Dude<int> MakeAdam()
        {
            int[] dna = new[] {1,2,3,4,5,6,7,8,9};
            var gens = new GenString<int> { Genes = dna };
            return new Dude<int>(gens);
        }

        public int Fitness(Dude<int> dude)
        {
            var dna = group(dude.HisGenes);

            var diff1 = DifferenzToOptimum(dna[0].Sum());
            var diff2 = DifferenzToOptimum(dna[1].Sum());
            var diff3 = DifferenzToOptimum(dna[2].Sum());

            return (int) (diff1 + diff2 + diff3);
        }

        public int DifferenzToOptimum(int sum)
        {
            return (int) Math.Pow(sum - 15, 2);    
        }

        public GenString<int> Radiation(GenString<int> block)
        {

            var results = group(block).OrderBy(b => DifferenzToOptimum(b.Sum()));
            var badGuys = results.Reverse().ToArray();

            var firstDnaPart = badGuys[0];
            var secoundDnaPart = badGuys[1];
            var thirdDnaPart = badGuys[2];

            var rand = new Random();
            var extremlyunCommon = rand.Next(100);
            if (extremlyunCommon % 3 == 0)
            {
                var swapIndex = new Random().Next(firstDnaPart.Length);
                var temp = thirdDnaPart[swapIndex];
                thirdDnaPart[swapIndex] = secoundDnaPart[swapIndex];
                secoundDnaPart[swapIndex] = temp;
            }
            else
            {


                var swapTwoPropability = rand.Next(100);
            if (swapTwoPropability % 2 == 0)
            {
                var swapIndex = new Random().Next(firstDnaPart.Length);
                var temp = firstDnaPart[swapIndex];
                firstDnaPart[swapIndex] = secoundDnaPart[swapIndex];
                secoundDnaPart[swapIndex] = temp;
            }
            else
            {
                var swapIndex = new Random().Next(firstDnaPart.Length);
                var secoundSwapIndex = new Random().Next(firstDnaPart.Length);
                var temp = firstDnaPart[swapIndex];
                var secoundTemp = firstDnaPart[secoundSwapIndex];
                firstDnaPart[swapIndex] = secoundDnaPart[swapIndex];
                firstDnaPart[secoundSwapIndex] = secoundDnaPart[secoundSwapIndex];
                secoundDnaPart[secoundSwapIndex] = secoundTemp;
                secoundDnaPart[swapIndex] = temp;
            }
        }



        var mutatetDna = new int[block.Genes.Length];
            mutatetDna[0] = firstDnaPart[0];
            mutatetDna[1] = firstDnaPart[1];
            mutatetDna[2] = firstDnaPart[2];
            mutatetDna[3] = secoundDnaPart[0];
            mutatetDna[4] = secoundDnaPart[1];
            mutatetDna[5] = secoundDnaPart[2];
            mutatetDna[6] = thirdDnaPart[0];
            mutatetDna[7] = thirdDnaPart[1];
            mutatetDna[8] = thirdDnaPart[2];

            return new GenString<int> {Genes = mutatetDna};
        }

        private int[][] group(GenString<int> block)
        {
            const int size = 3;
            var results = block.Genes.Select((x, i) => new { Key = i / size, Value = x })
                .GroupBy(x => x.Key, x => x.Value, (k, g) => g.ToArray())
                .ToArray();
            return results;
        }
    }
}