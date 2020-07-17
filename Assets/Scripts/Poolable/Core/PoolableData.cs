using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolableData", menuName = "Poolable/PoolableData", order = 0)]
public class PoolableData: ScriptableObject
{
    public string objectName = "";
    public uint defaultCount = 1;
    public uint maxCount = 5;
}
