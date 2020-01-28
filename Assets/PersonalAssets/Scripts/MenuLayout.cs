using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLayout : MonoBehaviour
{

    public float WidthContainer;
    public float HeightContainer;
    float PreviousWidth;
    float PreviousHeight;


    public int MenuItems;
    public int Row;
    float MenuZ;
    int PreviousItems;
    int PreviousRow;

    Text gameText;

    public GameObject Boundry;
    public GameObject MenuObject;
    Bounds b;


    // Start is called before the first frame update
    void Start()
    {

        gameText = GameObject.Find("txtMenuItems").GetComponent<Text>();
        gameText.text = $"Items: {MenuItems} - Rows: {Row}";

        WidthContainer = PreviousWidth = Boundry.transform.localScale.x;
        HeightContainer = PreviousHeight = Boundry.transform.localScale.y;
        MenuZ = MenuObject.transform.localScale.z;

        b = Boundry.GetComponent<Renderer>().bounds;

        MenuItems = PreviousItems = 1;
        Row = PreviousRow = 1;
        DisplayMenu(MenuItems, Row);
        //Instantiate(MenuObject, b.center, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

 
        if(Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.H)) Row--;
            if (Input.GetKeyDown(KeyCode.K)) Row++;
            if (Input.GetKeyDown(KeyCode.U)) MenuItems++;
            if (Input.GetKeyDown(KeyCode.J)) MenuItems--;
            if (Input.GetKeyDown(KeyCode.Y))
            {
                MenuItems = 9;
                Row = 3;
            }
            if (Input.GetKeyDown(KeyCode.I)) 
            {
                MenuItems = 100;
                Row = 10;
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                MenuItems = 1;
                Row = 1;
            }
            gameText.text = $"Items: {MenuItems} - Rows: {Row}";
        }
        


        if(SizeChange())
        {
            Boundry.transform.localScale = new Vector3(WidthContainer, HeightContainer, this.transform.localScale.z);
            DestroyMenu();
            DisplayMenu(MenuItems, Row);

            PreviousHeight = HeightContainer;
            PreviousWidth = WidthContainer;
        }

        if(MenuChange())
        {
            DestroyMenu();
            DisplayMenu(MenuItems, Row);
            PreviousItems = MenuItems;
            PreviousRow = Row;
            Debug.Log($"{MenuItems} - {Row}");
        }
        
    }

    bool SizeChange()
    {
        return (PreviousHeight != HeightContainer) || (WidthContainer != PreviousWidth);
    }

    private void DisplayMenu(int items, int row) 
    {


        if(items != 0 && row != 0)
        {
            b = Boundry.GetComponent<Renderer>().bounds;
            float MWidth = (b.size.x / items) * row;
            float MHeight = b.size.y / row;
            float startX = b.center.x - (b.size.x / 2) + (MWidth / 2);
            float startY = b.center.y + (b.size.y / 2) - (MHeight / 2);


            for (int i = 0; i < items; i++)
            {
                GameObject temp = Instantiate(MenuObject);
                temp.transform.localScale = new Vector3(MWidth, MHeight, 0.001f);
                temp.transform.localPosition = new Vector3(startX + (MWidth * (int)(i / row)), startY - (MHeight * (int)(i % row)), b.center.z);
                temp.transform.SetParent(Boundry.transform);
            }
        }



    } // End DisplayMenu

    bool MenuChange()
    {
        return (MenuItems != PreviousItems) || (Row != PreviousRow);
    } // End MenuChange()

    void DestroyMenu()
    {
        foreach(Transform child in Boundry.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

}
