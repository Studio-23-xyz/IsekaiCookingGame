using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogueBoxUIController : MonoBehaviour
{
   [SerializeField] private Image customerBg;
   [SerializeField] private Image customerPhoto;
   [Header("Dialogue Box")]
   [SerializeField] private TextMeshProUGUI customerDialogue;

   [SerializeField] private List<Image> UIForPreferredColor;
   [SerializeField] private List<Image> UIForBackgroundColor;

   [SerializeField] private Button actionButton;

   public void Init(Customer customer)
   {

      customerPhoto.sprite = customer.Characteristics.photo;
      customerBg.sprite = customer.Characteristics.bg;
      foreach (var item in UIForPreferredColor)
      {
         item.color = customer.Characteristics.preferredColor;
      }
      foreach (var item in UIForBackgroundColor)
      {
         item.color = customer.Characteristics.backgroundColor;
      }

      var dishPreference = customer.FoodData. RequestDish().ToString();
     customerDialogue.text = $" I want to buy a {dishPreference}";

   }
}
