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


