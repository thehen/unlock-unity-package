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
        private static extern void InitializePaywallJs(string str);

        [DllImport("__Internal")]
        private static extern void LoadCheckoutModalJs(string str);

        private void Start()
        {
            InitializePaywallJs(paywallConfig.GetSerialized());
        }

        public void LoadCheckoutModal( LockConfig lockConfig )
        {
            LoadCheckoutModalJs(lockConfig.GetSerialized());
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