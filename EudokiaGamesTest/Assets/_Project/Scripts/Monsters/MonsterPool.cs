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

    public MonsterPool(int size)
    {
        if (size == 0) size = 1;
        _poolSize = size;
    }
    public GameObject PullMonster()
    {
        if (_monsterPool.Count == 0) return null;
        GameObject monster = _monsterPool.Pop();
        monster.SetActive(true);
        return monster;
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
