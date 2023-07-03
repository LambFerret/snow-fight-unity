using System;
using System.Collections;
using script.player;
using UnityEngine;
using UnityEngine.UI;

namespace script.overlay
{
    public class SnowBarOverlay : MonoBehaviour
    {
        public int maxSnowAmountByLevel;
        public int currentSnowAmount;
        private Slider _slider;
        private Player _player;
        public float speed = 0.5f;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            _player = Player.PlayerInstance;
            currentSnowAmount = _player.snowAmount;
        }


        public void SetMaxSnowAmount(int snowAmount)
        {
            maxSnowAmountByLevel = snowAmount;
            _slider.maxValue = maxSnowAmountByLevel;
        }

        private void Update()
        {
            currentSnowAmount = _player.snowAmount;
            _slider.value = Mathf.Lerp(_slider.value, currentSnowAmount, speed * Time.deltaTime);
        }
    }
}