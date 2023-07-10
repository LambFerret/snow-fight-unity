using System;
using script.component;
using script.map;
using script.overlay;
using script.Overlay;
using script.player;
using UnityEngine.UI;

namespace script.manager
{
    public class PhaseSystem : Subject
    {
        public enum PhaseState
        {
            Pre,
            Ready,
            Action,
            Post
        }

        public PhaseState currentPhase;
        public int currentPhaseNumber;
        public Text phaseText;
        public Level currentLevel;
        public BuffManager buffManager;
        private CommandOverlay _commandOverlay;
        private Player _player;
        private SoldierOverlay _soldierOverlay;
        private int maxPhaseNumber;

        private void Start()
        {
            _commandOverlay = currentLevel.commandOverlay;
            _soldierOverlay = currentLevel.soldierOverlay;
            currentPhase = PhaseState.Pre;
            currentPhaseNumber = 1;
            _player = Player.PlayerInstance;
            _player.InitToPhase();
            _soldierOverlay.DispatchSoldiers(currentLevel.maxSoliderCapacity);
            _commandOverlay.StartLevel();
        }

        private void Update()
        {
            maxPhaseNumber = (int)currentLevel.region + 10;
            phaseText.text = currentPhaseNumber + " / " + maxPhaseNumber + ", Phase : " + currentPhase;
        }

        public void NextPhase()
        {
            switch (currentPhase)
            {
                case PhaseState.Pre:
                    currentPhase = PhaseState.Ready;
                    // 스테이지에 있을 병사 선발
                    WhenStartPhase();
                    break;

                case PhaseState.Ready:
                    currentPhase = PhaseState.Action;
                    _commandOverlay.EndTurn();
                    // 일하세요
                    currentLevel.HappyWorking();
                    break;

                case PhaseState.Action:
                    currentLevel.SetSoldierAnimation(false);
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
                        if (Player.PlayerInstance.snowAmount < currentLevel.minSnowAmount)
                            currentLevel.defeatPanel.SetActive(true);
                        else
                            currentLevel.victoryPanel.SetActive(true);
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void WhenStartPhase()
        {
            // 게임오브젝트 지우기
            currentLevel.ResetWorkingPlace();
            // 버프 발현
            buffManager.StartTurn();
            // 위치 잡기
            currentLevel.LocateWorkingPlace();
            // 카드 드로우
            _commandOverlay.StartTurn();
        }
    }
}