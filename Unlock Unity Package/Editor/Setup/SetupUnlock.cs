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
            string assetsPath = Application.dataPath;
            string webglDir = "Assets/WebGLTemplates";
            string source;
            string target;

            System.IO.Directory.CreateDirectory(assetsPath + "/WebGLTemplates");
            System.IO.Directory.CreateDirectory(assetsPath + "/WebGLTemplates/Unlock-custom");
            System.IO.Directory.CreateDirectory(assetsPath + "/WebGLTemplates/Unlock-paywall");

            source = "Packages/com.UnlockProtocol/WebGLTemplatesSource/Unlock-custom";
            target = webglDir + "/Unlock-custom";
            FileUtil.CopyFileOrDirectory(source, target);

            source = "Packages/com.UnlockProtocol/WebGLTemplatesSource/Unlock-paywall";
            target = webglDir + "/Unlock-paywall";
            FileUtil.CopyFileOrDirectory(source, target);

            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        }
    }
}
#endif