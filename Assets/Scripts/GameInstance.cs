using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    /*
     * singleton pattern ile kodlama yapýyoruz
     * burada proje boyunca yalnýzca bir nesne olacak
     * ve bütün iþlemler bu nesne ile gerçekleþtirilecek
     * bu nesne her yerde eriþilebilir olmalý
     * bunun için _instance tanýmlandý
     */
    private static GameInstance _instance;

    
    // altýn toplandýðýnda dinlenecek olayý tanýmladýk
    // <> içinde tanýmlama yapýldýðýnda GoldChanged eventinin metodu int parametre alýyor demektir
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
         * üstteki get bununla ayný iþi yapýyor
         * */
        set
        {
            _gold = value;
            // gold deðeri her deðiþtiðinde ilgili olay kontrol edilsin
            GoldChanged?.Invoke(_gold);
            /*
             * if(GoldChaned != null)
             *      GoldChanged.Invoke();
             *      
             * bu yukarýdaki ile ayný
             * */
        }
    }

    public float GoldMultiplier { get; set; } = 1;

    public void LoadCurrentLevel()
    {
        // Win() metodu içerisinde level++ yaptýrýyoruz bu yüzden burada var olunan level sonraki level olmuþ oluyor
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

    // dýþardaki objelerin bu nesneye eriþmesi için prop oluþturuldu
    public static GameInstance Instance
    {
        get
        {
            // eðer instance yoksa sahnedeki ayný türdeki instance ý bul
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
         * singleton a uygun olmasý için sadece bir nesnenin var olduðundan emin olmalýyýz
         * bunun için if kontrolü koyduk
         * eðer instance varsa ve ondan baþka bir nesneyse nesneyi yok et
         * eðer yoksa yani tek instance kendisi ise 
         * sahne deðiþse de obje var olsun ve yok edilmesin
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


