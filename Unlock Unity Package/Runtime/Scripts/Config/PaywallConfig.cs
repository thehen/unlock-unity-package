using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace UnlockProtocol
{
    [CreateAssetMenu(fileName = "Paywall Config", menuName = "Unlock/Paywall Config", order = 1)]
    public class PaywallConfig : ScriptableObject
    {
        [Serializable]
        public class Config
        {
            [JsonIgnore]
            public LockConfig[] lockConfigs;

            public Dictionary<string, LockConfig.Lock> locks = new Dictionary<string, LockConfig.Lock>();

            public string checkoutUrlBase = "https://paywall.unlock-protocol.com/static/unlock.latest.min.js";
            public string icon;
            public CallToAction callToAction;
            public string[] metadataInputs; // todo
            public bool persistentCheckout = false;
            public bool useDelegatedProvider = false;
            public int network;
            [HideInInspector]
            public string referrer = "0xde22DE740609532FC0F48287b7F258776bE814FD";
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

            foreach (var lockConfig in config.lockConfigs)
            {
                config.locks.Add(lockConfig.theLock.address, lockConfig.theLock);
            }

            return JsonConvert.SerializeObject(config);
        }
    }
}
