using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Zombi animasyon kontrol script'i
    private Animator _animator;
    // Zombi'nin hareketini y�neten NavMeshAgent 
    public GameObject agent;
    // Oyuncu transform bilgisi 
    public Transform player;

    private void Start()
    {
        // Zombi GameObject'inden Animator component'ini al
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Zombi s�rekli oyuncuya bakacak �ekilde d�nd�r
        transform.LookAt(player);
        // Zombi konumunu NavMeshAgent konumunun biraz a�a��s�na ayarla (y ekseni kayd�rma)
        transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y - 0.5f, agent.transform.position.z);

        AttackPlayer();
    }

    // Zombiyi �ld�rme fonksiyonu
    public void KillZombie()
    {
        // "die" tetikleyicisini animasyonda oynat
        _animator.SetTrigger("die");
        // Zombi yok etme i�lemini IEnumerator ile ba�lat
        StartCoroutine(DestroyZombie());
    }

    // Zombi yok etme coroutine'i (1 saniye gecikmeli)
    public IEnumerator DestroyZombie()
    {
        // 1.033 saniye bekle (animasyon tamamlanmas� i�in)
        yield return new WaitForSeconds(1.033f);
        // Zombi GameObject'unu yok et
        Destroy(gameObject);
    }

    public void AttackPlayer()
    {
        // playerla olan mesafeyi hesapla.
        float distanceToTarget = Vector3.Distance(transform.localPosition, player.localPosition);
        if (distanceToTarget < 3f) // Hedefe ula�ma mesafesi
        {
            _animator.SetTrigger("attack");
        }
    }
}

