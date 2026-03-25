using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Slider lifeBarSlide;

    private void Start(){
        lifeBarSlide = GetComponent<Slider>();
        
    }

    public void MaxLifeChange(float maxLife){
        lifeBarSlide.maxValue = maxLife;

    }

    public void ActualLifeChange(float amountLife){
        lifeBarSlide.value = amountLife;
    }

    public void StartLifeSystem(float amountLife, float maxLife){
        MaxLifeChange(maxLife);
        ActualLifeChange(amountLife);
    }

}
