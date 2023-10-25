using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{

    [SerializeField] RopeGenerator _ropeGenerator;
    [SerializeField] LineRenderer _lineRenderer;

    private void Update()
    {
        // On doit prévoir le nombre d'elements qu'il y aura dans le line renderer.
        // On veut le nombre de maillon + 1 pour l'ancre +1 pour le bonbon
        _lineRenderer.positionCount = _ropeGenerator.Rope.Count + 2;

        // On set manuellement l'ancre
        _lineRenderer.SetPosition(0, _ropeGenerator.Anchor.transform.position);

        // On parcoure la liste de maillon du rope generator et on fourni au line renderer la position de chaque maillon
        for (int i = 0; i < _ropeGenerator.Rope.Count; i++)
        {
            if (_ropeGenerator.Rope[i] == null)
            {
                _lineRenderer.positionCount = i + 1;
                return;
            }
            
            _lineRenderer.SetPosition(i + 1, _ropeGenerator.Rope[i].transform.position);
        }

        // On set manuellement le bonbon 
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _ropeGenerator.Candy.transform.position);

    }

}