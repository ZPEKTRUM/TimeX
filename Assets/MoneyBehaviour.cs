using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Events;

public class MoneyBehaviour : MonoBehaviour
{
    [SerializeField] UnityEvent _onPick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On cherche à savoir si la collision que l'on vient de detecter est le joueur
        if (collision.attachedRigidbody.gameObject.CompareTag("Player"))
        {
            // On sait que c'est le joueur => On enclenche l'évènement afin que le GD puisse mettre toutes les modifs qui l'intéresse (desactiver un objet, lancer une particule, un son etc.)
            _onPick.Invoke();

            // On ajoute du score au niveau
            // On choppe le singleton proposé par le ScoreManager et on lui ajoute du score
            ScoreManager.Instance.AddScore(10);

            // ##### VERSION ALTERNATIVES #####

            // On peut aussi essayer de chopper le gameobject qui s'appelle précisement "ScoreManager" et lui prendre
            // son composant ScoreManager. MAIS si le GD change le nom du gameobject ça ne marche plus.
            //GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore(10);


            // On peut aussi demander à Unity de parcourir la scene de jeu à la recherche du composant ScoreManager
            // MAIS ça necessite de parcourir la scene de bout en bout à la recherche du composant, c'est pas le 
            // plus efficace.
            //GameObject.FindObjectOfType<ScoreManager>().AddScore(10);
        }



    }

}