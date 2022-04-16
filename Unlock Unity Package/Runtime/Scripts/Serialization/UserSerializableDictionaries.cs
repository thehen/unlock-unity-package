using System;

namespace HenryHoffman.UnlockProtocol
{
    [Serializable]
    public class StringLockDictionary : SerializableDictionary<string, LockConfig.Lock> {}

    [Serializable]
    public class ChainIDNetworkDictionary : SerializableDictionary<int, NetworkConfig.Network> {}
}