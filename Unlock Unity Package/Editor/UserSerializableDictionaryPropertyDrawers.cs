using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HenryHoffman.UnlockProtocol
{
    [CustomPropertyDrawer(typeof(NetworkConfig.ChainIDNetworkDictionary))]
    internal class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
    internal class AnySerializableDictionaryStoragePropertyDrawer : SerializableDictionaryStoragePropertyDrawer { }
}
