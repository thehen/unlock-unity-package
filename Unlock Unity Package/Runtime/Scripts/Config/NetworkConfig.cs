using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace HenryHoffman.UnlockProtocol
{
    [CreateAssetMenu(fileName = "Network Config", menuName = "Unlock/Network Config", order = 1)]

    public class NetworkConfig : ScriptableObject
    {
        public ChainIDNetworkDictionary networks;

        [Serializable]
        public class Network
        {
            public string provider;
            public string locksmithUri;
            public string unlockAddress;
            public string unlockAppUrl;
            public string subgraphURI;
        }

        public string GetSerialized()
        {
            return JsonConvert.SerializeObject(networks);
        }
    }
}