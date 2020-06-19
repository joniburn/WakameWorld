
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class ShowNumber : UdonSharpBehaviour
{
    public string ninthParty;
    public string[] unnumberedParties;
    private System.DateTime baseDate;
    private int unnumberedMondays = 0;
    void Start()
    {
        baseDate = System.DateTime.Parse(ninthParty);
        foreach (var day in unnumberedParties)
        {
            if ((int)(System.DateTime.Parse(day).ToOADate()) % 7 == 2) unnumberedMondays++;
        }
    }
    private void Update()
    {
        int count = (int)(System.DateTime.Now.ToOADate() - baseDate.ToOADate())/7 + 10 - unnumberedMondays;
        GetComponent<Text>().text = string.Format("{0:G}", count);
    }
}
