using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionPersonnage : MonoBehaviour
{
    [SerializeField] private float vitesseMarche = 5f;
    [SerializeField] private float vitesseCourse = 10f;


    private float vitesseDeplacment;

    private Rigidbody2D rb2Dperso;
    private Collider2D colliderPerso;
    private float vitesseDeplacement;
    private Animator animatorPerso;

    private Vector2 valeurDDeplacement; // valeurs coordonnées x et y input system
    private Rigidbody2D rb2Perso;

    // Start is called before the first frame update
    void Start()
    {

        rb2Perso = GetComponent<Rigidbody2D>();
        animatorPerso = GetComponent<Animator>();
        colliderPerso = GetComponent<Collider2D>();

        vitesseDeplacement = vitesseMarche;


    }

    // Update is called once per frame
    private void FixeUpdate() //physique
    {
        Deplacement();

    }

    void Deplacement()

    {


        if (valeurDDeplacement.x != 0 || valeurDDeplacement.y != 0)
        {


            animatorPerso.SetFloat("mouvementHorizontal", valeurDDeplacement.x);
            animatorPerso.SetFloat("mouvementVetical", valeurDDeplacement.y);

            animatorPerso.SetBool("marche", true);
        }
        else
        {

            animatorPerso.SetBool("marche", false);

        }

        rb2Dperso.velocity = vitesseDeplacment * valeurDDeplacement;
    }


    //------------------------------------------------------------------------

    public void EcouteurMouvement(InputAction.CallbackContext Context)

    { valeurDDeplacement = Context.ReadValue<Vector2>();

    }

    //------------------------------------------------------------------------

    public void EcouteurCourse(InputAction.CallbackContext Context)


    {

        if (Context.performed)

        {

            vitesseDeplacment = vitesseCourse;
            animatorPerso.SetBool("course", true);
        }

     

            if (Context.canceled)
            {

                vitesseDeplacment = vitesseMarche;
                animatorPerso.SetBool("course", false);

            }

        }
        // ------------------------------------------------------------

        public void EcouteurSaut(InputAction.CallbackContext Context)

        {
            if (Context.started)

            {


                animatorPerso.SetTrigger("saut");
            }
        }

    //---------------------------------------------------------------

        public void EcouteurAttack(InputAction.CallbackContext Context)

        {
            if (Context.started)

            {


                animatorPerso.SetTrigger("Fire");


            }

        }


    }





