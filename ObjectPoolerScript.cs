using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerScript
{
    //public static ObjectPoolerScript current;
    public GameObject pooledObject;
    public int pooledAmount = 20;
    //用来判定该池是否能拓展
    public bool willGrow = true;
    public List<GameObject> pooledObjects;
    /// <summary>
    /// 对象池构造函数
    /// </summary>
    /// <param name="pooledObject">要装入池中的对象</param>
    /// <param name="pooledAmount">池子默认大小</param>
    /// <param name="willGrow">池子能否拓展</param>
    public ObjectPoolerScript(GameObject pooledObject, int pooledAmount = 20, bool willGrow = true)
    {
        this.pooledObject = pooledObject;
        this.pooledAmount = pooledAmount;
        this.willGrow = willGrow;

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = GameObject.Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    //private void Awake()
    //{
        //current = this;
    //}
    // Use this for initialization
    //void Start () {
	//}

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //不要对list进行remove操作，而用遍历的方法，因为遍历更快
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = GameObject.Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
