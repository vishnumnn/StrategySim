using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utilities
{
    public class Heap<T> where T : IComparable
    {
        public List<T> arr;
        public bool isMax;
        private Dictionary<T, int> map;
        public Heap(bool isMax)
        {
            this.isMax = isMax;
            map = new Dictionary<T, int>();
        }

        public Heap(List<T> elements, bool isMax)
        {
            arr = elements;
            this.isMax = isMax;
            map = new Dictionary<T, int>();
            for(int i = 0; i < arr.Count; i++)
            {
                map.Add(arr[i], i);
            }
            MakeHeap();
        }

        private void MakeHeap()
        {
            for(int i = (this.arr.Count / 2 - 1); i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }

        public T ExtractTop()
        {
            if (arr.Count == 0)
                return default;
            T top = arr[0];
            Swap(0, arr.Count - 1);
            arr.RemoveAt(arr.Count - 1);
            HeapifyUp(arr.Count - 1);
            return top;
        }

        public void Delete(T value)
        {
            int idx;
            if (map.ContainsKey(value))
                idx = map[value];
            else return;
            Swap(idx, arr.Count - 1);
            HeapifyDown(idx);
        }

        public bool Insert(T value)
        {
            if (map.ContainsKey(value))
                return false;
            arr.Add(value);
            map.Add(value, arr.Count - 1);
            HeapifyUp(arr.Count - 1);
            return true;
        }

        private void HeapifyDown(int index)
        {
            int c1 = index * 2 + 1;
            int c2 = index * 2 + 2;
            while(c1 < arr.Count)
            {
                if(c2 < arr.Count && (arr[c2].CompareTo(arr[c1]) < 0 ^ isMax))
                {
                    if(arr[c2].CompareTo(arr[index]) < 0 ^ isMax)
                    {
                        Swap(c2, index);
                        index = c2;
                        c1 = c2 * 2 + 1;
                        c2 = c2 * 2 + 2;
                        continue;
                    }
                    break;
                }
                else
                {
                    if (arr[c1].CompareTo(arr[index]) < 0 ^ isMax)
                    {
                        Swap(c1, index);
                        index = c1;
                        c1 = c1 * 2 + 1;
                        c2 = c1 * 2 + 2;
                        continue;
                    }
                    break;
                }
            }
        }

        private void HeapifyUp(int index)
        {
            while(index > 0)
            {
                int p = (index - 1) / 2;
                if(arr[p].CompareTo(arr[index]) > 0 ^ isMax)
                {
                    Swap(p, index);
                    index = p;
                }
            }
        }

        private void Swap(int idxA, int idxB)
        {
            map[arr[idxA]] = idxB;
            map[arr[idxB]] = idxA;
            T temp = arr[idxA];
            arr[idxA] = arr[idxB];
            arr[idxB] = temp;
            
        }
    }
}
