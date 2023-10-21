using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SurvivalText : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    private void Start()
    {
        int intTimeSurvived = (int)PersistentData.timeSurvived;

        text.text = "you survived for " + intTimeSurvived.ToString() + " seconds";
    }
}
