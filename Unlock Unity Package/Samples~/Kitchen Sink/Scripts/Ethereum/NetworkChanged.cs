using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HenryHoffman.UnlockProtocol;
using HenryHoffman.UnlockProtocol.Custom;

public class NetworkChanged : MonoBehaviour
{
    public int networkId;
    public GameObject changeNetworkPanel;

    void Start()
    {
        UnlockCustom.Instance.walletConnectedSuccess.AddListener(WalletConnected);
        UnlockCustom.Instance.getNetworkIdSuccess.AddListener(GetNetworkIdSuccess);
        UnlockCustom.Instance.getNetworkIdFailed.AddListener(GetNetworkIdFailed);
        UnlockCustom.Instance.networkChanged.AddListener(NetworkHasChanged);
    }

    private void WalletConnected( string address )
    {
        UnlockCustom.Instance.GetNetworkID();
    }

    private void NetworkHasChanged(int id)
    {
        changeNetworkPanel.SetActive(id != networkId);
    }

    private void GetNetworkIdFailed()
    {
        changeNetworkPanel.SetActive(true);
    }

    private void GetNetworkIdSuccess(int id)
    {
        changeNetworkPanel.SetActive(id != networkId);
    }
}
