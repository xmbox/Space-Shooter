using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotasyon : MonoBehaviour
{

    Rigidbody fizik;
    public float hiz;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.angularVelocity = Random.insideUnitSphere*hiz;
    }

}
