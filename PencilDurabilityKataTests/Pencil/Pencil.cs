using System;

namespace PencilLibrary
{
    public class Pencil
    {
        
        private int durability = 0;
        private int maxDurability = 0;

      
        public Pencil(int durability)
        {
            this.durability = durability;
            maxDurability = durability;
        }


        public int getDurability() => durability;

        public int getMaxDurability() => maxDurability;


        public string write(string WritingString, string StartingString = "")
        {
            string output = StartingString;

            foreach (char c in WritingString)
            {
                if (char.IsUpper(c))
                    durability -= 2;
                else if (char.IsLower(c))
                    durability -=1;

                output += c;
            }

            return output;
        }

       public void sharpen()
        {
            durability = maxDurability;
        }

    }
}
