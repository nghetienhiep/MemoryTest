using UnityEngine;
using System.Collections;

public class ButtonNumController : MonoBehaviour
{
    void OnMouseDown()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        DoTweenControllerScript.main.SetScaleMaskButton(transform.GetChild(0).gameObject);
        GameManager.main.CheckOnClick(name, GameManager.countOnClick);
        print(GameManager.countOnClick);
        GameManager.countOnClick++;
        Destroy(this);
    }
}