using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeCamera : MonoBehaviour
{
    // create camera list that can be updated in the inspector
   public List<Camera> Cameras;
   // create frame and button variables
   private VisualElement frame;
   private Button button;
   private Button lightbutton;
   public Light pointlight;

   // This function is called when the object becomes enabled and active.
   void OnEnable()
   {
       // get the UIDocument component (make sure this name matches!)
       var uiDocument = GetComponent<UIDocument>();
       // get the rootVisualElement (the frame component)
       var rootVisualElement = uiDocument.rootVisualElement;
       frame = rootVisualElement.Q<VisualElement>("Frame");
       // get the button, which is nested in the frame
       button = frame.Q<Button>("Button");
       lightbutton = frame.Q<Button>("LightButton");
       // create event listener that calls ChangeCamera() when pressed
       button.RegisterCallback<ClickEvent>(ev => ChangeCameraFunc());
       lightbutton.RegisterCallback<ClickEvent>(ev => toggleLight());
   }
   int click = 0;
    private void ChangeCameraFunc(){
        EnableCamera(click);
        click++;
        // reset counter so it is not out of bounds (only have 4 cameras)
        if(click > 3){
            click = 0;
        }
    }
    private void EnableCamera(int n){
        // disable each of the cameras
        Cameras.ForEach(cam => cam.enabled = false);
        // enable the selected camera
        Cameras[n].enabled = true;
    }
    private void toggleLight(){
        if (pointlight.enabled) pointlight.enabled = false; else pointlight.enabled = true;
    }
}
