#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System.Collections;

namespace HenryHoffman.UnlockProtocol.Paywall
{
    /// <summary>
    /// TODO 
    /// </summary>
    [CustomEditor(typeof(UnlockPaywall))]
    public class UnlockPaywallEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            UnlockPaywall paywall = (UnlockPaywall)target;
            GameObject paywallGameObject = paywall.gameObject;

            if (paywallGameObject.name != "UnlockPaywall")
            {
                paywallGameObject.name = "UnlockPaywall";
            }
        }
    }
}

#endif