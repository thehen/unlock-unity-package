using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace HenryHoffman.UnlockProtocol
{
    [CreateAssetMenu(fileName = "Lock Config", menuName = "Unlock/Lock Config", order = 1)]

    public class LockConfig : ScriptableObject
    {
        public Lock theLock;

        [Serializable]
        public class Lock
        {
            public string name;
            public int network;

            [JsonIgnore]
            public string address;

            [HideInInspector]
            public string referrer = "0xde22DE740609532FC0F48287b7F258776bE814FD";
        }

        public Dictionary<string, Lock> GetDictionary()
        {
            var dict = new Dictionary<string, Lock>();
            dict.Add(theLock.address, theLock);
            return dict;
        }

        public string GetSerialized()
        {
            var dict = GetDictionary();
            return JsonConvert.SerializeObject(dict);
        }

        /*
        public string GetFirstAddress()
        {
            string address = "";
            foreach (var l in locks)
            {
                address = l.Key;
                break;
            }
            return address;
        }
        */
    }
}