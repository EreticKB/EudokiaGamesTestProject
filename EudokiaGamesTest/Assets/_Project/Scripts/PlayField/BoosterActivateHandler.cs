using UnityEngine;

public class BoosterActivateHandler : MonoBehaviour
{
    [SerializeField] GameObject BadTrip;
    [SerializeField] Game _game;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip[] _sounds;
    public void HandleBooster(string boosterName)
    {
        if (boosterName.Equals("Banana")) UseBooster("Banana");
        else if (boosterName.Equals("Burger")) ChargeBoooster("Burger");
        else if (boosterName.Equals("HotDog")) ChargeBoooster("HotDog");
        else if (boosterName.Equals("WaterMelon")) ChargeBoooster("WaterMelon");
        else if (boosterName.Equals("Cherry")) UseBooster("Cherry");
        else if (boosterName.Equals("Cheese")) BadTripActive();
        else if (boosterName.Equals("Olive")) ChargeBoooster("Olive");
        else Debug.Log("Unknown Booster!");
    }

    //=================
    private void ChargeBoooster(string type)
    {
        Collider[] detected = Physics.OverlapSphere(Vector3.zero, 11, 8);
        if (detected.Length == 0) return;
        for (int i = 0; i < detected.Length; i++)
        {
            if (!detected[i].CompareTag("Monster")) continue;
            UseBooster(detected[i], type);
        }
    }
    private void UseBooster(Collider detected, string type)
    {
        if (type.Equals("Burger"))
        {
            detected.GetComponent<MonsterController>().Freeze();
            _audioSource.clip = _sounds[0];
        }
        else if (type.Equals("HotDog"))
        {
            detected.GetComponent<MonsterController>().Lure();
            _audioSource.clip = _sounds[1];
        }
        else if (type.Equals("WaterMelon"))
        {
            detected.GetComponent<MonsterController>().Hit();
            _audioSource.clip = _sounds[2];
        }
        else if (type.Equals("Olive"))
        {
            detected.GetComponent<MonsterController>().Slow();
            _audioSource.clip = _sounds[3];
        }
        _audioSource.Play();
    }
    
    private void UseBooster(string type)
    {
        if (type.Equals("Banana"))
        {
            _game.ExtendSpawnDelay(3f);
            _audioSource.clip = _sounds[5];
        }
        else if (type.Equals("Cherry"))
        {
            _audioSource.clip = _sounds[4];
            _game.AddPoints(10, false);
        }
        
        _audioSource.Play();
    }
    

    //====================

    private void BadTripActive()
    {
        BadTrip.SetActive(true);
        BadTrip.GetComponent<BadTripController>().Extend();
    }
}
