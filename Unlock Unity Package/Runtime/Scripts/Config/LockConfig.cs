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
            [Tooltip("Name of the lock")]
            public string name;

            /// <summary>
            /// Network chain ID. See <a href="https://docs.unlock-protocol.com/core-protocol/unlock/networks/">here</a> for an updated list of networks that Unlock Protocol supports.
            /// </summary>
            [Tooltip("Network chain ID")]
            public int network;

            /// <summary>
            /// Unique lock address
            /// </summary>
            [JsonIgnore]
            [Tooltip("Unique lock address")]
            public string address;

            /// <summary>
            /// The address which will receive UDT tokens (if the transaction is applicable)
            /// </summary>
            [HideInInspector]
            public string referrer = "0xde22DE740609532FC0F48287b7F258776bE814FD";
        }

        /// <summary>
        /// Gets a <c>Dictionary</c> representation of <c>Lock</c> object for correctly formatted json deserialization
        /// </summary>
        /// <returns><c>Dictionary</c> with lock address key and <c>Lock</c> object value</returns>
        internal Dictionary<string, Lock> GetDictionary()
        {
            var dict = new Dictionary<string, Lock>();
            dict.Add(@lock.address, @lock);
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