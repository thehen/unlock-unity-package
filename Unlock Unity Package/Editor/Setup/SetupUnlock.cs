using UnityEngine;
using UnityEditor;
using System.IO;
using System;

#if UNITY_EDITOR
namespace HenryHoffman.UnlockProtocol
{
    public class SetupUnlock : MonoBehaviour
    {
        [MenuItem("Unlock Protocol/Setup Unlock Protocol")]
        static void Setup()
        {
            string webglDir = "Assets/WebGLTemplates";
            string source;
            string target;

            AssetDatabase.CreateFolder("Assets", "WebGLTemplates");

            source = "Packages/com.UnlockProtocol/WebGLTemplatesSource/Unlock-custom";
            target = webglDir + "/Unlock-custom";
            AssetDatabase.CopyAsset(source, target);

            source = "Packages/com.UnlockProtocol/WebGLTemplatesSource/Unlock-paywall";
            target = webglDir + "/Unlock-paywall";
            AssetDatabase.CopyAsset(source, target);

            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        }
    }
}
#endif