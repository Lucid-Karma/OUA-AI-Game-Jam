using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Zombi animasyon kontrol script'i
    private Animator _animator;
    // Zombi'nin hareketini yöneten NavMeshAgent 
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
        // Zombi sürekli oyuncuya bakacak þekilde döndür
        transform.LookAt(player);
        // Zombi konumunu NavMeshAgent konumunun biraz aþaðýsýna ayarla (y ekseni kaydýrma)
        transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y - 0.5f, agent.transform.position.z);
    }

    // Zombiyi öldürme fonksiyonu
    public void KillZombie()
    {
        // "die" tetikleyicisini animasyonda oynat
        _animator.SetTrigger("die");
        // Zombi yok etme iþlemini IEnumerator ile baþlat
        StartCoroutine(DestroyZombie());
    }

    // Zombi yok etme coroutine'i (1 saniye gecikmeli)
    public IEnumerator DestroyZombie()
    {
        // 1.033 saniye bekle (animasyon tamamlanmasý için)
        yield return new WaitForSeconds(1.033f);
        // Zombi GameObject'unu yok et
        Destroy(gameObject);
    }
}

