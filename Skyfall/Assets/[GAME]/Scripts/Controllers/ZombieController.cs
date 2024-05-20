using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    Animator _animator;
    public GameObject agent;
    public Transform player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.LookAt(player);
        transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y - 0.5f, agent.transform.position.z);
    }

    public void KillZombie()
    {
        _animator.SetTrigger("die");
        StartCoroutine(DestroyZombie());
    }

    public IEnumerator DestroyZombie()
    {
        yield return new WaitForSeconds(1.033f);
        Destroy(gameObject);
    }
}
