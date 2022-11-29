using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace HenryHoffman.UnlockProtocol
{
    /// <summary>
    /// The lock configuration scriptable object. Create an instance of this object to define a lock configuration.
    /// </summary>
    [CreateAssetMenu(fileName = "Lock Config", menuName = "Unlock/Lock Config", order = 1)]
    public class LockConfig : ScriptableObject
    {
        /// <summary>
        /// The lock object
        /// </summary>
        public Lock @lock;

        /// <summary>
        /// The lock configuration. This is where local locks are configured for retrieving later in the application cycle.
        /// </summary>
        [Serializable]
        public class Lock
        {
            /// <summary>
            /// Name of the lock
            /// </summary>
            [SerializeField]
            [Tooltip("Name of the lock")]
            [JsonProperty]
            private string name;
            public string Name { get { return name; } set { name = value; } }

            /// <summary>
            /// Network chain ID. See <a href="https://docs.unlock-protocol.com/core-protocol/unlock/networks/">here</a> for an updated list of networks that Unlock Protocol supports.
            /// </summary>
            [SerializeField]
            [Tooltip("Network chain ID")]
            [JsonProperty]
            private int network;
            public int Network { get { return network; } set { network = value; } }

            /// <summary>
            /// Unique lock address
            /// </summary>
            [SerializeField]
            [JsonIgnore]
            [Tooltip("Unique lock address")]
            private string address;

            public string Address { get { return address; } set { address = value; }  }

            /// <summary>
            /// The address which will receive UDT tokens (if the transaction is applicable)
            /// </summary>
            [JsonProperty]
            private string referrer = "0xde22DE740609532FC0F48287b7F258776bE814FD";
            public string Referrer { get { return referrer; } set { referrer = value; } }
        }

        /// <summary>
        /// Gets a <c>Dictionary</c> representation of <c>Lock</c> object for correctly formatted json deserialization
        /// </summary>
        /// <returns><c>Dictionary</c> with lock address key and <c>Lock</c> object value</returns>
        internal Dictionary<string, Lock> GetDictionary()
        {
            var dict = new Dictionary<string, Lock>();
            dict.Add(@lock.Address, @lock);
            return dict;
        }

        /// <summary>
        /// Serializes the <c>Lock</c> dictionary object
        /// </summary>
        /// <returns>A serialized json string of the lock</returns>
        internal string GetSerialized()
        {
            var dict = GetDictionary();
            return JsonConvert.SerializeObject(dict);
        }
    }
}