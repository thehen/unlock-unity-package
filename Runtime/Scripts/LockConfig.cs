using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace HenryHoffman.UnlockProtocol
{
    [CreateAssetMenu(fileName = "Lock Config", menuName = "Unlock/Lock Config", order = 1)]

    public class LockConfig : ScriptableObject
    {
        public StringLockDictionary locks;

        [Serializable]
        public class Lock
        {
            public string name;
            public int network;
        }

        [Serializable]
        public class Locks
        {
            public StringLockDictionary locks;
        }

        public string GetSerialized()
        {
            Locks thisLocks = new Locks();
            thisLocks.locks = locks;
            return JsonConvert.SerializeObject(thisLocks);
        }
    }
}