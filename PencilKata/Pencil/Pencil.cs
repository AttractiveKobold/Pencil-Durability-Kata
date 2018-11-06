﻿namespace PencilLibrary
{
    public class Pencil
    {

        private int pointDurability = 0;
        private int maxDurability = 0;
        private int length = 0;
        private int eraserDurability = 0;

        private const int capitalLetterPointDegredation = 2;
        private const int lowercaseLetterPointDegredation = 1;
        private const int eraserDegredationAmount = 1;

        public int getPointDurability() => pointDurability;
        public int getMaxDurability() => maxDurability;
        public int getLength() => length;
        public int getEraserDurability() => eraserDurability;



        public Pencil(int pointDurability, int length, int eraserDurability)
        {
            this.pointDurability = pointDurability;
            this.maxDurability = pointDurability;
            this.length = length;
            this.eraserDurability = eraserDurability;
        }



        public string Write(string textToWrite, string startingString = "")
        {
            string output = startingString;

            foreach (char c in textToWrite)
            {

                if (degradePoint(c))
                    output += c;
                else
                    output += ' ';
            }

            return output;
        }

        private bool degradePoint(char myChar)
        {
            if (char.IsUpper(myChar) && pointDurability >= capitalLetterPointDegredation)
            {
                pointDurability -= capitalLetterPointDegredation;

            }
            else if (checkIfShouldDegradeLower(myChar))
            { 
                    pointDurability -= lowercaseLetterPointDegredation;
            }
            else
            {
                    return false;
            }

            return true;
        }

        private bool checkIfShouldDegradeLower(char myChar)
        {
            if (!char.IsUpper(myChar) && !(myChar == ' ' || myChar == '\n') && pointDurability >= lowercaseLetterPointDegredation)
                return true;
            else
                return false;
        }



        public void Sharpen()
        {
            if (length > 0)
            {
                pointDurability = maxDurability;
                length--;
            }
        }



        public string Erase(string textToErase, string startingString)
        {
            if (!startingString.Contains(textToErase))
                return startingString;

            int index = startingString.LastIndexOf(textToErase);

            string stringSection = startingString.Substring(index, textToErase.Length);

            char[] sectionArray = stringSection.ToCharArray();

            for (int i = sectionArray.Length - 1; i > -1; i--)
            {
                if (eraserDurability < eraserDegredationAmount)
                    break;

                if (sectionArray[i] != ' ')
                    eraserDurability -= eraserDegredationAmount;
                sectionArray[i] = ' ';
            }

            stringSection = new string(sectionArray);

            return startingString.Remove(index, textToErase.Length).Insert(index, stringSection);
        }

        

        public string Edit(string textToWrite, string startingString, int blankSpaceToEdit = 1)
        {
            int index = getIndexOfBlankSpace(blankSpaceToEdit, startingString);
            
            if (index == -1)
                return startingString; 

            char[] textToEditArray = startingString.ToCharArray();
            char[] textToWriteArray = textToWrite.ToCharArray();

            for (int i = index, j = 0; i < (index + textToWriteArray.Length) && i < startingString.Length - 1; i++, j++)
            {
                if (pointDurability == 0)
                    break;


                if (textToEditArray[i] == ' ')
                    textToEditArray[i] = textToWriteArray[j];
                else
                    textToEditArray[i] = '@';


                pointDurability--;
            }

            return new string(textToEditArray);
        }

        //returns -1 if the specified blank space does not exist
        private int getIndexOfBlankSpace(int blankSpaceToEdit, string text)
        {
            int index = 0;

            index = text.IndexOf("  ");
            blankSpaceToEdit--;

            while (blankSpaceToEdit > 0)
            {
                for (int i = index; i < text.Length - 1; i++)
                {
                    if (index == -1)
                        return index; //blank space was not found

                    if (!char.IsWhiteSpace(text[i]))
                    {
                        index = i;
                        break;
                    }
                }

                index = text.IndexOf("  ", index);
                blankSpaceToEdit--;
            }

            if (index > 0)
                index++;

            return index;
        }
    }
}
