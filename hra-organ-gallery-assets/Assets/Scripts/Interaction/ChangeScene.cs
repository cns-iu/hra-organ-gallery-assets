using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Interaction
{
    public class ChangeScene : MonoBehaviour
    {
        public Animator transition;
        public Button switchScene;
        int switchToScene = 0;
        
        void Awake()
        {
            switchScene.onClick.AddListener(()=>{
                // Debug.Log(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Switch Scene called");
                SwitchScene();
            });
            // if(Input.GetKeyDown(KeyCode.C)){
            //     SwitchScene();
            // }
        }
        // Update is called once per frame
        void Update()
        {
            

        }
        public void SwitchScene(){
            switchToScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;
            Debug.Log($"Switching scene to ${switchToScene}");
            StartCoroutine(LoadNewScene(switchToScene));
            // SceneManager.LoadScene(switchToScene);
            
        }
        IEnumerator LoadNewScene(int levelIndex){
            Debug.Log("Inside Coroutine");
            transition.SetTrigger("Start");
            Debug.Log("transition called");
            yield return new WaitForSeconds(1);
            Debug.Log("Loading Scene");
            SceneManager.LoadScene(levelIndex);
        }

    }
}