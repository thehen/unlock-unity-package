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

            source = "Packages/Unlock Protocol/WebGLTemplates~/Unlock-custom";
            target = webglDir + "/Unlock-custom";
            FileUtil.CopyFileOrDirectory(source, target);

            source = "Packages/Unlock Protocol/WebGLTemplates~/Unlock-paywall";
            target = webglDir + "/Unlock-paywall";
            FileUtil.CopyFileOrDirectory(source, target);

            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        }
    }
}