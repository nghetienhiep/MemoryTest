using UnityEngine;
using System.Collections;

public class ButtonMenuGameController : MonoBehaviour
{
    public ButtonMenu btnMenu;
    void OnMouseDown()
    {
        GameManager.main.OnClickButtonMenu(btnMenu);
    }
}
