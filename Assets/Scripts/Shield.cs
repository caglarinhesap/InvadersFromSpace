using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite[] shieldStates;
    private int health;
    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("FriendlyBullet"))
        {
            collision.gameObject.SetActive(false);
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                sr.sprite = shieldStates[health - 1];
            }
        }
    }
}
