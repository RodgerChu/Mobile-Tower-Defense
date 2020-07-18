using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolableObject", menuName = "Poolable/PoolableObject", order = 1)]
public class PoolableObject : ScriptableObject
{
    public Poolable poolable;
    public PoolableData poolableData;
}
