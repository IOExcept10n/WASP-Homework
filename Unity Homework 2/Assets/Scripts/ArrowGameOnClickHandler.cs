using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ArrowGameOnClickHandler : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// id ������, �� ������� ����� ������.
    /// </summary>
    public static int currentId = 0;
    /// <summary>
    /// ����������, �������� �� ��� ��������.
    /// </summary>
    public static bool Enabled = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (FindCurrentButtonId() == currentId)//���� ������ ������
        {
            Quaternion rot = GameObject.FindGameObjectsWithTag("Arrow").First(x => x.name == $"Image{currentId}").transform.rotation;
            if (rot.eulerAngles.z % 360 >= 315 || rot.eulerAngles.z % 360 <= 45)//��� ������ ����� 90 �������� ��� ������� ���������.
            {
                currentId++;
                GetComponent<Image>().color = Color.green;
                if (currentId == 3)//���� ������ ���� ���������, �� ���� ��������.
                {
                    currentId = 0;
                    MinigameScript.OnWin();
                }
            }
            else Data.SwapMinigame();//���� ����� �� �����, �� �� ��������.
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// ���������� ����� ������� ������.
    /// </summary>
    int FindCurrentButtonId()
    {
        if (!Enabled) return -1;
        switch (name)
        {
            case "Button":
                {
                    return 0;
                }
            case "Button2":
                {
                    return 1;
                }
            case "Button3":
                {
                    return 2;
                }
        }
        return -1;
    }
}
