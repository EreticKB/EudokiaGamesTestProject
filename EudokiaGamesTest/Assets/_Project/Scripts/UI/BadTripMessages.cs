using TMPro;
using UnityEngine;
using DG.Tweening;

public class BadTripMessages : MonoBehaviour
{
    public string[] MessageList;
    [SerializeField] TextMeshProUGUI _text;
    private void OnEnable()
    {
        _text.text = MessageList[Random.Range(0, MessageList.Length)];
        Sequence sequence = DOTween.Sequence();
        sequence.
            Append(transform.DOShakePosition(5, 2)).
            Join(DOTween.To(() => _text.color, x => _text.color = x, new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f), 2f).From(Color.white)).
            OnKill(() => Destroy(gameObject));
            
        _text.fontSize = Random.Range(40f, 120f);
        
            
    }
}
