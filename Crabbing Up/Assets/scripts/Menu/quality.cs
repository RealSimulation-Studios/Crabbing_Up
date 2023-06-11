using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quality : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}