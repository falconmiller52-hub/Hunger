using UnityEngine;
using UnityEngine.UI; // Если используешь обычный Text
// using TMPro; // Раскомментируй, если используешь TextMeshPro

public class PlayerInteraction : MonoBehaviour
{
    [Header("Настройки луча")]
    public float interactDistance = 3f; // Дистанция, с которой можно брать предметы
    public LayerMask interactLayer; // Слой предметов (пока можно оставить Everything)

    [Header("UI")]
    public GameObject interactText; // Сюда перетащим наш текст

    void Update()
    {
        // Пускаем луч из центра экрана
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Проверяем, попал ли луч во что-то
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Проверяем, есть ли у объекта тег "Interactable"
            if (hit.collider.CompareTag("Interactable"))
            {
                // 1. Показываем текст
                interactText.SetActive(true);

                // 2. Если нажали E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PickUpItem(hit.collider.gameObject);
                }
            }
            else
            {
                // Если смотрим на стену - прячем текст
                interactText.SetActive(false);
            }
        }
        else
        {
            // Если смотрим в пустоту - прячем текст
            interactText.SetActive(false);
        }
    }

    void PickUpItem(GameObject item)
    {
        // Тут можно добавить логику инвентаря
        Debug.Log("Подобрал: " + item.name);
        
        // Уничтожаем предмет
        Destroy(item);

        // Сразу прячем текст, так как предмета больше нет
        interactText.SetActive(false);
    }
}
