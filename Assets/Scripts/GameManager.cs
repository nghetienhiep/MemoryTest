using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    public GameObject btnNumPref;
    public GameObject timer;

    public GameObject UIMenuGame, UIGamePlay;
    public GameObject UIBoder, UINextGameStart, UITutorial;

    public Text txtScore;
    public Transform ParentBtnNum;

    public int startNum = 4;
    public int lenghtArray = 8;
    public int score = 0;
    public float timeWaitClose;
    public float disNum = 0.6f;

    [HideInInspector]
    public GameObject[] posBtnNum;

    public static int countNum;
    public static int countOnClick = 0;

    private int numButton = 0;
    private GameObject UI1;
    private GameObject UI2;
    void Awake()
    {
        main = this;
    }
    void Start()
    {
        countNum = startNum;
        posBtnNum = new GameObject[lenghtArray];
        txtScore.text = score + "";
        AddButtonNum();
    }
    public void AddButtonNum()
    {
        for (int i = 0; i < lenghtArray; i++)
        {
            GameObject gobj = Instantiate(btnNumPref);
            gobj.transform.SetParent(ParentBtnNum);
            gobj.SetActive(false);
            posBtnNum[i] = gobj;
        }
    }
    private void RePosition()
    {
        countOnClick = 0;
        numButton = 0;
        Vector2 pos;
        for (int i = 0; i < countNum; i++)
        {
            float posX = Random.Range(-2.8f + disNum, 2.8f - disNum);
            float posY = Random.Range(-5f + disNum, 4.5f - disNum);
            pos = new Vector2(posX, posY);
            numButton += Random.Range(1, 5);
            posBtnNum[i].GetComponentInChildren<Text>().text = numButton + "";
            posBtnNum[i].name = numButton + "";
            posBtnNum[i].transform.position = pos;
            posBtnNum[i].GetComponent<CircleCollider2D>().enabled = true;
            posBtnNum[i].SetActive(true);
            posBtnNum[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        for (int i = countNum; i < lenghtArray; i++)
        {
            posBtnNum[i].SetActive(false);
        }
    }
    IEnumerator CloseMaskNum()
    {
        yield return new WaitForSeconds(timeWaitClose);
        foreach (GameObject g in posBtnNum)
        {
            g.transform.GetChild(0).gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
            g.transform.GetChild(0).gameObject.SetActive(true);
            if (g.GetComponent<ButtonNumController>() == false)
                g.AddComponent<ButtonNumController>();
        }
    }
    public void OpenMaskNum()
    {
        foreach (GameObject g in posBtnNum)
        {
            g.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void CheckOnClick(string name, int num)
    {
        if (name.Equals(posBtnNum[num].name))
        {
            CheckEndNum(num + 1);
        }
        else
        {
            OpenMaskNum();
        }
    }
    public void CheckEndNum(int n)
    {
        if (n == countNum)
        {
            if (countNum < 8)
            {
                countNum++;
            }
            else if (countNum == 8)
            {
                countNum = 3;
                timeWaitClose -= 0.5f;
            }
            CallTimer();
            score++;
            txtScore.text = score + "";
        }
    }
    public void CallTimer()
    {
        StartCoroutine(CountingDown());
    }
    public IEnumerator CountingDown()
    {
        for (int i = 3; i > 0; i--)
        {
            timer.GetComponent<Text>().text = i + "";
            timer.transform.localScale = Vector2.one;
            DoTweenControllerScript.main.SetScaleTimer(timer);
            yield return new WaitForSeconds(1);
        }
        RePosition();
        StartCoroutine(CloseMaskNum());
    }
    public void OnClickButtonMenu(ButtonMenu bm)
    {
        switch (bm)
        {
            case ButtonMenu.Start:
                DoTweenControllerScript.main.SetAlphaShadow(() => { LoadNext(UIBoder, UINextGameStart); });
                break;
            case ButtonMenu.Music:
                print(bm);
                break;
            case ButtonMenu.Rank:
                print(bm);
                break;
            case ButtonMenu.Facebook:
                print(bm);
                break;
            case ButtonMenu.Twitter:
                print(bm);
                break;
            case ButtonMenu.Share:
                print(bm);
                break;
            case ButtonMenu.Like:
                print(bm);
                break;
            case ButtonMenu.MemoryTest:
                DoTweenControllerScript.main.SetAlphaShadow(() => { LoadNext(UINextGameStart, UITutorial); });
                break;
        }
        
    }
    public void LoadNext(GameObject UI1, GameObject UI2)
    {
        UI1.SetActive(false);
        UI2.SetActive(true);
    }
    public void OnClickButtonBackMenu(ButtonBackMenu bbm)
    {
        switch (bbm)
        {
            case ButtonBackMenu.NextGameStartBack:
                DoTweenControllerScript.main.SetAlphaShadow(() => { LoadNext(UINextGameStart, UIBoder); });
                break;
            case ButtonBackMenu.TutorialBack:
                DoTweenControllerScript.main.SetAlphaShadow(() => { LoadNext(UITutorial, UINextGameStart); });
                break;
        }
    }
    public void OnClickButtonPlay(ButtonPlayGame bpg)
    {
        switch (bpg)
        {
            case ButtonPlayGame.MemoryTest:
                DoTweenControllerScript.main.SetAlphaShadow(() => { LoadNext(UIMenuGame, UIGamePlay); });
                break;
            case ButtonPlayGame.SquaresGame:

                break;
            case ButtonPlayGame.TotalGame:

                break;
        }

    }
}
public enum ButtonMenu
{
    Start,
    Music,
    Rank,
    Facebook,
    Twitter,
    Share,
    Vote,
    Like,
    MemoryTest,
    SquaresGame,
    TotalGame
}
public enum ButtonBackMenu
{
    NextGameStartBack,
    TutorialBack
}
public enum ButtonPlayGame
{
    MemoryTest,
    SquaresGame,
    TotalGame
}

