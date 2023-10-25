using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create a new GameObject.
        GameObject projectile = new GameObject();

        // Assign the CanonFire script to the GameObject.
        projectile.AddComponent<CanonFire>();

        // Modify the values of the public variables.
        projectile.GetComponent<CanonFire>().speed = 100;

        // Create a new target GameObject.
        GameObject target = new GameObject();
        target.transform.position = new Vector3(0, 0, 0);

        // Assign the target to the projectile.
        projectile.GetComponent<CanonFire>().target = target.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
