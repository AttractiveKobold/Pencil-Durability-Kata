using System;

namespace PencilLibrary
{
    public class Pencil
    {

        private int durability = 0;
        private int maxDurability = 0;
        private int length = 0;


        public Pencil(int durability, int length)
        {
            this.durability = durability;
            maxDurability = durability;
            this.length = length;
        }


        public int getDurability() => durability;

        public int getMaxDurability() => maxDurability;

        public int getLength() => length;


        public string write(string toWrite, string startingString = "")
        {
            string output = startingString;

            foreach (char c in toWrite)
            {
                if (char.IsUpper(c))
                {
                    if (durability >= 2)
                        durability -= 2;
                    else
                    {
                        output += ' ';
                        continue;
                    }
                }
                else if (char.IsLower(c))
                {
                    if (durability >= 1)
                        durability -= 1;
                    else
                    {
                        output += ' ';
                        continue;
                    }
                }

                output += c;
            }

            return output;
        }

        public void sharpen()
        {
            if (length > 0)
            {
                durability = maxDurability;
                length -= 1;
            }
        }

        public string erase(string toErase, string startingString)
        {
            int index = startingString.LastIndexOf(toErase);
            string blanks = new string(' ', toErase.Length);

            return startingString.Remove(index, toErase.Length).Insert(index, blanks);
        }

    }
}
