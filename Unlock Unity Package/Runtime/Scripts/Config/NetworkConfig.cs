using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace HenryHoffman.UnlockProtocol
{
    /// <summary>
    /// The network configuration scriptable object. Create an instance of this object to define your network configurations.
    /// </summary>
    [CreateAssetMenu(fileName = "Network Config", menuName = "Unlock/Network Config", order = 1)]
    public class NetworkConfig : ScriptableObject
    {
        /// <summary>
        /// Array of <c>Network</c> objects supported
        /// </summary>
        public Network[] networks;

        /// <summary>
        /// The network configuration class. This is where networks used in the application are defined.
        /// </summary>
        [Serializable]
        public class Network
        {
            /// <summary>
            /// Network name
            /// </summary>
            [JsonIgnore]
            public string networkName;

            /// <summary>
            /// Network chain ID. See <a href="https://docs.unlock-protocol.com/core-protocol/unlock/networks/">here</a> for an updated list of networks that Unlock Protocol supports.
            /// </summary>
            [JsonIgnore]
            [Tooltip("Network chain ID")]
            public int chainID;

            /// <summary>
            /// Ethereum Gateway url
            /// </summary>
            public string provider;

            /// <summary>
            /// This is used for "optimistic" unlocking: a service which ensures that "pending" transactions are still taken into account to unlock a page.
            /// </summary>
            public string locksmithUri;

            /// <summary>
            /// The Unlock address
            /// </summary>
            public string unlockAddress;

            /// <summary>
            /// The Unlock App Url
            /// </summary>
            public string unlockAppUrl;

            /// <summary>
            /// The Subgraph Url
            /// </summary>
            public string subgraphURI;
        }

        /// <summary>
        /// Gets a <c>Dictionary</c> representation of <c>Network</c> object for correctly formatted json deserialization
        /// </summary>
        /// <returns><c>Dictionary</c> with lock address key and <c>Lock</c> object value</returns>
        internal Dictionary<int, Network> GetDictionary()
        {
            var dict = new Dictionary<int, Network>();
            foreach (var network in networks)
            {
                dict.Add(network.chainID, network);
            }
            return dict;
        }

        /// <summary>
        /// Serializes the <c>Network</c> dictionary object
        /// </summary>
        /// <returns>A serialized json string of the network config</returns>
        public string GetSerialized()
        {
            var dict = GetDictionary();
            return JsonConvert.SerializeObject(dict);
        }
    }
}