using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HenryHoffman.UnlockProtocol;
using HenryHoffman.UnlockProtocol.Custom;
using UnityEngine.UI;

public class SetAddress : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        UnlockCustom.Instance.walletConnectedSuccess.AddListener(WalletConnectedSuccess);
    }

    private void OnDestroy()
    {
        UnlockCustom.Instance.walletConnectedSuccess.RemoveListener(WalletConnectedSuccess);
    }

    void WalletConnectedSuccess( string address)
    {
        text.text = address.Substring(0, 6) + "..." + address.Substring(address.Length-4, 4);
    }
}
