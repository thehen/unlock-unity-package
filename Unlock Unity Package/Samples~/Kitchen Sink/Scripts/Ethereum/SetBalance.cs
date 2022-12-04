using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HenryHoffman.UnlockProtocol;
using HenryHoffman.UnlockProtocol.Custom;
using UnityEngine.UI;

public class SetBalance : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        UnlockCustom.Instance.getBalanceSuccess.AddListener(GetBalanceSuccess);
        UnlockCustom.Instance.getBalanceFailed.AddListener(GetBalanceFailed);
    }

    private void OnDestroy()
    {
        UnlockCustom.Instance.getBalanceSuccess.RemoveListener(GetBalanceSuccess);
        UnlockCustom.Instance.getBalanceFailed.RemoveListener(GetBalanceFailed);
    }

    void GetBalanceSuccess( float balance )
    {
        float roundedBalance = (float)Mathf.Round(balance * 100f) / 100f;
        text.text = roundedBalance.ToString();
    }

    void GetBalanceFailed(string error)
    {
        Debug.LogError(error);
    }

}
