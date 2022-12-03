#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System.Collections;

namespace HenryHoffman.UnlockProtocol.Paywall
{
    /// <summary>
    /// Forces the Unlock Paywall manager to have a fixed name, otherwise JavaScript can't send messages to the object 
    /// </summary>
    [CustomEditor(typeof(UnlockPaywall))]
    public class UnlockPaywallEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UnlockPaywall paywall = (UnlockPaywall)target;

            if (!PlayerSettings.WebGL.template.Contains("Unlock-paywall"))
            {
                EditorGUILayout.HelpBox("Incorrect WebGL Template selected. Go to 'Project Settings > Player Resolution and Presentation' and select Unlock-paywall.", MessageType.Warning);
            }

            if (!paywall.paywallConfig)
            {
                EditorGUILayout.HelpBox("Ensure a Paywall Config is assigned below, otherwise the paywall won't work.", MessageType.Warning);
            }

            DrawDefaultInspector();

            GameObject paywallGameObject = paywall.gameObject;

            if (paywallGameObject.name != "UnlockPaywall")
            {
                paywallGameObject.name = "UnlockPaywall";
            }
        }
    }
}

#endif