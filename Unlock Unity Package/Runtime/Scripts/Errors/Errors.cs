using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HenryHoffman.UnlockProtocol
{
    internal class Errors : MonoBehaviour
    {
        public static void UnsupportedPlatformOrEditor()
        {
            Debug.LogError("Error: Unlock Protocol needs to run in a WebGL build. Editor and other platforms are unsupported.");
        }

        public static void MissingNetworkConfig()
        {
            Debug.LogError("Error: a NetworkConfig needs to be assigned in your UnlockCustom component.");
        }

    }
}

