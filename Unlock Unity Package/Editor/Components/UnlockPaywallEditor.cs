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
            if (!PlayerSettings.WebGL.template.Contains("Unlock-paywall"))
            {
                EditorGUILayout.HelpBox("Incorrect WebGL Template selected. Go to 'Project Settings > Player Resolution and Presentation' and select Unlock-paywall.", MessageType.Warning);
            }

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