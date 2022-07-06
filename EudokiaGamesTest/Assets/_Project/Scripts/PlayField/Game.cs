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
    [SerializeField] GameObject _endMenuPanel;
    [SerializeField] GameObject _gameUI;
    public GameState Status;
    int _difficultyCounter;
    public int Points { get; private set; }
    private void Start()
    {
        _difficultyCounter = 0;
        _spawnDelayTimer = _spawnDelayTimerBase/5;
        _spawnDelayTimerMultiplier = _spawnDelayTimerMultiplierBase;
        _mainUIController.CollectData(_monstersHive.MonsterOnField, _monsterLimit, _difficultyCounter / 10);
    }

    public enum GameState
    {
        Menu,
        Playing,
        Death
    }
    /// <summary>
    /// Used for transfer long names, which becomes nonreadable in the Inspector, to context menu.
    /// </summary>
    private void DoNothing()
    {
        //it's does stuff, lol. DoingStuff(() => ("") (.)(.) (""))
    }

    private void Update()
    {
        if (Status == GameState.Playing && _monstersHive.MonsterOnField >= _monsterLimit) gamover();
        if (Status != GameState.Playing) return;
        _mainUIController.CollectData(_monstersHive.MonsterOnField, _monsterLimit, _difficultyCounter / 10);
        _spawnDelayTimer -= Time.deltaTime;
        if (_spawnDelayTimer > 0) return;
        _difficultyCounter++;
        _spawnDelayTimer = Random.Range(0.5f * _spawnDelayTimerBase, _spawnDelayTimerBase) * _spawnDelayTimerMultiplier;
        if (_spawnDelayTimerMultiplier > _spawnDelayTimerMultiplierMinimum) _spawnDelayTimerMultiplier -= _spawnDelayTimerMultiplierBase * 0.01f;
        _monstersHive.SpawnMonster(_difficultyCounter / 10 + 1);
    }

    private void gamover() //Читать как "гамовер".
    {
        Status = GameState.Death;
        _endMenuPanel.SetActive(true);
        _gameUI.SetActive(false);
        _endMenuPanel.GetComponent<EndMenuController>().Fill(Points, _difficultyCounter-_monsterLimit);
    }

    public void ExtendSpawnDelay(float time)
    {
        _spawnDelayTimer -= time;
    }

    /// <summary>
    /// If "<see cref="flat"/>" is false, then "<see cref="points"/>" means percent from total points.
    /// </summary>
    /// <param name="points"></param>
    /// <param name="flat"></param>
    public void AddPoints(int points, bool flat)
    {
        if (flat) Points += points;
        else Points += (Points * points) / 100;
    }
    /// <summary>
    /// Add "<see cref="points"/>" as flat number.
    /// </summary>
    /// <param name="points"></param>
    public void AddPoints(int points)
    {
        AddPoints(points, true);
    }

}
