using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestProController : MonoBehaviour
{
    [SerializeField]
    private LeftRight leftOrRight;

    [SerializeField]
    private InputActionProperty joystickInput;
    [SerializeField]
    private InputActionProperty triggerInput;
    [SerializeField]
    private InputActionProperty gripInput;
    [SerializeField]
    private InputActionProperty upperButtonInput;
    [SerializeField]
    private InputActionProperty lowerButtonInput;

    [SerializeField]
    private Transform joystick;
    [SerializeField]
    private Transform trigger;
    [SerializeField]
    private Transform grip;
    [SerializeField]
    private Transform upperButton;
    [SerializeField]
    private Transform lowerButton;

    // Update is called once per frame
    private void Update()
    {
        Vector2 joystickValue = joystickInput.action.ReadValue<Vector2>();
        bool triggerValue = triggerInput.action.ReadValue<bool>();
        bool gripValue = gripInput.action.ReadValue<bool>();
        bool upperButtonValue = upperButtonInput.action.ReadValue<bool>();
        bool lowerButtonValue = lowerButtonInput.action.ReadValue<bool>();

        joystick.localRotation = Quaternion.Euler(joystickValue.x, 0, joystickValue.y);
        trigger.localRotation = (triggerValue) ? Quaternion.Euler(-5, 0, 0) : Quaternion.Euler(0, 0, 0);

        if (leftOrRight == LeftRight.Left)
        {
            grip.localPosition = (gripValue) ? new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281) : new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281);
            upperButton.localPosition = (upperButtonValue) ? new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281) : new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281);
            lowerButton.localPosition = (lowerButtonValue) ? new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281) : new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281);
        }
        else
        {
            grip.localPosition = (gripValue) ? new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281) : new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281);
            upperButton.localPosition = (upperButtonValue) ? new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281) : new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281);
            lowerButton.localPosition = (lowerButtonValue) ? new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281) : new Vector3((float)-0.0096, (float)-0.028557, (float)0.0281);
        }
    }
}

public enum LeftRight
{
    Left = 1,
    Right = -1
}
