using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.PlayerLoop;
using Unity.VisualScripting;

public class ScoreController : MonoBehaviour
{
    public AudioSource trueNuts;
    public AudioSource falseNuts;
    public int count;
    public TextMeshProUGUI countText;
    public bool winPartCount;
    public GameObject[] scoreImage;
    public int winPart;
    [SerializeField] private RectTransform winPanel;

    [SerializeField] private List<GameObject> acornDrop = new List<GameObject>();
    [SerializeField] private List<GameObject> hazelnutDrop = new List<GameObject>();
    [SerializeField] private List<GameObject> walnutDrop = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            count = 4;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        //Acorn score ++ 
        if (winPartCount == false && scoreImage[0].activeInHierarchy == false && scoreImage[1].activeInHierarchy == false)
        {
            if (collision.gameObject.tag == "acorn")
            {
                count++;
                countText.text = count.ToString();
                Destroy(collision.gameObject);
                trueNuts.Play();
            }

            if (winPartCount == false && collision.gameObject.tag == "walnut" || collision.gameObject.tag == "hazelnut")
            {
                Destroy(collision.gameObject);
                count--;
                countText.text = count.ToString();
                falseNuts.Play();

            }

            if (count >= 5)
            {
                winPartCount = true;
            }

            else if (count <= 0)
            {
                count = 0;
                countText.text = count.ToString();
            }
           
        }



        //Hazelnut score ++ 
        if (winPartCount == false && scoreImage[1].activeInHierarchy == false  && scoreImage[0].activeInHierarchy == true)
        {
            if (collision.gameObject.tag == "hazelnut")
            {

                count++;
                countText.text = count.ToString();
                Destroy(collision.gameObject);
                trueNuts.Play();
            }
            if (winPartCount == false && collision.gameObject.tag == "walnut" || collision.gameObject.tag == "acorn")
            {
                Destroy(collision.gameObject);
                count--;
                countText.text = count.ToString();
                falseNuts.Play();
            }
            if (count >= 5)
            {
                winPartCount = true;
            }

            else if (count <= 0)
            {
                count = 0;
                countText.text = count.ToString();
            }

        }



        //Walnut score ++ 
        if (winPartCount == false && scoreImage[0].activeInHierarchy == false && scoreImage[1].activeInHierarchy == true)
        {
            if (collision.gameObject.tag == "walnut")
            {
                count++;
                countText.text = count.ToString();
                Destroy(collision.gameObject);
                trueNuts.Play();
            }
            if (winPartCount == false && collision.gameObject.tag == "hazelnut" || collision.gameObject.tag == "acorn")
            {
                Destroy(collision.gameObject);
                count--;
                countText.text = count.ToString();
                falseNuts.Play();
            }
            if (count >= 5)
            {
                winPartCount = true;
            }

            else if (count <= 0)
            {
                count = 0;
                countText.text = count.ToString();
            }

        }

        


        if (collision.gameObject.tag == "scorecontrol" && count == 5)
        {
            for (int i = 0; i < acornDrop.Count; i++)
            {
                acornDrop[i].SetActive(true);
                acornDrop[i].GetComponent<Rigidbody2D>().gravityScale = 1;
            }

            Debug.Log("hata");
            count = 0;
            countText.text = count.ToString();
            winPartCount = false;
            winPart++;
            scoreImage[0].SetActive(true);
        }

        if(collision.gameObject.tag == "scorecontrol" && count == 5 & scoreImage[0].activeInHierarchy == true)
        {
            
            Debug.Log("hata");
            count = 0;
            countText.text = count.ToString();
            winPartCount = false;
            winPart++;
        }

        if(collision.gameObject.tag == "scorecontrol" && count == 5 & scoreImage[1].activeInHierarchy == true)
        {
            
            Debug.Log("hata");
            count = 0;
            countText.text = count.ToString();
            winPartCount = false;
            winPart++;
        }


        if (winPart == 2)
        {
            for (int i = 0; i < walnutDrop.Count; i++)
            {
                walnutDrop[i].SetActive(true);
                walnutDrop[i].GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            scoreImage[0].SetActive(false);
            scoreImage[1].SetActive(true);
        }

        if(winPart == 3)
        {
            for (int i = 0; i < hazelnutDrop.Count; i++)
            {
                hazelnutDrop[i].SetActive(true);
                hazelnutDrop[i].GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            scoreImage[1].SetActive(false);
            scoreImage[0].SetActive(false);
        }

        if(winPart == 4)
        {
            RandomController.instance.secondSpawn = 100;
            winPanel.DOAnchorPosY(0, 1);


        }
    }
}
