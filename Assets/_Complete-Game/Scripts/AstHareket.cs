using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstHareket : MonoBehaviour
{
    Rigidbody fizik;
    public float hiz;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        //transformun yani bulundugu noktanin ilerisinde hareket etsin diyoruz
        fizik.velocity = transform.forward * hiz;
    }
}
