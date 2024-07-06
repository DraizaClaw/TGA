using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUnlock : MonoBehaviour
{

    public bool DashUnlocked;

    private void Awake()
    {
        DashUnlocked = false;
    }

    private void Update()
    {
        if (!DashUnlocked && GameObject.Find("Player") != null)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().CanDash = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DashUnlocked = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().CanDash = true;
        Destroy(gameObject);
    }
}
