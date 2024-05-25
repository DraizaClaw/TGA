using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private GameObject DeathScreen;


    private void Start()
    {
        DeathScreen.SetActive(false);
    }

    private void Update()
    {
        if (target != null)
        {
            transform.localPosition = target.transform.position;
        }
        else
        {
            print("Explosion");
            target = gameObject;
            StartCoroutine(PlayParticleSystem());
        }
    }

    IEnumerator PlayParticleSystem()
    {
        GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().startLifetime);

        Time.timeScale = 0;
        DeathScreen.SetActive(true);

        Destroy(gameObject);
    }

}
