using UnityEngine;
using System.Collections;

public class ButtonBackMenuController : MonoBehaviour
{
    public ButtonBackMenu btnBackMenu;
    void OnMouseDown()
    {
        GameManager.main.OnClickButtonBackMenu(btnBackMenu);
    }
}
