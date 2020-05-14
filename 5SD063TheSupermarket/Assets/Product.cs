using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ProductType
{
    NOT_SET,
    MILK,
    CEREAL,
    CHEESE,
    HAM,
    LEMON,
    CARROT,
    OATMEAL,
    MEDEL,
    COFFEE,
    MAYO,
    COOKIE,
    CHIPS,
    BREAD,
    CHICKEN
}

//public static string TypeToString(ProductType type)
//{
//    if (type == ProductType.MILK)
//        return "Milk";
//}

public class Product : MonoBehaviour
{
    public ProductType type = ProductType.NOT_SET;
    public GameObject[] products;
    public int index;


    void Start()
    {

    }



}
