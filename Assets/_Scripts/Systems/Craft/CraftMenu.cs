using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftMenu : MonoBehaviour
{
    public GameObject menuMainObject;
    public Color canCraftColor, cannotCraftColor;
    public Button doCraftButton;
    
    [SerializeField] private GameObject contentGroup;
    [SerializeField] private GameObject craftButton;

    [SerializeField] private GameObject resourcesGroup;
    [SerializeField] private GameObject craftResource;

    [SerializeField] private TMP_Text craftName;
    [SerializeField] private Image craftIcon;
    [SerializeField] private GameObject craftDetails;
    public static CraftMenu craftMenu;
    public Craft curRecipe;

    [SerializeField] private Item wood;
    [SerializeField] private Item penis;

    private void Awake()
    {
        if (craftMenu != null)
        {
            Destroy(craftMenu);
        }
        else
        {
            craftMenu = this;
        }
    }

    public void OpenMenu()
    {
        UpdateMenu();

        menuMainObject.SetActive(true);
    }
    
    private void Start()
    {
        InventorySystem.Inventory.AddItem(wood, 2);
        InventorySystem.Inventory.AddItem(penis, 1);

    }

    public void ChooseRecipe(Button button)
    {
        craftDetails.SetActive(true);
        foreach (Transform child in resourcesGroup.transform)
        {
            Destroy(child.gameObject);
        }

        curRecipe = button.GetComponent<CraftButtonPrefab>().craft;

        craftName.text = curRecipe.result[0].item.itemName;
        craftName.color = CraftSystem.crafting.CanCraft(curRecipe) ? canCraftColor : cannotCraftColor;
        doCraftButton.interactable = CraftSystem.crafting.CanCraft(curRecipe);
        craftIcon.sprite = curRecipe.result[0].item.itemImage;
        foreach (var itemStack in button.GetComponent<CraftButtonPrefab>().craft.resources)
        {
            var newResource = Instantiate(craftResource, Vector3.zero, Quaternion.identity, resourcesGroup.transform).GetComponent<CraftResourcePrefab>();

            newResource.icon.sprite = itemStack.item.itemImage;
            newResource.amount.text = itemStack.amount.ToString();
        }
    }

    public void UpdateMenu()
    {
        craftDetails.SetActive(false);
        foreach (Transform child in resourcesGroup.transform)
        {
            Destroy(child.gameObject);
        }
        
        foreach (Transform child in contentGroup.transform)
        {
            Destroy(child.gameObject);
        }
        
        foreach (var craft in CraftSystem.crafting.crafts)
        {
            var newButton = Instantiate(craftButton, Vector3.zero, Quaternion.identity, contentGroup.transform).GetComponent<CraftButtonPrefab>();
            
            newButton.icon.sprite = craft.result[0].item.itemImage;
            newButton.name.text = craft.result[0].item.itemName;
            newButton.name.color = CraftSystem.crafting.CanCraft(craft) ? canCraftColor : cannotCraftColor;
            newButton.amount.text = craft.result[0].amount.ToString();
            newButton.craft = craft;
        }
    }
    
    public void DoCrafting()
    {
        CraftSystem.crafting.Craft(curRecipe);
        UpdateMenu();
    }

    public void Close()
    {
        menuMainObject.SetActive(false);
    }
}
