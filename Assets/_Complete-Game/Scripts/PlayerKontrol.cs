using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour {


    Rigidbody fizik;

    float horizontal = 0;
    float vertical = 0;

    Vector3 vec;

    public float PlayerHiz;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float egim;
    float fireTime = 0;
    public float atesSure;
    public GameObject Kursun;
    public Transform KursunCikisYeri;
    AudioSource ses;

	void Start () {

        fizik = GetComponent<Rigidbody>();
        ses = GetComponent<AudioSource>();
		
	}

    // bizim mouse ve klavyeden gelen seyleri burada yazmamiz gerekiyormus!
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>fireTime)
        {
            fireTime = Time.time + atesSure;
            Instantiate(Kursun, KursunCikisYeri.position,Quaternion.identity);
            ses.Play();
        }
    }


    void FixedUpdate () {

        fizik = GetComponent<Rigidbody>();

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vec = new Vector3(horizontal,0,vertical);

        //velocity ile karakter hizini ayarliyoruz
        fizik.velocity = vec * PlayerHiz;

        //objenin ekran disina tasmasini onlemek icin sinirlarini belirleyelim
        fizik.position = new Vector3(

            //Xin maximum ve minimum degerlerini ayarliyoruz
            Mathf.Clamp(fizik.position.x,minX,maxX),
            0,
            //Zin maximum ve minimum degerlerini ayarliyoruz
            Mathf.Clamp(fizik.position.z,minZ,maxZ)
            );

        // ucagin saga sola gderken hafif yan yatmasini saglayalim
        fizik.rotation = Quaternion.Euler(0,0,fizik.velocity.x*-egim);

    }
}
