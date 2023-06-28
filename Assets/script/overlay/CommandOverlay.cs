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
        [SerializeField] private List<Command> totalDeck;

        // 덱이 전부 소모되기전 사용된 카드들
        [SerializeField] private List<Command> usedCommandList;

        // 플레이어가 가진 덱에서 소멸된 카드들
        [SerializeField] private List<Command> removalFromGameCommandList;

        // 플레이어가 손에 들고 있는 카드들
        [SerializeField] private List<Command> commandsInHand;

        private void Start()
        {
            _player = GameManager.Instance.player;
            totalDeck = _player.commands;
        }

        private void CreateCommandOverlay()
        {
            var group = gameObject.GetComponent<HorizontalLayoutGroup>().transform;

            foreach (var command in commandsInHand)
            {
                Vector3 v = group.position;
                var a = Instantiate(slot, v, Quaternion.identity, group);
                command.MakeCommandPrefab(a);
            }
        }

        private void DrawFromDeck()
        {
            var command = totalDeck[Random.Range(0, totalDeck.Count - 1)];
            commandsInHand.Add(command);
            totalDeck.Remove(command);
        }

        private void MakeHandFromDeck()
        {
            for (int i = 0; i < _player.maxCommandInHand; i++)
            {
                if (totalDeck.Count == 0) ResetDeck();
                if (totalDeck.Count == 0) break;
                DrawFromDeck();
            }
        }

        public void StartTurn()
        {
            MakeHandFromDeck();
            CreateCommandOverlay();
        }

        private void EndTurn()
        {
            usedCommandList.AddRange(commandsInHand);
            commandsInHand.Clear();
        }

        private void ResetDeck()
        {
            totalDeck.AddRange(usedCommandList);
            usedCommandList.Clear();
        }

        private void PlayCommandFromHand(Command command)
        {
            command.Effect();
            commandsInHand.Remove(command);
            if (command.type == Command.Type.Reward)
            {
                removalFromGameCommandList.Add(command);
                totalDeck.Remove(command);
            }
            else
            {
                usedCommandList.Add(command);
            }
        }

        private void EndStage(bool isWin)
        {
            if (!isWin)
            {
                totalDeck.AddRange(removalFromGameCommandList);
            }

            removalFromGameCommandList.Clear();
        }
    }
}