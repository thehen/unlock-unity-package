using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HenryHoffman.UnlockProtocol
{
    public class Errors : MonoBehaviour
    {
        public static void UnsupportedPlatformOrEditor()
        {
            Debug.LogError("Error: Unlock Protocol needs to run in a WebGL build. Editor and other platforms are unsupported.");
        }
    }
}

