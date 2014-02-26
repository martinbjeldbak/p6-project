using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  
  //Individuals in this list are guaranteed to be sorted according to fitness, such that the most fit individual is at index 0
  public class IndividualList {
    AITrainableGame game;
    List<AIPlayer> list;
    public int Count {
      get { return list.Count; }
    }
    
    public IndividualList(AITrainableGame game) {
      this.game = game;
      list = new List<AIPlayer>();
    }

    //Constructs a new list of sorted individuals merged from two other sorted list of individuals
    public IndividualList(IndividualList l1, IndividualList l2, AITrainableGame game) : this(game) {
      int i = Math.Min(l1.Count, l2.Count);
      int a = 0;
      int b = 0;

      //while both lists are not exhausted
      while (i > 0) {
        if (l1.list[a].GetFitness() > l2.list[b].GetFitness()) {
          list.Add(l1.list[a]);
          a++;
        }
        else {
          list.Add(l2.list[b]);
          b++;
        }
        i--;
      }

      //if list 1 is not exhausted, add all elements that remain
      if (a != l1.list.Count) {
        list.AddRange(l1.list.GetRange(a, l1.list.Count - a));
      }
      //if list 2 is not exhausted, add all elements that remain
      if (b != l2.list.Count) {
        list.AddRange(l2.list.GetRange(b, l2.list.Count - b));
      }
    }

    //Removes all individuals
    public void Clear() {
      list.Clear();
    }

    //Inserts an individual in a list such that it remains sorted according to fitness values
    public void Add(AIPlayer individual){
      if (list.Count == 0) {
        list.Add(individual);
        return;
      }
      
      int left = 0;
      int right = list.Count+1;
      
      while (left + 1 != right){
        int newIndex = (left + right) / 2;
        if (individual.GetFitness() > list[newIndex].GetFitness()) {
          right = newIndex;
        }
        else {
          left = newIndex;
        }
      }
      list.Insert(right, individual);
    }
    public AIPlayer Get(int index){
      return list[index];
    }

  }
}
