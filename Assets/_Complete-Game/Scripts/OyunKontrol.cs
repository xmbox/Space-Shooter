using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{

    public GameObject Asteroid;
    // vector3 3 deger aliyor. Burada x verdik ama asagida x hem eksi hem arti iki deger alacak.
    public Vector3 randomPos;

    public float basBekle;
    public float olBekle;
    public float donBekle;
    public Text text;
    public Text oyunBittiText;
    public Text reStart;
    bool oyunBittiKontrol = false;

    //yenıden baslatmak ıcın bır boolen tanimlayalim
    bool yenidenBaslat = false;

    int score;

    void Start()
    {
        score = 0;
        text.text = "Score = " + score;
        StartCoroutine(olustur());
    }

    // mouse ve klavyeden girilen degerleri burada yaziyorduk
    void Update()
    {
        //Input.GetKeyDown metodu ile klavyeden basilan tusu KeyCode ile aliyoruz
        if (Input.GetKeyDown(KeyCode.R) && yenidenBaslat)
        {
            SceneManager.LoadScene("level1");
        }
    }

    IEnumerator olustur()
    {
        // Random.Range= iki nokta arasinda random bir deger alan parametre
        // Random.Range(-randomPos.x, randomPos.x) Xin eksi ve artisi arasinda deger alacak

        yield return new WaitForSeconds(basBekle);

        while (true)
        {
            //while true dongusu sonsuza kadar doner

            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);

                yield return new WaitForSeconds(olBekle);
            }

            //taslarin oyun bittiginde cikmamasi isin

            if (oyunBittiKontrol)
            {
                reStart.text = "Yeniden Baslatmak icin R tusuna bas!";
                yenidenBaslat = true;
                break;
            }

            yield return new WaitForSeconds(donBekle);
        }



    }

    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        text.text = "Score = " + score;
    }

    public void oyunBitti()
    {
        oyunBittiText.text = "OYUN BITTI!";
        oyunBittiKontrol = true;
    }


}
