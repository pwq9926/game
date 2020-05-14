using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoppinglist : MonoBehaviour
{
    public Text myShoppinglist, myCereal, myMilk, myCheese, myLemon, myOatmeal, myMayo, myChicken, myChips, myCoffee, myMedel, myBread, myCookie, myHam, myPocky, myTomato, myPotato,
        myAvocado, myRice, myTea, myHotsauce;
    public int listNr;

    // Start is called before the first frame update
    void Start()
    {
        SetShoppinglistText();

    }

    public void SetShoppinglistText()
    {
        listNr = Random.Range(1, 6);

        if (listNr == 1)
        {
            myShoppinglist.text = "Shoppinglist";

            myCereal.text = "Cereal";

            myMilk.text = "Milk";

            myCheese.text = "Cheese";

            myLemon.text = "Lemon";

            myChicken.text = "Chicken";

            myMayo.text = "Mayo";

            myOatmeal.text = "Oatmeal";

            myHam.GetComponent<Text>().enabled = false;
            myCookie.GetComponent<Text>().enabled = false;
            myChips.GetComponent<Text>().enabled = false;
            myMedel.GetComponent<Text>().enabled = false;
            myTea.GetComponent<Text>().enabled = false;
            myCoffee.GetComponent<Text>().enabled = false;
            myHotsauce.GetComponent<Text>().enabled = false;
            myAvocado.GetComponent<Text>().enabled = false;
            myBread.GetComponent<Text>().enabled = false;
            myPocky.GetComponent<Text>().enabled = false;
            myPotato.GetComponent<Text>().enabled = false;
            myRice.GetComponent<Text>().enabled = false;
            myTomato.GetComponent<Text>().enabled = false;
        }
        else if (listNr == 2)
        {
            myShoppinglist.text = "Shoppinglist";

            myHam.text = "Ham";

            myCookie.text = "Cookies";

            myChips.text = "Chips";

            myChicken.text = "Chicken";

            myLemon.text = "Lemon";

            myMilk.text = "Milk";

            myMedel.text = "Detergent";

            myTea.GetComponent<Text>().enabled = false;
            myCoffee.GetComponent<Text>().enabled = false;
            myHotsauce.GetComponent<Text>().enabled = false;
            myAvocado.GetComponent<Text>().enabled = false;
            myBread.GetComponent<Text>().enabled = false;
            myPocky.GetComponent<Text>().enabled = false;
            myPotato.GetComponent<Text>().enabled = false;
            myRice.GetComponent<Text>().enabled = false;
            myTomato.GetComponent<Text>().enabled = false;
            myCereal.GetComponent<Text>().enabled = false;
            myOatmeal.GetComponent<Text>().enabled = false;
            myCheese.GetComponent<Text>().enabled = false;
            myMayo.GetComponent<Text>().enabled = false;
        }
        else if (listNr == 3)
        {
            myShoppinglist.text = "Shoppinglist";

            myOatmeal.text = "Oatmeal";

            myTea.text = "Tea";

            myTomato.text = "Tomato";

            myChips.text = "Chips";

            myMayo.text = "Mayo";

            myMedel.text = "Detergent";

            myHotsauce.text = "Hotsauce";

            myHam.GetComponent<Text>().enabled = false;
            myCookie.GetComponent<Text>().enabled = false;
            myCoffee.GetComponent<Text>().enabled = false;
            myAvocado.GetComponent<Text>().enabled = false;
            myBread.GetComponent<Text>().enabled = false;
            myPocky.GetComponent<Text>().enabled = false;
            myPotato.GetComponent<Text>().enabled = false;
            myRice.GetComponent<Text>().enabled = false;
            myCereal.GetComponent<Text>().enabled = false;
            myCheese.GetComponent<Text>().enabled = false;
            myMilk.GetComponent<Text>().enabled = false;
            myChicken.GetComponent<Text>().enabled = false;
            myLemon.GetComponent<Text>().enabled = false;
        }
        else if (listNr == 4)
        {
            myShoppinglist.text = "Shoppinglist";

            myAvocado.text = "Avocado";

            myMilk.text = "Milk";

            myBread.text = "Bread";

            myCereal.text = "Cereal";

            myCoffee.text = "Coffee";

            myCookie.text = "Cookies";

            myRice.text = "Rice";

            myHam.GetComponent<Text>().enabled = false;
            myChips.GetComponent<Text>().enabled = false;
            myMedel.GetComponent<Text>().enabled = false;
            myTea.GetComponent<Text>().enabled = false;
            myHotsauce.GetComponent<Text>().enabled = false;
            myPocky.GetComponent<Text>().enabled = false;
            myPotato.GetComponent<Text>().enabled = false;
            myTomato.GetComponent<Text>().enabled = false;
            myOatmeal.GetComponent<Text>().enabled = false;
            myCheese.GetComponent<Text>().enabled = false;
            myMayo.GetComponent<Text>().enabled = false;
            myChicken.GetComponent<Text>().enabled = false;
            myLemon.GetComponent<Text>().enabled = false;
        }
        else if (listNr == 5)
        {
            myShoppinglist.text = "Shoppinglist";

            myPotato.text = "Potato";

            myPocky.text = "Pocky";

            myTea.text = "Tea";

            myBread.text = "Bread";

            myLemon.text = "Lemon";

            myCheese.text = "Cheese";

            myOatmeal.text = "Oatmeal";

            myHam.GetComponent<Text>().enabled = false;
            myCookie.GetComponent<Text>().enabled = false;
            myChips.GetComponent<Text>().enabled = false;
            myMedel.GetComponent<Text>().enabled = false;
            myCoffee.GetComponent<Text>().enabled = false;
            myHotsauce.GetComponent<Text>().enabled = false;
            myAvocado.GetComponent<Text>().enabled = false;
            myRice.GetComponent<Text>().enabled = false;
            myTomato.GetComponent<Text>().enabled = false;
            myCereal.GetComponent<Text>().enabled = false;
            myMayo.GetComponent<Text>().enabled = false;
            myMilk.GetComponent<Text>().enabled = false;
            myChicken.GetComponent<Text>().enabled = false;
        }
        else if (listNr == 6)
        {
            myShoppinglist.text = "Shoppinglist";

            myAvocado.text = "Avocado";

            myCoffee.text = "Coffee";

            myHam.text = "Ham";

            myHotsauce.text = "Hotsauce";

            myPocky.text = "Pocky";

            myRice.text = "Rice";

            myTomato.text = "Tomato";

            myCookie.GetComponent<Text>().enabled = false;
            myChips.GetComponent<Text>().enabled = false;
            myMedel.GetComponent<Text>().enabled = false;
            myTea.GetComponent<Text>().enabled = false;
            myBread.GetComponent<Text>().enabled = false;
            myPotato.GetComponent<Text>().enabled = false;
            myCereal.GetComponent<Text>().enabled = false;
            myOatmeal.GetComponent<Text>().enabled = false;
            myCheese.GetComponent<Text>().enabled = false;
            myMayo.GetComponent<Text>().enabled = false;
            myMilk.GetComponent<Text>().enabled = false;
            myChicken.GetComponent<Text>().enabled = false;
            myLemon.GetComponent<Text>().enabled = false;
        }

    }
}
