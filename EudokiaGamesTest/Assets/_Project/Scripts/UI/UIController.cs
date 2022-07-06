using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Text;

public class UIController : MonoBehaviour
{
    [SerializeField] Game _game;
    [SerializeField] GameObject _hitIndicator;
    [SerializeField] TextMeshProUGUI _HPBoost;
    [SerializeField] TextMeshProUGUI _monsterCounter;
    [SerializeField] TextMeshProUGUI _totalPoints;
    [SerializeField] AudioSource _audioSource;
    public readonly string RecordSaveSlotName = "SaveRecord";
    int _difficulty;
    int _monsterLimit;
    int _monsterOnField;


    public void GameStart()
    {
        _game.Status = Game.GameState.Playing;
    }

    private void Update()
    {
        if (_game.Status == Game.GameState.Playing)
        {
            colliderInteraction();
            StringBuilder builder = new StringBuilder();
            //Extra HP for new monsters UI;
            builder.Append("Monster HP: +");
            builder.Append(_difficulty.ToString());
            _HPBoost.text = builder.ToString();
            builder.Clear();
            //Monster counter UI;
            builder.Append("Monster: ");
            builder.Append(_monsterOnField.ToString());
            builder.Append('/');
            builder.Append(_monsterLimit.ToString());
            _monsterCounter.text = builder.ToString();
            builder.Clear();
            //Point UI;
            builder.Append(_game.Points.ToString());
            builder.Append(" pts");
            _totalPoints.text = builder.ToString();
        }
    }

    private void colliderInteraction()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, 8)) return;
        if (hit.collider.CompareTag("Monster"))
        {
            _audioSource.Play();
            hit.collider.GetComponent<MonsterController>().Hit();
            Transform indicator = Instantiate(_hitIndicator, transform).transform;
            indicator.position = Input.mousePosition;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(indicator.DOLocalJump(indicator.localPosition + new Vector3(Screen.width * 0.1f, Screen.height * 0.1f, 0), 2, 1, 1f)).
                Join(indicator.DOScale(new Vector3(0.2f, .2f, 1), 1f)).OnKill(() => Destroy(indicator.gameObject));
        }
        if (hit.collider.CompareTag("Booster")) hit.collider.GetComponent<BoosterDisabling>().Activate();

    }

    internal void CollectData(int monsterOnField, int monsterLimit, int difficulty)
    {
        _monsterOnField = monsterOnField;
        _monsterLimit = monsterLimit;
        _difficulty = difficulty;
    }
    

    public void CloseGame()
    {
        Application.Quit();
    }
}
