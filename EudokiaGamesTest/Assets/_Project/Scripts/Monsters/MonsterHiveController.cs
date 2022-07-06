using UnityEngine;

public class MonsterHiveController : MonoBehaviour
{
    MonsterPool[] _monsterPool;
    [SerializeField] int _poolSize;
    [SerializeField] GameObject[] _monsters;
    [SerializeField] Game _game;
    [SerializeField] Transform _monsterParent;
    [SerializeField] Transform[] _navPoints;
    public int MonsterOnField { get; private set; }


    void Start()
    {
        MonsterOnField = 0;
        _monsterPool = new MonsterPool[_monsters.Length];
        for (int i = 0; i < _monsterPool.Length; i++) _monsterPool[i] = new MonsterPool(_poolSize);
    }

    public void SpawnMonster(int difficulty) //предпочел сделать случайный спавн из нескольких контроллируемых точек во избежание застреваний, бустеры полностью на рандоме.
    {
        int monsterType = Random.Range(0, _monsters.Length);
        GameObject monster = _monsterPool[monsterType].PullMonster()?.gameObject ?? Instantiate(_monsters[monsterType], _monsterParent);
        monster.transform.SetParent(_monsterParent);
        monster.transform.position = _navPoints[Random.Range(0, _navPoints.Length)].position;
        monster.GetComponent<MonsterController>().Initialise(this, difficulty);
        MonsterOnField++;
    }

    public void ForfeitMoster(int monsterType, GameObject monster)
    {
        MonsterOnField--;
        _game.AddPoints(50);    
        if (_monsterPool[monsterType].PushMonster(monster)) return;
        Destroy(monster);
    }

    public Transform GetNewNavPoint()
    {
        return _navPoints[Random.Range(0, _navPoints.Length)];
    }

    internal void AddPoints(int points)
    {
        _game.AddPoints(10);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform checkPoint in _navPoints)
        {
            Gizmos.DrawSphere(checkPoint.position, .5f);
        }
        Gizmos.color = Color.blue;
        //Gizmos.DrawSphere(transform.position, 10f);
    }

}
