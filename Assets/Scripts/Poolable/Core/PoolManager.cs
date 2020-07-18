using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
    private static Dictionary<string, PoolableList> poolsDictionary;
    private static GameObject deactivatedObjectsParent;

    public static void Initialize()
    {
        poolsDictionary = new Dictionary<string, PoolableList>();
        deactivatedObjectsParent = new GameObject();
        deactivatedObjectsParent.name = "Poolabel Objects";
    }

    public static void AddToPool(PoolableObject poolableObject)
    {
        AddToPool(poolableObject.poolableData, poolableObject.poolable);
    }

    public static void AddToPool(PoolableData data, Poolable poolable)
    {
        poolable.gameObject.SetActive(false);

        if (poolsDictionary.ContainsKey(data.objectName))
        {
            var poolableList = poolsDictionary[data.objectName];
            if (!poolableList.InsertPoolable(poolable))
            {
                GameObject.Destroy(poolable.gameObject);
            }
        }
        else
        {
            var poolableList = new PoolableList(data, poolable, deactivatedObjectsParent.transform);
            poolsDictionary[data.objectName] = poolableList;
        }
    }

    public static GameObject GetFromPool(Poolable poolable)
    {
        GameObject gObject = null;
        if (poolsDictionary.ContainsKey(poolable.objectName))
        {
            var list = poolsDictionary[poolable.objectName];
            gObject = list.GetObjectFromPool();
        }
        else
        {
            Debug.LogWarning("Tried to get from pull object that is not in pool");
        }

        return gObject;
    }

    public static void AddToPool(Poolable poolable)
    {
        if (poolsDictionary.ContainsKey(poolable.objectName))
        {
            var list = poolsDictionary[poolable.objectName];
            if (!list.InsertPoolable(poolable))            
            {
                GameObject.Destroy(poolable.gameObject);
            }
                
        }
        else
        {
            var list = new PoolableList(poolable, deactivatedObjectsParent.transform);
            poolsDictionary[poolable.objectName] = list;
        }
    }
}
