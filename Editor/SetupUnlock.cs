using UnityEngine;
using UnityEditor;
using System.IO;

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

            if (!Directory.Exists(webglDir))
            {
                Directory.CreateDirectory(webglDir);
            }

            source = "Packages/com.henryhoffman.unlockprotocol/WebGLTemplates~/Unlock-custom";
            target = webglDir + "/Unlock-custom";
            AssetDatabase.CopyAsset(source, target);

            source = "Packages/com.henryhoffman.unlockprotocol/WebGLTemplates~/Unlock-paywall";
            target = webglDir + "/Unlock-paywall";
            AssetDatabase.CopyAsset(source, target);

            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        }
    }
}