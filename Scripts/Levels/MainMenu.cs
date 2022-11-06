using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Image PlayButton;
    public Image SpaceShip;
    public Image Fade;

    void Start()
    {
        FadeScene(true);
    }
    public void FadeScene(bool typeOfFade)
    {
        if (typeOfFade == true)
        {
            //FADE IN
            LeanTween.alpha(Fade.rectTransform, 0f, 0.5f).setEaseInOutQuad();
        }
        else
        {
            //FADE OUT
            LeanTween.alpha(Fade.rectTransform, 1f, 0.5f).setEaseInOutQuad();
        }
    }
    IEnumerator PlaySequence()
    {
        FadeScene(false);

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("01_Columbia");
    }
    public void PlaySelect()
    {
        StartCoroutine(PlaySequence());
    }
}
