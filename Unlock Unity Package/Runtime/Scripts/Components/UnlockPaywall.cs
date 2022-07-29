using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace HenryHoffman.UnlockProtocol
{
    public class UnlockPaywall : MonoBehaviour
    {
        public PaywallConfig paywallConfig;
        public UnityEvent stateUnlocked;
        public UnityEvent stateLocked;

#if !UNITY_EDITOR && UNITY_WEBGL
        [DllImport("__Internal")]
        private static extern void InitializePaywallJs(string str);

        [DllImport("__Internal")]
        private static extern void LoadCheckoutModalJs(string str);
#else
        private static void InitializePaywallJs(string paywallConfig) { Errors.UnsupportedPlatformOrEditor(); }
        private static void LoadCheckoutModalJs(string lockConfig) { Errors.UnsupportedPlatformOrEditor(); }
#endif
        private void Start()
        {
            InitializePaywallJs(paywallConfig.GetSerialized());
        }

        public void LoadCheckoutModal( LockConfig lockConfig )
        {
            paywallConfig.config.locks = lockConfig.GetDictionary();
            LoadCheckoutModalJs(paywallConfig.GetSerialized());
        }

        public void UpdateStatus( string status )
        {
            switch (status)
            {
                case "locked":
                    stateLocked.Invoke();
                    break;
                case "unlocked":
                    stateUnlocked.Invoke();
                    break;
            }
        }

        public void UpdateAddress( string address )
        {
            
        }
        public void UpdateHash( string hash )
        {
            
        }

    }
}