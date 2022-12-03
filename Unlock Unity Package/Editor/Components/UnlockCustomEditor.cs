#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System.Collections;

namespace HenryHoffman.UnlockProtocol.Custom
{
    /// <summary>
    /// Forces the Unlock Custom manager to have a fixed name, otherwise JavaScript can't send messages to the object 
    /// </summary>
    [CustomEditor(typeof(UnlockCustom))]
    public class UnlockCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if (!PlayerSettings.WebGL.template.Contains("Unlock-custom"))
            {
                EditorGUILayout.HelpBox("Incorrect WebGL Template selected. Go to 'Project Settings > Player Resolution and Presentation' and select Unlock-custom.", MessageType.Warning);
            }

            DrawDefaultInspector();

            UnlockCustom custom = (UnlockCustom)target;
            GameObject customGameObject = custom.gameObject;

            if (customGameObject.name != "UnlockCustom")
            {
                customGameObject.name = "UnlockCustom";
            }
        }
    }
}

#endif