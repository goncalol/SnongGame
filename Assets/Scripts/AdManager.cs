//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using GoogleMobileAds.Api;

//public class AdManager : MonoBehaviour {

//    //public static AdManager Instance { get; set; }

//    //   private void Start()
//    //   {
//    //       Instance = this;
//    //       DontDestroyOnLoad(gameObject);

//    //       Admob.Instance().initAdmob("ca-app-pub-3940256099942544/6300978111", "");//ca-app-pub-8455806674655279/1104310608", "ca-app-pub-8455806674655279/9985833050");
//    //       //Admob.Instance().setTesting(true);
//    //       //Admob.Instance().loadInterstitial();
//    //   }

//    //   public void ShowBanner()
//    //   {
//    //       Admob.Instance().showBannerRelative(AdSize.Banner,AdPosition.MIDDLE_CENTER,0);
//    //   }

//    BannerView bannerView;
//    string appId = "ca-app-pub-8455806674655279~6959272510";
//    string bannerId = "ca-app-pub-8455806674655279/1104310608";

//    private void Awake()
//    {
//        MobileAds.Initialize(appId);
//        bannerView = new BannerView(bannerId,AdSize.Banner,AdPosition.Bottom);

//        AdRequest request = new AdRequest.Builder().Build();
//        bannerView.LoadAd(request);
//    }
//}
