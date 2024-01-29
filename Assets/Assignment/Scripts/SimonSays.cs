using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    List<int> lightOrder = new List<int>();
    public List<int> shotOrder = new List<int>();
    public GameObject red, yellow, green, blue;
    int current = 0, time = 120, counter = 0;
    bool show = true;

    // Start is called before the first frame update
    void Start()
    {
        AddLights();
        counter = time;
    }

    // Update is called once per frame
    void Update()
    {
        // Show lights
        if(show)
        {
            if (counter == 0)
            {
                switch (lightOrder[current])
                {
                    case 1:
                        red.GetComponent<Target>().TurnOn();
                        print("red");
                        break;

                    case 2:
                        yellow.GetComponent<Target>().TurnOn();
                        print("yellow");
                        break;

                    case 3:
                        green.GetComponent<Target>().TurnOn();
                        print("green");
                        break;

                    case 4:
                        blue.GetComponent<Target>().TurnOn();
                        print("blue");
                        break;
                }

                if (current != lightOrder.Count - 1) current++;
                else show = false;

                counter = time;
            }
            else counter--;
        }
    }

    private void AddLights()
    {
        // Add a random colour next to the sequence
        lightOrder.Add(Random.Range(1, 4));
    }

    private void NextSequence()
    {
        // Clear the shot order the player took
        shotOrder.Clear();

        // Add another light
        AddLights();
        current = 0;
        show = true;
    }

    private void CheckIfDone()
    {
        // Check if the player has taken all the shots
        if (shotOrder.Count == lightOrder.Count)
        {
            NextSequence();
        }
    }

    public void AddToOrder(int objectHit)
    {
        shotOrder.Add(objectHit);
        CheckIfDone();
    }
}
