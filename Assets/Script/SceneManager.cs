using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene(); UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);

        
    }
}
