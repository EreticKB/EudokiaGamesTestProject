using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BadTripController : MonoBehaviour
{
    [SerializeField] Image _colorFilter;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Sprite _monster;
    Sequence sequence;
    float _messagesDelay;
    float _pastaMonsterLookAtYouTimer;


    private void Awake()
    {
        sequence = DOTween.Sequence();
        sequence.
             Append(DOTween.To(() => _colorFilter.color, x => _colorFilter.color = x, new Color(1f, 0f, 0f, 0.5f), .2f)).
             Append(DOTween.To(() => _colorFilter.color, x => _colorFilter.color = x, new Color(1f, 1f, 0f, 0.5f), .2f)).
             Append(DOTween.To(() => _colorFilter.color, x => _colorFilter.color = x, new Color(0f, 1f, 0f, 0.5f), .2f)).
             Append(DOTween.To(() => _colorFilter.color, x => _colorFilter.color = x, new Color(0f, 1f, 1f, 0.5f), .2f)).
             Append(DOTween.To(() => _colorFilter.color, x => _colorFilter.color = x, new Color(0f, 0f, 1f, 0.5f), .2f)).
             Append(DOTween.To(() => _colorFilter.color, x => _colorFilter.color = x, new Color(1f, 0f, 1f, 0.5f), .2f)).
             Append(DOTween.To(() => _colorFilter.color, x => _colorFilter.color = x, new Color(1f, 0f, 0f, 0.5f), .2f)).
             SetLoops(-1);
        sequence.Pause();
        //  _colorFilter.DOColor("FFFFFF", 1); CS1929 нет времени выяснять, где баг вылез.
    }

    private void OnEnable()
    {
        _messagesDelay = 0.5f;
        sequence.Play();
    }
    private void OnDisable()
    {
        sequence.Pause();
    }

    private void Update()
    {
        _pastaMonsterLookAtYouTimer -= Time.deltaTime;
        _messagesDelay -= Time.deltaTime;
        if (_messagesDelay < 0)
        {
            _messagesDelay = 2.1f;
            Instantiate(_text, transform).transform.position = new Vector2(Random.Range(Screen.width*0.15f, Screen.width * 0.85f), Random.Range(Screen.height * 0.15f, Screen.height * 0.85f));
            if (Random.Range(0, 1000f) > 750f) _colorFilter.sprite = _monster;
            _pastaMonsterLookAtYouTimer = 0.25f;
        }
        if (_pastaMonsterLookAtYouTimer > 0) return;
        _colorFilter.sprite = null;
    }
}
