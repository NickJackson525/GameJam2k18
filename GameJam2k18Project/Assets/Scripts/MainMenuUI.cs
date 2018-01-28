using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject background;
    public Sprite menuBackground1;
    public Sprite menuBackground2;
    int timer = 100;

    private void Update()
    {
        if(timer > 0)
        {
            timer--;

            if(timer == 0)
            {
                if(background.GetComponent<Image>().sprite == menuBackground1)
                {
                    background.GetComponent<Image>().sprite = menuBackground2;
                }
                else
                {
                    background.GetComponent<Image>().sprite = menuBackground1;
                }

                timer = 100;
            }
        }

        Audio_Manager.Instance.Update();

        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            switch(Random.Range(1,10))
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
                case 7:
                    Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret7);
                    break;
                case 8:
                    Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret8);
                    break;
                case 9:
                    Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret9);
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
