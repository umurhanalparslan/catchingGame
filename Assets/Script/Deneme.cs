using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Deneme : MonoBehaviour
{

    public TextMeshProUGUI countText; // TextMeshPro bileþeni
    private int count; // sayacý saklayan deðiþken

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("walnut") ||other.CompareTag("hazelnut"))
        {
          //other.gameObject.SetActive(false); // Toplama nesnesini etkisiz hale getirin
            count++; // sayacý arttýrýn
            countText.text = count.ToString(); // sayacý TextMeshPro bileþenine yazýn
        }
    }


}
