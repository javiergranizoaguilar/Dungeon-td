using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_User : MonoBehaviour
{
    public InputField User;
    public InputField Password;
    public GameObject BotonVerificar;
    public GameObject BotonCrear;
    public GameObject TextNoUser;
    public User_Password user_Password;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarCrear()
    {
        BotonCrear.SetActive(true);
        BotonVerificar.SetActive(false);
        TextNoUser.SetActive(false);
    }
    public void CambiarVerificar()
    {
        user_Password.CrearUser(User.text,Password.text);
        BotonCrear.SetActive(false);
        BotonVerificar.SetActive(true);
        TextNoUser.SetActive(true);
    }
    public void Verifica(){
        user_Password.VerifyUser(User.text,Password.text);
    }
}
