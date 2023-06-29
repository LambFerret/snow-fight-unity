using System.Collections.Generic;
using script.command;
using script.manager;
using script.player;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace script.overlay
{
    public class CommandOverlay : MonoBehaviour
    {
        public GameObject slot;
        private Player _player;

        // 플레이어가 가진 진짜 덱
        [SerializeField] private List<GameObject> totalDeck;

        // 덱이 전부 소모되기전 사용된 카드들
        [SerializeField] private List<GameObject> usedCommandList;

        // 플레이어가 가진 덱에서 소멸된 카드들
        [SerializeField] private List<GameObject> removalFromGameCommandList;

        // 플레이어가 손에 들고 있는 카드들
        [SerializeField] private List<GameObject> hand;

        private void Start()
        {
            _player = Player.PlayerInstance;
            foreach (var playerCommand in _player.commands)
            {
                totalDeck.Add(playerCommand.MakeCommandCard(Instantiate(slot)));
            }
        }

        public void CreateCommandOverlay()
        {
            var group = gameObject.GetComponent<HorizontalLayoutGroup>();
            foreach (var command in hand)
            {
                var commandTransform = command.transform;
                commandTransform.SetParent(group.transform, false);
            }
        }

        public void StartTurn()
        {
            MakeHandFromDeck();
            CreateCommandOverlay();
        }

        public void DrawFromDeck()
        {
            var command = totalDeck[Random.Range(0, totalDeck.Count - 1)];
            hand.Add(command);
            totalDeck.Remove(command);
        }

        public void ResetDeck()
        {
            totalDeck.AddRange(usedCommandList);
            usedCommandList.Clear();
        }

        public void MakeHandFromDeck()
        {
            for (int i = 0; i < _player.maxCommandInHand; i++)
            {
                if (totalDeck.Count == 0) ResetDeck();
                if (totalDeck.Count == 0) break;
                DrawFromDeck();
            }
        }

        public void PlayCommandFromHand(GameObject commandObject)
        {
            hand.Remove(commandObject);
            var command = commandObject.GetComponent<Command>();
            command.Effect();
            if (command.type == Command.Type.Reward)
            {
                removalFromGameCommandList.Add(commandObject);
                totalDeck.Remove(commandObject);
            }
            else
            {
                usedCommandList.Add(commandObject);
            }
        }

        public void EndTurn()
        {
            usedCommandList.AddRange(hand);
            hand.Clear();
        }

        public void EndStage(bool isWin)
        {
            if (!isWin)
            {
                totalDeck.AddRange(removalFromGameCommandList);
            }

            removalFromGameCommandList.Clear();
        }
    }
}