using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Antarctica : MonoBehaviour
{
    public GameObject Goobie;
    public GameObject Shoob;
    public GameObject Bigglesmorf;

    private Animation Goobie_Speak_Anim;
    private Animation Shoob_Speak_Anim;
    private Animation Goobie_Anim;
    private Animation Shoob_Anim;
    private Animation Bigglesmorf_Anim;

    private bool Goobie_Speak = false;
    private bool Shoob_Speak = false;

    public Image Goobie_VisBubble;
    public Image Shoob_VisBubble;

    public TextMeshProUGUI Goobie_Bubble;
    public TextMeshProUGUI Shoob_Bubble;

    public Image Fade;
    public AudioSource Music;

    private string G_DIALOG_1 = "It's pretty chilly here!";
    private string G_DIALOG_2 = "They are so adorable.";
    private string G_DIALOG_3 = "Let's scram!";

    private string S_DIALOG_1 = "I know but I love it! And look at the cute little penguins!";
    private string S_DIALOG_2 = "Look- it's Bigglesmorf, here to pick us up finally!";

    public static bool CAN_HOVER = true;
    public static bool CAN_SELECT = false;

    // Start is called before the first frame update

    void Start()
    {
        //Goobie_Speak_Anim = Goobie.GetComponent<Animation>();
        //Shoob_Speak_Anim = Shoob.GetComponent<Animation>();
        Goobie_Anim = Goobie.GetComponent<Animation>();
        Shoob_Anim = Shoob.GetComponent<Animation>();
        Bigglesmorf_Anim = Bigglesmorf.GetComponent<Animation>();
        StartCoroutine(LevelSequence());
    }

    public void EnableBubble(Image Bubble)
    {

        Vector2 setScale = new Vector3(1f, 1f, 1f);
        Vector2 oldScale = Bubble.rectTransform.sizeDelta;
        LeanTween.scale(Bubble.GetComponent<RectTransform>(), setScale,0.75f).setEaseOutBounce();
    }

    public void DisableButton(Image Bubble)
    {
        Vector2 setScale = new Vector3(0f, 0f, 0f);
        LeanTween.scale(Bubble.GetComponent<RectTransform>(), setScale, 0.75f).setEaseInBounce();
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

 
    void updateValueExampleCallback(Color val, TextMeshProUGUI label)
    {
        label.color = val;
    }

    //SCENE FUNCTIONS
    void DisableAll()
    {
        DisableButton(Goobie_VisBubble);
        DisableButton(Shoob_VisBubble);
    }
    
    IEnumerator LevelSequence()
    {
        DisableAll();

        yield return new WaitForSeconds(0.75f);
        FadeScene(true);

        EnableBubble(Goobie_VisBubble);
        yield return new WaitForSeconds(0.75f);

        //Goobie_Speak_Anim.Play("GoobieSpeak");
        Dialog.SetDialog(Goobie_Bubble, G_DIALOG_1, this);
        yield return new WaitForSeconds(3f);
        //Goobie_Speak_Anim.Stop("GoobieSpeak");

        
        EnableBubble(Shoob_VisBubble);
        yield return new WaitForSeconds(0.75f);
        
        //Shoob_Speak_Anim.Play("Shoob_Speak");
        Dialog.SetDialog(Shoob_Bubble, S_DIALOG_1, this);
        yield return new WaitForSeconds(4f);
        //Shoob_Speak_Anim.Stop("Shoob_Speak");

        //Goobie_Speak_Anim.Play("GoobieSpeak");
        Dialog.SetDialog(Goobie_Bubble, G_DIALOG_2, this);
        yield return new WaitForSeconds(3f);
        //Goobie_Speak_Anim.Stop("GoobieSpeak");

        //Shoob_Speak_Anim.Play("Shoob_Speak");
        Dialog.SetDialog(Shoob_Bubble, S_DIALOG_2, this);
        yield return new WaitForSeconds(3f);
        //Shoob_Speak_Anim.Stop("Shoob_Speak");

        //Goobie_Speak_Anim.Play("GoobieSpeak");
        Dialog.SetDialog(Goobie_Bubble, G_DIALOG_3, this);
        yield return new WaitForSeconds(4.5f);
        //Goobie_Speak_Anim.Stop("GoobieSpeak");

        DisableButton(Goobie_VisBubble);
        DisableButton(Shoob_VisBubble);

        yield return new WaitForSeconds(2f);

        Goobie_Anim.Play();
        Shoob_Anim.Play();
        Bigglesmorf_Anim.Play();

        yield return new WaitForSeconds(2f);

        FadeScene(false);

    }
}
