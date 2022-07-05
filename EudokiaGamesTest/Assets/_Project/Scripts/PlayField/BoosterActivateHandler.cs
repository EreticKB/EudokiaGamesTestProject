using UnityEngine;

public class BoosterActivateHandler : MonoBehaviour
{
    [SerializeField] GameObject BadTrip;
    [SerializeField] Game _game;
    public void UseBooster(string boosterName)
    {
        if (boosterName.Equals("Banana")) _game.ExtendSpawnDelay(3f);
        else if (boosterName.Equals("Burger")) ChargeBoooster("Burger");
        else if (boosterName.Equals("HotDog")) ChargeBoooster("HotDog");
        else if (boosterName.Equals("WaterMelon")) ChargeBoooster("WaterMelon");
        else if (boosterName.Equals("Cherry")) Debug.Log("Cherry");
        else if (boosterName.Equals("Cheese")) BadTripActive();
        else if (boosterName.Equals("Olive")) ChargeBoooster("Olive");
        else Debug.Log("Unknown Booster!");
    }

    //=================
    private void ChargeBoooster(string type)
    {
        Collider[] detected = Physics.OverlapSphere(Vector3.zero, 15, 8);
        if (detected.Length == 0) return;
        for (int i = 0; i < detected.Length; i++)
        {
            if (!detected[i].CompareTag("Monster")) continue;
            UseBooster(detected[i], type);
        }
    }
    private void UseBooster(Collider detected, string type)
    {
        if (type.Equals("Burger")) detected.GetComponent<MonsterController>().Freeze();
        else if (type.Equals("HotDog")) detected.GetComponent<MonsterController>().Lure();
        else if (type.Equals("WaterMelon")) detected.GetComponent<MonsterController>().Hit();
        else if (type.Equals("Olive")) detected.GetComponent<MonsterController>().Slow();
    }

    //====================

    private void BadTripActive()
    {
        BadTrip.SetActive(true);
        BadTrip.GetComponent<BadTripController>().Extend();
    }
}
