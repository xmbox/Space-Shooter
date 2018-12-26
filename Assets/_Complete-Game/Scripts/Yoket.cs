using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoket : MonoBehaviour
{
    public GameObject patlama;
    public GameObject playerPatlama;

    GameObject OyunKontrol;
    OyunKontrol  kontrol;

    void Start()
    {
        //OyunKontrol aldik
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");

        //Scriptine nasil ulascaz
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Dursun")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(patlama,transform.position, transform.rotation);
            kontrol.ScoreArttir(10);
        }

        if (other.tag == "Player")
        {
            // Instantiate 3 deger aliyordu; olusacak obje, pozisyonu ve rotasyonu
            Instantiate(playerPatlama, other.transform.position, other.transform.rotation);

            // oyunbittiginde gameover yazidracak foksyonu oyunkontrolden cagiriyoruz.
            kontrol.oyunBitti();
        }

    }
}
