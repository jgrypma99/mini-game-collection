using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team00
{
    public class PlayerJump : MiniGameBehaviour
    {
        [field: SerializeField] private bool ControlsActive { get; set; }

        protected override void OnGameStart()
        {
            ControlsActive = true;
        }

        protected override void OnGameEnd()
        {
            ControlsActive = false;
        }

        private void Update()
        {
            if (!ControlsActive)
                return;


        }
    }
}