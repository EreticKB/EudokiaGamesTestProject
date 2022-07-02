using UnityEngine;

public class MonsterTypeID : MonoBehaviour
{
    [SerializeField] int _ID;

    internal int GetID()
    {
        return _ID;
    }
}
