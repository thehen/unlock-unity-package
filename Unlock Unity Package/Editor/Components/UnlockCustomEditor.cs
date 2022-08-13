using UnityEditor;
using UnityEngine;
using System.Collections;

namespace HenryHoffman.UnlockProtocol
{
    [CustomEditor(typeof(UnlockCustom))]

    public class UnlockCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
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