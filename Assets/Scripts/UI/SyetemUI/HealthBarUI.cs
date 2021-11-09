using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarUI : MonoBehaviour
{
   public GameObject HealthBarPrefab;
   public Transform BarPoint;
   private Image HealthSlider;
   private Transform UIBar;
   private Transform MainCameraTrans;

   public float MaxHealth = 100f;
   public float CurrentHealth = 100f;
   private void OnEnable()
   {
      MainCameraTrans = Camera.main.transform;
      foreach (var cans in FindObjectsOfType<Canvas>())
      {
         if (cans.tag == "HealthBarCanvas")
         {
            UIBar = Instantiate(HealthBarPrefab, cans.transform).transform;
            HealthSlider = UIBar.GetChild(0).GetComponent<Image>();
         }
      }
   }

   private void Update()
   {
      CurrentHealth = CurrentHealth - 0.1f;
      HealthSlider.fillAmount = CurrentHealth / MaxHealth;
   }

   private void LateUpdate()
   {
      UIBar.position = BarPoint.position;
      UIBar.forward = -MainCameraTrans.forward;
   }
}
