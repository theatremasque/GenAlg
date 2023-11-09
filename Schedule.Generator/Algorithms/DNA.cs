namespace Schedule.Generator.Algorithms;

public class DNA<T>
{
    public T[] Genes { get; set; }
    public float Fitness { get; set; }
    private readonly Random _random;
    public readonly Func<T> _getRandomGene;
    public readonly Func<float, int> _fitnessFunction;

    public DNA(int size, Random random, Func<T> getRandomGene, Func<float, int> fitnessFunction, bool shouldInitGenes = true)
    {
        Genes = new T[size];
        _random = random;
        _getRandomGene = getRandomGene;
        _fitnessFunction = fitnessFunction;

        if (shouldInitGenes)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = _getRandomGene();
            } 
        }

        
    }

    public float CalculateFitness(int index)
    {
        Fitness = _fitnessFunction(index);
        return Fitness;
    }

    public DNA<T> Crossover(DNA<T> otherParent)
    {
        DNA<T> child = new DNA<T>(Genes.Length, _random, _getRandomGene, _fitnessFunction,false);

        for (int i = 0; i < Genes.Length; i++)
        {
            child.Genes[i] = Random.Shared.NextDouble() < 0.5 ? Genes[i] : otherParent.Genes[i];
        }

        return child;
    }

    public void Mutate(float mutationRate)
    {
        for (int i = 0; i < Genes.Length; i++)
        {
            if (Random.Shared.NextDouble() < mutationRate)
            {
                Genes[i] = _getRandomGene();
            }
        }
    }
}