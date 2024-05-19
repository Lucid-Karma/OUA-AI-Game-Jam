//  config dosyası parametreleri en altta verilmiştir.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class AI_Chaserp : Agent
{
    private Rigidbody rbody;
    public Transform Hedef;
    public float carpan = 5f;
    private Vector3 startingPosition; // Düşman aşlangıç pozisyonunu saklama

    // Başlangıçta çalıştırılacak kodlar
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        startingPosition = transform.localPosition; // Başlangıç pozisyonunu kaydet
    }

    // Bölüm başlangıcında çalıştırılacak kodlar
    public override void OnEpisodeBegin()
    {
        ResetAgent(); // Düşman sıfırlama
    }

    // Gözlemleri toplama
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Hedef.localPosition);
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(rbody.velocity.x);
        sensor.AddObservation(rbody.velocity.z);
    }

    // Aksiyonları alındığında çalıştırılacak kodlar
    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actions.ContinuousActions[0];
        controlSignal.z = actions.ContinuousActions[1];
        rbody.AddForce(controlSignal * carpan);

        float distanceToTarget = Vector3.Distance(transform.localPosition, Hedef.localPosition);
        if (distanceToTarget < 0.05f) // Hedefe ulaşma mesafesi
        {
            SetReward(1.0f);
            ResetAgent(); // Düşman sıfırlama
        }

        if (transform.localPosition.y < 0f)
        {
            SetReward(-1.0f);
            ResetAgent(); // Düşman sıfırlama
        }
    }

    // Dışarıdan kontrol için kullanılacak kodlar
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }

    // Düşmanı ve hedefi sıfırlama fonksiyonu
    private void ResetAgent()
    {
        // Düşmanı sıfırlama
        rbody.angularVelocity = Vector3.zero;
        rbody.velocity = Vector3.zero;
        transform.localPosition = startingPosition;

        // Hedefi rastgele bir pozisyona taşıma (eğitim sırasında kullanıldı)
        //Hedef.localPosition = new Vector3(Random.Range(-0.5f, 0.5f), 1f, Random.Range(-0.5f, 0.5f));
    }
}

/*
behaviors:
  MeteorYonelmeSon:
    trainer_type: ppo
    hyperparameters:
      batch_size: 128  # Daha yüksek batch size daha fazla deneyim toplar
      buffer_size: 4096  # Daha büyük buffer size daha fazla öğrenme örneği toplar
      learning_rate: 1.0e-4  # Daha düşük öğrenme oranı daha yavaş ama daha kararlı öğrenme sağlar
      beta: 5.0e-4
      epsilon: 0.2
      lambd: 0.95
      num_epoch: 4  # Daha fazla epoch her batch üzerinde daha fazla eğitim sağlar
      learning_rate_schedule: linear
      beta_schedule: constant
    network_settings:
      normalize: true
      hidden_units: 256  # Daha fazla hidden unit daha karmaşık ilişkileri öğrenebilir
      num_layers: 3  # Daha fazla katman daha derin öğrenme sağlar
    reward_signals:
      extrinsic:
        gamma: 0.99
        strength: 1.0
    max_steps: 1000000  # Eğitim süresini uzatmak için daha fazla adım
    time_horizon: 64
    summary_freq: 10000  # Daha sık özet güncellemeleri
*/