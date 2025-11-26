using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно для работы со сценами!

public class MainMenuController : MonoBehaviour
{
    // Эту функцию мы привяжем к кнопке "Новая игра"
    public void PlayGame()
    {
        // Загружаем сцену с именем "Game"
        // Важно: имя должно точь-в-точь совпадать с названием твоего файла сцены!
        SceneManager.LoadScene("SampleScene"); 
    }

    // Эту функцию привяжем к кнопке "Выход"
    public void QuitGame()
    {
        Debug.Log("Игра закрылась!"); // Чтобы видеть в редакторе, что кнопка работает

        // Эта команда работает только в скомпилированной игре (.exe)
        Application.Quit(); 
        
        // Небольшой хак, чтобы кнопка работала и внутри редактора Unity:
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
