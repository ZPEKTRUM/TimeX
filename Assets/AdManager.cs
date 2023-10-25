using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    // Preparation du système de pub
    [SerializeField] string _androidGameId = "5431274";
    //[SerializeField] string _iOSGameId = "5431275";
    [SerializeField] bool _testMode = true;
    string _gameId;

    // Preparation de la pub que l'on veut lancer
    [SerializeField] string _placementAndroid = "Rewarded_Android";
    //[SerializeField] string _placementiOS = "Rewarded_iOS";
    string _placementID;

    [SerializeField] UnityEvent _onAdReady;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
#if UNITY_IOS
        _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
#if UNITY_IOS
        //_placementID = _placementiOS;
#elif UNITY_ANDROID
        _placementID = _placementAndroid;
#elif UNITY_EDITOR
        _placementID = _androidPlacementID; //Only for testing the functionality in the Editor
#endif

        Advertisement.Load(_placementID, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Unity Ads initialization failed.");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Success");
        _onAdReady.Invoke();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log(message);
    }

    public void LaunchAd()
    {
        Advertisement.Show(_placementID, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Lancement de la pub");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Trop cool le joueur a cliqué");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("FINIIII :D");
    }
}