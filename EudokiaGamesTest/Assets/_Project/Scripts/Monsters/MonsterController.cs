using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _AI;
    internal MonsterHiveController _overMind;
    [SerializeField] float _goalCompleteRadius;
    [SerializeField] MonsterTypeID _ID;

    private void Start()
    {
        _AI.destination =_overMind.GetNewNavPoint().position;
        Debug.Log($"{_AI.destination} + {_ID.GetID()}");
    }
    private void Update()
    {
        if (Vector3.SqrMagnitude(transform.position - _AI.destination) < _goalCompleteRadius * _goalCompleteRadius) Start();
    }
}
