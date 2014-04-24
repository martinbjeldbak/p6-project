using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility {
  //Individuals in this list are guaranteed to be sorted according to fitness,
  such that the most fit individual is at index 0
  public class SortList<T> : IEnumerable<T> where T : IComparable {
    private List<T> list;

    public int Count {
      get { return list.Count; }
    }
    
    public SortList() {
      list = new List<T>();
    }
  
    /// <summary>
    /// Removes all individuals
    /// </summary>
    public void Clear() {
      list.Clear();
    }

    //Inserts an individual in a list such that it remains sorted according to fitness values
    public void Add(T item){
      if (list.Count == 0) {
        list.Add(item);
        return;
      }
      
      int left = -1;
      int right = list.Count;
      
      while (left + 1 < right){
        int newIndex = (left + right) / 2;
        if (item.CompareTo(list[newIndex]) == 1) {
          right = newIndex;
        }
        else {
          left = newIndex;
        }
      }
      list.Insert(right, item);
    }
    public T Get(int index){
      return list[index];
    }

    public void Remove(T obj) {
      list.Remove(obj);
    }

    /// <summary>
    /// Crops the list by removing the lowest valued elements
    /// </summary>
    /// <param name="num">The number of elements to remain in the list</param>
    public void Crop(int num) {
      if (list.Count > num)
        list.RemoveRange(num, list.Count - num);
    }

    public T this[int i] {
      get { return Get(i); }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator() {
      return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return list.GetEnumerator();
    }
  }
}
