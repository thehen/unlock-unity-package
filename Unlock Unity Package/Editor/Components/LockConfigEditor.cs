#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System.Collections;

namespace HenryHoffman.UnlockProtocol.Custom
{
    /// <summary>
    /// Forces the Unlock Custom manager to have a fixed name, otherwise JavaScript can't send messages to the object 
    /// </summary>
    [CustomEditor(typeof(LockConfig))]
    public class LockConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            LockConfig lockConfig = (LockConfig)target;

            if (lockConfig != null && lockConfig.@lock != null)
            {
                lockConfig.@lock.Address = lockConfig.@lock.Address.ToLower();
                lockConfig.@lock.Referrer = lockConfig.@lock.Referrer.ToLower();
            }
        }
    }
}

#endif