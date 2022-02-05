using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordDisplay : MonoBehaviour
{
    /// <summary>
    /// ���� � ������� ��� ������ ������.
    /// </summary>
    public Text Display;
    /// <summary>
    /// ������� ���������� �����.
    /// </summary>
    public static int CurrentScore;
    /// <summary>
    /// ������� ������ �����.
    /// </summary>
    public static int Record;

    // Start is called before the first frame update
    void Start()
    {
        Record = PlayerPrefs.GetInt("record", 0);//��������� ������ �� ������.
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentScore > Record)//���� ��������� ������, �� ������������� ���.
        {
            Record = CurrentScore;
            PlayerPrefs.SetInt("record", Record);
        }
        Display.text = $"Record: {Record}; Current: {CurrentScore}";//������� ����� �����.
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();//��������� ��������� ������ (�� ������ ������).
    }
}
