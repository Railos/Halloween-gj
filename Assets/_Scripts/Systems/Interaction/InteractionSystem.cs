using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public string hoverMessage = "Курсор наведен на объект";
    public string clickMessage = "Вы держите кнопку, осталось держать {0:F1}/{1:F1} секунд";
    public string finalMessage = "Вы удержали кнопку в течение {0:F1} секунд и выполнили действие.";

    [SerializeField] private GameObject tipUpgradeAndLoot;
    [SerializeField] private GameObject tipUpgrade;

    private IInteractable currentInteractable = null;
    private bool isClicking = false;
    private float clickDuration = 5f;
    private float interactionTime = 0f;

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tipUpgradeAndLoot.transform.position = new Vector3(mousePos.x, mousePos.y);
        tipUpgrade.transform.position = new Vector3(mousePos.x, mousePos.y);
        
        IInteractable interactable = hitCollider != null ? hitCollider.GetComponent<IInteractable>() : null;

        if (interactable != null)
        {
            if (currentInteractable != interactable)
            {
                currentInteractable = interactable;
                Debug.Log(hoverMessage);
                
                if (hitCollider.GetComponent<Upgradable>() && hitCollider.GetComponent<LootGenerator>())
                {
                    tipUpgradeAndLoot.SetActive(true);
                }else if (hitCollider.GetComponent<Upgradable>())
                {
                    tipUpgrade.SetActive(true);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                isClicking = true;
                interactionTime = 0f;
            }
            else if (Input.GetMouseButtonUp(0) && isClicking)
            {
                isClicking = false;
                Debug.Log("Клавиша отпущена");
                interactionTime = 0f;
            }

            if (isClicking)
            {
                interactionTime += Time.deltaTime;
                float remainingTime = Mathf.Max(0, clickDuration - interactionTime);
                string message = string.Format(clickMessage, remainingTime, clickDuration);
                Debug.Log(message);

                if (interactionTime >= clickDuration)
                {
                    isClicking = false;
                    Debug.Log(string.Format(finalMessage, clickDuration));
                    interactable.Interact(); // Вызов метода Interact() у объекта IInteractable
                    interactionTime = 0f;
                }
            }
        }
        else
        {
            // курсор убран
            currentInteractable = null;
            tipUpgrade.SetActive(false);
            tipUpgradeAndLoot.SetActive(false);
        }
    }
}
