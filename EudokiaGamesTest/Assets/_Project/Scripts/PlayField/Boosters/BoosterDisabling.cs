using UnityEngine;

public class BoosterDisabling : MonoBehaviour
{
    [SerializeField]float _lifespan;
    [SerializeField] string _name;

    private void Update()
    {
        _lifespan -= Time.deltaTime;
        if (_lifespan > 0) return;
        Destroy(gameObject);
    }

    public void Activate()
    {
        GetComponentInParent<BoosterActivateHandler>().HandleBooster(_name);
        Destroy(gameObject);
    }

}
