using UnityEngine;

[CreateAssetMenu()]
public class UnitChoiceInfo : ScriptableObject
{
    public UnitChoice choice;

    public void SetChoice(int choice)
    {
        if (choice < 0) choice = 0;
        if (choice > 1) choice = 1;
        this.choice = (UnitChoice)choice;
    }
}

public enum UnitChoice
{
    Metric,
    Imperial
}
