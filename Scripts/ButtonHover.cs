using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonHover : MonoBehaviour
{
    private bool mouse_over = false;

    public GameObject moneySlider;
    public GameObject emissionsSlider;
    public GameObject timeSlider;

    public void OnMouseEnter()
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
        Vector2 setScale = new Vector3(1f, 1f, 1f);

        LeanTween.scale(moneySlider, setScale, 0.2f).setEaseInOutQuad();
        LeanTween.scale(emissionsSlider, setScale, 0.2f).setEaseInOutQuad();
        LeanTween.scale(timeSlider, setScale, 0.2f).setEaseInOutQuad();

    }

    public void OnMouseExit()
{
      
        mouse_over = false;
        Debug.Log("Mouse exit");
        Vector2 setScale = new Vector3(0f, 0f, 0f);

        LeanTween.scale(moneySlider, setScale, 0.2f).setEaseInOutQuad();
        LeanTween.scale(emissionsSlider, setScale, 0.2f).setEaseInOutQuad();
        LeanTween.scale(timeSlider, setScale, 0.2f).setEaseInOutQuad();
    }
}
