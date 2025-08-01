using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class InformationWindow : MonoBehaviour
{
    [TitleGroup("References")]
    [SerializeField] private TMP_Text plantName;
    [SerializeField] private TMP_Text indigiousLocation;
    [SerializeField] private TMP_Text carbonStorageValue;
    [SerializeField] private TMP_Text biodiversityValue;
    [SerializeField] private TMP_Text soilQualityValue;

    public void SetValues(string name, string location, int value1, int value2, int value3)
    {
        plantName.text = name;
        indigiousLocation.text = location; 
        carbonStorageValue.text = value1.ToString();
        biodiversityValue.text = value2.ToString();
        soilQualityValue.text = value3.ToString();
    }

}
