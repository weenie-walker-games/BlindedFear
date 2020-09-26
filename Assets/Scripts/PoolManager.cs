﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    //Takes an array of GameObjects to instantiate randomly
    public List<GameObject> GeneratePooledObjects(List<GameObject> list, GameObject[] poolOptions, Transform parent)
    {
        GameObject item = Instantiate(poolOptions[Random.Range(0, poolOptions.Length)], parent);
        item.SetActive(false);
        list.Add(item);

        return list;

    }

    //Instantiates all one type of the same object
    public List<MonsterController> GeneratePooledObjects(List<MonsterController> list, MonsterController pooledItem, Transform parent)
    {
        MonsterController item = Instantiate(pooledItem, parent);
        item.gameObject.SetActive(false);
        list.Add(item);

        return list;

    }


    public MonsterController RequestPooledObject(List<MonsterController> list, bool randomly = false)
    {


        MonsterController item;
        if (randomly == true)
        {
            item = list[Random.Range(0, list.Count)];
        }
        else
        {
            item = list[0];
        }
        list.Remove(item);
        return item;
    }
}
