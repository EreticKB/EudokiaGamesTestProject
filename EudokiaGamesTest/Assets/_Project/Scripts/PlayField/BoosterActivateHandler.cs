using UnityEngine;

public class BoosterActivateHandler : MonoBehaviour
{
    public void UseBooster(string boosterName)
    {
        if (boosterName.Equals("Banana")) Debug.Log("Banana");
        if (boosterName.Equals("Burger")) Debug.Log("Burger");
        if (boosterName.Equals("HotDog")) Debug.Log("HotDog");
        if (boosterName.Equals("WaterMelon")) Debug.Log("WaterMelon");
        if (boosterName.Equals("Cherry")) Debug.Log("Cherry");
        if (boosterName.Equals("Cheese")) Debug.Log("Cheese");
        if (boosterName.Equals("Olive")) Debug.Log("Olive");
        Debug.Log("Unknown Booster!");
    }
}
