using Syntra.Cli.Ext;
using System.Text;

namespace Syntra.MyProject.Lib
{
    public class GreekAccents : ICliExecutable
    {
        public string Name => GetType().Name;
        public string Description => "Awsome extension made by Yannick";

        // Define an enum for the accent patterns.
        public enum AccentPattern
        {
            None = 0,
            Oxy, // Oxytone: acute on the last vowel.
            Paroxy, // Paroxytone: acute on the second last vowel.
            Propar, // Proparoxytone: acute on the third last vowel.
            Per, // Perispomenon: circumflex on the last vowel.
            Proper // Properispomenon: circumflex on the second last vowel.
            
        }

        public bool Execute(ICliRuntime owner, ICliCommand parameters)
        {
            Console.InputEncoding = Encoding.UTF8;
            if((parameters.Command.ToLower() == "greek")&&(parameters.Parameters.Count > 0)) {
               return ProcessOption(parameters.Parameters[0]);
            }
            return false;
        }
        public bool ProcessOption(ICliCommandParameter parameter)
        {
            try
            {
                // Use a switch statement to parse the accent pattern from the user input.
                AccentPattern pattern = parameter.Option.ToLower() switch
                {
                    "--oxy" => AccentPattern.Oxy,
                    "--paroxy" => AccentPattern.Paroxy,
                    "--propar" => AccentPattern.Propar,
                    "--per" => AccentPattern.Per,
                    "--proper" => AccentPattern.Proper,
                    _ => AccentPattern.None,
                };
                if(pattern == AccentPattern.None) {
                    Console.WriteLine("Something went wrong. The accent patterns are: -oxy, -paroxy, -propar, -per, and -proper.");
                    return false;
                }
                if(!parameter.HasValue)
                {
                    Console.WriteLine("Please provide a Greek word");
                    return false;
                }

                string result = AnalyzeAndAccent(parameter.Value, pattern);
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("Result: " + result + ".");
            } catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return true;
        }
        public static string AnalyzeAndAccent(string word, AccentPattern accentPattern)
        {
            List<char> Vowels = new List<char>();
            Vowels.Add('α');
            Vowels.Add('ἀ');
            Vowels.Add('ἁ');
            Vowels.Add('ε');
            Vowels.Add('ἐ');
            Vowels.Add('ἑ');
            Vowels.Add('η');
            Vowels.Add('ἠ');
            Vowels.Add('ἡ');
            Vowels.Add('ι');
            Vowels.Add('ἰ');
            Vowels.Add('ἱ');
            Vowels.Add('ο');
            Vowels.Add('ὀ');
            Vowels.Add('ὁ');
            Vowels.Add('υ');
            Vowels.Add('ὐ');
            Vowels.Add('ὑ');
            Vowels.Add('ω');
            Vowels.Add('ὠ');
            Vowels.Add('ὡ');
            Vowels.Add('Α');
            Vowels.Add('Ε');
            Vowels.Add('Η');
            Vowels.Add('Ι');
            Vowels.Add('Ο');
            Vowels.Add('Υ');
            Vowels.Add('Ω');

            List<string> VowelPairs = new List<string>();
            VowelPairs.Add("αι");
            VowelPairs.Add("αἰ");
            VowelPairs.Add("αἱ");
            VowelPairs.Add("αυ");
            VowelPairs.Add("αὐ");
            VowelPairs.Add("αὑ");
            VowelPairs.Add("ει");
            VowelPairs.Add("εἰ");
            VowelPairs.Add("εἱ");
            VowelPairs.Add("ευ");
            VowelPairs.Add("εὐ");
            VowelPairs.Add("εὑ");
            VowelPairs.Add("ηυ");
            VowelPairs.Add("ηὐ");
            VowelPairs.Add("ηὑ");
            VowelPairs.Add("οι");
            VowelPairs.Add("οἰ");
            VowelPairs.Add("οἱ");
            VowelPairs.Add("ου");
            VowelPairs.Add("οὐ");
            VowelPairs.Add("οὑ");
            VowelPairs.Add("υι");
            VowelPairs.Add("υἰ");
            VowelPairs.Add("υἱ");
            VowelPairs.Add("ωυ");
            VowelPairs.Add("ωὐ");
            VowelPairs.Add("ωὑ");
            VowelPairs.Add("Αι");
            VowelPairs.Add("Αἰ");
            VowelPairs.Add("Αἱ");
            VowelPairs.Add("Αυ");
            VowelPairs.Add("Αὐ");
            VowelPairs.Add("Αὑ");
            VowelPairs.Add("Ει");
            VowelPairs.Add("Εἰ");
            VowelPairs.Add("Εἱ");
            VowelPairs.Add("Ευ");
            VowelPairs.Add("Εὐ");
            VowelPairs.Add("Εὑ");
            VowelPairs.Add("Ηυ");
            VowelPairs.Add("Ηὐ");
            VowelPairs.Add("Ηὑ");
            VowelPairs.Add("Οι");
            VowelPairs.Add("Οἰ");
            VowelPairs.Add("Οἱ");
            VowelPairs.Add("Ου");
            VowelPairs.Add("Οὐ");
            VowelPairs.Add("Οὑ");
            VowelPairs.Add("Υι");
            VowelPairs.Add("Υἰ");
            VowelPairs.Add("Υἱ");
            VowelPairs.Add("Ωυ");
            VowelPairs.Add("Ωὐ");
            VowelPairs.Add("Ωὑ");
            VowelPairs.Add("ΑΙ");
            VowelPairs.Add("ΑἸ");
            VowelPairs.Add("ΑἹ");
            VowelPairs.Add("ΑΥ");
            VowelPairs.Add("ΑὙ");
            VowelPairs.Add("ΕΙ");
            VowelPairs.Add("ΕἸ");
            VowelPairs.Add("ΕἹ");
            VowelPairs.Add("ΕΥ");
            VowelPairs.Add("ΕὙ");
            VowelPairs.Add("ΗΥ");
            VowelPairs.Add("ΗὙ");
            VowelPairs.Add("ΟΙ");
            VowelPairs.Add("ΟἸ");
            VowelPairs.Add("ΟἹ");
            VowelPairs.Add("ΟΥ");
            VowelPairs.Add("ΟὙ");
            VowelPairs.Add("ΥΙ");
            VowelPairs.Add("ΥἸ");
            VowelPairs.Add("ΥἹ");
            VowelPairs.Add("ΩΥ");
            VowelPairs.Add("ΩὙ");

            Dictionary<char, char> vowelAcuteMap = new Dictionary<char, char>
            {
                {'α', 'ά'},
                {'ἀ', 'ἄ'},
                {'ἁ', 'ἅ'},
                {'ε', 'έ'},
                {'ἐ', 'ἔ'},
                {'ἑ', 'ἕ'},
                {'η', 'ή'},
                {'ἠ', 'ἤ'},
                {'ἡ', 'ἥ'},
                {'ι', 'ί'},
                {'ἰ', 'ἴ'},
                {'ἱ', 'ἵ'},
                {'ο', 'ό'},
                {'ὀ', 'ὄ'},
                {'ὁ', 'ὅ'},
                {'υ', 'ύ'},
                {'ὐ', 'ὔ'},
                {'ὑ', 'ὕ'},
                {'ω', 'ώ'},
                {'ὠ', 'ὤ'},
                {'ὡ', 'ὥ'},
                {'Α', 'Ά'},
                {'Ἀ', 'Ἄ'},
                {'Ἁ', 'Ἅ'},
                {'Ε', 'Έ'},
                {'Ἐ', 'Ἔ'},
                {'Ἑ', 'Ἕ'},
                {'Η', 'Ή'},
                {'Ἠ', 'Ἤ'},
                {'Ἡ', 'Ἥ'},
                {'Ι', 'Ί'},
                {'Ἰ', 'Ἴ'},
                {'Ἱ', 'Ἵ'},
                {'Ο', 'Ό'},
                {'Ὀ', 'Ὄ'},
                {'Ὁ', 'Ὅ'},
                {'Υ', 'Ύ'},
                {'Ὑ', 'Ὕ'},
                {'Ω', 'Ώ'},
                {'Ὠ', 'Ὤ'},
                {'Ὡ', 'Ὥ'}
            };
            Dictionary<char, char> vowelPerispomenonMap = new Dictionary<char, char>
            {
                {'α', 'ᾶ'},
                {'ἀ', 'ἆ'},
                {'ἁ', 'ἇ'},
                {'η', 'ῆ'},
                {'ἠ', 'ἦ'},
                {'ἡ', 'ἧ'},
                {'ι', 'ῖ'},
                {'ἰ', 'ἶ'},
                {'ἱ', 'ἷ'},
                {'υ', 'ῦ'},
                {'ὐ', 'ὖ'},
                {'ὑ', 'ὗ'},
                {'ω', 'ῶ'},
                {'ὠ', 'ὦ'},
                {'ὡ', 'ὧ'},
                {'Ἀ', 'Ἆ'},
                {'Ἁ', 'Ἇ'},
                {'Ἠ', 'Ἦ'},
                {'Ἡ', 'Ἧ'},
                {'Ἰ', 'Ἶ'},
                {'Ἱ', 'Ἷ'},
                {'Ὑ', 'Ὗ'},
                {'Ὠ', 'Ὦ'},
                {'Ὡ', 'Ὧ'}
            };

            int vowelCount = 0;
            string result = string.Empty;

            // Use a while loop to iterate through the word backwards.
            int i = word.Length - 1;
            while(i >= 0)
            {
                char currentChar = word[i];

                // Check if the character and the previous character form a vowel pair.
                bool isVowelPair = false;

                // Check if the character is a vowel (using the vowel set).
                if(Vowels.Contains(currentChar))
                {
                    vowelCount++;

                    if(i > 0 && VowelPairs.Contains(word[i - 1].ToString() + currentChar.ToString()))
                    {
                        isVowelPair = true;
                    }
                    if(isVowelPair)
                    {
                        string previousChar = word[i - 1].ToString();
                        // Use the enum value to check the accent condition.
                        switch(accentPattern)
                        {
                            case AccentPattern.Oxy when vowelCount == 1:
                                currentChar = GetVowelAccent(currentChar, vowelAcuteMap);
                                result = previousChar + currentChar + result;
                                i--;
                                i--;
                                break;
                            case AccentPattern.Paroxy when vowelCount == 2:
                                currentChar = GetVowelAccent(currentChar, vowelAcuteMap);
                                result = previousChar + currentChar + result;
                                i--;
                                i--;
                                break;
                            case AccentPattern.Propar when vowelCount == 3:
                                currentChar = GetVowelAccent(currentChar, vowelAcuteMap);
                                result = previousChar + currentChar + result;
                                i--;
                                i--;
                                break;
                            case AccentPattern.Per when vowelCount == 1:
                                currentChar = GetVowelAccent(currentChar, vowelPerispomenonMap);
                                result = previousChar + currentChar + result;
                                i--;
                                i--;
                                break;
                            case AccentPattern.Proper when vowelCount == 2:
                                currentChar = GetVowelAccent(currentChar, vowelPerispomenonMap);
                                result = previousChar + currentChar + result;
                                i--;
                                i--;
                                break;
                            default:
                                // Character is an unaccented vowel.
                                result = previousChar + currentChar + result;
                                i--;
                                i--;
                                break;
                        }
                    }
                    else
                    {
                        // Use the enum value to check the accent condition.
                        switch(accentPattern)
                        {
                            case AccentPattern.Oxy when vowelCount == 1:
                                currentChar = GetVowelAccent(currentChar, vowelAcuteMap);
                                result = currentChar + result;
                                i--;
                                break;
                            case AccentPattern.Paroxy when vowelCount == 2:
                                currentChar = GetVowelAccent(currentChar, vowelAcuteMap);
                                result = currentChar + result;
                                i--;
                                break;
                            case AccentPattern.Propar when vowelCount == 3:
                                currentChar = GetVowelAccent(currentChar, vowelAcuteMap);
                                result = currentChar + result;
                                i--;
                                break;
                            case AccentPattern.Per when vowelCount == 1:
                                currentChar = GetVowelAccent(currentChar, vowelPerispomenonMap);
                                result = currentChar + result;
                                i--;
                                break;
                            case AccentPattern.Proper when vowelCount == 2:
                                currentChar = GetVowelAccent(currentChar, vowelPerispomenonMap);
                                result = currentChar + result;
                                i--;
                                break;
                            default:
                                // Character is a consonant or an unaccented vowel.
                                result = currentChar + result;
                                i--;
                                break;
                        }
                    }
                }
                else
                {
                    result = currentChar + result;
                    i--;
                }
            }

            return result;
        }

        // A helper method to map an unaccented vowel or vowel pair to an accented one.
        public static char GetVowelAccent(char currentChar, Dictionary<char, char> dict)
        {
            char accentedChar;
            accentedChar = dict[currentChar];
            return accentedChar;
        }

       
    }
}

