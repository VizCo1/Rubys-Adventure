using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    public ParticleSystem HealingEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                Instantiate(HealingEffect, pos, Quaternion.identity);
                controller.ChangeHealth(1);
                Destroy(gameObject);

                controller.PlaySound(collectedClip);
            }
        }
    }
}
