using System.Collections;
using UnityEngine;

public class CastSpell : MonoBehaviour
{

    public GameObject spell;
    //public AudioSource spellAudioSource;
    public Animator animator;
    [SerializeField] AudioSource spellCastAudioSource;
    private AudioSource spellAudioSource;

    IEnumerator InstantiateSpell()
    {
        animator.SetTrigger("Spell");
        yield return new WaitForSeconds(1.7f); //attendre le pas
        Instantiate(spell, transform);
        //spellAudioSource.Play();



    }

    // Start is called before the first frame update
    void Start()
    {
        spellAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //void Update()
    //{
        //Instantiate(spell, transform);


   // }

}