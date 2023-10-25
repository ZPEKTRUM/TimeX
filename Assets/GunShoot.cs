using UnityEngine.EventSystems;
using UnityEngine;

public class GunShoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update

    public Transform firepoint;
    public GameObject bulletPrefab;

    private bool isShooting;

    public void OnDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException(); // Pas n�cessaire d'impl�menter cette m�thode pour un jeu 2D
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isShooting = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletPrefab != null && isShooting)
        {
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
    }

}