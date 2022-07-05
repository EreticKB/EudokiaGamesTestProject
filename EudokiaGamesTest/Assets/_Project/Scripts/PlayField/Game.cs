using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] BoosterSpawner _boosterController;
    [SerializeField] int _monsterLimit;
    [SerializeField, ContextMenuItem("SD Base", "DoNothing")] float _spawnDelayTimerBase;
    [SerializeField, Range(0.25f, 4f), ContextMenuItem("SD Multiplier", "DoNothing")] float _spawnDelayTimerMultiplierBase;
    [SerializeField, ContextMenuItem("SD Mult. Minimum", "DoNothing")] float _spawnDelayTimerMultiplierMinimum;
    [SerializeField]float _spawnDelayTimer;
    float _spawnDelayTimerMultiplier;
    [SerializeField] MonsterHiveController _monstersHive;
    [SerializeField] UIController _mainUIController;
    public GameState Status;
    int _difficultyCounter;
    private void Start()
    {
        _difficultyCounter = 0;
        _spawnDelayTimer = _spawnDelayTimerBase;
        _spawnDelayTimerMultiplier = _spawnDelayTimerMultiplierBase;
        _mainUIController.CollectData(_monstersHive.MonsterOnField, _monsterLimit, _difficultyCounter / 10);
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
        _mainUIController.CollectData(_monstersHive.MonsterOnField, _monsterLimit, _difficultyCounter / 10);
        _spawnDelayTimer -= Time.deltaTime;
        if (_spawnDelayTimer > 0) return;
        _difficultyCounter++;
        _spawnDelayTimer = Random.Range(0.5f * _spawnDelayTimerBase, _spawnDelayTimerBase) * _spawnDelayTimerMultiplier;
        if (_spawnDelayTimerMultiplier > _spawnDelayTimerMultiplierMinimum) _spawnDelayTimerMultiplier -= _spawnDelayTimerMultiplierBase * 0.01f;
        _monstersHive.SpawnMonster(_difficultyCounter / 10 + 1);
    }


}
