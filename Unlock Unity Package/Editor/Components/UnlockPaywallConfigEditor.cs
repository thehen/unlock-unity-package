#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System.Collections;

namespace HenryHoffman.UnlockProtocol.Paywall
{
    /// <summary>
    /// Adds warning messaging when fields are empty
    /// </summary>
    [CustomEditor(typeof(PaywallConfig))]
    public class UnlockPaywallConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            PaywallConfig paywallConfig = (PaywallConfig)target;

            bool configExists = false;
            foreach (var config in paywallConfig.config.lockConfigs)
            {
                if (config != null)
                {
                    configExists = true;
                }
            }

            if (!configExists)
            {
                EditorGUILayout.HelpBox("Please assign your lock configs, otherwise the paywall won't work.", MessageType.Warning);
            }

            DrawDefaultInspector();
        }
    }
}

#endif