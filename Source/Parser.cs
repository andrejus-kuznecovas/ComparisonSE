using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSE
{
    public class Parser
    {
        public static Shop GetShopName(string text) {
            Dictionary<Shop, string[]> shopUniqueTexts = new Dictionary<Shop, string[]>();
            shopUniqueTexts.Add(Shop.IKI, new string[]{ "palink", "iki"});
            shopUniqueTexts.Add(Shop.MAXIMA, new string[] { @"maxim(a|[^u]\w+)"});
            shopUniqueTexts.Add(Shop.RIMI, new string[] { "rimi" });
            shopUniqueTexts.Add(Shop.LIDL, new string[] { @"lidl\w*" });
            shopUniqueTexts.Add(Shop.NORFA, new string[] { @"norf\w+" });
            string receiptText = Parser.RemoveInternationalLetters(text);

            foreach (KeyValuePair<Shop,string[]> shopInfo in shopUniqueTexts)  // loop through all the shops (their names)
            {
                foreach(string shopIdentifier in shopInfo.Value) {
                    string shopPattern = @"\b" + shopIdentifier.ToLower() + @"\b"; // look for the name of enum as one word
                    Shop currentShop = shopInfo.Key;
    
                    bool matching = Regex.IsMatch(receiptText, shopPattern, RegexOptions.IgnoreCase);
                    if (matching)
                    {
                        return currentShop; // return Shop
                    }
                }
            }
            return Shop.UNKNOWN_SHOP; // if nothing is found, return unknown shop
        }

        public static float ExtractPriceFloat(string text) {
            string pricePattern = @"(-?\d+(\.|,)\s?\d{1,2})\s?(A|N)\b"; // match price-formatted float
            float result;
            Match priceMatch = Regex.Match(RemoveInternationalLetters(text),
                pricePattern, RegexOptions.IgnoreCase);
            try
            {
                string preparedMatch = priceMatch.Groups[1].Value.Replace(" ","");
                preparedMatch = preparedMatch.Replace(',', '.'); // replace , to . for parsing
                result = float.Parse(preparedMatch);
                return result;
            }
            catch(FormatException e) {
                return -1000f;
            }
        }

        // Replace international letter with its latin form (e.g. Š->S)
        public static string RemoveInternationalLetters(string text)
        {
            return String.Join("", text.Normalize(NormalizationForm.FormD)
                .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
        }

        public static string RemoveNonLetters(string text)
        {
            string patternForPrice = @"(-?\d+(\.|,)\s?\d{1,2})\s?(A|N)\b";
            string textWithoutPrice = Regex.Replace(text, patternForPrice, "");
            textWithoutPrice = RemoveInternationalLetters(textWithoutPrice);
            string patternForLetters = @"[^a-zA-Z\s]";
            string replaced = Regex.Replace(textWithoutPrice, patternForLetters, "");
            return RemoveTrailingWhitespace(replaced);
        }

        public static string RemoveTrailingWhitespace(string text)
        {
            string whitespacePattern = @"\s+$";
            return Regex.Replace(text, whitespacePattern, "");
        }


        
    }
}
