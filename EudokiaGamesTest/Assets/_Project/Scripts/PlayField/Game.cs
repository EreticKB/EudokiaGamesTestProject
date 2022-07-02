using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] int _monsterLimit;
    [SerializeField] int _monsterOnField;
    [SerializeField, ContextMenuItem("SD Base", "DoNothing")] float _spawnDelayTimerBase;
    [SerializeField, Range(0.25f, 4f), ContextMenuItem("SD Multiplier", "DoNothing")] float _spawnDelayTimerMultiplierBase;
    [SerializeField, ContextMenuItem("SD Mult. Minimum", "DoNothing")] float _spawnDelayTimerMultiplierMinimum;
    [SerializeField]float _spawnDelayTimer;
    float _spawnDelayTimerMultiplier;
    [SerializeField] MonsterHiveController _monstersHive;
    public GameState Status;

    private void Start()
    {
        _spawnDelayTimer = _spawnDelayTimerBase;
        _spawnDelayTimerMultiplier = _spawnDelayTimerMultiplierBase;
    }

    public enum GameState
    {
        Menu,
        Playing,
        Death
    }
    private void DoNothing()
    {
        //it's does stuff, lol. DoingStuff(() => ("") (.)(.) (""))
    }

    private void Update()
    {
        if (Status == GameState.Playing) playScriptWrapper();
    }

    private void playScriptWrapper()
    {
        _spawnDelayTimer -= Time.deltaTime;
        if (_spawnDelayTimer > 0) return;
        _spawnDelayTimer = Random.Range(0.5f * _spawnDelayTimerBase, _spawnDelayTimerBase) * _spawnDelayTimerMultiplier;
        if (_spawnDelayTimerMultiplier > _spawnDelayTimerMultiplierMinimum) _spawnDelayTimerMultiplier -= _spawnDelayTimerMultiplierBase * 0.01f;
        _monstersHive.SpawnMonster();

    }

}
