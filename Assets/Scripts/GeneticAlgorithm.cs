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

        updateReport(); //called to get some stats
                        // fills the rest with mutations of the best !

        //elitismo
        if (elitist)
        {
            //associa o melhor inidividuo
            bestIndividual = GenerationBest.Clone();
        }


        new_pop = selection.selectIndividuals(population, populationSize);

        //crossover -> atenção a população ímpar!
        for (int i = 0; i < populationSize; i += 2)
        {
            new_pop[i].Crossover(new_pop[i + 1], crossoverProbability);
            //newPopulation [i].Crossover (newPopulation [i + 1], crossoverProbability);
        }

        //mutation
        for (int i = 0; i < populationSize; i += 2)
        {
            new_pop[i].Mutate(mutationProbability);
        }

        //população passa a ter os descendentes
        population = new_pop;

        //troca a primeira posição da nova população pelo melhor individuo da geração anterior
        if (elitist)
        {
            population[0] = bestIndividual;
        }

        generation++;
    }

}

