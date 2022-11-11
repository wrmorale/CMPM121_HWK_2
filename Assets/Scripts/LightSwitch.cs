using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class LightSwitch : MonoBehaviour
{
    public List<Light> Lights;
    private VisualElement frame;
    private Button button;
    private bool LightOn;
    private bool LightDim;
    // This function is called when the object becomes enabled and active.
    void OnEnable()
    {
        // get the UIDocument component (make sure this name matches!)
        var uiDocument = GetComponent<UIDocument>();
        // get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("LightFrame");
        // get the button, which is nested in the frame
        button = frame.Q<Button>("LightButton");
        // create event listener that calls ChangeCamera() when pressed
        button.RegisterCallback<ClickEvent>(ev => ChangeLight());
    }
    int i = 0;
    private void ChangeLight(){

        if(LightOn == true && LightDim == true){
            for(i = 0; i < Lights.Count; i++){
                Lights[i].enabled = false;
            }
           LightOn = false;
           LightDim = false;
        }
        else if(LightOn == true && LightDim == false){
            for(i = 0; i < Lights.Count; i++){
                Lights[i].intensity = 0.5f;
            }
            LightDim = true;
        }
        else if(LightOn == false && LightDim == false){
            for(i = 0; i < Lights.Count; i++){
                Lights[i].intensity = 1f;
                Lights[i].enabled = true;
           }
           LightOn = true;
        }
        
    }

    
}
