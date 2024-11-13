using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Inicial : MonoBehaviour
{
    public GameObject Usuario;
    public GameObject AjustesU;
    public GameObject ChangeP;
    public GameObject ChangeU;
    public GameObject Log_out;
    public InputField OldPassword;
    public InputField NewPassword;
    public InputField RepeatNewPassword;
    public InputField NewName;
    public InputField Password;
    public InputField RepeatPassword;
    public TextMeshProUGUI TextoErrorC;
    public TextMeshProUGUI TextoErrorN;
    public BaseDatos user_Password;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Niveles()
    {
        SceneManager.LoadScene("Menu_Niveles");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Ajustes()
    {
        SceneManager.LoadScene("Menu_Ajustes");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Menu_Creditos");
    }
    public void AjustesUsuario()
    {
        Usuario.SetActive(true);
    }
    public void ElejirUsuario()
    {
        SceneManager.LoadScene("Menu_Usuario");
    }
    public void SalirUsuario()
    {
        Usuario.SetActive(false);
        AjustesU.SetActive(true);
        ChangeP.SetActive(false);
        ChangeU.SetActive(false);
        Log_out.SetActive(false);
    }
    public void SalirAjustes()
    {
        Usuario.SetActive(true);
        AjustesU.SetActive(true);
        ChangeP.SetActive(false);
        ChangeU.SetActive(false);
        Log_out.SetActive(false);
    }
    public void NombreUsuario()
    {
        Usuario.SetActive(true);
        AjustesU.SetActive(false);
        ChangeP.SetActive(false);
        ChangeU.SetActive(true);
        Log_out.SetActive(false);
    }
    public void ChangePassword()
    {
        Usuario.SetActive(true);
        AjustesU.SetActive(false);
        ChangeP.SetActive(true);
        ChangeU.SetActive(false);
        Log_out.SetActive(false);
    }
    public void SalirDelUsuario()
    {
        Usuario.SetActive(true);
        AjustesU.SetActive(false);
        ChangeP.SetActive(false);
        ChangeU.SetActive(false);
        Log_out.SetActive(true);
    }
    public void CambiarContrasenia()
    {
        
        if (user_Password.ComprobarChangePassword(OldPassword.text, NewPassword.text, RepeatNewPassword.text))
        {
            user_Password.CambiarContrasenia(NewPassword.text);
            SalirUsuario();
        }
        else
        {
            TextoErrorC.text = "Error la contraseña Nueva y La Contrasña que a repetido son diferentes";
        }
        Blanquear();
    }
    public void CambiarNombre()
    {
        
        if (user_Password.ComprobarChangeName(Password.text, RepeatPassword.text))
        {
            user_Password.CambiarName(NewName.text);

            SalirUsuario();
        }
        else
        {
            TextoErrorN.text = "Error la contraseña Nueva y La Contrasña que a repetido son diferentes";
        }
        Blanquear();
    }
    public void Blanquear()
    {
        OldPassword.text = "";
        NewPassword.text = "";
        RepeatNewPassword.text = "";
        NewName.text = "";
        Password.text = "";
        RepeatPassword.text = ""; 
        TextoErrorC.text = "";
        TextoErrorN.text = "";
    }

}
