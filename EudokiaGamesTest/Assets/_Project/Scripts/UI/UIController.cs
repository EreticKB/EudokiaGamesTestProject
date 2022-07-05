using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] Game _game;
    [SerializeField] GameObject _startButton;
    [SerializeField] GameObject _hitIndicator;
    [SerializeField] TextMeshProUGUI _HPBoost;
    [SerializeField] TextMeshProUGUI _monsterCounter;

    int _difficulty;
    int _monsterLimit;
    int _monsterOnField;


    public void GameStart()
    {
        _game.Status = Game.GameState.Playing;
        _startButton.SetActive(false);
    }

    private void Update()
    {
        if (_game.Status == Game.GameState.Playing)
        {
            colliderInteraction();
            _HPBoost.text = $"Monster HP: +{_difficulty}";
            _monsterCounter.text = $"Monster: {_monsterOnField}/{_monsterLimit}";

        }
    }

    private void colliderInteraction()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, 8)) return;
        if (hit.collider.CompareTag("Monster"))
        {
            hit.collider.GetComponent<MonsterController>().Hit();
            Transform indicator = Instantiate(_hitIndicator, transform).transform;
            indicator.position = Input.mousePosition;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(indicator.DOLocalJump(indicator.localPosition + new Vector3(Screen.width * 0.1f, Screen.height * 0.1f, 0), 2, 1, 1f)).
                Join(indicator.DOScale(new Vector3(0.2f, .2f, 1), 1f)).OnKill(() => Destroy(indicator.gameObject));
        }

    }

    internal void CollectData(int monsterOnField, int monsterLimit, int difficulty)
    {
        _monsterOnField = monsterOnField;
        _monsterLimit = monsterLimit;
        _difficulty = difficulty;
    }
}
