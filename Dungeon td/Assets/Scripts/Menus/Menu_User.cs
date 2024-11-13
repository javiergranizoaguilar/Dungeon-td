using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu_User : MonoBehaviour
{
    public InputField User;
    public InputField Password;
    public GameObject BotonVerificar;
    public GameObject BotonCrear;
    public GameObject BotonBack;
    public GameObject TextNoUser;
    public BaseDatos user_Password;
    public TextMeshProUGUI textoError;
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
        BotonBack.SetActive(true);
        BotonCrear.SetActive(true);
        BotonVerificar.SetActive(false);
        TextNoUser.SetActive(false);
        Blanquear();
    }
    public void CambiarVerificar()
    {
        
        BotonCrear.SetActive(false);
        BotonVerificar.SetActive(true);
        TextNoUser.SetActive(true);
        BotonBack.SetActive(false);
        Blanquear();
    }
    public void Creare()
    {
        user_Password.CrearUser(User.text, Password.text);
    }
    public void Verifica()
    {
        user_Password.VerifyUser(User.text, Password.text, textoError);
        User.text = "";
        Password.text = "";
    }
    public void Blanquear()
    {
        User.text = "";
        Password.text = "";
        textoError.text = "";
    }
}
