using UnityEngine;
using System.Collections;

public class ScoreMenu : MonoBehaviour {

    public void VoltarMenuPrincipal()
    {
        Time.timeScale = 1;
        Application.LoadLevel("MenuPrincipal");
    }
}
