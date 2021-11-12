using System;

namespace HenryHoffman.UnlockProtocol
{
    [Serializable]
    public class StringStringDictionary : SerializableDictionary<string, string> {}

    [Serializable]
    public class StringLockDictionary : SerializableDictionary<string, LockConfig.Lock> {}
}