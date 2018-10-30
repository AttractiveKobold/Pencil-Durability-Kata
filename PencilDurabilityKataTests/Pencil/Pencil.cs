using System;

namespace PencilLibrary
{
    public class Pencil
    {
        
        private int durability = 0;


      
        public Pencil(int durability)
        {
            this.durability = durability;
        }

        public string write(string WritingString, string StartingString = "")
        {
            durability -= WritingString.Length;
            return StartingString + WritingString;
        }

        public int getDurability() => durability;

    }
}
