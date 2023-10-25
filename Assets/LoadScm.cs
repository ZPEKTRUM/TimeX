using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public static class LoadScm
{ 

   public enum Scene { }

public static void Loadc(Scene scene)
    
    { 
        
        
        SceneManager.LoadScene(scene.ToString()); 
            
            }
    
}

