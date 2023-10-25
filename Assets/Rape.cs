using UnityEngine;

public class Rape : MonoBehaviour
{
    public Rigidbody2D hook;

    public GameObject linkPrefab;

    public int links = 7;

    // Start is called before the first frame update
    void Start() { GenerateRope(); }



    void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        {

            GameObject link = Instantiate(linkPrefab, transform);

            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();

            joint.connectedBody = previousRB;

            previousRB = link.GetComponent<Rigidbody2D>();
        }
    }

}

