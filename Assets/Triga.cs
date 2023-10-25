using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triga : MonoBehaviour
{

    public float score;
    public float pointsPerCollectable = 25;
    private object other;
    private float scoreValue;

  

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {

        score += pointsPerCollectable;
        Destroy(other.gameObject);
    }
}
