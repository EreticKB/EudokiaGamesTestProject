using UnityEngine;

public class MonsterHiveController : MonoBehaviour
{
    MonsterPool[] _monsterPool;
    [SerializeField] int _poolSize;
    [SerializeField] GameObject[] _monsters;
    [SerializeField] Transform _monsterParent;
    [SerializeField] Transform[] _navPoints;


    void Start()
    {
        _monsterPool = new MonsterPool[_monsters.Length];
        for (int i = 0; i < _monsterPool.Length; i++) _monsterPool[i] = new MonsterPool(_poolSize);
    }

    public void SpawnMonster()
    {
        int monsterType = Random.Range(0, _monsters.Length);
        GameObject monster = _monsterPool[monsterType].PullMonster()?.gameObject ?? Instantiate(_monsters[monsterType], _monsterParent);
        monster.transform.SetParent(_monsterParent);
        monster.transform.position = _navPoints[Random.Range(0, _navPoints.Length)].position;
        monster.GetComponent<MonsterController>()._overMind = this;
    }

    public void ForfeitMoster(int monsterType, GameObject monster)
    {
        if (_monsterPool[monsterType].PushMonster(monster)) return;
        Destroy(monster);
    }

    public Transform GetNewNavPoint()
    {
        return _navPoints[Random.Range(0, _navPoints.Length)];
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform checkPoint in _navPoints)
        {
            Gizmos.DrawSphere(checkPoint.position, .5f);
        }
    }
}
