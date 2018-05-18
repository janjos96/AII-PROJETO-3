using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MetaHeuristic
{
    public float mutationProbability;
    public float crossoverProbability;
    public int tournamentSize;
    public bool elitist;

    private Individual bestIndividual;

    public override void InitPopulation()
    {
        population = new List<Individual>();

        selection = new TournamentSelection(tournamentSize);
        // jncor 
        while (population.Count < populationSize)
        {
            GeneticIndividual new_ind = new GeneticIndividual(topology);
            new_ind.Initialize();
            population.Add(new_ind);
        }

    }

    //The Step function assumes that the fitness values of all the individuals in the population have been calculated.
    public override void Step()
    {
        //You should implement the code runs in each generation here
        List<Individual> new_pop = new List<Individual>();
        List<Individual> parents = new List<Individual>();

        updateReport(); //called to get some stats
                        // fills the rest with mutations of the best !

        //elitismo
      

        parents = selection.selectIndividuals(population, populationSize * 2);

        //crossover -> atenção a população ímpar!
        int j = 0;
        for (int i = 0; i < populationSize * 2; i += 2)
        {
            parents[i].Crossover(parents[i + 1], crossoverProbability);
            new_pop.Add(parents[j]);
            j++;
            //newPopulation [i].Crossover (newPopulation [i + 1], crossoverProbability);
        }

        //mutation
        for (int i = 0; i < populationSize; i++)
        {
            new_pop[i].Mutate(mutationProbability);
        }

        //população passa a ter os descendentes
        population = new_pop;

        //troca a primeira posição da nova população pelo melhor individuo da geração anterior
        if (elitist)
        {
            population[0] = GenerationBest.Clone();
        }

        generation++;
    }

}

