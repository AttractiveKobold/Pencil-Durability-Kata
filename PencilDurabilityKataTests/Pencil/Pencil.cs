namespace PencilLibrary
{
    public class Pencil
    {

        private int pointDurability = 0;
        private int maxDurability = 0;
        private int length = 0;
        private int eraserDurability = 0;


        public Pencil(int pointDurability, int length, int eraserDurability)
        {
            this.pointDurability = pointDurability;
            this.maxDurability = pointDurability;
            this.length = length;
            this.eraserDurability = eraserDurability;
        }


        public int getPointDurability() => pointDurability;

        public int getMaxDurability() => maxDurability;

        public int getLength() => length;

        public int getEraserDurability() => eraserDurability;


        public string write(string toWrite, string startingString = "")
        {
            string output = startingString;

            foreach (char c in toWrite)
            {
                if (char.IsUpper(c))
                {
                    if (pointDurability >= 2)
                        pointDurability -= 2;
                    else
                    {
                        output += ' ';
                        continue;
                    }
                }
                else if (c == ' ' || c == '\n')
                {
                    //do nothing because ' ' and '\n' do not degrade point durability
                }
                else
                {
                    if (pointDurability >= 1)
                        pointDurability -= 1;
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
                pointDurability = maxDurability;
                length--;
            }
        }

        public string erase(string toErase, string startingString)
        {
            if (!startingString.Contains(toErase))
                return startingString;

            int index = startingString.LastIndexOf(toErase);

            string stringSection = startingString.Substring(index, toErase.Length);

            char[] sectionArray = stringSection.ToCharArray();

            for (int i = sectionArray.Length - 1; i > -1; i--)
            {
                if (eraserDurability <= 0)
                    break;

                if (sectionArray[i] != ' ')
                    eraserDurability--;
                sectionArray[i] = ' ';
            }

            stringSection = new string(sectionArray);            

            return startingString.Remove(index, toErase.Length).Insert(index, stringSection);
        }

        public string edit(string toWrite, string startingString, int n = 1)
        {
            int index = startingString.IndexOf("  ") + 1;
            n--;

            while (n > 0)
            {
                for (int i = index; i < startingString.Length - 1; i++)
                {
                    if (!char.IsWhiteSpace(startingString[i]))
                    {
                        index = i;
                        break;
                    }
                }

                index = startingString.IndexOf("  ", index) + 1;

                n--;
            }
            
            char[] startArray = startingString.ToCharArray();
            char[] writeArray = toWrite.ToCharArray();

            int j = 0;

            for (int i = index; i < (index + writeArray.Length) && i < startingString.Length - 1; i++)
            {
                if(pointDurability == 0)
                    break;

                if (startArray[i] == ' ')
                    startArray[i] = writeArray[j];
                else
                    startArray[i] = '@';

                pointDurability--;

                j++;
            }

            return new string(startArray);
        }
    }
}
