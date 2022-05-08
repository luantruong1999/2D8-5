using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image image;

    private void Start()
    {
        SetNameText(character.displayStringName);
    }

    private void OnEnable()
    {
        character.onTakeDame += UpdateHealthBar;
        character.onHeal += UpdateHealthBar;
    }

    private void OnDisable()
    {
        character.onTakeDame -= UpdateHealthBar;
        character.onHeal -= UpdateHealthBar;
    }

    void SetNameText(string nameText)
    {
        text.text = nameText;
        
    }

    void UpdateHealthBar()
    {
        float healthPercent = (float)character.curHp / (float)character.maxHp;
        image.fillAmount = healthPercent;
    }
}
