using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clothes : MonoBehaviour
{
    public static Clothes Instance;
    public enum ClothesType
    {
        Correct,
        Wrong
    }

    public GameObject m_Cloth;
    public int m_price;
    public ClothesType m_clothesType;

    private void Awake()
    {
        Instance = this;
    }
    public void ChangeClothes(Transform _parent)
    {
        foreach (Transform item in _parent)
        {
            item.gameObject.SetActive(false);
        }
      
    }

   
}
