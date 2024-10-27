using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DinoData", order = 1)]
public class DinoData : ScriptableObject
{
    [SerializeField] private TextMeshProUGUI nameDino;
    [SerializeField] private TextMeshProUGUI damageDinoData;
    [SerializeField] private int damageDino;

}