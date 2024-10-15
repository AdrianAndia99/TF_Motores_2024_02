using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DinoData", order = 1)]
public class DinoData : ScriptableObject
{
    [SerializeField] private GameObject dinosaur;
    [SerializeField] private TextMeshProUGUI nameDino;
    [SerializeField] private TextMeshProUGUI lifeDinoData;
    [SerializeField] private TextMeshProUGUI damageDinoData;
    [SerializeField] private int lifeDino;
    [SerializeField] private int damageDino;


}
