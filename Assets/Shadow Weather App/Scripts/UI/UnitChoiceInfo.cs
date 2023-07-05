using UnityEngine;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    [CreateAssetMenu(menuName = "Shadow Weather App/UI/Unit Choice Info")]
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
}