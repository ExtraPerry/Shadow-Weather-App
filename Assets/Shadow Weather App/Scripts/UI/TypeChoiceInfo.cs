using UnityEngine;

[CreateAssetMenu()]
public class TypeChoiceInfo : ScriptableObject
{
    public TypeChoice choice;

    public void SetChoice(int choice)
    {
        if (choice < 0) choice = 0;
        if (choice > 2) choice = 2;
        this.choice = (TypeChoice)choice;
    }
}

public enum TypeChoice
{
    Average,
    Maximum,
    Minimum

}
