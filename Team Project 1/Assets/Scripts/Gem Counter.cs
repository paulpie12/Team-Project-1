using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCounter : MonoBehaviour
{
    public static GemCounter instance;

    public TMP_Text gemText;
    static public int currentGems = 0;
    public int gemslost = 1;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gemText.text = "Gems: " + currentGems.ToString();
    }

    public void IncreaseGems(int v)
    {
        currentGems += v;
        gemText.text = "Gems: " + currentGems.ToString();
    }

    public void DecreaseGems(int v)
    {
        currentGems -= gemslost;
        gemText.text = "Gems: " + currentGems.ToString();
    }
}
