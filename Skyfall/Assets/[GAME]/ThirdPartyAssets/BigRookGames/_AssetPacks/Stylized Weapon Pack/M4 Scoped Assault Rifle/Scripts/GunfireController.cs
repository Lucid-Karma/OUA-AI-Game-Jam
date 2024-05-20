using UnityEngine;

namespace BigRookGames.Weapons
{
    public class GunfireController : MonoBehaviour
    {
        // --- Ses ---
        public AudioClip GunShotClip; // Silah sesi klibi
        public AudioSource source; // Ses kaynağı
        public Vector2 audioPitch = new Vector2(.9f, 1.1f); // Ses perdesi aralığı

        // --- Namlu ---
        public GameObject muzzlePrefab; // Namlu flaşı prefab'ı
        public GameObject muzzlePosition; // Namlu pozisyonu

        // --- Konfigürasyon ---
        public bool rotate = true; // Dönme
        public float rotationSpeed = .25f; // Dönme hızı


        // --- Mermi ---
        [Tooltip("Her ateşlemede oluşturulacak mermi nesnesi.")]
        public GameObject projectilePrefab; // Mermi prefab'ı
        [Tooltip("Bazen ateşlemede bir mesh'i devre dışı bırakmak gerekir. Örneğin, roket fırlatıldığında, yeni bir roket oluşturulur ve roketatarın görünür roketi devre dışı bırakılır.")]
        public GameObject projectileToDisableOnFire; // Ateşleme sırasında devre dışı bırakılacak mermi nesnesi

        // --- Zamanlama ---
        [SerializeField] private float timeLastFired; // Son ateşleme zamanı

        private void Start()
        {
            // Ses kaynağını ayarla
            if (source != null) source.clip = GunShotClip;
            timeLastFired = 0;
        }

        private void Update()
        {
            // --- Eğer döndürme aktifse, silahı sahnede döndür ---
            if (rotate)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + rotationSpeed, transform.localEulerAngles.z);
            }

            // --- Sol fare tuşuna basıldığında ateşle ---
            if (Input.GetMouseButtonDown(0))
            {
                FireWeapon();
            }
        }

        /// <summary>
        /// Namlu flaşı oluşturur.
        /// Ayrıca her ateşlemede yeni bir ses kaynağı oluşturur, böylece birden fazla atış aynı ses kaynağında üst üste binmez.
        /// Bu işlevde mermi kodunu ekleyin.
        /// </summary>
        public void FireWeapon()
        {
            // --- Silahın ateşlendiği zamanı takip et ---
            timeLastFired = Time.time;

            // --- Namlu flaşını oluştur ---
            var flash = Instantiate(muzzlePrefab, muzzlePosition.transform);

            // --- Mermi nesnesini oluştur ve ateşle ---
            if (projectilePrefab != null)
            {
                GameObject newProjectile = Instantiate(projectilePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation, transform);
            }

            // --- Gerekirse oyun nesnelerini devre dışı bırak ---
            if (projectileToDisableOnFire != null)
            {
                projectileToDisableOnFire.SetActive(false);
                Invoke("ReEnableDisabledProjectile", 3);
            }

            // --- Sesleri yönet ---
            if (source != null)
            {
                if (source.transform.IsChildOf(transform))
                {
                    source.Play();
                }
                else
                {
                    // --- Ses için prefab'ı oluştur, birkaç saniye sonra sil ---
                    AudioSource newAS = Instantiate(source);
                    if ((newAS = Instantiate(source)) != null && newAS.outputAudioMixerGroup != null && newAS.outputAudioMixerGroup.audioMixer != null)
                    {
                        // --- Tekrarlanan atışlara çeşitlilik katmak için perdeyi değiştir ---
                        newAS.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", Random.Range(audioPitch.x, audioPitch.y));
                        newAS.pitch = Random.Range(audioPitch.x, audioPitch.y);

                        // --- Silah sesini çal ---
                        newAS.PlayOneShot(GunShotClip);

                        // --- Birkaç saniye sonra kaldır. Test script'i sadece. ---
                        Destroy(newAS.gameObject, 4);
                    }
                }
            }
        }

        private void ReEnableDisabledProjectile()
        {
            projectileToDisableOnFire.SetActive(true); // Devre dışı bırakılan mermiyi yeniden etkinleştir
        }
    }
}
