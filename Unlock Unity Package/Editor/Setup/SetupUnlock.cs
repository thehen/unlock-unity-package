using UnityEngine;
using UnityEditor;
using System.IO;

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

            if (!Directory.Exists(Application.dataPath + "WebGLTemplates"))
            {
                Directory.CreateDirectory(Application.dataPath + "WebGLTemplates");
            }

            source = "Packages/com.henryhoffman.unlockprotocol/WebGLTemplatesSource/Unlock-custom";
            target = webglDir + "/Unlock-custom";
            FileUtil.CopyFileOrDirectory(source, target);

            source = "Packages/com.henryhoffman.unlockprotocol/WebGLTemplatesSource/Unlock-paywall";
            target = webglDir + "/Unlock-paywall";
            FileUtil.CopyFileOrDirectory(source, target);

            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        }
    }
}
#endif