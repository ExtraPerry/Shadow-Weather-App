using UnityEngine;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    [CreateAssetMenu(menuName = "Shadow Weather App/UI/Type Choice Info")]
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
}