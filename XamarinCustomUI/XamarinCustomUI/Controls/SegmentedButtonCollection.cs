using System.Collections;
using System.Collections.Generic;

namespace XamarinCustomUI.Controls
{
    public class SegmentedButtonCollection : ICollection<SegmentedButton>
    {
        private List<SegmentedButton> _segmentedButtons = new List<SegmentedButton>();

        public int Count => _segmentedButtons.Count;

        public bool IsReadOnly => false;

        public void Add(SegmentedButton item)
        {
            _segmentedButtons.Add(item);
        }

        public void Clear()
        {
            _segmentedButtons.Clear();
        }

        public bool Contains(SegmentedButton item)
        {
            return _segmentedButtons.Contains(item);
        }

        public void CopyTo(SegmentedButton[] array, int arrayIndex)
        {
            _segmentedButtons.CopyTo(array, arrayIndex);
        }

        public IEnumerator<SegmentedButton> GetEnumerator()
        {
            return _segmentedButtons.GetEnumerator();
        }

        public bool Remove(SegmentedButton item)
        {
            return _segmentedButtons.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _segmentedButtons.GetEnumerator();
        }
    }
}