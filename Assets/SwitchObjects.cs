using UnityEngine;

public class SwitchObjects : MonoBehaviour
{
    public GameObject objectToTurnOff;
    public GameObject objectToTurnOn;
    public float switchDelay = 3f; // Delay time in seconds

    private bool hasSwitched = false;
    private float timer = 0f;

    void Update()
    {
        // Check if the switch has not been made yet
        if (!hasSwitched)
        {
            // Increment the timer
            timer += Time.deltaTime;

            // Check if the timer has exceeded the switch delay
            if (timer >= switchDelay)
            {
                // Turn off objectToTurnOff and turn on objectToTurnOn
                objectToTurnOff.SetActive(false);
                objectToTurnOn.SetActive(true);

                // Set hasSwitched to true to avoid repeating the switch
                hasSwitched = true;
            }
        }
    }
}
