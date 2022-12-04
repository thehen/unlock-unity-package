using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HenryHoffman.UnlockProtocol;
using HenryHoffman.UnlockProtocol.Custom;
using UnityEngine.SceneManagement;

public class AccountsChanged : MonoBehaviour
{

    void Start()
    {
        UnlockCustom.Instance.walletConnectedSuccess.AddListener(WalletConnected);
    }

    private void WalletConnected(string address)
    {
        UnlockCustom.Instance.accountsChanged.AddListener(AccountsChange);
        UnlockCustom.Instance.disconnected.AddListener(Disconnected);
    }

    private void AccountsChange(List<string> accounts)
    {
        RestartGame();
    }

    private void Disconnected()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
