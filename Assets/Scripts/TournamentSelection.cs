using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TournamentSelection : SelectionMethod
{
    private int tournamentSize;
    private Individual bestOfTournament;

    public TournamentSelection(int tournamentS)
    {   //n de torneios = variavel a definir no programa
        tournamentSize = tournamentS;
    }


    public override List<Individual> selectIndividuals(List<Individual> oldpop, int num) //lista de individuos 'vencedores' dos torneios
    {
        List<Individual> selectedIndsByTournaments = new List<Individual>();

        for (int i = 0; i < num; i++)
        {   //Para cada torneio:
            selectedIndsByTournaments.Add(tournamentSelection(oldpop, tournamentSize).Clone());    //adiciona à lista o individuo 'vencedor' desse torneio
        }

        return selectedIndsByTournaments;
    }


    public Individual tournamentSelection(List<Individual> oldpop, int tournamentS)
    { //TORNEIO, DEVOLVE O MELHOR

        List<Individual> selectedIndsForTournament = new List<Individual>(); //lista de individuos selecionados para o torneio
        int popsize = oldpop.Count;
        for (int i = 0; i < tournamentS; i++)
        {   //para cada individuo:
            //make sure selected individuals are different
            Individual ind = oldpop[Random.Range(0, popsize)];  //seleciona um individuo Random
            while (selectedIndsForTournament.Contains(ind))
            {       //caso já tenha sido selecionado:
                ind = oldpop[Random.Range(0, popsize)];         //seleciona outro
            }
            selectedIndsForTournament.Add(ind); //adiciona um clone desse individuo à lista
                                                //we return copies of the selected individuals
        }
        bestOfTournament = selectedIndsForTournament[0];
        //Ver o melhor, consoante o fitness
        for (int i = 1; i < selectedIndsForTournament.Count; i++)
        {
           
            if (selectedIndsForTournament[i].Fitness > bestOfTournament.Fitness)
            {
                bestOfTournament = selectedIndsForTournament[i];
            }
        }

        return bestOfTournament.Clone();
    }

    public Individual GenerationBest(Individual[] tournamentSize)
    {
        float max = float.MinValue;
        Individual max_ind = null;
        foreach (Individual indiv in tournamentSize)
        {
            if (indiv.Fitness > max)
            {
                max = indiv.Fitness;
                max_ind = indiv;
            }
        }
        return max_ind;

    }

}
