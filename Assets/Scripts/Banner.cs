using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class Banner : MonoBehaviour
{
    // Start is called before the first frame update
    private BannerView bannerView;
    public bool location;

    public void Start()
    {
        // adds test id 
        string appIdTest = "ca-app-pub-3940256099942544~3347511713";

        #if UNITY_ANDROID
            string appId = "ca-app-pub-9317663396480628~7197711083";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-9317663396480628~2527020092";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

    }

    public void RequestBanner()
    {
        // test id
        string adUnitIdTest = "ca-app-pub-3940256099942544/6300978111";

        if(location) {
            #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-9317663396480628/6242903826";
            #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-9317663396480628/1565292212";
            #else
                string adUnitId = "unexpected_platform";
            #endif
        
            // Create a 320x50 banner at the top of the screen.
            bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        } else {
            #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-9317663396480628/8083309545";
            #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-9317663396480628/2495230509";
            #else
                string adUnitId = "unexpected_platform";
            #endif
        
            // Create a 320x50 banner at the top of the screen.
            bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        }
        

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy() {
        if(bannerView != null) bannerView.Destroy();
    }

}
