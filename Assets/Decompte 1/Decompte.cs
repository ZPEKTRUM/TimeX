using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Decompte : MonoBehaviour
{
    [SerializeField]
    private InfosNiveau _infosniveau;

    private bool decompteActif = false; //booléen actif ou pas 0 ou 1 

    public UnityEvent auChangementDuTemps;// Event public accessibles/ L' évènement est appellé à chaque changement de temps
    public UnityEvent aLaFinDuTemps;

    // Start is called before the first frame update
    void Start()
    {
        // _infosniveau = GetComponent<InfosNiveau>();

        DemmarrerDecompte(); // temps initialiser public void + compte actif agrée → Update to chrono decompte → Unity ScriptableObject
    }

    // Update is called once per frame // le décompte peut-il jouer?
    void Update() // défilement du décompte
    {
        if (decompteActif)

        {

            if (_infosniveau.temps > 0)  // ↑ plus grande que 0 passer par la variable temps du scriptableObject + Avoir un évènement

            {
                _infosniveau.temps -= Time.deltaTime; // Calcule - du nombre de temps entre deux images frames fractions de secondes

                auChangementDuTemps.Invoke(); // Déclenchement de l' event 

            } //début de création du décompte syncrhonisation avec le temps du jeu dimminution du temps

            else

            { // si temps plus petit que 0

                _infosniveau.temps = 0; // Confirmer que le temps et bien égal à 0

                decompteActif = false; // le décompte Actif est égal à False

                aLaFinDuTemps.Invoke();

            }

        }
    }

    // saut 3} déclaration du méthode public pour attribuer le défilment du temps et sa réinitialisation

    public void DemmarrerDecompte()

    {

        _infosniveau.temps = _infosniveau.tempsInitial; // Boucle
        decompteActif = true; // CountDown démmarrage


    }

}