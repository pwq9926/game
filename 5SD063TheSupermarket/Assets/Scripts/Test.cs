using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//[Serializable]
//public class ShoppingListItem
//{
//    public uint amount = 0;
//    public ProductType type = ProductType.NOT_SET;
//}
public class Test : MonoBehaviour
{
    //public Text myShoppinglist, myCereal, myMilk, myCheese, myLemon, myOatmeal, myMayo, myChicken, myChips;
    //public PlayerScript myPlayer;
    //public List<ShoppingListItem> shoppingList; 

    private void Start()
    {
        WallMaker.CreateMap();
        // varje element har 2 variavblers, dvs amount och type
    }


}
