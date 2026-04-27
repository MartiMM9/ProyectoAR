using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private Image[] vingetteEffect;
    private float timeSinceHit;
    [SerializeField] private float healingCooldown;

    private void Start()
    {
        StartCoroutine(HealingOverTime());
    }

    private void Update()
    {
        timeSinceHit += Time.deltaTime;
    }

    public void TakeDamage(float _damage)
    {
        Debug.Log("au");
        life -= _damage;
        timeSinceHit = 0;
        if(life <= 0)
        {
            Debug.Log("te morite");
            life = 0;
            //morite
        }
        VignetteEffectLifeSync();
    }

    private void VignetteEffectLifeSync()
    {
        for (int i = 0; i < vingetteEffect.Length; i++)
        {
            Color c = vingetteEffect[i].color;
            c.a = 1 - life / 100;
            vingetteEffect[i].color = c;
        }
    }

    IEnumerator HealingOverTime()
    {
        while (true)
        {
            if(timeSinceHit > healingCooldown)
            {
                life += 1;
                if(life >= 100)
                {
                    life = 100;
                }
                VignetteEffectLifeSync();
                Debug.Log("curo");
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
