using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MinigameScript : MonoBehaviour
{
    public int Id;

    // Start is called before the first frame update
    void Start()
    {
        //Заполняем списки кнопок и миниигр, а затем выбираем первую миниигру.
        Data.Minigames = GameObject.FindGameObjectsWithTag("Minigame").ToList();
        Data.MemButtons = GameObject.FindGameObjectsWithTag("MemButton").ToList();
        Data.RangeButtons = GameObject.FindGameObjectsWithTag("RangeButton").ToList();
        Data.ArrowButtons = GameObject.FindGameObjectsWithTag("Arrow").ToList();
        Data.FixButtons = GameObject.FindGameObjectsWithTag("FixButton").ToList();
        Data.InitializeForm();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Если выиграли игру
    /// </summary>
    public static void OnWin()
    {
        RecordDisplay.CurrentScore++;
        Data.SwapMinigame();
    }
}
