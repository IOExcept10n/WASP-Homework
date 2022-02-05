using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    /// <summary>
    /// Этот класс я сделал в первую очередь для хранения списка кнопок, но также,
    /// из-за моих ошибок мне пришлось добавить пару переменных, которые не должны были здесь находиться.
    /// По крайней мере, это работает, так что пойдёт.
    /// </summary>
    public static class Data
    {
        private static List<GameObject> minigames;
        private static List<GameObject> membtns;
        private static List<GameObject> rangebtns;
        private static List<GameObject> arrowbtns;
        private static List<GameObject> fixbtns;
        private static bool r1 = false;
        private static bool r2 = false;
        private static bool r3 = false;
        private static bool r4 = false;
        private static bool r5 = false;
        private static bool r6 = false;
        public static bool showSequence;
        public static int currentSequencePosition;
        public static List<int> Sequence;

        public static List<GameObject> Minigames
        {
            get => minigames;
            set
            {
                if (!r1) minigames=value;
                r1=true;
            }
        }

        public static List<GameObject> MemButtons
        {
            get => membtns;
            set
            {
                if (!r2) membtns=value;
                r2=true;
            }
        }

        public static List<GameObject> RangeButtons
        {
            get => rangebtns;
            set
            {
                if (!r3) rangebtns=value;
                r3 = true;
            }
        }

        public static List<GameObject> ArrowButtons
        {
            get => arrowbtns;
            set
            {
                if (!r4) arrowbtns=value;
                r4 = true;
            }
        }

        public static List<GameObject> FixButtons
        {
            get => fixbtns;
            set
            {
                if (!r5) fixbtns=value;
                r5 = true;
            }
        }

        public static void InitializeForm()
        {
            if (!r6)
            {
                SwapMinigame();
                r6 = false;
            }
        }
        /// <summary>
        /// Алгоритм переключения миниигр.
        /// </summary>
        public static void SwapMinigame()
        {
            Debug.Log("Swapping form");
            Minigames.ForEach(x => x.SetActive(false));
            ArrowGameOnClickHandler.Enabled = false;
            var game = Minigames[Random.Range(0, Minigames.Count)];
            switch (game.GetComponent<MinigameScript>().Id)
            {
                case 0:
                    {
                        ArrowButtons.ForEach(x =>
                        {
                            x.transform.rotation = Quaternion.Euler(0, 0, Random.value * 360);
                        });
                        FixButtons.ForEach(x =>
                        {
                            x.GetComponent<Image>().color = Color.white;
                        });
                        ArrowGameOnClickHandler.currentId = 0;
                        ArrowGameOnClickHandler.Enabled = true;
                        break;
                    }
                case 1:
                    {
                        Queue<int> nums = new Queue<int>(Enumerable.Range(1, 10).OrderBy(x => Random.value).ToList());
                        RangeButtons.ForEach(x =>
                        {
                            int n = nums.Dequeue();
                            x.GetComponentInChildren<Text>().text = n.ToString();
                            x.GetComponent<Image>().color = Color.white;
                        });
                        RangeOnClickHandler.currentMaximum = 0;
                        break;
                    }
                case 2:
                    {
                        Sequence = Enumerable.Range(0, 9).OrderBy(x => Random.value).ToList().GetRange(0, 5);
                        MemButtons.ForEach(x => x.GetComponent<Image>().color = Color.white);
                        currentSequencePosition = 0;
                        showSequence = true;
                        break;
                    }
            }
            game.SetActive(true);
        }
    }
}
