using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FlexibleGridLayoutRect : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private int _columnsCount = 6;
        [SerializeField] private int _rowsCount = 5;
        [SerializeField] private float _verticalOffset;
        [SerializeField] private float _horizontalOffset;
        [SerializeField] private bool _sameSidesSize;
        [SerializeField] private bool _singleColumn;
        [SerializeField] private bool _singleRow;

        private Vector2 _newSize;

        private void Awake()
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();

            if (_gridLayoutGroup == null)
                _gridLayoutGroup = GetComponent<GridLayoutGroup>();

            float rectWidth = _rectTransform.rect.width;
            float rectHeight = _rectTransform.rect.height;
            float horizontalCellSize = 0;
            float verticalCellSize = 0;

            if (_singleColumn)
            {
                horizontalCellSize = rectWidth - _gridLayoutGroup.padding.horizontal * 2;
                verticalCellSize = rectHeight / _rowsCount - _gridLayoutGroup.spacing.y;
                _newSize = new Vector2(horizontalCellSize, verticalCellSize);
            }
            else if (_singleRow)
            {
                horizontalCellSize = rectWidth / _columnsCount - _gridLayoutGroup.spacing.x;
                verticalCellSize = rectHeight - _gridLayoutGroup.padding.vertical * 2;
                _newSize = new Vector2(horizontalCellSize, verticalCellSize);
            }
            else
            {
                horizontalCellSize = rectWidth / _columnsCount - _gridLayoutGroup.spacing.x;
                verticalCellSize = rectHeight / _rowsCount - _gridLayoutGroup.spacing.y;

                if (_sameSidesSize)
                {
                    float cellSize = Math.Min(horizontalCellSize, verticalCellSize);
                    _newSize = new Vector2(cellSize, cellSize);
                }
                else
                {
                    _newSize = new Vector2(horizontalCellSize, verticalCellSize);
                }
            }

            _gridLayoutGroup.cellSize = _newSize;
        }
    }
}