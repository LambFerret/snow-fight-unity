using System.Collections.Generic;
using script.command;
using script.player;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace script.overlay
{
    public class CommandOverlay : MonoBehaviour
    {
        public GameObject prefab;
        private Player _player;
        private Dictionary<Command, GameObject> _commandToGameObjectMap;

        // 플레이어가 가진 진짜 덱
        [SerializeField] private List<Command> totalDeck;

        // 덱이 전부 소모되기전 사용된 카드들
        [SerializeField] private List<Command> usedCommandList;

        // 플레이어가 가진 덱에서 소멸된 카드들
        [SerializeField] private List<Command> removalFromGameCommandList;

        // 플레이어가 손에 들고 있는 카드들
        [SerializeField] private List<Command> hand;

        private void Start()
        {
            _commandToGameObjectMap = new Dictionary<Command, GameObject>();
            _player = Player.PlayerInstance;
            foreach (var playerCommand in _player.commands)
            {
                totalDeck.Add(playerCommand);
            }
        }

        public void StartTurn()
        {
            MakeHandFromDeck();
        }

        private void DrawFromDeck()
        {
            var group = gameObject.GetComponent<HorizontalLayoutGroup>();

            var command = totalDeck[Random.Range(0, totalDeck.Count - 1)];
            var commandGameObject = command.MakeCommandCard(Instantiate(prefab));
            commandGameObject.transform.SetParent(group.transform, false);
            Button button = commandGameObject.GetComponent<Button>();
            button.onClick.AddListener(() => PlayCommandFromHand(command));

            hand.Add(command);
            totalDeck.Remove(command);
            _commandToGameObjectMap.Add(command, commandGameObject);
        }

        private void ResetDeck()
        {
            totalDeck.AddRange(usedCommandList);
            usedCommandList.Clear();
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

        private void PlayCommandFromHand(Command command)
        {
            hand.Remove(command);
            _commandToGameObjectMap[command].SetActive(false);
            Debug.Log(command.id);
            command.Effect();

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

        public void EndTurn()
        {
            usedCommandList.AddRange(hand);
            hand.Clear();
            _commandToGameObjectMap.Clear();
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