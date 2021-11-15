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

        [DllImport("__Internal")]
        private static extern void initializePaywall(string str);

        [DllImport("__Internal")]
        private static extern void loadCheckoutModal(string str);

        private void Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            initializePaywall(paywallConfig.GetSerialized());
#endif
        }

        public void LoadCheckoutModal( LockConfig lockConfig )
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            loadCheckoutModal(lockConfig.GetSerialized());
#endif
        }

        public void UpdateStatus( string status )
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            switch (status)
            {
                case "locked":
                    stateLocked.Invoke();
                    break;
                case "unlocked":
                    stateUnlocked.Invoke();
                    break;
            }
#endif
        }

        public void UpdateAddress( string address )
        {
            
        }
        public void UpdateHash( string hash )
        {
            
        }

    }
}