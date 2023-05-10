using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    
    private float startPosX;
    private bool isBeingHeld = false;
    


    private void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition = new Vector3(mousePos.x - startPosX, transform.localPosition.y, 0);
        }

        float xPos = Mathf.Clamp(transform.position.x, -7.66f, 7.66f);
        transform.position=new Vector2(xPos,transform.position.y);
    }

    private void OnMouseDown()
    {
        isBeingHeld = true;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPosX = mousePos.x - transform.localPosition.x;
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
   public void AgainButton()
    {
        SceneManager.LoadScene(0);
    }
}
