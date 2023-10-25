using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GunScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GunState _state;
    // Variable int pour stocker la cadence de tir
    int _rateOfFire;
    private static bool gunscriptActif;
    private bool Gunscript;
    private int fire;


    public bool GunscriptActif { get; private set; }

    [SerializeField] AudioSource _audiosouce;

    [SerializeField]  GameObject _bulletPrefab;
    
    [SerializeField] UnityEvent _onFire;

    void Start()
    {
        DemmarrerGunscript();
        // Obtenir une instance du scriptable object
        // _stat = GetComponent<ScriptableGunStat>();

        // Initialiser la variable int � la cadence de tir par d�faut
        _rateOfFire = (int)_state.Rate;

        // Initialiser la variable Gunscript � false
        Gunscript = false;
        fire = GunState.fire;
    }

    void Update()
    {

        GunscriptActif = GunState.fire > 0;
        Gunscript = true;
    }

    private static void DemmarrerGunscript()

    {
        GunState.fire = GunState.fireInitial;
        gunscriptActif = true;
    }

    // Fonction pour augmenter la cadence de tir
    public void IncreaseRateOfFire()
    {
        // Obtenir la cadence de tir actuelle du scriptable object
        float rateOfFire = _state.Rate;

        // Augmenter la cadence de tir de 10
        rateOfFire += 10;

        // Assigner la nouvelle cadence de tir � la variable int
        _rateOfFire = (int)rateOfFire;
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        // On stop le tir
        GunState.fire = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // On va tirer � interval r�gulier � partir de l�
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            // attendre une seconde
            yield return new WaitForSeconds(1f / _rateOfFire);

            // tirer
            Shoot();
            //augmenter la cadence de tir
            if (GunscriptActif)
            {
                _rateOfFire += 1;
            }
        }
    }

    private void Shoot()
    {
        // TODO: Implement shooting logic here
        //Cr�ation du pr�fabriqu� de puce et son instanciation
        //var bulletPrefab = Resources.Load<GameObject>("BulletPrefab");
        //var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //lecture d�un effet sonore
        var audioSource = GetComponentInChildren<AudioSource>();

        //tant que le joueur a pas rel�ch� la touche de l' �cran la cadence de tir de l'audio augmente et tire en rafale jusqu'� la d�charge compl�te de munitions
        if (fire > 0)
        {
            fire -= 1;
        }
    }
}