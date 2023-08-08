using System;
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

    
    // alt�n topland���nda dinlenecek olay� tan�mlad�k
    // <> i�inde tan�mlama yap�ld���nda GoldChanged eventinin metodu int parametre al�yor demektir
    // invoke ile ilgili parametreyi vermek gerekir
    public event Action<int> GoldChanged;

    public event Action<int> LevelChanged;

    public event Action GameStarted;

    public event Action GameEnded;

    public event Action Won;

    public event Action Lost;

    public bool IsGameStarted { get; private set; }

    public void StartGame()
    {
        IsGameStarted = true;
        GameStarted?.Invoke();
    }

    private void EndGame()
    {
        IsGameStarted = false;
        GameEnded?.Invoke();
    }

    public int _level;

    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            LevelChanged?.Invoke(_level);
        }
    }

    private int _gold;

    public int Gold
    {
        get => _gold;
        /*
         * get
         * {
         *      return _gold;
         * }
         * 
         * �stteki get bununla ayn� i�i yap�yor
         * */
        set
        {
            _gold = value;
            // gold de�eri her de�i�ti�inde ilgili olay kontrol edilsin
            GoldChanged?.Invoke(_gold);
            /*
             * if(GoldChaned != null)
             *      GoldChanged.Invoke();
             *      
             * bu yukar�daki ile ayn�
             * */
        }
    }

    public float GoldMultiplier { get; set; } = 1;

    public void LoadCurrentLevel()
    {
        // Win() metodu i�erisinde level++ yapt�r�yoruz bu y�zden burada var olunan level sonraki level olmu� oluyor
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        Level++;
        EndGame();

        Won?.Invoke();
    }

    public void Lose()
    {
        EndGame();
        Lost?.Invoke();
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


