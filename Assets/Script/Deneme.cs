using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Deneme : MonoBehaviour
{

    public TextMeshProUGUI countText; // TextMeshPro bile�eni
    private int count; // sayac� saklayan de�i�ken

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("walnut") ||other.CompareTag("hazelnut"))
        {
          //other.gameObject.SetActive(false); // Toplama nesnesini etkisiz hale getirin
            count++; // sayac� artt�r�n
            countText.text = count.ToString(); // sayac� TextMeshPro bile�enine yaz�n
        }
    }


}
