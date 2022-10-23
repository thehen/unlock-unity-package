using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace UnlockProtocol
{
    public class UnlockCustom : MonoBehaviour
    {
        public string WalletAddress { get; private set; }

        public NetworkConfig networkConfig;

        public UnityEvent<string> walletConnectedSuccess;
        public UnityEvent<string> walletConnectedFail;
        public UnityEvent<Lock> getLockSuccess;
        public UnityEvent<GetHasValidKeySuccessParams> getHasValidKey;
        public UnityEvent<string> purchaseKeySuccess;
        public UnityEvent<LockErrorParams> purchaseKeyFailed;
        public UnityEvent<float> getBalanceSuccess;
        public UnityEvent<LockErrorParams> getLockFailed;
        public UnityEvent<LockErrorParams> getHasValidKeyFailed;
        public UnityEvent<string> getBalanceFailed;
        public UnityEvent<int> networkChanged;
        public UnityEvent<int> getNetworkIdSuccess;
        public UnityEvent getNetworkIdFailed;
        public UnityEvent disconnected;
        public UnityEvent<List<string>> accountsChanged;

        public static UnlockCustom Instance { get; private set; }

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

        public class LockErrorParams
        {
            public string lockAddress;
            public string error;
        }

        public class GetHasValidKeySuccessParams
        {
            public bool hasKey;
            public string recipient;
            public string lockAddress;
            public int network;
        }

        private void Awake()
        {
            Instance = this;
            InitializeJs(networkConfig.GetSerialized());
        }

        public void ConnectMetaMask()
        {
            ConnectMetaMaskJs();
        }

        public void ConnectWalletConnect()
        {
            ConnectWalletConnectJs();
        }

        public void GetLock(LockConfig lockConfig)
        {
            GetLockJs(lockConfig.GetSerialized());
        }

        public void PurchaseKey(LockConfig lockConfig)
        {
            PurchaseKeyJs(lockConfig.GetSerialized());
        }

        public void GetHasValidKey(LockConfig lockConfig, string recipient)
        {
            GetHasValidKeySuccessParams getHasValidKeyParams = new GetHasValidKeySuccessParams();
            getHasValidKeyParams.recipient = recipient;
            getHasValidKeyParams.lockAddress = lockConfig.theLock.address;
            getHasValidKeyParams.network = lockConfig.theLock.network;
            GetHasValidKeyJs(JsonConvert.SerializeObject(getHasValidKeyParams));
        }

        public void GetBalance()
        {
            GetBalanceJs(WalletAddress);
        }

        public void GetNetworkID()
        {
            GetNetworkIdJs();
        }

        // Called from JavaScript

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


    }
}