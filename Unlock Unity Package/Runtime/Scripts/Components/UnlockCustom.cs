using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace HenryHoffman.UnlockProtocol
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

        [DllImport("__Internal")]
        private static extern string ConnectMetaMaskJs();

        [DllImport("__Internal")]
        private static extern string ConnectWalletConnectJs();

        [DllImport("__Internal")]
        private static extern void GetLockJs(string str);

        [DllImport("__Internal")]
        private static extern void InitializeJs(string network);

        [DllImport("__Internal")]
        private static extern void PurchaseKeyJs(string network);

        [DllImport("__Internal")]
        private static extern void GetHasValidKeyJs(string network);

        [DllImport("__Internal")]
        private static extern string GetBalanceJs(string adddress);

        [DllImport("__Internal")]
        private static extern string GetNetworkIdJs();

        public class LockErrorParams
        {
            public string lockAddress;
            public string error;
        }

        public class GetHasValidKeySuccessParams
        {
            public bool hasKey;
            public string recipient;
            public LockConfig lockConfig;
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
            getHasValidKeyParams.lockConfig = lockConfig;
            getHasValidKeyParams.recipient = recipient;
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