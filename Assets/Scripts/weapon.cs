using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        Destroy(other.gameObject);
    //        Destroy(gameObject);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
