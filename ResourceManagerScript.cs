using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//挂在根节点的资源管理器，由单例模式实现
public class ResourceManagerScript : SingletonBehaviour<ResourceManagerScript> {
	//设定资源的路径，以用于资源或者预制件的加载
    public string RESOURCE_XX_PATH = "";
	
	
	//设定装载游戏对象池子的集合
	public List<ObjectPoolerScript> listObjectPoolers;
	//设定装载UI对象池子的集合
	public List<UIPoolerScript> listUIPoolers;


    public void Awake()
    {
        listObjectPoolers = new List<ObjectPoolerScript>();
		listUIPoolers = new List<UIPoolerScript>();
    }

}
