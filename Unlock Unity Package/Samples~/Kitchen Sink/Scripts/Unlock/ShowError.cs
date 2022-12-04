using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HenryHoffman.UnlockProtocol;
using HenryHoffman.UnlockProtocol.Custom;

public class ShowError : MonoBehaviour
{
    public Text heading;
    public Text bodyText;

    private void Start()
    {
        UnlockCustom.Instance.walletConnectedFail.AddListener(WalletConnectedFail);
        UnlockCustom.Instance.purchaseKeyFailed.AddListener(PurchaseKeyFailed);
    }

    public void WalletConnectedFail( string error)
    {
        PopulateAndShowError("Error!", error);
    }

    public void PurchaseKeyFailed( UnlockCustom.LockErrorParams error )
    {
        PopulateAndShowError("Error!", error.error);
    }

    public void PopulateAndShowError( string head, string text)
    {
        heading.text = head;
        bodyText.text = text;
    }

}
