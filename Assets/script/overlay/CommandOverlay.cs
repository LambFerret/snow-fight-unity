using System.Collections.Generic;
using script.command;
using script.player;
using UnityEngine;
using UnityEngine.UI;

namespace script.overlay
{
    public class CommandOverlay : MonoBehaviour
    {
        public GameObject prefab;
        private List<CommandObjectPair> _commandToGameObjectPairs;
        private List<Command> _hand;
        private Player _player;
        private List<Command> _removalFromGameCommandList;
        private List<Command> _totalDeck;
        private List<Command> _usedCommandList;

        private void Start()
        {
            _commandToGameObjectPairs = new List<CommandObjectPair>();
            _player = Player.PlayerInstance;
        }

        public void StartLevel()
        {
            _totalDeck = _player.totalDeck;
            _usedCommandList = _player.usedCommandList;
            _removalFromGameCommandList = _player.removalFromGameCommandList;
            _hand = _player.hand;
            foreach (var playerCommand in _player.commands) _player.totalDeck.Add(playerCommand);
        }

        public void StartTurn()
        {
            MakeHandFromDeck();
        }

        private void DrawFromDeck()
        {
            var group = gameObject.GetComponent<HorizontalLayoutGroup>();

            var command = _totalDeck[Random.Range(0, _totalDeck.Count - 1)];
            var commandGameObject = command.MakeCommandCard(Instantiate(prefab));
            commandGameObject.transform.SetParent(group.transform, false);
            var button = commandGameObject.GetComponent<Button>();
            button.onClick.AddListener(() => PlayCommandFromHand(command));

            _hand.Add(command);
            _totalDeck.Remove(command);
            _commandToGameObjectPairs.Add(new CommandObjectPair(command, commandGameObject));
        }

        private void ResetDeck()
        {
            _totalDeck.AddRange(_usedCommandList);
            _usedCommandList.Clear();
        }

        private void MakeHandFromDeck()
        {
            for (var i = 0; i < _player.maxCommandInHand; i++)
            {
                if (_totalDeck.Count == 0) ResetDeck();
                if (_totalDeck.Count == 0) break;
                DrawFromDeck();
            }
        }

        private void PlayCommandFromHand(Command command)
        {
            _hand.Remove(command);
            GetGameObjectForCommand(command).SetActive(false);
            Debug.Log(command.id);
            command.Effect(_totalDeck);

            if (command.type == Command.Type.Reward)
            {
                _removalFromGameCommandList.Add(command);
                _totalDeck.Remove(command);
            }
            else
            {
                _usedCommandList.Add(command);
            }
        }

        public void EndTurn()
        {
            _usedCommandList.AddRange(_hand);
            foreach (Transform child in transform) Destroy(child.gameObject);
            _hand.Clear();
            _commandToGameObjectPairs.Clear();
        }

        public void EndStage(bool isWin)
        {
            if (!isWin) _totalDeck.AddRange(_removalFromGameCommandList);

            _removalFromGameCommandList.Clear();
        }

        private GameObject GetGameObjectForCommand(Command command)
        {
            foreach (var pair in _commandToGameObjectPairs)
                if (pair.command == command)
                    return pair.gameObject;

            return null;
        }

        private class CommandObjectPair
        {
            public readonly Command command;
            public readonly GameObject gameObject;

            public CommandObjectPair(Command command, GameObject gameObject)
            {
                this.command = command;
                this.gameObject = gameObject;
            }
        }
    }
}