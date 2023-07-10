using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBullet : MonoBehaviour
{
    public float bulletDeactivePos;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > bulletDeactivePos || transform.position.y < -bulletDeactivePos)
        {
            gameObject.SetActive(false);
        }
    }
}
