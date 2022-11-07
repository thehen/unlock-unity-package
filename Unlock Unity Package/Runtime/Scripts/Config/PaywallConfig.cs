using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace HenryHoffman.UnlockProtocol.Paywall
{
    /// <summary>
    /// The paywall configuration scriptable object. Create an instance of this object to define your paywall configurations.
    /// </summary>
    [CreateAssetMenu(fileName = "Paywall Config", menuName = "Unlock/Paywall Config", order = 1)]
    public class PaywallConfig : ScriptableObject
    {
        internal Config config;

        /// <summary>
        /// The paywall configuration class. This is where paywalls used in the application are defined.
        /// </summary>
        [Serializable]
        public class Config
        {
            /// <summary>
            /// Array of <c>LockConfig</c> objects. This is so your paywall can support multiple locks if needed.
            /// </summary>
            [JsonIgnore]
            public LockConfig[] lockConfigs;

            /// <summary>
            /// The base url used for the paywall checkout. This is useful if a beta release has a different base url.
            /// </summary>
            public string checkoutUrlBase = "https://paywall.unlock-protocol.com/static/unlock.latest.min.js";

            /// <summary>
            /// The icon displayed in the checkout modal.
            /// </summary>
            public string icon;

            /// <summary>
            /// The <c>CallToAction</c> object which defines call to action parameters.
            /// </summary>
            public CallToAction callToAction;

            /// <summary>
            /// TODO
            /// </summary>
            public string[] metadataInputs;

            /// <summary>
            /// true if the modal cannot be closed, defaults to false when embedded.
            /// </summary>
            public bool persistentCheckout = false;

            /// <summary>
            /// The delegated provider allows the embedded paywall to synchronize with the provider used on the host page
            /// </summary>
            public bool useDelegatedProvider = false;

            /// <summary>
            /// Network chain ID. See <a href="https://docs.unlock-protocol.com/core-protocol/unlock/networks/">here</a> for an updated list of networks that Unlock Protocol supports.
            /// </summary>
            public int network;

            /// <summary>
            /// The address which will receive UDT tokens (if the transaction is applicable)
            /// </summary>
            [HideInInspector]
            public string referrer = "0xde22DE740609532FC0F48287b7F258776bE814FD";

            /// <summary>
            /// If supplied, the user is prompted to sign this message using their wallet.
            /// </summary>
            public string messageToSign = "";

            /// <summary>
            /// By default, to reduce friction, we do not require users to wait for the transaction to be mined before offering them to be redirected. By setting this to true, users will need to wait for the transaction to have been mined in order to proceed to the next step.
            /// </summary>
            public bool pessimistic = false;

            internal Dictionary<string, LockConfig.Lock> locks = new Dictionary<string, LockConfig.Lock>();
        }

        /// <summary>
        /// Call to action object
        /// </summary>
        [Serializable]
        public class CallToAction
        {
            /// <summary>
            /// Default call to action text
            /// </summary>
            public string @default;

            /// <summary>
            /// Expired call to action text
            /// </summary>
            public string expired;

            /// <summary>
            /// TODO
            /// </summary>
            public string metadata;
        }

        /// <summary>
        /// Serializes the <c>Network</c> dictionary object
        /// </summary>
        /// <returns>A serialized json string of the network config</returns>
        internal string GetSerialized()
        {
            config.locks.Clear();

            foreach (var lockConfig in config.lockConfigs)
            {
                config.locks.Add(lockConfig.@lock.address, lockConfig.@lock);
            }

            return JsonConvert.SerializeObject(config);
        }
    }
}
