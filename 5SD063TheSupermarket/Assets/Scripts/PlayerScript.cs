using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.Events;



public class PlayerScript : MonoBehaviour
{
    public GameObject myPlayer, myAlien;
    public GameObject[] myProducts;
    public Rigidbody myRB;
    public CapsuleCollider myCol;
    public Test myMain;
    public Shoppinglist myShoppingScript;
    public float mySpeed, myRecoveryTimer, myTimer, myForwardspeed; 
    public int myMoney, myBudget, bumpAlien, bumpMother, bumpBaby, bumpGrandma;
    public Text myMoneyText, myTimerText;
    public float minTurnSpeed, maxTurnSpeed;
    public bool isBacking;
    Scene myActiveScene;
    public UnityEvent win;
    public UnityEvent lose;
    public GameObject youdietext, backgroundwin, backgroundlose, backgrounddie, button, playsound;
    public AudioClip winsound, loosesound, loosetune;
    public AudioSource myAudio;

    public Animator anim;
    public AnimationClip animclip;

    public static Resolution currentResolution;

    // Start is called before the first frame update
    void Start()
    {
        myMain = GameObject.Find("Grid").GetComponent<Test>();
        myAlien = GameObject.Find("alien");
        myShoppingScript = GameObject.Find("Grid").GetComponent<Shoppinglist>();
        myPlayer = GameObject.Find("player");
        myActiveScene = SceneManager.GetActiveScene();
        myRB = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
        winsound = Resources.Load<AudioClip>("(P) Win");
        //loosesound = Resources.Load<AudioClip>("Lose sound EDIT");
        //loosetune = Resources.Load<AudioClip>("(P) Lose");


        //minTurnSpeed = 5.0f;
        //maxTurnSpeed = 42.0f;

        // build-speed
        minTurnSpeed = 10.0f;
        maxTurnSpeed = 80.0f;
        myForwardspeed = 1.5f;

        mySpeed = 0.6f;
        myBudget = 600;
        myMoney = myBudget;
        myTimer = 160.0f;
        bumpAlien = 0;
        bumpBaby = 0;
        bumpGrandma = 0;
        bumpMother = 0;

        isBacking = false;

        SetBudgetText();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region Movement

        if (!isBacking)
        {
            currentResolution = Screen.currentResolution;
            Vector3 mousePos = Input.mousePosition;

            //float center = Screen.width / 2;
            float center = currentResolution.width / 2;

            float distance = Mathf.Abs(mousePos.x - center);

            if (distance > 50 && distance < currentResolution.width)
            {
                float turnSpeed = minTurnSpeed;
                turnSpeed += ((distance - 50) / (center - 50)) * (maxTurnSpeed - minTurnSpeed);

                transform.Rotate(0, Time.deltaTime * turnSpeed * (Mathf.Sign(mousePos.x - center)), 0);
            }
            myRB.velocity = transform.forward * myForwardspeed;

        }

        if (isBacking)
        {
            if (myRecoveryTimer > 0)
            {
                myRecoveryTimer -= Time.deltaTime;
            }
            else { isBacking = false; }

        }
        
        //myRB.AddForce(transform.forward * mySpeed * Time.deltaTime, ForceMode.VelocityChange);

        #endregion
    }

