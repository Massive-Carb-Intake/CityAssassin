//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class IronSourceScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IronSource.Agent.init("1aad0e0d5", IronSourceAdUnits.INTERSTITIAL);
        IronSource.Agent.init("1aad0e0d5", IronSourceAdUnits.REWARDED_VIDEO);
        IronSource.Agent.validateIntegration();
        Debug.Log("Started");
    }

    private void OnEnable()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
        IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
        IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;
        Debug.Log("Enabled");
    }
    

    void OnApplicationPause(bool isPaused)
    {
        IronSource.Agent.onApplicationPause(isPaused);
    }

    // Interstitial Buttons
    public void LoadInterstitialAd()
    {
        Debug.Log("Load Function Triggered");
        IronSource.Agent.loadInterstitial();
    }

    public void ShowInterstitialAd()
    {
        if (IronSource.Agent.isInterstitialReady())
        {
            IronSource.Agent.showInterstitial();
        }
        else
        {
            Debug.Log("AD NOT READY");
        }
    }
    
    
    private void SdkInitializationCompletedEvent(){}
    
    // Interstitial Callbacks
    /************* Interstitial AdInfo Delegates *************/
    
    
    // Invoked when the interstitial ad was loaded successfully.
    void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo) {
        Debug.Log("hi");
    }
    
    
    // Invoked when the initialization process has failed.
    void InterstitialOnAdLoadFailed(IronSourceError ironSourceError)
    {
        Debug.Log("ad load failed");
    }
    
    
    // Invoked when the Interstitial Ad Unit has opened. This is the impression indication. 
    void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo) {
    }
    
    
    // Invoked when end user clicked on the interstitial ad
    void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo) {
    }
    
    
    // Invoked when the ad failed to show.
    void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo) {
        Debug.Log("ad show failed");
    }
    
    
    // Invoked when the interstitial ad closed and the user went back to the application screen.
    void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo) {
    }
    
    
    // Invoked before the interstitial ad was opened, and before the InterstitialOnAdOpenedEvent is reported.
    // This callback is not supported by all networks, and we recommend using it only if  
    // it's supported by all networks you included in your build. 
    void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo) {
    }


    // Rewarded Callbacks
    
    
    
}
