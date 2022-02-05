using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SequencePlayer : MonoBehaviour
{
    public int Id;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Text>().text = ""+Id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Data.showSequence)
        {
            StartCoroutine(ShowSequence());
            Data.showSequence = false;
        }
    }
    /// <summary>
    /// Осуществляем показ нужных кнопок.
    /// </summary>
    public static IEnumerator ShowSequence()
    {
        foreach (int num in Data.Sequence)
        {
            Data.MemButtons[num].GetComponent<Image>().color = Color.blue;
            yield return new WaitForSeconds(0.5f);
            Data.MemButtons[num].GetComponent<Image>().color = Color.white;
        }
    }

    public void OnPointerClick()
    {
        if (Id - 1 == Data.Sequence[Data.currentSequencePosition])//Если это нужная кнопка, то переходим к следующей.
        {
            Data.currentSequencePosition++;
            GetComponent<Image>().color = Color.green;
            if (Data.currentSequencePosition == 5)//Если все нажаты правильно, то победа.
            {
                Data.currentSequencePosition = 0;
                MinigameScript.OnWin();
            }
        }
        else Data.SwapMinigame();//Иначе игрок проиграл.
    }
}
