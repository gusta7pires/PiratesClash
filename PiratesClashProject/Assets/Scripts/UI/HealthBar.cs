using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image progressImage;

    public void SetProgress(float progress){
        progressImage.fillAmount = progress;
    }
}
