using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class AfficheDesComptes : MonoBehaviour
{

    [SerializeField]

    private InfosNiveau InfosNiveau;


    [SerializeField]

    private TMP_Text champTexteTemps; // Variable du type champs texte + texte pour le temps

    public void AfficheTemps() // Une fonction public pour afficjher le temps

    {

        float temps = InfosNiveau.temps; // Le temps est à zéro 

        if (temps < 0)

        {

            temps = 0;

        }

        TimeSpan ts = TimeSpan.FromSeconds(temps);


        champTexteTemps.text = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds); // les : sépare les élements de temps

        //ToString chnager le charactère en chiffre La classe TimeSpan permet plusieurs manipulation du temps
        // A partir d'une date, d' une heure, de minutesbou de secondes et plus, Time>Span nous permet de convertir des données.
        //Exemple 2632 secondes → savoir que  il y' a 43 heures et 52 secondes pratique pour l' affichage d' un compte. NameSpace
        // L' espace d'un nom using System, 

        // La Méthode string.Format() nous permet de formater une chaîne de caractères
        //Exemple Debug.Log(string.Format("Il y'a   {0} secondes!", 4) ); La console affichera Il y' 4 secondes! 

        //Affichage plus complexe minutes:secondes:millisecondes ("{0:00} : {1:00} : {2:000}" 3,24,16); → 03:24:016






    }

}
