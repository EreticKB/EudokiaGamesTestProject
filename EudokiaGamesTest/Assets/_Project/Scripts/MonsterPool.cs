using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool
{
    Stack<GameObject> _monsterPool = new Stack<GameObject>();
    int _poolSize;

    public MonsterPool()
    {
        _poolSize = 100;
    }

    public MonsterPool(int size, GameObject filler)
    {
        if (size == 0) size = 1;
        _poolSize = size;
        for (int i = 0; i < Math.Min(size, 10); i++)
        {
            _monsterPool.Push(filler);
        }
    }
    public GameObject PullMonster()
    {
        if (_monsterPool.Count == 0) return null;
        return _monsterPool.Pop();
    }

    public bool PushMonster(GameObject monster)
    {
        if (_monsterPool.Count > _poolSize) return false;
        else
        {
            monster.SetActive(false);
            _monsterPool.Push(monster);
            return true;
        }
    }
}
