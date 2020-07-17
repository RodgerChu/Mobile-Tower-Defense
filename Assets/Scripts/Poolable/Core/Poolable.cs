using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Poolable: MonoBehaviour
{
    public string objectName = "";
    public GameObject prefab;

    public abstract void OnMovedToPool();
    public abstract void OnActivatedFromPool();
}
