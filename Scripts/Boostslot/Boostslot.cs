using UnityEngine;

public class Boostslot : MonoBehaviour
{
    public Transform boostSlots;
    public GameObject[] slots;
    public GameObject[] positions;
    public GameObject slotOne;
    public GameObject slotTwo;
    public GameObject slotThree;
    public GameObject slotFour;
    public GameObject slotFive;
    public static int activSalf;
    private void OnEnable()
    {
        activSalf = 0;
        /*if (SlotShop.saveSlotShop == 2)
        {
            slotTwo.SetActive(true);
            gameObject.transform.position += new Vector3(0, 50, 0);
        }

        else if (SlotShop.saveSlotShop == 3)
        {
            slotTwo.SetActive(true);
            slotThree.SetActive(true);
            gameObject.transform.position += new Vector3(0, 100, 0);
        }

        else if (SlotShop.saveSlotShop == 4)
        {
            slotTwo.SetActive(true);
            slotThree.SetActive(true);
            slotFour.SetActive(true);
            gameObject.transform.position += new Vector3(0, 150, 0);
        }

        else if (SlotShop.saveSlotShop == 5)
        {
            slotTwo.SetActive(true);
            slotThree.SetActive(true);
            slotFour.SetActive(true);
            slotFive.SetActive(true);
            gameObject.transform.position += new Vector3(0, 200, 0);
        }*/
        for (int i = 0; i < ShoBoost.staticValueSlot; i++)
        {
            slots[i].SetActive(true);          
        }
        boostSlots.position = positions[ShoBoost.staticValueSlot - 2].transform.position;
    }

    void Update()
    {
        
    }

    public void BoostSlotOneActive()
    {
        

        if (activSalf == 0)
        {
            if (slotOne.activeSelf)
            {
                var one = slotOne.GetComponent<HierarchyBoost>();
                one.Hierarchy();
                activSalf = 0;

            }
        }
        else if (activSalf == 1)
        {
            if (slotTwo.activeSelf)
            {
                var one = slotTwo.GetComponent<HierarchyBoost>();
                one.Hierarchy();
                activSalf = 0;

            }
        }

        else if (activSalf == 2)
        {
            if (slotThree.activeSelf)
            {
                var one = slotThree.GetComponent<HierarchyBoost>();
                one.Hierarchy();
                activSalf = 0;

            }
        }

        else if (activSalf == 3)
        {
            if (slotFour.activeSelf)
            {
                var one = slotFour.GetComponent<HierarchyBoost>();
                one.Hierarchy();
                activSalf = 0;

            }
        }

        else if (activSalf == 4)
        {
            if (slotFive.activeSelf)
            {
                var one = slotFive.GetComponent<HierarchyBoost>();
                one.Hierarchy();
                activSalf = 0;

            }
        }


    }

    public void Disabel()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<HierarchyBoost>().OverDisable();
        }
    }
    
}
