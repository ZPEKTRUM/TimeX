using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RopeGenerator : MonoBehaviour
{
    
    [SerializeField] Rigidbody2D _anchor;
    [SerializeField] Transform _candy;
    [SerializeField] GameObject _prefab;
    [SerializeField] int _count;

    [SerializeField] List<GameObject> _rope;

    public List<GameObject> Rope { get => _rope; }
    public Rigidbody2D Anchor { get => _anchor; }
    public Transform Candy { get => _candy; }

    private void Start()
    {
        // Représente une portion de la corde
        float jump = 1f / ((float)_count + 1);

        // On génère autant de corde que demandé
        for (int i = 0; i < _count; i++)
        {
            // On calcule la position de notre maillon en faisant "i+1 sauts"
            var pos = Vector3.Lerp(transform.position, _candy.position, jump * (i + 1));
            // Création de la corde avec la position calculée
            var go = Instantiate(_prefab, pos, Quaternion.identity, transform);
            _rope.Add(go);
        }

        // On gère ensuite la connexion entre chaque maillon

        // First rope connected to anchor
        _rope[0].GetComponent<HingeJoint2D>().connectedBody = _anchor;
        // list connection
        for (int i = 1; i < _rope.Count; i++)
        {
            var hinge = _rope[i].GetComponent<HingeJoint2D>();
            hinge.connectedBody = _rope[i - 1].GetComponent<Rigidbody2D>();
        }
        // Candy connected to the last link 
        var candyHinge = _candy.AddComponent<HingeJoint2D>().connectedBody = _rope[_rope.Count - 1].GetComponent<Rigidbody2D>();

    }


}