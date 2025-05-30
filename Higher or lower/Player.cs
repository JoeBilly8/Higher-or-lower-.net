using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Higher_or_lower
{
    public class Player
    {
        private string Name { get; set; }
        private int Points { get; set; }
        private bool IsGo {  get; set; }

        public Player(string name, int points, bool isGo)
        {
            Name = name;
            Points = points;
            IsGo = isGo;
        }

        public string GetName() 
        { 
            return Name; 
        }
        public int GetPoints() 
        { 
            return Points; 
        }
        public void SetPoints(int points)
        {
            Points = points;
        }
        public int GetGoStatus() 
        { 
            return IsGo ? 1 : 0; 
        }
    }
}
