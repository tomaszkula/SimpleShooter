namespace TSG.Game
{
    using System.Collections.Generic;
    using TMPro;
    using TSG.Model;
    using UnityEngine;
    using UnityEngine.UI;

    public class TSG_LeaderboardUI : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] TSG_ObjectsPool leaderboardEntryUIPrefab = null;

        [Header("References")]
        [SerializeField] RectTransform highscoresContainer = null;
        [SerializeField] TextMeshProUGUI scoreTMP = null;




        [SerializeField] ScrollRect scrollRect = null;

        List<TSG_LeaderboardEntryUI> leaderboardEntriesUI = new List<TSG_LeaderboardEntryUI>();

        int firstItemId = 0;
        //int lastId = 0;

        LeaderboardModel leaderboardModel = null;

        private void Start()
        {
            for (int i = 0; i < 20; i++)
            {
                TSG_LeaderboardEntryUI _xd = leaderboardEntryUIPrefab?.Get()?.GetComponent<TSG_LeaderboardEntryUI>();
                _xd.transform.SetParent(highscoresContainer);
                (_xd.transform as RectTransform).pivot = highscoresContainer.pivot;
                (_xd.transform as RectTransform).anchorMin = highscoresContainer.anchorMin;
                (_xd.transform as RectTransform).anchorMax = highscoresContainer.anchorMax;
                //(_xd.transform as RectTransform).anchoredPosition3D = new Vector3((_xd.transform as RectTransform).anchoredPosition3D.x, -25f - i * 50f, (_xd.transform as RectTransform).anchoredPosition3D.z);
                //_xd.Setup(i, _leaderboardEntryModel);
                leaderboardEntriesUI.Add(_xd);
            }
        }

        private void Update()
        {
            updateItemsList();
        }

        public void OnScoreUpdate(TSG_GameEventData _gameEventData)
        {
            int _score = _gameEventData.IntValues[0];
            refreshScoreUI(_score);
        }

        public void OnLeaderboardUpdate(TSG_GameEventData _gameEventData)
        {
            leaderboardModel = _gameEventData.ObjectValues[0] as LeaderboardModel;
            if (leaderboardModel == null)
            {
                return;
            }

            int _recordsCount = leaderboardModel.NumItems;
            for (int i = 0; i < _recordsCount && i < leaderboardEntriesUI.Count; i++)
            {
                LeaderboardEntryModel _leaderboardEntryModel = leaderboardModel.GetItem(i);

                (leaderboardEntriesUI[i].transform as RectTransform).anchoredPosition3D = new Vector3(0f, - i * 50f, 0f);
                leaderboardEntriesUI[i].Setup(i, _leaderboardEntryModel);
            }

            firstItemId = 0;

            highscoresContainer.sizeDelta = new Vector2(highscoresContainer.sizeDelta.x, _recordsCount * 50f);
        }

        private void refreshScoreUI(int _score)
        {
            scoreTMP.text = $"{_score}";
        }

        private void updateItemsList()
        {
            if(leaderboardModel == null || leaderboardEntriesUI.Count < 1)
            {
                return;
            }

            updateFirstListItem();
            updateLastListItem();
        }

        private void updateFirstListItem()
        {
            for (int i = 0; i < leaderboardEntriesUI.Count; i++)
            {
                TSG_LeaderboardEntryUI _leaderboardEntryUI = leaderboardEntriesUI[i];
                RectTransform _leaderboardEntryUITransform = _leaderboardEntryUI.transform as RectTransform;
                float _leaderboardEntryUIHeight = _leaderboardEntryUITransform.rect.height;

                Vector3 _localPosition = _leaderboardEntryUITransform.anchoredPosition3D;
                Vector3 _worldPosition = (_leaderboardEntryUITransform.parent as RectTransform).TransformPoint(_localPosition);
                Vector3 _localPositionToViewport = scrollRect.viewport.InverseTransformPoint(_worldPosition);

                if (_localPositionToViewport.y > _leaderboardEntryUIHeight && firstItemId + leaderboardEntriesUI.Count < leaderboardModel.NumItems)
                {
                    firstItemId++;

                    leaderboardEntriesUI.Remove(_leaderboardEntryUI);
                    leaderboardEntriesUI.Add(_leaderboardEntryUI);
                    _leaderboardEntryUITransform.SetAsLastSibling();

                    int _newItemId = (firstItemId + leaderboardEntriesUI.Count - 1);
                    _leaderboardEntryUITransform.anchoredPosition3D = new Vector3(0f, -_newItemId * _leaderboardEntryUIHeight, 0f);
                    _leaderboardEntryUI.Setup(_newItemId, leaderboardModel.GetItem(_newItemId));

                    i--;
                }
            }
        }

        private void updateLastListItem()
        {
            for (int i = leaderboardEntriesUI.Count - 1; i > -1; i--)
            {
                TSG_LeaderboardEntryUI _leaderboardEntryUI = leaderboardEntriesUI[i];
                RectTransform _leaderboardEntryUITransform = _leaderboardEntryUI.transform as RectTransform;
                float _leaderboardEntryUIHeight = _leaderboardEntryUITransform.rect.height;

                Vector3 _localPosition = _leaderboardEntryUITransform.anchoredPosition3D;
                Vector3 _worldPosition = (_leaderboardEntryUITransform.parent as RectTransform).TransformPoint(_localPosition);
                Vector3 _localPositionToViewport = scrollRect.viewport.InverseTransformPoint(_worldPosition);

                if (_localPositionToViewport.y < -scrollRect.viewport.rect.height && firstItemId > 0)
                {
                    firstItemId--;

                    leaderboardEntriesUI.Remove(_leaderboardEntryUI);
                    leaderboardEntriesUI.Insert(0, _leaderboardEntryUI);
                    _leaderboardEntryUITransform.SetAsFirstSibling();

                    int _newItemId = firstItemId;
                    _leaderboardEntryUITransform.anchoredPosition3D = new Vector3(0f, -_newItemId * 50f, 0f);
                    _leaderboardEntryUI.Setup(_newItemId, leaderboardModel.GetItem(_newItemId));

                    i++;
                }
            }
        }
    }
}