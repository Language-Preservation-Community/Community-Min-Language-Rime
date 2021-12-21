using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RomanizationGenerator
{

    class Program
    {


        // using a for loop for each tone markers and change every 9 times
        // For all 9 tones
        // There's no huo 
        static string[] allToneMarkers = { "a", "á", "à", "a", "â", "ǎ", "ā", "a̍", "ǎ",
                                    "e", "é", "è", "e", "ê", "ĕ", "ē", "e̍", "ĕ",
                                    "er", "ér", "èr", "er", "êr", "ĕr", "ēr", "e̍r", "ĕr",
                                    "ere", "ére", "ère", "ere", "êre", "ĕre", "ēre", "e̍re", "ĕre",
                                    "o", "ó", "ò", "o", "ô", "ŏ", "ō", "o̍", "ŏ",
                                    "i", "í", "ì", "i", "î", "ĭ", "ī", "i̍", "ĭ",
                                    "ie", "íe", "ìe", "ie", "îe", "ĭe", "īe", "i̍e", "ĭe",
                                    "ier", "íer", "ìer", "ier", "îer", "ĭer", "īer", "i̍er", "ĭer",
                                    "ir", "ír", "ìr", "ir", "îr", "ĭr", "īr", "i̍r", "ĭr",
                                    "u", "ú", "ù", "u", "û", "ŭ", "ū", "u̍", "ŭ",
                                    "ng", "ńg", "ǹg", "ng", "n̂g", "n̆g","n̄g","n̍g", "n̆g" };






        static void Main(string[] args)
        {
            // huang, huannh, huann
            string[] allPossibleConsonant = { "", "ts", "tsh", "l", "n", "d", "t", "th", "s", "b","m", "n", "ng", "g", "k", "kh", "h",
                                                "j", /*"ch", "chh"*/};

            string[][] allVowels = new string[][] {
                                        new string[]{ "a", "á", "à", "a", "â", "ǎ", "ā", "a̍", "ǎ" },
                                        new string[]{ "ai", "ái", "ài", "ai", "âi", "ǎi", "āi", "a̍i", "ǎi" },
                                        new string[]{ "e", "é", "è", "e", "ê", "ĕ", "ē", "e̍", "ĕ" },
                                        new string[]{ "er", "ér", "èr", "er", "êr", "ĕr", "ēr", "e̍r", "ĕr"},
                                        new string[]{ "ere", "ére", "ère", "ere", "êre", "ĕre", "ēre", "e̍re", "ĕre"},
                                        new string[]{ "i", "í", "ì", "i", "î", "ĭ", "ī", "i̍", "ĭ"},
                                        new string[]{ "ia", "iá", "ià", "ia", "iâ", "iǎ", "iā", "ia̍", "iǎ" },
                                        new string[]{ "iau", "iáu", "iàu", "iau", "iâu", "iǎu", "iāu", "ia̍u", "iǎu" },
                                        new string[]{ "ie", "ié", "iè", "ie", "iê", "iĕ", "iē", "ie̍", "iĕ" },
                                        new string[]{ "io", "ió", "iò", "io", "iô", "iŏ", "iō", "io̍", "iŏ"},
                                        new string[]{ "iu", "iú", "iù", "iu", "iû", "iŭ", "iū", "iu̍", "iŭ"},
                                        new string[]{ "ier", "íer", "ìer", "ier", "îer", "ĭer", "īer", "i̍er", "ĭer"},
                                        new string[]{ "ir", "ír", "ìr", "ir", "îr", "ĭr", "īr", "i̍r", "ĭr"},
                                        new string[]{ "o", "ó", "ò", "o", "ô", "ŏ", "ō", "o̍", "ŏ"},
                                        new string[]{ "oo", "óo", "òo", "oo", "ôo", "ŏo", "ōo", "o̍o", "ŏo"},
                                        // new string[]{ "oa", "oá", "oà", "oa", "oâ", "oǎ", "oā", "oa̍", "oǎ" },
                                        // new string[]{ "oe", "oé", "oè", "oe", "oê", "oĕ", "oē", "oe̍", "oĕ" },
                                        new string[]{ "u", "ú", "ù", "u", "û", "ŭ", "ū", "u̍", "ŭ"},
                                        new string[]{ "ua", "uá", "uà", "ua", "uâ", "uǎ", "uā", "ua̍", "uǎ" },
                                        new string[]{ "uai", "uái", "uài", "uai", "uâi", "uǎi", "uāi", "ua̍i", "uǎi" },
                                        new string[]{ "ue", "ué", "uè", "ue", "uê", "uĕ", "uē", "ue̍", "uĕ" },
                                        new string[]{ "ui", "úi", "ùi", "ui", "ûi", "ŭi", "ūi", "u̍i", "ŭi"},
                                        new string[]{ "ng", "ńg", "ǹg", "ng", "n̂g", "n̆g","n̄g","n̍g", "n̆g" }
            };
            


            // inh, hainn
            string[] allEndings = { "", "h", "t", "p", "k", "n", "m", "ng", "ⁿ", "ⁿh" };

            // Can't think of any other way so gonna create another way to check
            // so we can skip impossible sounds like ngk, ngt, ngh etc

            List<string> irSounds = new List<string> { "ir", "ír", "ìr", "ir", "îr", "ĭr", "īr", "i̍r", "ĭr" };
            List<string> ngSounds = new List<string> { "ng", "ńg", "ǹg", "ng", "n̂g", "n̆g", "n̄g", "n̍g", "n̆g" };
            List<string> ereSounds = new List<string> { "ere", "ére", "ère", "ere", "êre", "ĕre", "ēre", "e̍re", "ĕre" };
            List<string> uSounds = new List<string> { "u", "ú", "ù", "u", "û", "ŭ", "ū", "u̍", "ŭ" };
            List<string> uaiSounds = new List<string> { "uai", "uái", "uài", "uai", "uâi", "uǎi", "uāi", "ua̍i", "uǎi" };
            List<string> soundDontHaveMEnding = new List<string> 
            { 
                "ai", "ái", "ài", "ai", "âi", "ǎi", "āi", "a̍i", "ǎi"
                ,"u", "ú", "ù", "u", "û", "ŭ", "ū", "u̍", "ŭ"
                ,"ui", "úi", "ùi", "ui", "ûi", "ŭi", "ūi", "u̍i", "ŭi"
                ,"ua", "uá", "uà", "ua", "uâ", "uǎ", "uā", "ua̍", "uǎ"
                ,"iu", "iú", "iù", "iu", "iû", "iŭ", "iū", "iu̍", "iŭ"
                ,"io", "ió", "iò", "io", "iô", "iŏ", "iō", "io̍", "iŏ"
                ,"iau", "iáu", "iàu", "iau", "iâu", "iǎu", "iāu", "ia̍u", "iǎu"
                ,"ue", "ué", "uè", "ue", "uê", "uĕ", "uē", "ue̍", "uĕ"
                ,"uai", "uái", "uài", "uai", "uâi", "uǎi", "uāi", "ua̍i", "uǎi"
                ,"ere", "ére", "ère", "ere", "êre", "ĕre", "ēre", "e̍re", "ĕre"
            };

            List<string> soundDontHaveNEnding = new List<string> { 
                                                                   "io", "ió", "iò", "io", "iô", "iŏ", "iō", "io̍", "iŏ"
                                                                   ,"iau", "iáu", "iàu", "iau", "iâu", "iǎu", "iāu", "ia̍u", "iǎu"
                                                                   ,"uai", "uái", "uài", "uai", "uâi", "uǎi", "uāi", "ua̍i", "uǎi"};

            List<string> soundDontHaveEnteringTones = new List<string>
            {
                "iu", "iú", "iù", "iu", "iû", "iŭ", "iū", "iu̍", "iŭ",
                "ui", "úi", "ùi", "ui", "ûi", "ŭi", "ūi", "u̍i", "ŭi",
                "uai", "uái", "uài", "uai", "uâi", "uǎi", "uāi", "ua̍i", "uǎi"
            };

            // we can modify for the dz sounds as well using same logic
            List<string> vowelsThatMConsonantDontHave = new List<string>
            {
                "ir", "ír", "ìr", "ir", "îr", "ĭr", "īr", "i̍r", "ĭr",
                "ier", "íer", "ìer", "ier", "îer", "ĭer", "īer", "i̍er", "ĭer",
                "io", "ió", "iò", "io", "iô", "iŏ", "iō", "io̍", "iŏ",
                "er", "ér", "èr", "er", "êr", "ĕr", "ēr", "e̍r", "ĕr",
                "ere", "ére", "ère", "ere", "êre", "ĕre", "ēre", "e̍re", "ĕre"
            };


            // for tone 4 and 8
            List<string> notEnteringTones = new List<string> { "n", "m", "", "ng", "ⁿ"};

            // All entering tones
            List<string> enteringTone = new List<string> { "h", "t", "p", "k", "ngh", "ⁿh" };


            // this is for putting the tones out
            int indexForToneMarkers = 0;

            string combination;

            StreamWriter writer = new StreamWriter("Romanization.txt");


            foreach (string consonant in allPossibleConsonant)
            {
                foreach (string[] vowelCombination in allVowels)
                {
                    foreach (string ending in allEndings)
                    {

                        foreach (string tone in vowelCombination)
                        {
                            indexForToneMarkers++;

                            if (indexForToneMarkers == 10)
                            {
                                indexForToneMarkers = 1;
                            }

                            // for ng
                            if (ngSounds.Exists(x => x.Equals(tone)) && (!ending.Equals("h") || ending.Equals("")))
                            {
                                // skipping the impossible ng sounds =.=
                                continue;

                            }

                            // ir sounds generally don't have any endings
                            if (irSounds.Exists(x => x.Equals(tone)) && (!ending.Equals("")))
                            {
                                continue;
                            }

                            // Skip sounds that impossible to have m at the end like uim, uem
                            if (soundDontHaveMEnding.Exists(x => x.Equals(tone)) && ending.Equals("m"))
                            {
                                continue;
                            }

                            // no mam, mom, miom etc
                            if (consonant.Equals("m") && ending.Equals("m"))
                            {
                                continue;
                            }

                            if (consonant.Equals("m") && vowelsThatMConsonantDontHave.Exists(x => x.Equals(tone)))
                            {
                                continue;
                            }

                            if (soundDontHaveEnteringTones.Exists(x => x.Equals(tone)) && enteringTone.Exists(x => x.Equals(ending)))
                            {
                                continue;
                            }    

                            // Skip sounds that impossible to have n and nn at the end like uin
                            if (soundDontHaveNEnding.Exists(x => x.Equals(tone)) && (ending.Equals("n") || ending.Equals("ⁿ")))
                            {
                                continue;
                            }

                            // skip tone 4 or 8 while is not -p,-k,-t,-h endings
                            if ((indexForToneMarkers == 4 || indexForToneMarkers == 8) && notEnteringTones.Exists(x => x.Equals(ending)))
                            {

                                continue;
                            }

                            // skip the tone that are not 4 or 8 while ending is p, t, k ,h
                            if ((indexForToneMarkers != 4 && indexForToneMarkers != 8) && enteringTone.Exists(x => x.Equals(ending)))
                            {
                                continue;
                            }

                            string modifiedEnding = ending;

                            if (ending.Contains("ⁿ"))
                            {
                                modifiedEnding = modifiedEnding.Replace("ⁿ", "nn");
                            }

                            combination = consonant + tone + ending + "\t" + consonant + vowelCombination[0] + modifiedEnding + indexForToneMarkers.ToString();
                            Console.WriteLine(combination);
                            writer.WriteLine(combination);


                        }
                        
                    }

                }

            }

            writer.Close();
        }
    }
}
