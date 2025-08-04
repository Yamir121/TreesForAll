using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public ValueContainer ValueContainer1 => valueContainer1;
    public ValueContainer ValueContainer2 => valueContainer2;
    public ValueContainer ValueContainer3 => valueContainer3;
    public TMP_Text TimerText => timerText;

    [Serializable]
    public class ValueContainer
    {
        public Image icon;
        public TMP_Text value1Name;
        public TMP_Text value;
    }

    [TitleGroup("References")]
    [SerializeField] private ValueContainer valueContainer1;
    [SerializeField] private ValueContainer valueContainer2;
    [SerializeField] private ValueContainer valueContainer3;
    [SerializeField] private TMP_Text timerText;

}
