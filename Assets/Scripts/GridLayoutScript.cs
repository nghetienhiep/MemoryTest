using UnityEngine;
using System.Collections;

public class GridLayoutScript : MonoBehaviour
{
    public int row, col;
    public int numArrayQuest = 3;
    public float startScaleSquare = 1.5f;

    public float scaleDown = 0.1f;
    public GameObject squarePref;

    private GameObject[] squareArray;
    private int[] squareSelected;
    private float scaleSquare;
    private int numberOfSquare;
    private int numSquare = 0;

    void Start()
    {
        scaleSquare = startScaleSquare - (col - 3) * scaleDown;
        Auto(1);
        RandomQuest(numArrayQuest);
    }
    public void Auto(int level)
    {
        numberOfSquare = row * col;
        squareArray = new GameObject[numberOfSquare];
        float posDown = scaleSquare * 3;
        float posX = 0, posY = 0;
        if (col % 2 == 0)
        {
            posX = -(posDown / 2 + (col / 2 - 1) * posDown);
        }
        else
        {
            int col2 = col / 2;
            posX = -(posDown * col2);
        }
        if (row % 2 == 0)
        {
            posY = posDown / 2 + (row / 2 - 1) * posDown;
        }
        else
        {
            int row2 = row / 2;
            posY = posDown * row2;
        }
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                int col2 = col / 2;
                int row2 = row / 2;
                //Vector2 vt = new Vector2(posX * row2 + (i * posDown), posY * col2 - (posDown * j));
                Vector2 vt = new Vector2(posX + posDown * i, posY - posDown * j);
                GameObject square = Instantiate(squarePref);
                square.transform.SetParent(transform);
                square.transform.localScale = new Vector3(scaleSquare, scaleSquare);
                square.transform.localPosition = vt;
                square.name = (i + 1) + " - " + (j + 1);
                squareArray[numSquare] = square;
                numSquare++;
            }
        }

    }
    public void RandomQuest(int num)
    {
        squareSelected = new int[num];
        for (int i = 0; i < num; i++)
        {
            int numRd = MyRandom(squareSelected, squareArray.Length);
            squareSelected[i] = numRd;
            squareArray[numRd].GetComponent<ButtonSquareController>().isSelect = true;
            squareArray[numRd].GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    private int MyRandom(int[] arrayI, int n)
    {
        int numRd = 0;
        bool exist = true;
        do
        {
            numRd = Random.Range(0, n);
            bool exit2 = false;
            for (int i = 0; i < arrayI.Length; i++)
            {
                if (numRd == arrayI[i])
                {
                    exit2 = true;
                    break;
                }
            }
            if (exit2)
            {
                exist = true;
            }
            else
            {
                exist = false;
            }
        }
        while (exist);
        return numRd;
    }
}
