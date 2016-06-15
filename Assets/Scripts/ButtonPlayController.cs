using UnityEngine;
using System.Collections;

public class ButtonPlayController : MonoBehaviour
{
    public ButtonPlayGame btnPlayGame;
    void OnMouseDown()
    {
        GameManager.main.OnClickButtonPlay(btnPlayGame);
    }
}
