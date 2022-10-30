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
        /// TODO
        /// </summary>
        public string lockAddress;

        /// <summary>
        /// TODO
        /// </summary>
        public int asOf;

        /// <summary>
        /// TODO
        /// </summary>
        public string balance;

        /// <summary>
        /// TODO
        /// </summary>
        public string beneficiary;

        /// <summary>
        /// TODO
        /// </summary>
        public string currencyContractAddress;

        /// <summary>
        /// TODO
        /// </summary>
        public string currencySymbol;

        /// <summary>
        /// TODO
        /// </summary>
        public int expirationDuration;

        /// <summary>
        /// TODO
        /// </summary>
        public string keyPrice;

        /// <summary>
        /// TODO
        /// </summary>
        public int maxNumberOfKeys;

        /// <summary>
        /// TODO
        /// </summary>
        public string name;

        /// <summary>
        /// TODO
        /// </summary>
        public int outstandingKeys;

        /// <summary>
        /// TODO
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