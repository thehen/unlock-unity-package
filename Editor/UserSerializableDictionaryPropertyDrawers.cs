using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HenryHoffman.UnlockProtocol
{
    [CustomPropertyDrawer(typeof(StringStringDictionary))]
    [CustomPropertyDrawer(typeof(StringLockDictionary))]
    public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
    public class AnySerializableDictionaryStoragePropertyDrawer : SerializableDictionaryStoragePropertyDrawer { }
}