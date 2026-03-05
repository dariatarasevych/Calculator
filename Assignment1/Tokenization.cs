namespace Assignment1;

public class Tokenization
{
   public static string[] Tokenize(string input)
   {
      string[] tokens = new string[100];
      int index = 0;
      string buffer = "";

      foreach (char s in input)
      {
         if (char.IsDigit(s))
         {
            buffer += s;
         }
         else
         {
            if (buffer !="")
            {
               tokens[index] = buffer;
               index ++;
               buffer = "";
            }

            if (s == ' ') continue;
            tokens[index] = s.ToString();
            index++;
         }
      }

      if (buffer != "")
      {
         tokens[index] = buffer;
         index ++;
      }

      string[] result = new string[index];

      for (int i = 0; i < index; i++)
      {
         result[i] = tokens[i];
      }

      return result;
   }
}