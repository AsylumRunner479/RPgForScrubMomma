using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            Ray interactionRay;
            interactionRay = Camera.main.ScreenPointToRay
            (new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interactionRay, out hitInfo, 10))
            {
                switch (hitInfo.collider.tag)
                {
                    case "NPC":
                        Debug.Log("Talk to NPC is triggered");
                        break;
                    case "Item":
                        Debug.Log("hit item");
                        ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>();
                        if(handler != null)
                        {
                            handler.OnCollection();
                        }
                        break;
                    case "Chest":
                        Debug.Log("open chest");
                        Chest chest = hitInfo.transform.GetComponent<Chest>();
                        if (chest != null)
                        {
                            chest.showChest = true;
                            LinearInventory.showInv = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            Time.timeScale = 0;
                        }
                        break;
                    case "Shop":
                        Debug.Log("open shop");
                        Shop shop = hitInfo.transform.GetComponent<Shop>();
                        if (shop != null)
                        {
                            shop.showShop = true;
                            LinearInventory.showInv = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            Time.timeScale = 0;
                        }
                        break;


                }
            }
            /*/if(Physics.Raycast(interactionRay, out hitInfo,10))
            {
                if(hitInfo.collider.CompareTag("NPC"))
                {
                    Debug.Log("Talk to NPC is triggered");
                }
                if(hitInfo.collider.tag == "Item")
                {
                    Debug.Log("hit item");
                }
            }
            /*/
        }
    }
}
