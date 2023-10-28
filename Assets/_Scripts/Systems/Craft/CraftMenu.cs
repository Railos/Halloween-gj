using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftMenu : MonoBehaviour
{
    [SerializeField] private GameObject contentGroup;
    [SerializeField] private GameObject craftButton;

    [SerializeField] private GameObject resourcesGroup;
    [SerializeField] private GameObject craftResource;

    [SerializeField] private TMP_Text craftName;
    [SerializeField] private Image craftIcon;

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

    private void Start()
    {
        InventorySystem.Inventory.AddItem(wood, 2);
        InventorySystem.Inventory.AddItem(penis, 1);
        
        foreach (var craft in CraftSystem.crafting.crafts)
        {
            var newButton = Instantiate(craftButton, Vector3.zero, Quaternion.identity, contentGroup.transform).GetComponent<CraftButtonPrefab>();

            newButton.icon.sprite = craft.result[0].item.itemImage;
            newButton.name.text = craft.result[0].item.itemName;
            newButton.amount.text = craft.result[0].amount.ToString();
            newButton.craft = craft;
        }
    }

    public void ChooseRecipe(Button button)
    {
        foreach (Transform child in resourcesGroup.transform)
        {
            Destroy(child.gameObject);
        }

        curRecipe = button.GetComponent<CraftButtonPrefab>().craft;

        craftName.text = curRecipe.result[0].item.itemName;
        craftIcon.sprite = curRecipe.result[0].item.itemImage;
        foreach (var itemStack in button.GetComponent<CraftButtonPrefab>().craft.resources)
        {
            var newResource = Instantiate(craftResource, Vector3.zero, Quaternion.identity, resourcesGroup.transform).GetComponent<CraftResourcePrefab>();

            newResource.icon.sprite = itemStack.item.itemImage;
            newResource.amount.text = itemStack.amount.ToString();
        }
    }

    public void DoCrafting()
    {
        CraftSystem.crafting.Craft(curRecipe);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
