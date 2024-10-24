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
        [SerializeField] private float _horizontalPadding;
        [SerializeField] private bool _sameSidesSize;
        [SerializeField] private bool _singleColumn;
        [SerializeField] private bool _singleRow;

        private void Awake()
        {
            _gridLayoutGroup.cellSize = CalculateSize(_rectTransform, _columnsCount, _rowsCount, _singleColumn,
                _singleRow, _sameSidesSize);
        }

        public Vector2 CalculateSize(RectTransform rectTransform, int columnsCount, int rowsCount, bool singleColumn,
            bool singleRow, bool sameSidesSize)
        {
            float rectWidth = rectTransform.rect.width;
            float rectHeight = rectTransform.rect.height;
            float horizontalCellSize = 0;
            float verticalCellSize = 0;

            if (singleColumn)
            {
                horizontalCellSize = rectWidth - _horizontalPadding * 2;
                verticalCellSize = rectHeight / rowsCount;
            }
            else if (singleRow)
            {
                horizontalCellSize = rectWidth / columnsCount;
                verticalCellSize = rectHeight;
            }
            else
            {
                horizontalCellSize = rectWidth / columnsCount;
                verticalCellSize = rectHeight / rowsCount;

                if (sameSidesSize)
                {
                    float cellSize = Mathf.Min(horizontalCellSize, verticalCellSize);
                    return new Vector2(cellSize, cellSize);
                }
            }

            return new Vector2(horizontalCellSize, verticalCellSize);
        }
    }
}