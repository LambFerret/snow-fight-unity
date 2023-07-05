using script.player;
using UnityEngine;
using UnityEngine.UI;

namespace script.overlay
{
    public class SnowBarOverlay : MonoBehaviour
    {
        public int maxSnowAmountByLevel;
        public int currentSnowAmount;
        public float speed = 20;
        private Player _player;
        private Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            _player = Player.PlayerInstance;
            currentSnowAmount = _player.snowAmount;
        }

        private void Update()
        {
            currentSnowAmount = _player.snowAmount;
            _slider.value = Mathf.Lerp(_slider.value, currentSnowAmount, speed * Time.deltaTime);
        }


        public void SetMaxSnowAmount(int snowAmount)
        {
            maxSnowAmountByLevel = snowAmount;
            _slider.maxValue = maxSnowAmountByLevel;
        }
    }
}