using UnityEngine;

public class PacMan : MonoBehaviour
{
    public int points = 0;

    // OnTriggerEnter2D is called when this collider enters the trigger collider of another collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Si l'autre collider est une pilule, on augmente le score du joueur de 10 points et on désactive la pilule
        if (other.gameObject.tag == "Pills")
        {
            points += 10;
            other.gameObject.SetActive(false);
        }
        // Si l'autre collider est une super pilule, on augmente le score du joueur de 50 points et on désactive la super pilule
        else if (other.gameObject.tag == "PowerPill")
        {
            points += 50;
            other.gameObject.SetActive(false);

            // On peut aussi utiliser une boucle for pour itérer sur tous les fantômes et les rendre bleus pendant une certaine durée
            foreach (GameObject ghost in GameObject.FindGameObjectsWithTag("Ghost"))
            {
                ghost.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
    }
}