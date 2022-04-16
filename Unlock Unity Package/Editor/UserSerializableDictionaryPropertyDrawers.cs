using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HenryHoffman.UnlockProtocol
{
    [CustomPropertyDrawer(typeof(StringLockDictionary))]
    [CustomPropertyDrawer(typeof(ChainIDNetworkDictionary))]
    public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
    public class AnySerializableDictionaryStoragePropertyDrawer : SerializableDictionaryStoragePropertyDrawer { }
}