using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace HenryHoffman.UnlockProtocol
{
    public class Lock
    {
        public string lockAddress;
        public int asOf;
        public string balance;
        public string beneficiary;
        public string currencyContractAddress;
        public string currencySymbol;
        public int expirationDuration;
        public string keyPrice;
        public int maxNumberOfKeys;
        public string name;
        public int outstandingKeys;
        public int publicLockVersion;

        public static Lock GetDeserialized( string json )
        {
            Lock deserialisedLock = JsonConvert.DeserializeObject<Lock>(json);
            return deserialisedLock;
        }
    }
}