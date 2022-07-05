using UnityEngine;

public class BoosterDisabling : MonoBehaviour
{
    [SerializeField]float _lifespan;

    private void Update()
    {
        _lifespan -= Time.deltaTime;
        if (_lifespan > 0) return;
        Destroy(gameObject);
    }

    public void Activate()
    {
        //GetComponentInParent<BoosterActivateHandler>();
    }

}
