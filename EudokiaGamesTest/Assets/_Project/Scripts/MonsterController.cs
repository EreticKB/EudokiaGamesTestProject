using UnityEngine;

public class MonsterController : MonoBehaviour
{
    MonsterPool[] _monsterPool;
    [SerializeField] int _poolSize;
    [SerializeField] GameObject[] _monsters;
    [SerializeField] Transform _monsterParent;
    [SerializeField] Transform[] _navPoints;


    void Start()
    {
        _monsterPool = new MonsterPool[_monsters.Length];
        for (int i = 0; i < _monsterPool.Length; i++) _monsterPool[i] = new MonsterPool(_poolSize, _monsters[i]);
    }

    public void GetMonster()
    {
        int monsterType = Random.Range(0, _monsters.Length);
        GameObject mon = _monsterPool[monsterType].PullMonster()?.gameObject ?? Instantiate(_monsters[monsterType], _monsterParent);
    }

    public void ForfeitMoster(int monsterType, GameObject monster)
    {
        if (_monsterPool[monsterType].PushMonster(monster)) return;
        Destroy(monster);
    }
}
