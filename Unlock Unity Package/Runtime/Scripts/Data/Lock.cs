using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace HenryHoffman.UnlockProtocol
{
    /// <summary>
    ///   The Unlock Protocol <c>Lock</c> object. This object represents the retrieved lock, and contains all the lock details.
    /// </summary>

    public class Lock
    {
        /// <summary>
        /// Address of the lock
        /// </summary>
        public string lockAddress;

        /// <summary>
        /// As of block number
        /// </summary>
        public int asOf;

        /// <summary>
        /// The balance of the lock
        /// </summary>
        public string balance;

        /// <summary>
        /// The beneficiary who recieves funds on withdrawl
        /// </summary>
        public string beneficiary;

        /// <summary>
        /// The contract address for the lock currency
        /// </summary>
        public string currencyContractAddress;

        /// <summary>
        /// The symbol used for the lock currency
        /// </summary>
        public string currencySymbol;

        /// <summary>
        /// The duration until expiration of the lock
        /// </summary>
        public int expirationDuration;

        /// <summary>
        /// The price of a key for the lock
        /// </summary>
        public string keyPrice;

        /// <summary>
        /// The maximum number of keys available
        /// </summary>
        public int maxNumberOfKeys;

        /// <summary>
        /// The name of the lock
        /// </summary>
        public string name;

        /// <summary>
        /// The number of outstanding keys available
        /// </summary>
        public int outstandingKeys;

        /// <summary>
        /// Public lock version
        /// </summary>
        public int publicLockVersion;

        /// <summary>
        /// Deserializes a json string to a <c>Lock</c> object
        /// </summary>
        /// <param name="json">A json string of the lock object</param>
        /// <returns>Deserialized <c>Lock</c> object</returns>

        internal static Lock GetDeserialized( string json )
        {
            Lock deserialisedLock = JsonConvert.DeserializeObject<Lock>(json);
            return deserialisedLock;
        }
    }
}