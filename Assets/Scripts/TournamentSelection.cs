using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TournamentSelection : SelectionMethod
{
    private int tournamentS;
    private Individual bestOfTournament;

    public TournamentSelection(int tournamentSize) : base()
    {   //n de torneios = variavel a definir no programa
        tournamentS = tournamentSize;
    }


    public override List<Individual> selectIndividuals(List<Individual> oldpop, int num) //lista de individuos 'vencedores' dos torneios
    {
        List<Individual> selectedIndsByTournaments = new List<Individual>();

        for (int i = 0; i < num; i++)
        {   //Para cada torneio:
            selectedIndsByTournaments.Add(tournamentSelection(oldpop, tournamentS).Clone());    //adiciona à lista o individuo 'vencedor' desse torneio
        }

        return selectedIndsByTournaments;
    }


    Individual tournamentSelection(List<Individual> oldpop, int tournamentS)
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

        //Ver o melhor, consoante o fitness
        for (int b = 0; b < selectedIndsForTournament.Count; b++)
        {
            if (b == 0)
            {
                bestOfTournament = selectedIndsForTournament[b];
            }
            else
            {
                if (selectedIndsForTournament[b].Fitness > bestOfTournament.Fitness)
                {
                    bestOfTournament = selectedIndsForTournament[b];
                }
            }
        }

        return bestOfTournament;
    }

}
