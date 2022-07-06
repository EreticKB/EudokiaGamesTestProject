using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _AI;
     MonsterHiveController _overMind;
    [SerializeField] float _goalCompleteRadius;
    [SerializeField] Animator _animator;
    [SerializeField] MonsterTypeID _ID;
    [SerializeField] float _initialSpeed;
    [SerializeField]int _monsterHP;
    bool _initialised;

    private void Update()
    {
        if (!_initialised) return;
        if (Vector3.SqrMagnitude(transform.position - _AI.destination) < _goalCompleteRadius * _goalCompleteRadius) GetNewGoal();
        if (_monsterHP < 1) _overMind.ForfeitMoster(_ID.GetID(), gameObject);
    }
    
    internal void Initialise(MonsterHiveController hive, int difficulty)
    {
        _AI.enabled = true;
        _animator.enabled = true;
        _overMind = hive;
        GetNewGoal();
        _animator.SetBool("Walking", true);
        int size = Random.Range(1, 3);
        transform.localScale = new Vector3(size, size, size);
        _AI.speed = (_initialSpeed * difficulty) / (2 * size);
        _monsterHP = difficulty + size - 1;
        _initialised = true;
    }
    private void GetNewGoal()
    {
        _AI.destination = _overMind.GetNewNavPoint().position;
    }

    internal void Slow()
    {
        _AI.speed -= _AI.speed / 2;
    }

    internal void Freeze()
    {
        StopAllCoroutines();
        _AI.enabled = false;
        _animator.enabled = false;
        StartCoroutine(UnFreeze(Random.Range(3,8)));
    }
    
    IEnumerator UnFreeze(float timer)
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        _AI.enabled = true;
        _animator.enabled = true;
    }

    internal void Hit()
    {
        _monsterHP--;
        _overMind.AddPoints(10);
    }
    private void OnDisable()
    {
        _initialised = false;
    }

    internal void Lure()
    {
        _AI.destination = Vector3.zero;
    }
}
