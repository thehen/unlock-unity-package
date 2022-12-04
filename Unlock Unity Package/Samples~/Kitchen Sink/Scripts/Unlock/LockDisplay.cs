using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace HenryHoffman.UnlockProtocol.Custom
{
    public class LockDisplay : MonoBehaviour
    {
        public LockConfig lockConfig;

        public Text asOf;
        public Text balance;
        public Text beneficiary;
        public Text currencyContractAddress;
        public Text expirationDuration;
        public Text keyPrice;
        public Text maxNumberOfKeys;
        public Text lockName;
        public Text outstandingKeys;
        public Text publicLockVersion;  

        public GameObject notPurchasedPanel;
        public GameObject purchasedPanel;
        public GameObject loadingPanel;

        public float delay = 0f;

        private void Start()
        {

            notPurchasedPanel.SetActive(false);
            purchasedPanel.SetActive(false);
            loadingPanel.SetActive(true);

            StartCoroutine(GetLock());

            UnlockCustom.Instance.getHasValidKey.AddListener(GetHasValidKey);
            UnlockCustom.Instance.purchaseKeySuccess.AddListener(PurchaseKeySuccess);
            UnlockCustom.Instance.purchaseKeyFailed.AddListener(PurchaseKeyFailed);

            UnlockCustom.Instance.getLockSuccess.AddListener(GetLockSuccess);
            UnlockCustom.Instance.getLockFailed.AddListener(GetLockFailed);
        }

        private void OnDestroy()
        {
            UnlockCustom.Instance.getHasValidKey.RemoveListener(GetHasValidKey);
            UnlockCustom.Instance.purchaseKeySuccess.RemoveListener(PurchaseKeySuccess);
            UnlockCustom.Instance.purchaseKeyFailed.RemoveListener(PurchaseKeyFailed);
        }

        private void PurchaseKeySuccess(string lockAddress)
        {
            if (lockAddress == lockConfig.@lock.Address)
            {
                purchasedPanel.SetActive(true);
                loadingPanel.SetActive(false);
            }
        }

        private void PurchaseKeyFailed(UnlockCustom.LockErrorParams purchaseKeyFailedParams)
        {
            if (purchaseKeyFailedParams.lockAddress == lockConfig.@lock.Address)
            {
                notPurchasedPanel.SetActive(true);
                loadingPanel.SetActive(false);

            }
        }

        private void GetLockSuccess(Lock l)
        {
            if (l.lockAddress == lockConfig.@lock.Address)
            {
                PopulateLock(l);
            }
        }

        private void GetLockFailed(UnlockCustom.LockErrorParams lockError)
        {
            if (lockError.lockAddress == lockConfig.@lock.Address)
            {
                Debug.LogError(lockError.error);
            }
        }


        private void GetHasValidKey(UnlockCustom.GetHasValidKeySuccessParams p)
        {
            if (p.lockAddress == lockConfig.@lock.Address)
            {
                if (p.hasKey)
                {
                    notPurchasedPanel.SetActive(false);
                    purchasedPanel.SetActive(true);
                    loadingPanel.SetActive(false);
                }
                else
                {
                    notPurchasedPanel.SetActive(true);
                    purchasedPanel.SetActive(false);
                    loadingPanel.SetActive(false);
                }
            }
        }

        public void PopulateLock(Lock l)
        {
            if (asOf)
                asOf.text = l.asOf.ToString();

            if (balance)
                balance.text = l.balance.ToString();

            if (beneficiary)
                beneficiary.text = l.beneficiary;

            if (currencyContractAddress)
                currencyContractAddress.text = l.currencyContractAddress;

            if (expirationDuration)
                expirationDuration.text = l.expirationDuration.ToString();

            if (keyPrice)
                keyPrice.text = l.keyPrice.ToString() + " " + l.currencySymbol;

            if (maxNumberOfKeys)
                maxNumberOfKeys.text = l.maxNumberOfKeys.ToString();

            if (lockName)
                lockName.text = l.name;

            if (outstandingKeys)
                outstandingKeys.text = l.outstandingKeys.ToString();

            if (publicLockVersion)
                publicLockVersion.text = l.publicLockVersion.ToString();
        }

        public void PurchaseKey()
        {
            notPurchasedPanel.SetActive(false);
            loadingPanel.SetActive(true);
            UnlockCustom.Instance.PurchaseKey(lockConfig);
        }

        IEnumerator GetLock()
        {
            yield return new WaitForSeconds(delay);

            UnlockCustom.Instance.GetLock(lockConfig);
            UnlockCustom.Instance.GetHasValidKey(lockConfig, UnlockCustom.Instance.WalletAddress);
            yield return null;
        }
    }
}
