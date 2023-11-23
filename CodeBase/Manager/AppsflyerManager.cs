using UnityEngine;
using AppsFlyerSDK;

namespace CodeBase.Manager
{
    public class AppsflyerManager : MonoBehaviour
    {
        void Start()
        {
            AppsFlyer.initSDK("ytPuQc6oHMvGHLh83FVpdd", "AppsFlyerTrackerCallbacks");
        }
    }
}