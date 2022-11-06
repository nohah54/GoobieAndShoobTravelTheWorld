using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Paris : MonoBehaviour
{
    public GameObject Goobie;
    public GameObject Shoob;

    private Animation Goobie_Speak_Anim;
    private Animation Shoob_Speak_Anim;

    private bool Goobie_Speak = false;
    private bool Shoob_Speak = false;

    public Image Goobie_VisBubble;
    public Image Shoob_VisBubble;

    public TextMeshProUGUI Goobie_Bubble;
    public TextMeshProUGUI Shoob_Bubble;
    public TextMeshProUGUI AfterLabel;
    public TextMeshProUGUI TravelDataEmission;
    public TextMeshProUGUI TravelDataCost;
    public TextMeshProUGUI ArrivedLabel;
    public TextMeshProUGUI LocationLabel;

    public Image Fade;
    public AudioSource Music;

    public Image QuestionBubble;
    public Image Car_Button;
    public Image Plane_Button;
    public Image Train_Button;
    public Image Boat_Button;

    public Image VehicleIcon;
    public Image BoatIcon;
    public Image PlaneIcon;
    public Image Trainicon;

    private string G_DIALOG_1 = "Maybe there is jelly juice at the top of that tower.";
    private string G_DIALOG_2 = "Why don’t we go to Egypt?";
    private string G_DIALOG_3 = "That sounds good, but how should we get there?";
    private string G_DIALOG_4 = "How should we get there?";

    private string S_DIALOG_1 = "Hm, I don’t want to climb that high. ";
    private string S_DIALOG_2 = " I remember having jelly juice last time I was there.";
    private string S_DIALOG_3 = "Me neither, but I’d take a jelly juice! I bet they have them in Europe...";

    private string CAR_COST = "- $440 SPENT FROM OUR PIGGY BANK";
    private string CAR_TIME = "AFTER 2 DAYS AND 13 HOURS ...";
    private string CAR_EMISSIONS = "- 508.64 KG OF CARBON DIOXIDE EMISSIONS";

    private string PLANE_COST = "- $155 SPENT FROM OUR PIGGY BANK";
    private string PLANE_TIME = "AFTER 4 HOURS AND 25 MINUTES ...";
    private string PLANE_EMISSIONS = "- 1,351.09 KG OF CARBON DIOXIDE EMISSIONS";

    private string TRAIN_COST = "- $46.52 SPENT FROM OUR PIGGY BANK";
    private string TRAIN_TIME = "AFTER 15 HOURS AND 33 MINUTES ...";
    private string TRAIN_EMISSIONS = "- 217.23 KG OF CARBON DIOXIDE EMISSIONS";

    private string BOAT_COST = "- $550 SPENT FROM OUR PIGGY BANK";
    private string BOAT_TIME = "AFTER 3 DAYS AND 12 HOURS ...";
    private string BOAT_EMISSIONS = "- 110.84 KG OF CARBON DIOXIDE EMISSIONS";

    private string ARRIVAL_MESSAGE = "WE ARRIVED TO CAIRO!";

    private int CAR = 1;
    private int PLANE = 2;
    private int TRAIN = 3;
    private int BOAT = 4;

    public static bool CAN_HOVER = true;
    public static bool CAN_SELECT = false;

    // Start is called before the first frame update

    void Start()
    {
        Goobie_Speak_Anim = Goobie.GetComponent<Animation>();
        Shoob_Speak_Anim = Shoob.GetComponent<Animation>();
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
        DisableButton(Car_Button);
        DisableButton(Plane_Button);
        DisableButton(Train_Button);
        DisableButton(Boat_Button);
        DisableButton(QuestionBubble);
    }

    //BUTTON FUNCTIONS --------------------------------------------------------------------------------
    public void CarSelected()
    {
        CAN_HOVER = false;
        CAN_SELECT = false;

        DisableAll();
        FadeScene(false);
        StartCoroutine(TransitionScreen(1));
    }

    public void PlaneSelected()
    {
        CAN_HOVER = false;
        CAN_SELECT = false;

        DisableAll();
        FadeScene(false);
        StartCoroutine(TransitionScreen(2));
    }

    public void TrainSelected()
    {
        CAN_HOVER = false;
        CAN_SELECT = false;

        DisableAll();
        FadeScene(false);
        StartCoroutine(TransitionScreen(3));
    }
    
    public void BoatSelected()
    {
        CAN_HOVER = false;
        CAN_SELECT = false;

        DisableAll();
        FadeScene(false);
        StartCoroutine(TransitionScreen(4));
    }

    IEnumerator TransitionScreen(int vehicleChoice)
    {
        float waitTime = 2f;

        LeanTween.value(gameObject, Music.volume, 0f, 2f).setOnUpdate((float volume) =>{Music.volume = volume;}).setOnComplete(() =>{Debug.Log("Done");});

        yield return new WaitForSeconds(waitTime);
       
        switch (vehicleChoice)
        {
            case 1:
                {
                    //CAR WAS CHOSEN
                    EnableBubble(VehicleIcon);
                    Dialog.SetDialog(AfterLabel, CAR_TIME, this);
                    yield return new WaitForSeconds(waitTime);

                    Dialog.SetDialog(TravelDataCost, CAR_COST, this);
                    Dialog.SetDialog(TravelDataEmission, CAR_EMISSIONS, this);

                    break;
                }
            case 2:
                {
                    //PLANE WAS CHOSEN
                    EnableBubble(PlaneIcon);
                    Dialog.SetDialog(AfterLabel, PLANE_TIME, this);
                    yield return new WaitForSeconds(waitTime);

                    Dialog.SetDialog(TravelDataCost, PLANE_COST, this);
                    Dialog.SetDialog(TravelDataEmission, PLANE_EMISSIONS, this);

                    break;
                }
            case 3:
                {
                    //TRAIN WAS CHOSEN
                    EnableBubble(Trainicon);
                    Dialog.SetDialog(AfterLabel, TRAIN_TIME, this);
                    yield return new WaitForSeconds(waitTime);

                    Dialog.SetDialog(TravelDataCost, TRAIN_COST, this);
                    Dialog.SetDialog(TravelDataEmission, TRAIN_EMISSIONS, this);

                    break;
                }
            case 4:
                {
                    //BOAT WAS CHOSEN
                    EnableBubble(BoatIcon);
                    Dialog.SetDialog(AfterLabel, BOAT_TIME, this);
                    yield return new WaitForSeconds(waitTime);

                    Dialog.SetDialog(TravelDataCost, BOAT_COST, this);
                    Dialog.SetDialog(TravelDataEmission, BOAT_EMISSIONS, this);

                    break;
                }
            default:
                {
                    break;
                }
        }

        Dialog.SetDialog(ArrivedLabel, ARRIVAL_MESSAGE, this);


        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("04_Egypt");
    }
    
    IEnumerator LevelSequence()
    {
        DisableAll();

        yield return new WaitForSeconds(0.75f);
        FadeScene(true);

        EnableBubble(Goobie_VisBubble);
        yield return new WaitForSeconds(0.75f);

        Goobie_Speak_Anim.Play("GoobieSpeak");
        Dialog.SetDialog(Goobie_Bubble, G_DIALOG_1, this);
        yield return new WaitForSeconds(2f);
        Goobie_Speak_Anim.Stop("GoobieSpeak");

        
        EnableBubble(Shoob_VisBubble);
        yield return new WaitForSeconds(0.75f);
        
        Shoob_Speak_Anim.Play("Shoob_Speak");
        Dialog.SetDialog(Shoob_Bubble, S_DIALOG_1, this);
        yield return new WaitForSeconds(3f);
        Shoob_Speak_Anim.Stop("Shoob_Speak");

        Goobie_Speak_Anim.Play("GoobieSpeak");
        Dialog.SetDialog(Goobie_Bubble, G_DIALOG_2, this);
        yield return new WaitForSeconds(3f);
        Goobie_Speak_Anim.Stop("GoobieSpeak");

        Shoob_Speak_Anim.Play("Shoob_Speak");
        Dialog.SetDialog(Shoob_Bubble, S_DIALOG_2, this);
        yield return new WaitForSeconds(3f);
        Shoob_Speak_Anim.Stop("Shoob_Speak");

        Goobie_Speak_Anim.Play("GoobieSpeak");
        Dialog.SetDialog(Goobie_Bubble, G_DIALOG_3, this);
        yield return new WaitForSeconds(3f);
        Goobie_Speak_Anim.Stop("GoobieSpeak");

        DisableButton(Goobie_VisBubble);
        DisableButton(Shoob_VisBubble);

        EnableBubble(QuestionBubble);
        yield return new WaitForSeconds(1f);

        EnableBubble(Car_Button);
        yield return new WaitForSeconds(0.1f);
        EnableBubble(Plane_Button);
        yield return new WaitForSeconds(0.1f);
        EnableBubble(Train_Button);
        yield return new WaitForSeconds(0.1f);
        EnableBubble(Boat_Button);
    }
}
