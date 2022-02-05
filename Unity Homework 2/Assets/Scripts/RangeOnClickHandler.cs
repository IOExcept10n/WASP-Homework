using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RangeOnClickHandler : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// ����� ������, �� ������� ����� ������
    /// </summary>
    public static int currentMaximum;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponentInChildren<Text>().text == (currentMaximum + 1).ToString())//���� ��� �� ������:
        {
            currentMaximum++;
            GetComponent<Image>().color = Color.green;
            if (currentMaximum == 10)//���� ���������, �� �������.
            {
                currentMaximum = 0;
                MinigameScript.OnWin();
            }
        }
        else Data.SwapMinigame();//���� �� ��, �� ��������.
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
