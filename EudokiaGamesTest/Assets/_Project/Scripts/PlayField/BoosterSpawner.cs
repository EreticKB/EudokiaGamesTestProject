using UnityEngine;
using UnityEngine.AI;

public class BoosterSpawner : MonoBehaviour
{
    [SerializeField] Game _gameScript;
    [SerializeField] GameObject[] _boosters;
    [SerializeField] float _spawnDelayBase;
    [SerializeField] float _spawnDelayTimer = 0;
    //вместо флажка вкл/выкл буду использовать само включение и отключение компонента.    

    private void OnEnable()
    {
        _spawnDelayTimer = Random.Range(_spawnDelayBase * 0.25f, 2 * _spawnDelayBase);
    }
    private void Update()
    {
        if (_gameScript.Status != Game.GameState.Playing) return;
        _spawnDelayTimer -= Time.deltaTime;
        if (_spawnDelayTimer > 0) return;
        _spawnDelayTimer = Random.Range(_spawnDelayBase * 0.25f, 2 * _spawnDelayBase);
        NavMeshHit hit = new NavMeshHit();
        while (!NavMesh.SamplePosition(new Vector3(Random.Range(-5, 5), 0f, Random.Range(-9, 9)), out hit, 0.2f, NavMesh.AllAreas)) ;
        Instantiate(_boosters[Random.Range(0, _boosters.Length)], transform).
            transform.position = hit.position;

    }

}
