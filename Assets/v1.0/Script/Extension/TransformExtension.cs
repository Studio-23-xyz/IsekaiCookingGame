using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension 
{
   public static void DestroyAllChildren(this Transform transform)
   {
      for (int i = transform.childCount - 1; i >= 0; i--)
      {
         GameObject.Destroy(transform.GetChild(i).gameObject);
      }
   }
}
