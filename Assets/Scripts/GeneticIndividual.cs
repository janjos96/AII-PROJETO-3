using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticIndividual : Individual {


	public GeneticIndividual(int[] topology) : base(topology) {
	}

	public override void Initialize () 
	{
		for (int i = 0; i < totalSize; i++) {
			genotype [i] = Random.Range (-1.0f, 1.0f);
		}
	}
		
	public override void Crossover (Individual partner, float probability) //recombinação
	{
		float r = Random.Range (0.0f, 1.0f);
		//float temp1;
		//bool temp2;
		if (r < probability) {
            int p1 = Random.Range (0, totalSize/2); //escolhe aleatoriamente o cromossoma inicial a ser alterado
            int p2 = Random.Range (p1+1, totalSize); //escolhe aleatoriamente o cromossoma final a ser alterado
			for (int i = p1; i < p2-p1; i++) {

                genotype[i] = partner.genotype[i];

			}
		}
	}

	public override void Mutate (float probability)
	{
		for (int i = 0; i < totalSize; i++) {
			if (Random.Range (0.0f, 1.0f) < probability) {
				genotype [i] = Random.Range (-1.0f, 1.0f);
			}
		}
	}

	public override Individual Clone ()
	{
		GeneticIndividual new_ind = new GeneticIndividual(this.topology);

		genotype.CopyTo (new_ind.genotype, 0);
		new_ind.fitness = this.Fitness;
		new_ind.evaluated = false;

		return new_ind;
	}

}
























                /*//CHROMOSOME 1 ----
                temp1 = horizontalMoves[i];
                horizontalMoves[i] = partner.horizontalMoves[i];
                partner.horizontalMoves[i] = temp1; //altera os cromossomas escolhidos de forma a = ao do outro pai

                //CHROMOSOME 2 ----
                temp2 = shots[i];
                shots[i] = partner.shots[i];
                partner.shots[i] = temp2;*/
