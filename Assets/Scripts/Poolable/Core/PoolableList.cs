using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableList
{
    private PoolableData poolableData;
    private LinkedList<Poolable> poolables;
    private GameObject prefab;

    private Transform deactivatedObjectsParent;
    private GameObject currentObjectsParent;

    public PoolableList(PoolableData data, Poolable poolable, Transform transform)
    {
        poolables = new LinkedList<Poolable>();
        poolableData = data;
        prefab = poolable.prefab;
        deactivatedObjectsParent = transform;

        CreateParent();

        for (int index = 0; index < poolableData.defaultCount; index++)
        {
            var gObject = GameObject.Instantiate(poolable.prefab);
            var poolableAtGameObject = gObject.GetComponent<Poolable>();
            InsertPoolable(poolableAtGameObject);
        }
    }

    public PoolableList(Poolable poolable, Transform transform)
    {
        poolables = new LinkedList<Poolable>();
        prefab = poolable.prefab;
        deactivatedObjectsParent = transform;

        poolableData = new PoolableData();
        poolableData.objectName = poolable.objectName;
        poolableData.defaultCount = 1;
        poolableData.maxCount = 10;

        CreateParent();
        InsertPoolable(poolable);
    }

    private void CreateParent()
    {
        currentObjectsParent = new GameObject();
        currentObjectsParent.name = poolableData.objectName;
        currentObjectsParent.transform.parent = deactivatedObjectsParent;
    }

    public GameObject GetObjectFromPool()
    {
        GameObject gObject;
        if (poolables.Count > 0)
        {
            gObject = poolables.First.Value.gameObject;
            poolables.RemoveFirst();
        }
        else
        {
            gObject = GameObject.Instantiate(prefab);
        }

        gObject.SetActive(true);
        gObject.transform.parent = null;
        var poolableAtGameObject = gObject.GetComponent<Poolable>();
        poolableAtGameObject.OnActivatedFromPool();

        return gObject;
    }

    public bool InsertPoolable(Poolable poolable)
    {
        poolable.transform.parent = currentObjectsParent.transform;
        poolable.OnMovedToPool();
        poolable.gameObject.SetActive(false);

        if (poolables.Count < poolableData.maxCount)
        {
            poolables.AddFirst(poolable);
            return true;
        }

        return false;
    }
}
