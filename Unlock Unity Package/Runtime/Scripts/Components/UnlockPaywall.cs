using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace HenryHoffman.UnlockProtocol.Paywall
{
    /// <summary>
    /// The manager component for a paywall unlock integration. This component should be present at all times in a Unity scene when interacting with Unlock Protocol using a paywall.
    /// </summary>
    public class UnlockPaywall : MonoBehaviour
    {
        /// <summary>
        /// The paywall configuration scriptable object. 
        /// </summary>
        public PaywallConfig paywallConfig;

        /// <summary>
        /// Event is triggered when the paywall is unlocked
        /// </summary>
        public UnityEvent stateUnlocked;

        /// <summary>
        /// Event is triggered when the paywall is locked
        /// </summary>
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

        /// <summary>
        /// Show the paywall to allow user to purchase a key.
        /// </summary>
        /// <param name="lockConfig"></param>
        public void LoadCheckoutModal( LockConfig lockConfig )
        {
            paywallConfig.config.locks = lockConfig.GetDictionary();
            LoadCheckoutModalJs(paywallConfig.GetSerialized());
        }

        private void UpdateStatus( string status )
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
    }
}