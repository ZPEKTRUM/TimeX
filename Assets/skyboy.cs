using UnityEngine;

public class SkyboyText : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color[] colors = {
        Color.red, Color.green, Color.blue, Color.yellow, Color.magenta, Color.cyan
    };

    void Start()
    {
        // Initialiser le texte avec la première couleur
        spriteRenderer.color = colors[0];

        // Démarrer l'animation
        InvokeRepeating("ChangeColor", 0.2f, 0.2f);
    }

    void ChangeColor()
    {
        // Changer la couleur du texte
        spriteRenderer.color = colors[Random.Range(0, colors.Length)];
    }
}