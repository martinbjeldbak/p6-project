using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GANNAI {
  
  //Individuals in this list are guaranteed to be sorted according to fitness, such that the most fit individual is at index 0
  public class SortList<T> where T : IComparable {
    List<T> list;
    public int Count {
      get { return list.Count; }
    }
    
    public SortList() {
      list = new List<T>();
    }

    /// <summary>
    /// Constructs a new list of 'count' sorted items merged from two other sorted list of items
    /// </summary>
    /// <param name="l1">The first item list</param>
    /// <param name="l2">The second item list</param>
    /// <param name="count">The number of sorted items to contain</param>

    public SortList(SortList<T> l1, SortList<T> l2, int count) : this() {
      int a = 0;
      int b = 0;
      int i = count;

      //while both lists are not exhausted
      while (l1.Count - a > 0 && l2.Count - b > 0 && i > 0) {
        if (l1.list[a].CompareTo(l2.list[b]) == 1) {
          list.Add(l1.list[a]);
          a++;
          i--;
        }
        else {
          list.Add(l2.list[b]);
          b++;
          i--;
        }
      }

      //if list 1 is not exhausted, add all elements that remain
      if (a != l1.list.Count && i > 0) {
        list.AddRange(l1.list.GetRange(a, Math.Min(l1.list.Count - a, i)));
      }
      //if list 2 is not exhausted, add all elements that remain
      else if (b != l2.list.Count && i > 0) {
        list.AddRange(l2.list.GetRange(b, Math.Min(l2.list.Count - b, i)));
      }
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

  }
}
