using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class Cutscene_controller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        // Do nothing
    }

    // On pointer down, play the cutscene
    public void OnPointerDown(PointerEventData eventData)
    {
        if (director.state != PlayState.Playing)
        {
            director.Play();
        }
    }

    // On pointer up, stop the cutscene
    public void OnPointerUp(PointerEventData eventData)
    {
        director.Stop();
    }
}