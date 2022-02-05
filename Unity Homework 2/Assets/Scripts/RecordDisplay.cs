using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordDisplay : MonoBehaviour
{
    /// <summary>
    /// Поле с текстом для вывода данных.
    /// </summary>
    public Text Display;
    /// <summary>
    /// Текущее количество очков.
    /// </summary>
    public static int CurrentScore;
    /// <summary>
    /// Текущий рекорд очков.
    /// </summary>
    public static int Record;

    // Start is called before the first frame update
    void Start()
    {
        Record = PlayerPrefs.GetInt("record", 0);//Загружаем рекорд из памяти.
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentScore > Record)//Если превысили рекорд, то пересохраняем его.
        {
            Record = CurrentScore;
            PlayerPrefs.SetInt("record", Record);
        }
        Display.text = $"Record: {Record}; Current: {CurrentScore}";//Выводим число очков.
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();//Сохраняем настройки игрока (на всякий случай).
    }
}
