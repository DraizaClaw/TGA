using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private PolygonCollider2D colliderforpolygon;

    private void Awake()
    {
        colliderforpolygon = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("setting player prefs");
            PlayerPrefs.SetInt("Player Pos X", Mathf.RoundToInt(transform.position.x));
            PlayerPrefs.SetInt("Player Pos Y", Mathf.RoundToInt(transform.position.y));
            PlayerPrefs.SetInt("Player Pos Z", Mathf.RoundToInt(transform.position.z));
        }
        
    }

    private void Update()
    {
        print(PlayerPrefs.GetInt("Player Pos X"));
        print(PlayerPrefs.GetInt("Player Pos Y"));
        print(PlayerPrefs.GetInt("Player Pos Z"));
    }





}