    void Update()
    {
        if (myTimer > 0.0f)
        {
            myTimer -= Time.deltaTime;
        }

        if (myTimer <= 0.0f)
        {
            lose.Invoke();
            Time.timeScale = 0f;
            backgroundlose.SetActive(true);
            button.SetActive(true);
        }

        if (bumpAlien >= 3)
        {
            lose.Invoke();
            Time.timeScale = 0f;
            backgrounddie.SetActive(true);
            button.SetActive(true);
        }
        if (bumpMother >= 3)
        {
            lose.Invoke();
            Time.timeScale = 0f;
            backgrounddie.SetActive(true);
            button.SetActive(true);
        }
        if (bumpBaby >= 3)
        {
            lose.Invoke();
            Time.timeScale = 0f;
            backgrounddie.SetActive(true);
            button.SetActive(true);
        }
        if (bumpGrandma >= 3)
        {
            lose.Invoke();
            Time.timeScale = 0f;
            backgrounddie.SetActive(true);
            button.SetActive(true);
        }

        SetTimerText();
        SetBudgetText();

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            PickProduct();
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "alien")
        {
            myRecoveryTimer = 2.0f;
            myMoney = myMoney - 80;
            bumpAlien = bumpAlien + 1;
            isBacking = true;
            myRB.velocity = -transform.forward * mySpeed;
            FindObjectOfType<AudioManager>().Play("Alien");
            FindObjectOfType<AudioManager>().Play("Crash");
        }
        else if (col.gameObject.name == "mother")
        {
            myRecoveryTimer = 2.0f;
            myMoney = myMoney - 80;
            bumpMother = bumpMother + 1;
            isBacking = true;
            myRB.velocity = -transform.forward * mySpeed;
            FindObjectOfType<AudioManager>().Play("Crash");
            FindObjectOfType<AudioManager>().Play("Mother");
        }
        else if (col.gameObject.name == "grandma")
        {
            myRecoveryTimer = 2.0f;
            myMoney = myMoney - 80;
            bumpGrandma = bumpGrandma + 1;
            isBacking = true;
            myRB.velocity = -transform.forward * mySpeed;
            FindObjectOfType<AudioManager>().Play("Crash");
            FindObjectOfType<AudioManager>().Play("Grandma");
        }
        else if (col.gameObject.name == "cryingbaby")
        {
            myRecoveryTimer = 2.0f;
            myMoney = myMoney - 140;
            bumpBaby = bumpBaby + 1;
            isBacking = true;
            myRB.velocity = -transform.forward * mySpeed;
            FindObjectOfType<AudioManager>().Play("Crash");
            FindObjectOfType<AudioManager>().Play("BabyCry");
        }
        if (col.gameObject.name == "toiletpaper")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.name == "Register")
        {
            if (myShoppingScript.listNr == 1)
            {
                if (myShoppingScript.myMilk.color == Color.green && myShoppingScript.myCereal.color == Color.green && myShoppingScript.myCheese.color == Color.green && myShoppingScript.myLemon.color == Color.green 
                    && myShoppingScript.myChicken.color == Color.green && myShoppingScript.myMayo.color == Color.green && myShoppingScript.myOatmeal.color == Color.green)
                {
                    win.Invoke();
                    Time.timeScale = 0f;
                    backgroundwin.SetActive(true);
                    button.SetActive(true);
                    playsound.SetActive(true);
                    myAudio.PlayOneShot(winsound);
                }
            }
            else if (myShoppingScript.listNr == 2)
            {
                if (myShoppingScript.myHam.color == Color.green && myShoppingScript.myCookie.color == Color.green && myShoppingScript.myChips.color == Color.green && myShoppingScript.myChicken.color == Color.green &&
                    myShoppingScript.myLemon.color == Color.green && myShoppingScript.myMilk.color == Color.green && myShoppingScript.myMedel.color == Color.green)
                {
                    win.Invoke();
                    Time.timeScale = 0f;
                    backgroundwin.SetActive(true);
                    button.SetActive(true);
                    playsound.SetActive(true);
                    myAudio.PlayOneShot(winsound);
                }
            }
            else if (myShoppingScript.listNr == 3)
            {
                if (myShoppingScript.myOatmeal.color == Color.green && myShoppingScript.myTea.color == Color.green && myShoppingScript.myTomato.color == Color.green && myShoppingScript.myChips.color == Color.green &&
                    myShoppingScript.myMayo.color == Color.green && myShoppingScript.myMedel.color == Color.green && myShoppingScript.myHotsauce.color == Color.green)
                {
                    win.Invoke();
                    Time.timeScale = 0f;
                    backgroundwin.SetActive(true);
                    button.SetActive(true);
                    playsound.SetActive(true);
                    myAudio.PlayOneShot(winsound);
                }
            }
            else if (myShoppingScript.listNr == 4)
            {
                if (myShoppingScript.myAvocado.color == Color.green && myShoppingScript.myMilk.color == Color.green && myShoppingScript.myBread.color == Color.green && myShoppingScript.myCereal.color == Color.green &&
                    myShoppingScript.myCoffee.color == Color.green && myShoppingScript.myCookie.color == Color.green && myShoppingScript.myRice.color == Color.green)
                {
                    win.Invoke();
                    Time.timeScale = 0f;
                    backgroundwin.SetActive(true);
                    button.SetActive(true);
                    playsound.SetActive(true);
                    myAudio.PlayOneShot(winsound);
                }
            }
            else if (myShoppingScript.listNr == 5)
            {
                if (myShoppingScript.myPotato.color == Color.green && myShoppingScript.myPocky.color == Color.green && myShoppingScript.myTea.color == Color.green && myShoppingScript.myBread.color == Color.green &&
                    myShoppingScript.myLemon.color == Color.green && myShoppingScript.myCheese.color == Color.green && myShoppingScript.myOatmeal.color == Color.green)
                {
                    win.Invoke();
                    win.Invoke();
                    Time.timeScale = 0f;
                    backgroundwin.SetActive(true);
                    button.SetActive(true);
                    playsound.SetActive(true);
                    myAudio.PlayOneShot(winsound);
                }
            }
            else if (myShoppingScript.listNr == 6)
            {
                if (myShoppingScript.myAvocado.color == Color.green && myShoppingScript.myCoffee.color == Color.green && myShoppingScript.myHam.color == Color.green && myShoppingScript.myHotsauce.color == Color.green &&
                    myShoppingScript.myPocky.color == Color.green && myShoppingScript.myRice.color == Color.green && myShoppingScript.myTomato.color == Color.green)
                {
                    win.Invoke();
                    Time.timeScale = 0f;
                    backgroundwin.SetActive(true);
                    button.SetActive(true);
                    playsound.SetActive(true);
                    myAudio.PlayOneShot(winsound);
                }
            }
        }
    }


    void PickProduct()
    {
               
        GameObject TM = GameObject.FindGameObjectWithTag("map");
        Tilemap TileMap = TM.GetComponent<Tilemap>();

        BoundsInt bi = TileMap.cellBounds;

        Vector3Int v = new Vector3Int(bi.xMin + Mathf.RoundToInt(transform.position.x), bi.yMin + Mathf.RoundToInt(transform.position.z), 0);
        //Vector3Int south = new Vector3Int(bi.xMin + (int)transform.position.x, bi.yMin + (int)transform.position.z - 1, 0); // tile - 1z from player tile
        //Vector3Int west = new Vector3Int(bi.xMin + (int)transform.position.x - 1, bi.yMin + (int)transform.position.z, 0); // tile - 1x from player tile
        //Vector3Int east = new Vector3Int(bi.xMin + (int)transform.position.x + 1, bi.yMin + (int)transform.position.z, 0); // tile - 1x from player tile

        TileBase T = TileMap.GetTile(v);

        Debug.Log(T);

        if (T.name == "cerealaisle" || T.name == "cerealshelf") 
        {
            GameObject[] cereal = GameObject.FindGameObjectsWithTag("pops");
            if (cereal.Length > 0)
            {
                Destroy(cereal[0]);
                myMoney = myMoney - 25;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
                myShoppingScript.myCereal.color = Color.green;
            }
        }
        if (T.name == "hamaisle" || T.name == "hamshelf")
        {
            GameObject[] ham = GameObject.FindGameObjectsWithTag("ham");
            if (ham.Length > 0)
            {
                Destroy(ham[0]);
                myMoney = myMoney - 20;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
                myShoppingScript.myHam.color = Color.green;
            }
        }
        if (T.name == "milkaisle" || T.name == "milkshelf")
        {
            GameObject[] milk = GameObject.FindGameObjectsWithTag("milk");
            if (milk.Length > 0)
            {
                Destroy(milk[0]);
                myMoney = myMoney - 12;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
                myShoppingScript.myMilk.color = Color.green;
            }

        }
        if (T.name == "cheeseaisle" || T.name == "cheeseshelf")
        {
            GameObject[] cheese = GameObject.FindGameObjectsWithTag("cheese");
            if (cheese.Length > 0)
            {
                Destroy(cheese[0]);
                myMoney = myMoney - 50;
                myShoppingScript.myCheese.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "lemonaisle" || T.name == "lemonshelf")
        {
            GameObject[] lemon = GameObject.FindGameObjectsWithTag("lemon");
            if (lemon.Length > 0)
            {
                Destroy(lemon[0]);
                myMoney = myMoney - 8;
                myShoppingScript.myLemon.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "medelaisle" || T.name == "medelshelf")
        {
            GameObject[] medel = GameObject.FindGameObjectsWithTag("medel");
            if (medel.Length > 0)
            {
                Destroy(medel[0]);
                myMoney = myMoney - 30;
                myShoppingScript.myMedel.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "oatmealaisle" || T.name == "oatmealshelf")
        {
            GameObject[] oatmeal = GameObject.FindGameObjectsWithTag("oatmeal");
            if (oatmeal.Length > 0)
            {
                Destroy(oatmeal[0]);
                myMoney = myMoney - 10;
                myShoppingScript.myOatmeal.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "mayoaisle" || T.name == "mayoshelf")
        {
            GameObject[] mayo = GameObject.FindGameObjectsWithTag("mayo");
            if (mayo.Length > 0)
            {
                Destroy(mayo[0]);
                myMoney = myMoney - 10;
                myShoppingScript.myMayo.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "coffeeaisle" || T.name == "coffeeshelf")
        {
            GameObject[] coffee = GameObject.FindGameObjectsWithTag("coffee");
            if (coffee.Length > 0)
            {
                Destroy(coffee[0]);
                myMoney = myMoney - 35;
                myShoppingScript.myCoffee.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "cookieaisle" || T.name == "cookieshelf")
        {
            GameObject[] cookie = GameObject.FindGameObjectsWithTag("cookie");
            if (cookie.Length > 0)
            {
                Destroy(cookie[0]);
                myMoney = myMoney - 20;
                myShoppingScript.myCookie.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "chipsaisle" || T.name == "chipsshelf")
        {
            GameObject[] chips = GameObject.FindGameObjectsWithTag("chips");
            if (chips.Length > 0)
            {
                Destroy(chips[0]);
                myMoney = myMoney - 20;
                myShoppingScript.myChips.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "breadaisle" || T.name == "breadshelf")
        {
            GameObject[] bread = GameObject.FindGameObjectsWithTag("bread");
            if (bread.Length > 0)
            {
                Destroy(bread[0]);
                myMoney = myMoney - 25;
                myShoppingScript.myBread.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "chickenaisle" || T.name == "chickenshelf")
        {
            GameObject[] chicken = GameObject.FindGameObjectsWithTag("chicken");
            if (chicken.Length > 0)
            {
                Destroy(chicken[0]);
                myMoney = myMoney - 65;
                myShoppingScript.myChicken.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "riceaisle" || T.name == "riceshelf")
        {
            GameObject[] rice = GameObject.FindGameObjectsWithTag("rice");
            if (rice.Length > 0)
            {
                Destroy(rice[0]);
                myMoney = myMoney - 25;
                myShoppingScript.myRice.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "potatoaisle" || T.name == "potatoshelf")
        {
            GameObject[] potato = GameObject.FindGameObjectsWithTag("potato");
            if (potato.Length > 0)
            {
                Destroy(potato[0]);
                myMoney = myMoney - 5;
                myShoppingScript.myPotato.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "tomatoaisle" || T.name == "tomatoshelf")
        {
            GameObject[] tomato = GameObject.FindGameObjectsWithTag("tomato");
            if (tomato.Length > 0)
            {
                Destroy(tomato[0]);
                myMoney = myMoney - 5;
                myShoppingScript.myTomato.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "avocadoaisle" || T.name == "avocadoshelf")
        {
            GameObject[] avocado = GameObject.FindGameObjectsWithTag("avocado");
            if (avocado.Length > 0)
            {
                Destroy(avocado[0]);
                myMoney = myMoney - 15;
                myShoppingScript.myAvocado.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "hotsauseaisle" || T.name == "hotsauseshelf")
        {
            GameObject[] hotsauce = GameObject.FindGameObjectsWithTag("hotsauce");
            if (hotsauce.Length > 0)
            {
                Destroy(hotsauce[0]);
                myMoney = myMoney - 20;
                myShoppingScript.myHotsauce.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "pockyaisle" || T.name == "pockyshelf")
        {
            GameObject[] pocky = GameObject.FindGameObjectsWithTag("pocky");
            if (pocky.Length > 0)
            {
                Destroy(pocky[0]);
                myMoney = myMoney - 20;
                myShoppingScript.myPocky.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
        if (T.name == "teaaisle" || T.name == "teashelf")
        {
            GameObject[] tea = GameObject.FindGameObjectsWithTag("tea");
            if (tea.Length > 0)
            {
                Destroy(tea[0]);
                myMoney = myMoney - 15;
                myShoppingScript.myTea.color = Color.green;
                FindObjectOfType<AudioManager>().Play("ItemPickup");
            }
        }
    }

    void SetBudgetText()
    {
        myMoneyText.text = "Budget: " + myMoney.ToString();
        
    }
    public void SetTimerText()
    {
        myTimerText.text = "" + Mathf.Round(myTimer);
        if (myTimer <= 10.0f)
        {
            myTimerText.color = Color.red;
        }
    }


}
