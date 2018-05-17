using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MetaHeuristic {
	public float mutationProbability;
	public float crossoverProbability;
	public int tournamentSize;
	public bool elitist;

    protected SelectionMethod 

    void Start()
    {
        generation = 0;

            selection = new TournamentSelection(2);
       
    }

	public override void InitPopulation () {
		population = new List<Individual> ();

		// jncor 
		while (population.Count < populationSize) {
            GeneticIndividual new_ind= new GeneticIndividual (topology);
			new_ind.Initialize ();
			population.Add (new_ind);
		}

	}

	//The Step function assumes that the fitness values of all the individuals in the population have been calculated.
	public override void Step() {
		//You should implement the code runs in each generation here
		List<Individual> new_pop = new List<Individual> ();
        List<Individual> temp_pop = new List<Individual>();

		updateReport (); //called to get some stats
		// fills the rest with mutations of the best !

		for (int i = 0; i < populationSize ; i++) {

            temp_pop = selection.tournamente 

            Debug.Log("2");

            Individual ind1 = temp_pop[0];
            Individual ind2 = temp_pop[1];

            ind1.Crossover(ind2, crossoverProbability);

            ind1.Mutate (mutationProbability);

            new_pop.Add(ind1);
			
		}

		population = new_pop;

		generation++;
	}

}
