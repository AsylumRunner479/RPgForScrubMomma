using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LinearInventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public GameObject invShow;
    public Item item;
    public PlayerHandler player;
    public Vector2 scr;
    public static Item selectedItem;
    public static int money;
    public Vector2 scrollPos;
    public string sortType = "All";
    public Transform dropLocation;
    [System.Serializable]
    public struct EquippedItems
    {
        public string slotName;
        public Transform location;
        public GameObject equippedItem;
    };
    public EquippedItems[] equippedItems;

    public GameObject[] weapons;
    public GameObject[] armours;
    public GameObject[] potions;
    public GameObject[] foods;
    public GameObject[] ingredients;
    public GameObject[] craftables;
    public GameObject[] quests;
    public GameObject[] miscs;
    //public Text[] ItemOptions;
    public DisplayItem display;
    public bool invFilterOptions;
    public GUISkin invSkin;
    public GUIStyle titleStyle;

    #endregion
    [System.Serializable]
    public struct DisplayItem
    {
        public Text itemName;
        public RawImage itemIcon;
        public Text itemDescription;
        public Text itemDamage;
        public Text UseItem;
        public Text RemoveItem;

    };
    void Start()
    {
        //adds on a bunch of different items in your inventory
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(100));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(302));
        inv.Add(ItemData.CreateItem(400));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(402));
        inv.Add(ItemData.CreateItem(500));
        inv.Add(ItemData.CreateItem(501));
        inv.Add(ItemData.CreateItem(502));
        inv.Add(ItemData.CreateItem(600));
        inv.Add(ItemData.CreateItem(601));
        inv.Add(ItemData.CreateItem(602));
        inv.Add(ItemData.CreateItem(700));
        inv.Add(ItemData.CreateItem(701));
        inv.Add(ItemData.CreateItem(702));
        money = 1000;
        showInv = false;
        invShow.SetActive(false);
    }
    private void Update()
    {
        // makes the inventory open and close based on whther you press tab.
        if (Input.GetButtonDown("Inventory") && !PauseMenu.isPaused)
        {

            showInv = !showInv;
            if (showInv)
            {
                invShow.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                invShow.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                selectedItem = null;

            }
        }
        if (Input.GetKey(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(Random.Range(0, 3)));
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            inv[10].Amount++;
        }
    }
    private void HideItems()
    {
        weapons[0].SetActive(false);
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);
        armours[0].SetActive(false);
        armours[1].SetActive(false);
        armours[2].SetActive(false);
        potions[0].SetActive(false);
        potions[1].SetActive(false);
        potions[2].SetActive(false);
        foods[0].SetActive(false);
        foods[1].SetActive(false);
        foods[2].SetActive(false);
        ingredients[0].SetActive(false);
        ingredients[1].SetActive(false);
        ingredients[2].SetActive(false);
        craftables[0].SetActive(false);
        craftables[1].SetActive(false);
        craftables[2].SetActive(false);
        quests[0].SetActive(false);
        quests[1].SetActive(false);
        quests[2].SetActive(false);
        miscs[0].SetActive(false);
        miscs[1].SetActive(false);
        miscs[2].SetActive(false);
    }
    public void ShowWeapon()
    {
        HideItems();
        weapons[0].SetActive(true);
        weapons[1].SetActive(true);
        weapons[2].SetActive(true);

    }
    public void ShowArmour()
    {
        HideItems();
        armours[0].SetActive(true);
        armours[1].SetActive(true);
        armours[2].SetActive(true);
    }
    public void ShowPotion()
    {
        HideItems();
        potions[0].SetActive(true);
        potions[1].SetActive(true);
        potions[2].SetActive(true);
    }
    public void ShowFood()
    {
        HideItems();
        foods[0].SetActive(true);
        foods[1].SetActive(true);
        foods[2].SetActive(true);
    }
    public void ShowIngredient()
    {
        HideItems();
        ingredients[0].SetActive(true);
        ingredients[1].SetActive(true);
        ingredients[2].SetActive(true);
    }
    public void ShowCraftable()
    {
        HideItems();
        craftables[0].SetActive(true);
        craftables[1].SetActive(true);
        craftables[2].SetActive(true);
    }
    public void ShowQuest()
    {
        HideItems();
        quests[0].SetActive(true);
        quests[1].SetActive(true);
        quests[2].SetActive(true);
    }
    public void ShowMisc()
    {
        HideItems();
        miscs[0].SetActive(true);
        miscs[1].SetActive(true);
        miscs[2].SetActive(true);
    }
    public void ShowAll()
    {
        weapons[0].SetActive(true);
        weapons[1].SetActive(true);
        weapons[2].SetActive(true);
        armours[0].SetActive(true);
        armours[1].SetActive(true);
        armours[2].SetActive(true);
        potions[0].SetActive(true);
        potions[1].SetActive(true);
        potions[2].SetActive(true);
        foods[0].SetActive(true);
        foods[1].SetActive(true);
        foods[2].SetActive(true);
        ingredients[0].SetActive(true);
        ingredients[1].SetActive(true);
        ingredients[2].SetActive(true);
        craftables[0].SetActive(true);
        craftables[1].SetActive(true);
        craftables[2].SetActive(true);
        quests[0].SetActive(true);
        quests[1].SetActive(true);
        quests[2].SetActive(true);
        miscs[0].SetActive(true);
        miscs[1].SetActive(true);
        miscs[2].SetActive(true);
    }
    void DisplayInv()
    {
        //If we have a Type selected (filter)
        if (!(sortType == "All" || sortType == ""))
        {
            ItemTypes type = (ItemTypes)
                System.Enum.Parse(typeof(ItemTypes), sortType);
            int a = 0;
            int s = 0;
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].ItemType == type)
                {
                    a++;
                }
            }
            if (a <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].ItemType == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                        s++;
                    }

                }
            }

            else
            {

                scrollPos =

               GUI.BeginScrollView(
               //our position and size of our window
               new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y),
               //our current position in the scroll view
               scrollPos,
               //viewable area
               new Rect(0, 0, 0, a * (0.25f * scr.y)),
                //can we see our Horizontal bar?
                false,
               //Can we see our Vertical Bar?
               true);
                #region Scrollable Space
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].ItemType == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, s * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                        s++;
                    }
                }
                #endregion
                GUI.EndScrollView();
            }

        }
        //All Items are shown
        else
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
            }
            else// we have more items than screen space
            {
                //our move position of our scroll window
                scrollPos =
               //the Start of our scroll view
               GUI.BeginScrollView(
               //our position and size of our window
               new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y),
               //our current position in the scroll view
               scrollPos,
               //viewable area
               new Rect(0, 0, 0, inv.Count * (0.25f * scr.y)),
                //can we see our Horizontal bar?
                false,
               //Can we see our Vertical Bar?
               true);

                #region Scrollable Space
                //displays all the invenory items in a list format
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
                #endregion
                GUI.EndScrollView();
            }
        }
    }

    public void SelectItem(int j)
    {
        // inv.Add(ItemData.CreateItem(j));
        selectedItem = inv[j];

        print("The item name is " + selectedItem.Name);
        ShowItemOptions();
        if (j <= 2)
        {
            display.UseItem.text = "Wear";
        }
        else
        {
            display.UseItem.text = "Use";
        }


    }
    public void ShowItemOptions()
    {
        //ITEM DATA IS ALWAYS EMPTY!

        display.UseItem.text = selectedItem.UseItem;
        display.RemoveItem.text = selectedItem.RemoveItem;
        display.itemName.text = selectedItem.Name;
        //display.itemIcon.sprite = selectedItem.IconName;
        display.itemDescription.text = selectedItem.Description + "\nAmount: " + selectedItem.Amount + "\nPrice: $" + selectedItem.Value;
        display.itemDamage.text = "Damage: " + selectedItem.Damage;
        display.itemIcon.texture = selectedItem.IconName.texture;
        display.UseItem.text = "Use";

        Debug.Log("ShowItem");
    }
    public void DiscardItem()
    {
        //check if the item is equipped
                    for (int i = 0; i < equippedItems.Length; i++)
                    {
                       if (equippedItems[i].equippedItem != null && selectedItem.Name == equippedItems[i].equippedItem.name)
                        {
                            //if so destroy from scene
                            Destroy(equippedItems[i].equippedItem);
                        }
                    }

                    //spawn item at droplocation
                    GameObject itemToDrop = Instantiate(selectedItem.MeshName, dropLocation.position, Quaternion.identity);
                    //apply gravity and make sure its named correctly 
                    itemToDrop.name = selectedItem.Name;
                    itemToDrop.AddComponent<Rigidbody>().useGravity = true;

                    //is the amount > 1 if so reduce from list
                    if (selectedItem.Amount > 1)
                    {
                        selectedItem.Amount--;
                    }
                    else//else remove from list 
                    {
                        inv.Remove(selectedItem);
                        selectedItem = null;
                        return;
                    }
    }
    public void RemoveItem()
    {
        switch (selectedItem.ItemType)
            {
                case ItemTypes.Armour:
                    //this allows to wear and take off your colothing from your inventory
                    if (!(equippedItems[1].equippedItem == null || selectedItem.Name != equippedItems[1].equippedItem.name))
                    {
                   
                        Destroy(equippedItems[1].equippedItem);
                        equippedItems[1].equippedItem = null;
                    
                }
                    
                    break;
                case ItemTypes.Weapon:
                    //when a weapon is selected this allows you to see the damage and equip and de equip it
                    
                    if (!(equippedItems[1].equippedItem == null || selectedItem.Name != equippedItems[1].equippedItem.name))
                    {
                   
                        Destroy(equippedItems[1].equippedItem);
                        equippedItems[1].equippedItem = null;
                    
                    }
                    

                        break;
                    
                    default:
                        break;
                }
    }
    public void UseItem()
    {
        switch (selectedItem.ItemType)
            {
                case ItemTypes.Armour:
                    //this allows to wear and take off your colothing from your inventory
                    if (equippedItems[1].equippedItem == null || selectedItem.Name != equippedItems[1].equippedItem.name)
                    {
                        
                            if (equippedItems[1].equippedItem != null)
                            {
                                Destroy(equippedItems[1].equippedItem);
                            }
                            equippedItems[1].equippedItem = Instantiate(selectedItem.MeshName, equippedItems[1].location);
                            equippedItems[1].equippedItem.name = selectedItem.Name;
                        
                    }
                   
                    break;
                case ItemTypes.Weapon:
                    //when a weapon is selected this allows you to see the damage and equip and de equip it
                    
                    if (equippedItems[1].equippedItem == null || selectedItem.Name != equippedItems[1].equippedItem.name)
                    {
                        
                            if (equippedItems[1].equippedItem != null)
                            {
                                Destroy(equippedItems[1].equippedItem);
                            }
                            equippedItems[1].equippedItem = Instantiate(selectedItem.MeshName, equippedItems[1].location);
                            equippedItems[1].equippedItem.name = selectedItem.Name;
                        
                    }
                   

                        break;
                    case ItemTypes.Potion:
                        
                            // heals the player when they drink a potion
                            player.curHealth += selectedItem.Heal;
                            selectedItem.Amount -= 1;

                        break;
                    case ItemTypes.Food:
                        
                            //heals the player when they eat something
                            player.curHealth += selectedItem.Heal;
                           selectedItem.Amount -= 1;
                        
                        break;
                   case ItemTypes.Ingredient:

                            selectedItem.Amount -= 1;
                        
                        break;
                    case ItemTypes.Craftable:
                       
                            selectedItem.Amount -= 1;
                        
                        break;
                    default:
                        break;
                }
        }


        //void OnGUI()
        //{
        //    if (showInv && !PauseMenu.isPaused)
        //    {
        //        scr = new Vector2(Screen.width / 16, Screen.height / 9);
        //        GUI.skin = invSkin;

        //        DisplayInv();
        //        if (GUI.Button(new Rect(4f * scr.x, 6.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Filter"))
        //        {
        //            invFilterOptions = !invFilterOptions;

        //        }
        //        GUI.skin = null;
        //        if (invFilterOptions)
        //        {
        //            //allows you filter the items by type for easier navigation
        //            if (GUI.Button(new Rect(5.5f * scr.x, 6.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "All"))
        //            {
        //                sortType = "All";
        //            }
        //            if (GUI.Button(new Rect(5.5f * scr.x, 7f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Weapon"))
        //            {
        //                sortType = "Weapon";
        //            }
        //            if (GUI.Button(new Rect(5.5f * scr.x, 7.25f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Armour"))
        //            {
        //                sortType = "Armour";
        //            }
        //            if (GUI.Button(new Rect(5.5f * scr.x, 7.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Potion"))
        //            {
        //                sortType = "Potion";
        //            }
        //            if (GUI.Button(new Rect(5.5f * scr.x, 7.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Food"))
        //            {
        //                sortType = "Food";
        //            }
        //            if (GUI.Button(new Rect(5.5f * scr.x, 8f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Ingredient"))
        //            {
        //                sortType = "Ingredient";
        //            }
        //            if (GUI.Button(new Rect(5.5f * scr.x, 8.25f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Craftable"))
        //            {
        //                sortType = "Craftable";
        //            }
        //            if (GUI.Button(new Rect(5.5f * scr.x, 8.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Quest"))
        //            {
        //                sortType = "Quest";
        //            }
        //            if (GUI.Button(new Rect(5.5f * scr.x, 8.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Misc"))
        //            {
        //                sortType = "Misc";
        //            }



        //        }
        //        if (selectedItem == null)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            UseItem();
        //        }

        //    }

        //    void UseItem()
        //    {
        //        //displays all the stat and options on what to do with them
        //        GUI.Box(new Rect(4f * scr.x, 0.25f * scr.y, 3 * scr.x, 0.25f * scr.y), selectedItem.Name, titleStyle);
        //        GUI.skin = invSkin;
        //        // GUI.Box(new Rect(4f * scr.x, 0.5f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.IconName);
        //        GUI.Box(new Rect(4f * scr.x, 3.5f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Description + "\nAmount: " + selectedItem.Amount + "\nPrice: $" + selectedItem.Value);
        //        switch (selectedItem.ItemType)
        //        {
        //            case ItemTypes.Armour:
        //                //this allows to wear and take off your colothing from your inventory
        //                if (equippedItems[1].equippedItem == null || selectedItem.Name != equippedItems[1].equippedItem.name)
        //                {
        //                    if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Wear"))
        //                    {
        //                        if (equippedItems[1].equippedItem != null)
        //                        {
        //                            Destroy(equippedItems[1].equippedItem);
        //                        }
        //                        equippedItems[1].equippedItem = Instantiate(selectedItem.MeshName, equippedItems[1].location);
        //                        equippedItems[1].equippedItem.name = selectedItem.Name;
        //                    }
        //                }
        //                else
        //                {
        //                    if (GUI.Button(new Rect(4 * scr.x, 7f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "strip"))
        //                    {
        //                        Destroy(equippedItems[1].equippedItem);
        //                        equippedItems[1].equippedItem = null;
        //                    }
        //                }
        //                break;
        //            case ItemTypes.Weapon:
        //                //when a weapon is selected this allows you to see the damage and equip and de equip it
        //                GUI.Box(new Rect(4 * scr.x, 7f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Damage: " + selectedItem.Damage);
        //                if (equippedItems[1].equippedItem == null || selectedItem.Name != equippedItems[1].equippedItem.name)
        //                {
        //                    if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Equip"))
        //                    {
        //                        if (equippedItems[1].equippedItem != null)
        //                        {
        //                            Destroy(equippedItems[1].equippedItem);
        //                        }
        //                        equippedItems[1].equippedItem = Instantiate(selectedItem.MeshName, equippedItems[1].location);
        //                        equippedItems[1].equippedItem.name = selectedItem.Name;
        //                    }
        //                }
        //                else
        //                {
        //                    if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "UnEquip"))
        //                    {
        //                        Destroy(equippedItems[1].equippedItem);
        //                        equippedItems[1].equippedItem = null;
        //                    }
        //                }

        //                break;
        //            case ItemTypes.Potion:
        //                if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Drink"))
        //                {
        //                    // heals the player when they drink a potion
        //                    player.curHealth += selectedItem.Heal;
        //                    selectedItem.Amount -= 1;

        //                }
        //                break;
        //            case ItemTypes.Food:
        //                if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Eat"))
        //                {
        //                    //heals the player when they eat something
        //                    player.curHealth += selectedItem.Heal;
        //                    selectedItem.Amount -= 1;
        //                }
        //                break;
        //            case ItemTypes.Ingredient:
        //                if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Use"))
        //                {
        //                    selectedItem.Amount -= 1;
        //                }
        //                break;
        //            case ItemTypes.Craftable:
        //                if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Use"))
        //                {
        //                    selectedItem.Amount -= 1;
        //                }
        //                break;
        //            default:
        //                break;
        //        }

        //        // this allows the player to throw away items they don't need or want
        //        if (GUI.Button(new Rect(5.5f * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Discard"))
        //        {
        //            //check if the item is equipped
        //            for (int i = 0; i < equippedItems.Length; i++)
        //            {
        //                if (equippedItems[i].equippedItem != null && selectedItem.Name == equippedItems[i].equippedItem.name)
        //                {
        //                    //if so destroy from scene
        //                    Destroy(equippedItems[i].equippedItem);
        //                }
        //            }

        //            //spawn item at droplocation
        //            GameObject itemToDrop = Instantiate(selectedItem.MeshName, dropLocation.position, Quaternion.identity);
        //            //apply gravity and make sure its named correctly 
        //            itemToDrop.name = selectedItem.Name;
        //            itemToDrop.AddComponent<Rigidbody>().useGravity = true;

        //            //is the amount > 1 if so reduce from list
        //            if (selectedItem.Amount > 1)
        //            {
        //                selectedItem.Amount--;
        //            }
        //            else//else remove from list 
        //            {
        //                inv.Remove(selectedItem);
        //                selectedItem = null;
        //                return;
        //            }

        //        }
        //    }
        //}
    }
