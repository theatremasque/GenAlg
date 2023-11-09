namespace Schedule.Generator.Algorithms;

public class GeneticAlgorithm<T>
{
    public List<DNA<T>> Population { get; set; }
    public int Generation { get; set; }
    public float MutationRate { get; set; }
    
    private Random _random;

    private float _fitnessSum;

    public float DestFitness { get; set; }
    
    public T[] BestGenes { get; set; }

    public GeneticAlgorithm(int populationSize, int dnaSize, Random random, Func<T> getRandomGene, Func<float, int> fitnessFunction, float mutationRate = 0.01f)
    {
        Generation = 1;
        MutationRate = mutationRate;
        Population = new List<DNA<T>>();
        _random = random;

        for (int i = 0; i < populationSize; i++)
        {
            Population.Add(new DNA<T>(dnaSize, random, getRandomGene, fitnessFunction, true));
        }
        
    }

    public void NewGeneration()
    {
        if (Population.Count <= 0)
        {
            return;
        }

        CalculateFitness();

        List<DNA<T>> newPopulation = new List<DNA<T>>();

        for (int i = 0; i < Population.Count; i++)
        {
            DNA<T> parent1 = ChooseParent();
            DNA<T> parent2 = ChooseParent();

            DNA<T> child = parent1.Crossover(parent1);
            
            child.Mutate(MutationRate);
            
            newPopulation.Add(child);
        }

        Population = newPopulation;

        Generation++;
    }

    private void CalculateFitness()
    {
        DNA<T> best = Population[0];
        
        _fitnessSum = 0;
        for (int i = 0; i < Population.Count; i++)
        {
            _fitnessSum += Population[i].CalculateFitness(i);
            
            if (Population[i].Fitness > best.Fitness)
            {
                best = Population[i];
            }
        }

        DestFitness = best.Fitness;
        best.Genes.CopyTo(BestGenes, 0);
    }

    private DNA<T> ChooseParent()
    {
        double randomNumber = Random.Shared.NextDouble() * _fitnessSum;

        for (int i = 0; i < Population.Count; i++)
        {
            if (randomNumber < Population[i].Fitness)
            {
                return Population[i];
            }

            randomNumber = Population[i].Fitness;
        }

        return null;
    }
}