using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace HenryHoffman.UnlockProtocol
{
    [CreateAssetMenu(fileName = "Paywall Config", menuName = "Unlock/Paywall Config", order = 1)]
    public class PaywallConfig : ScriptableObject
    {
        [Serializable]
        public class Config
        {
            [JsonIgnore]
            public LockConfig[] lockConfigs;

            [HideInInspector]
            public StringLockDictionary locks;

            public string icon;
            public CallToAction callToAction;
            public string metadataInputs; // todo
            public bool persistentCheckout = false;
            public bool useDelegatedProvider = false;
            public int network;
            public string referrer;
            public string messageToSign = "";
            public bool pessimistic = false;
        }

        [Serializable]
        public class CallToAction
        {
            public string @default;
            public string expired;
            public string metadata;
        }

        public Config config;

        public string GetSerialized()
        {
            config.locks.Clear();
            foreach (var thisLock in config.lockConfigs)
            {
                foreach (var lockConfig in thisLock.locks)
                {
                    config.locks.Add(lockConfig.Key, lockConfig.Value);
                }
            }
            return JsonConvert.SerializeObject(config);
        }
    }
}
