using System;
using map;
using script.overlay;
using script.Overlay;
using UnityEngine;
using UnityEngine.UI;

namespace script.manager
{
    public class PhaseSystem : MonoBehaviour
    {
        public PhaseState currentPhase;
        public int currentPhaseNumber;
        public Text phaseText;
        public Level currentLevel;
        private CommandOverlay _commandOverlay;
        private SoldierOverlay _soldierOverlay;

        private void Start()
        {
            _commandOverlay = currentLevel.commandOverlay;
            _soldierOverlay = currentLevel.soldierOverlay;
            currentPhase = PhaseState.Pre;
            currentPhaseNumber = 1;
        }

        private void Update()
        {
            phaseText.text = currentPhaseNumber + " / " + ((int)currentLevel.region + 2) + ", Phase : " + currentPhase;
        }

        public void NextPhase()
        {
            int maxPhaseNumber = (int)currentLevel.region + 2;

            switch (currentPhase)
            {
                case PhaseState.Pre:
                    currentPhase = PhaseState.Ready;
                    // 스테이지에 있을 병사 선발
                    _soldierOverlay.DispatchSoldiers(currentLevel.maxSoliderCapacity);
                    WhenStartPhase();
                    break;

                case PhaseState.Ready:
                    currentPhase = PhaseState.Action;
                    _commandOverlay.EndTurn();
                    // 일하세요
                    currentLevel.HappyWorking();
                    break;

                case PhaseState.Action:
                    if (currentPhaseNumber < maxPhaseNumber)
                    {
                        currentPhaseNumber++;
                        phaseText.text = currentPhaseNumber.ToString();
                        currentPhase = PhaseState.Ready;
                        WhenStartPhase();
                    }
                    else
                    {
                        phaseText.text = currentPhaseNumber.ToString();
                        currentPhase = PhaseState.Post;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void WhenStartPhase()
        {
            // 위치 잡기
            currentLevel.LocateWorkingPlace();
            // 카드 드로우
            _commandOverlay.StartTurn();
        }

        public enum PhaseState
        {
            Pre,
            Ready,
            Action,
            Post
        }
    }
}