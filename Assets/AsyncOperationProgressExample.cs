using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncOperationProgressExample : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

public GameObject loadingScreen;
    public Slider slider;
    public TMPro.TextMeshProUGUI m_Text;
    public Button m_Button;
    private object sceneMenu;
    private object operation;
    public TMPro.TextMeshProUGUI progressText;
    private int progress;
    private object SceneIndex;

    void Start()
    {
       
       
    }

   public void LoadLevel(int sceneIndex )
    {
        //Start loading the Scene asynchronously and output the progress bar
        StartCoroutine(LoadAsync(sceneIndex));
    }

    private IEnumerator LoadAsync(int sceneIndex)
    {
        //Start loading the Scene asynchronously
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneIndex);

        //Create an IEnumerator to track the progress of the load
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            //Yield to give the Unity engine a chance to do other work
            yield return null;
        }

        //The load is finished
        //return asyncOperation;
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneIndex);

        loadingScreen.SetActive(true);

        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {

            {

            }
            yield return null; 

            
            //Output the current progress
            m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
                slider.value = asyncOperation.progress;

            progressText.text = progress * 100 + "%";


            {
                //Change the Text to show the Scene is ready
                m_Text.text = "Press the space bar to continue";
                //Wait to you press the space key to activate the Scene
                    if (Input.GetMouseButtonDown(0) || ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) )
                        //Activate the Scene
                        asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
