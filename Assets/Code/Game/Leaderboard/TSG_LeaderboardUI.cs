namespace TSG.Game
{
    using System.Collections.Generic;
    using TMPro;
    using TSG.Model;
    using UnityEngine;
    using UnityEngine.UI;

    public class TSG_LeaderboardUI : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] float itemHeight = 50f;

        LeaderboardModel leaderboardModel = null;
        int mineLeaderboardEntryModelId = 0;
        int firstItemId = 0;

        [Header("References")]
        [SerializeField] TextMeshProUGUI scoreTMP = null;
        [SerializeField] RectTransform leaderboardEntriesUIContainer = null;
        [SerializeField] ScrollRect scrollRect = null;

        [Header("Objects Pools")]
        [SerializeField] TSG_ObjectsPool leaderboardEntryUIObjectsPool = null;

        List<TSG_LeaderboardEntryUI> leaderboardEntriesUI = new List<TSG_LeaderboardEntryUI>();

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
            mineLeaderboardEntryModelId = _gameEventData.IntValues[0];
            leaderboardModel = _gameEventData.ObjectValues[0] as LeaderboardModel;
            if (leaderboardModel == null)
            {
                return;
            }

            leaderboardEntriesUIContainer.sizeDelta = new Vector2(leaderboardEntriesUIContainer.sizeDelta.x, leaderboardModel.NumItems * itemHeight);
            manageLeaderboardEntriesUICount(16 * itemHeight);
            focusOnItem(mineLeaderboardEntryModelId);
        }

        private void manageLeaderboardEntriesUICount(float _height)
        {
            int _leaderboardEntriesUICount = Mathf.CeilToInt(_height / itemHeight);
            int _missingLeaderboardEntriesUICount = _leaderboardEntriesUICount - leaderboardEntriesUI.Count;
            if (_missingLeaderboardEntriesUICount > 0)
            {
                for (int i = 0; i < _missingLeaderboardEntriesUICount; i++)
                {
                    createLeaderboardEntryUI();
                }
            }
            else
            {
                for (int i = _missingLeaderboardEntriesUICount; i < 0; i++)
                {
                    destroyLeaderboardEntryUI();
                }
            }
        }

        private void refreshScoreUI(int _score)
        {
            scoreTMP.text = $"{_score}";
        }

        private void createLeaderboardEntryUI()
        {
            TSG_LeaderboardEntryUI _leaderBoardEntryUI = leaderboardEntryUIObjectsPool?.Get()?.GetComponent<TSG_LeaderboardEntryUI>();
            RectTransform _leaderBoardEntryUITransform = (_leaderBoardEntryUI.transform as RectTransform);

            _leaderBoardEntryUI.transform.SetParent(leaderboardEntriesUIContainer);
            _leaderBoardEntryUITransform.pivot = leaderboardEntriesUIContainer.pivot;
            _leaderBoardEntryUITransform.anchorMin = leaderboardEntriesUIContainer.anchorMin;
            _leaderBoardEntryUITransform.anchorMax = leaderboardEntriesUIContainer.anchorMax;
            _leaderBoardEntryUITransform.sizeDelta = new Vector2(_leaderBoardEntryUITransform.sizeDelta.x, itemHeight);

            leaderboardEntriesUI.Add(_leaderBoardEntryUI);
        }

        private void destroyLeaderboardEntryUI()
        {
            TSG_LeaderboardEntryUI _leaderBoardEntryUI = leaderboardEntriesUI[0];
            leaderboardEntriesUI.Remove(_leaderBoardEntryUI);

            leaderboardEntryUIObjectsPool.Release(_leaderBoardEntryUI.gameObject);
        }

        private void focusOnItem(int _itemId)
        {
            int _halfOfLeaderboardEntriesUICount = leaderboardEntriesUI.Count / 2;
            int _firstItemId = 0;
            if (_itemId - _halfOfLeaderboardEntriesUICount >= 0 && _itemId + _halfOfLeaderboardEntriesUICount < leaderboardModel.NumItems)
            {
                _firstItemId = _itemId - _halfOfLeaderboardEntriesUICount;
            }
            else if (_itemId - _halfOfLeaderboardEntriesUICount < 0)
            {
                _firstItemId = 0;
            }
            else
            {
                _firstItemId = leaderboardModel.NumItems - 1 - leaderboardEntriesUI.Count;
            }

            firstItemId = _firstItemId;

            for (int i = 0; i < leaderboardModel.NumItems && i < leaderboardEntriesUI.Count; i++)
            {
                TSG_LeaderboardEntryUI _leaderboardEntryUI = leaderboardEntriesUI[i];
                RectTransform _leaderboardEntryUITransform = _leaderboardEntryUI.transform as RectTransform;

                _leaderboardEntryUITransform.anchoredPosition3D = new Vector3(0f, -(firstItemId + i) * 50f, 0f);

                select(_leaderboardEntryUI, _firstItemId + i, leaderboardModel.GetItem(_firstItemId + i), mineLeaderboardEntryModelId);
            }

            float _verticalScrollbarValue = 1f - (_firstItemId / (float)(leaderboardModel.NumItems - 1 - leaderboardEntriesUI.Count));
            _verticalScrollbarValue = Mathf.Clamp(_verticalScrollbarValue, Mathf.Epsilon, 1f - Mathf.Epsilon); // little hax for this buggy shit during setting vertical scrollbar value
            scrollRect.verticalScrollbar.value = _verticalScrollbarValue;
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
                    select(_leaderboardEntryUI, _newItemId, leaderboardModel.GetItem(_newItemId), mineLeaderboardEntryModelId);

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
                    select(_leaderboardEntryUI, _newItemId, leaderboardModel.GetItem(_newItemId), mineLeaderboardEntryModelId);

                    i++;
                }
            }
        }

        private void select(TSG_LeaderboardEntryUI _leaderboardEntryUI, int _id, LeaderboardEntryModel _leaderboardEntryModel, int _mineId)
        {
            _leaderboardEntryUI.Setup(_id, _leaderboardEntryModel);
            if(_mineId == _id)
            {
                _leaderboardEntryUI.Select();
            }
            else
            {
                _leaderboardEntryUI.Deselect();
            }
        }
    }
}