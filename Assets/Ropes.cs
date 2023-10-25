using UnityEngine;

public class Ropes : MonoBehaviour
{



    public Rigidbody2D hook;

    public GameObject linkPrefab;

    public Weights weigth;

    public int links = 7;

    // Use this for initialization
    void Start()
    {
        // Check if hook is null.
        if (hook == null)
        {
            // Throw an exception if hook is null.
            throw new UnityException("The hook variable is null.");
        }

        // Generate the ropes.
        GenerateRopes();
    }

    public void GenerateRopes()
    {

        Rigidbody2D previousRB = hook; // 1er connection au hook 

        for (int i = 0; i < links; i++)
        {
            // Check if linkPrefab is null.
            if (linkPrefab == null)
            {
                // Throw an exception if linkPrefab is null.
                throw new UnityException("The linkPrefab variable is null.");
            }

            // Instantiate a new link object.
            GameObject link = Instantiate(linkPrefab, transform);

            // Get the HingeJoint2D component of the link object.
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();

            // Set the connectedBody of the HingeJoint2D component to the previous rigidbody.
            joint.connectedBody = previousRB;

            // If this is not the last link, then set the previous rigidbody to the rigidbody of the current link.
            if (i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                // If this is the last link, then connect the end of the rope to the weight.
                weigth.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
        }
    }
}