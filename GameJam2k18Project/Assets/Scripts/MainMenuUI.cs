using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            switch(Random.Range(1,7))
            {
                case 1:
                    Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret1);
                    break;
                case 2:
                    Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret2);
                    break;
                case 3:
                    Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret3);
                    break;
                case 4:
                    Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret4);
                    break;
                case 5:
                    Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret5);
                    break;
                case 6:
                    Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret6);
                    break;
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
