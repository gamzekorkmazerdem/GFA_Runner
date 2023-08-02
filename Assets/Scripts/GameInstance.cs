using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    /*
     * singleton pattern ile kodlama yap�yoruz
     * burada proje boyunca yaln�zca bir nesne olacak
     * ve b�t�n i�lemler bu nesne ile ger�ekle�tirilecek
     * bu nesne her yerde eri�ilebilir olmal�
     * bunun i�in _instance tan�mland�
     */
    private static GameInstance _instance;

    public int Gold { get; set; }
    public int Level { get; set; }
    public void Win()
    {
        Debug.Log("You win!");
        Level++;
        SceneManager.LoadScene(0);
    }
    public void Lose()
    {
        Debug.Log("You lose!");
        SceneManager.LoadScene(0);
    }

    // d��ardaki objelerin bu nesneye eri�mesi i�in prop olu�turuldu
    public static GameInstance Instance
    {
        get
        {
            // e�er instance yoksa sahnedeki ayn� t�rdeki instance � bul
            if (!_instance)
            {
                _instance = FindObjectOfType<GameInstance>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        /*
         * singleton a uygun olmas� i�in sadece bir nesnenin var oldu�undan emin olmal�y�z
         * bunun i�in if kontrol� koyduk
         * e�er instance varsa ve ondan ba�ka bir nesneyse nesneyi yok et
         * e�er yoksa yani tek instance kendisi ise 
         * sahne de�i�se de obje var olsun ve yok edilmesin
         */

        if (_instance && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}


