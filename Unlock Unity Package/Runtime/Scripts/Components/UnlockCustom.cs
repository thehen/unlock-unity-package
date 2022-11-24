using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace HenryHoffman.UnlockProtocol.Custom
{
    /// <summary>
    /// The manager component for a custom unlock integration. This component should be present at all times in a Unity scene when interacting with Unlock Protocol for a custom integration (not using the paywall).
    /// </summary>
    public class UnlockCustom : MonoBehaviour
    {

        #region "Statics"
        /// <summary>
        /// Static class instance reference to easily reference from other scripts
        /// </summary>
        public static UnlockCustom Instance { get; private set; }
        #endregion

        #region "Properties"
        /// <summary>
        /// Gets the connected wallet address
        /// </summary>
        public string WalletAddress { get; private set; }
        #endregion

        #region "Public"
        /// <summary>
        /// The network configuration object
        /// </summary>
        public NetworkConfig networkConfig;
        #endregion

        #region "Unity Events"

        /// <summary>
        /// Event is triggered when the users wallet successfully connects to the application
        /// </summary>
        public UnityEvent<string> walletConnectedSuccess;

        /// <summary>
        /// Event is triggered when the users wallet fails to connect to the application
        /// </summary>
        public UnityEvent<string> walletConnectedFail;

        /// <summary>
        /// Event is triggered when the lock is successfully retrieved 
        /// </summary>
        public UnityEvent<Lock> getLockSuccess;

        /// <summary>
        /// Event is triggered when the lock fails to be retrieved 
        /// </summary>
        public UnityEvent<LockErrorParams> getLockFailed;

        /// <summary>
        /// Event is triggered when the lock is succesfully queried to determine if the user has a valid key 
        /// </summary>
        public UnityEvent<GetHasValidKeySuccessParams> getHasValidKey;

        /// <summary>
        /// Event is triggered when failing to query whether the user has a valid key
        /// </summary>
        public UnityEvent<LockErrorParams> getHasValidKeyFailed;

        /// <summary>
        /// Event is triggered when a key purchase is successful
        /// </summary>
        public UnityEvent<string> purchaseKeySuccess;

        /// <summary>
        /// Event is triggered when a key purchase fails
        /// </summary>
        public UnityEvent<LockErrorParams> purchaseKeyFailed;

        /// <summary>
        /// Event is triggered when the user wallat balance is successfully retrieved
        /// </summary>
        public UnityEvent<float> getBalanceSuccess;

        /// <summary>
        /// Event is triggered when the user wallat balance fails to be retrieved
        /// </summary>
        public UnityEvent<string> getBalanceFailed;

        /// <summary>
        /// Event is triggered when the user changes the network
        /// </summary>
        public UnityEvent<int> networkChanged;

        /// <summary>
        /// Event is triggered when the user network chain ID is retrieved
        /// </summary>
        public UnityEvent<int> getNetworkIdSuccess;

        /// <summary>
        /// Event is triggered when the user network chain ID fails to be retrieved
        /// </summary>
        public UnityEvent getNetworkIdFailed;

        /// <summary>
        /// Event is triggered when the user disconnects their wallet
        /// </summary>
        public UnityEvent disconnected;

        /// <summary>
        /// Event is triggered when the user changes their account
        /// </summary>
        public UnityEvent<List<string>> accountsChanged;

        #endregion

        #region "WebGL bridge"

#if !UNITY_EDITOR && UNITY_WEBGL
        [DllImport("__Internal")]
        private static extern string ConnectMetaMaskJs();

        [DllImport("__Internal")]
        private static extern void ConnectWalletConnectJs();

        [DllImport("__Internal")]
        private static extern void GetLockJs(string lockConfig);

        [DllImport("__Internal")]
        private static extern void InitializeJs(string networkConfig);

        [DllImport("__Internal")]
        private static extern void PurchaseKeyJs(string lockConfig);

        [DllImport("__Internal")]
        private static extern void GetHasValidKeyJs(string lockConfig);

        [DllImport("__Internal")]
        private static extern void GetBalanceJs(string adddress);

        [DllImport("__Internal")]
        private static extern void GetNetworkIdJs();
#else
        private static void ConnectMetaMaskJs() { Errors.UnsupportedPlatformOrEditor(); }
        private static void ConnectWalletConnectJs() { Errors.UnsupportedPlatformOrEditor(); }
        private static void GetLockJs(string lockConfig) { Errors.UnsupportedPlatformOrEditor(); }
        private static void InitializeJs(string networkConfig) { Errors.UnsupportedPlatformOrEditor(); }
        private static void PurchaseKeyJs(string lockConfig) { Errors.UnsupportedPlatformOrEditor(); }
        private static void GetHasValidKeyJs(string lockConfig) { Errors.UnsupportedPlatformOrEditor(); }
        private static void GetBalanceJs(string adddress) { Errors.UnsupportedPlatformOrEditor(); }
        private static void GetNetworkIdJs() { Errors.UnsupportedPlatformOrEditor(); }
#endif

        #endregion

        #region "Event parameters"

        /// <summary>
        /// Lock error parameters 
        /// </summary>
        public class LockErrorParams
        {
            /// <summary>
            /// The unique address of the lock
            /// </summary>
            public string lockAddress;
            /// <summary>
            /// Error from JavaScript frontend
            /// </summary>
            public string error;
        }

        /// <summary>
        /// <c>GetHasValidKeySuccess</c> parameters 
        /// </summary>
        public class GetHasValidKeySuccessParams
        {
            /// <summary>
            /// Whether the user already has a valid key to the lock
            /// </summary>
            public bool hasKey;
            /// <summary>
            /// The wallet address of the recipient of the key
            /// </summary>
            public string recipient;
            /// <summary>
            /// The unique lock address
            /// </summary>
            public string lockAddress;
            /// <summary>
            /// Network chain ID. See <a href="https://docs.unlock-protocol.com/core-protocol/unlock/networks/">here</a> for an updated list of networks that Unlock Protocol supports.
            /// </summary>
            public int network;
        }

        #endregion

        #region "Initialization"

        private void Awake()
        {
            Instance = this;

            if (networkConfig == null)
            {
                Errors.MissingNetworkConfig();
            }

            InitializeJs(networkConfig.GetSerialized());
        }

        #endregion

        #region "Public C# functions"


        /// <summary>
        /// Connect to MetaMask wallet
        /// </summary>
        public void ConnectMetaMask()
        {
            ConnectMetaMaskJs();
        }

        /// <summary>
        /// Connect to WalletConnect wallet
        /// </summary>
        public void ConnectWalletConnect()
        {
            ConnectWalletConnectJs();
        }

        /// <summary>
        /// Retrieve a lock
        /// </summary>
        /// <param name="lockConfig">The <c>LockConfig</c> object which defines all the lock parameters needed to retrieve it</param>
        public void GetLock(LockConfig lockConfig)
        {
            GetLockJs(lockConfig.GetSerialized());
        }

        /// <summary>
        /// Purchase a key to a lock
        /// </summary>
        /// <param name="lockConfig">The <c>LockConfig</c> object which defines all the lock parameters needed to retrieve it</param>
        public void PurchaseKey(LockConfig lockConfig)
        {
            PurchaseKeyJs(lockConfig.GetSerialized());
        }

        /// <summary>
        /// Checks if the user has a non-expired key.
        /// </summary>
        /// <param name="lockConfig">The <c>LockConfig</c> object which defines all the lock parameters needed to retrieve it</param>
        /// <param name="recipient">The user's address to check</param>
        public void GetHasValidKey(LockConfig lockConfig, string recipient)
        {
            GetHasValidKeySuccessParams getHasValidKeyParams = new GetHasValidKeySuccessParams();
            getHasValidKeyParams.recipient = recipient;
            getHasValidKeyParams.lockAddress = lockConfig.@lock.Address;
            getHasValidKeyParams.network = lockConfig.@lock.Network;
            GetHasValidKeyJs(JsonConvert.SerializeObject(getHasValidKeyParams));
        }

        /// <summary>
        /// Get the user's wallet balance
        /// </summary>
        public void GetBalance()
        {
            GetBalanceJs(WalletAddress);
        }

        /// <summary>
        /// Get the user's network chain ID. See <a href="https://docs.unlock-protocol.com/core-protocol/unlock/networks/">here</a> for an updated list of networks that Unlock Protocol supports.
        /// </summary>
        public void GetNetworkID()
        {
            GetNetworkIdJs();
        }

        #endregion

        #region "JavaScript frontend"

        private void ConnectWalletSuccess(string walletAddress)
        {
            WalletAddress = walletAddress;
            walletConnectedSuccess.Invoke(walletAddress);
        }

        private void ConnectWalletFail(string error)
        {
            walletConnectedFail.Invoke(error);
        }

        private void GetHasValidKeySuccess(string jsonParams )
        {
            GetHasValidKeySuccessParams getHasValidKeyParams = JsonConvert.DeserializeObject<GetHasValidKeySuccessParams>(jsonParams);
            getHasValidKey.Invoke(getHasValidKeyParams);
        }

        private void GetHasValidKeyFailed(string jsonParams)
        {
            LockErrorParams getHasValidKeyFailedParams = JsonConvert.DeserializeObject<LockErrorParams>(jsonParams);
            getHasValidKeyFailed.Invoke(getHasValidKeyFailedParams);
        }

        private void GetLockSuccess(string jsonLock)
        {
            Lock gotLock = Lock.GetDeserialized(jsonLock);
            getLockSuccess.Invoke(gotLock);
        }

        private void GetLockFailed(string jsonParams)
        {
            LockErrorParams getLockFailedParams = JsonConvert.DeserializeObject<LockErrorParams>(jsonParams);
            getLockFailed.Invoke(getLockFailedParams);
        }

        private void PurchaseKeySuccess(string lockAddress)
        {
            purchaseKeySuccess.Invoke(lockAddress);
        }

        private void PurchaseKeyFailed( string jsonParams )
        {
            LockErrorParams purchaseKeyFailedParams = JsonConvert.DeserializeObject<LockErrorParams>(jsonParams);
            purchaseKeyFailed.Invoke(purchaseKeyFailedParams);
        }

        private void GetBalanceSuccess(float balance)
        {
            getBalanceSuccess.Invoke(balance);
        }

        private void GetBalanceFailed(string error)
        {
            getBalanceFailed.Invoke(error);
        }

        private void NetworkChanged(int newNetwork)
        {
            networkChanged.Invoke(newNetwork);
        }

        private void GetNetworkIdSuccess(int networkID)
        {
            getNetworkIdSuccess.Invoke(networkID);
        }

        private void GetNetworkIdFailed()
        {
            getNetworkIdFailed.Invoke();
        }

        private void AccountsChanged(string jsonArray)
        {
            List<string> accounts = JsonConvert.DeserializeObject<List<string>>(jsonArray);
            accountsChanged.Invoke(accounts);
        }

        private void Disconnected()
        {
            disconnected.Invoke();
        }

        #endregion

    }
}