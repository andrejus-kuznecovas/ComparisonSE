using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Login
{
    public class Parser
    {
        /// <summary>
        /// Find shop name in the text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Shop GetShopName(string text) {

            // Different shops can be spelled differently depending on the context
            Dictionary<Shop, string[]> shopUniqueTexts = new Dictionary<Shop, string[]>();
            shopUniqueTexts.Add(Shop.IKI, new string[]{ "palink", "iki"});
            shopUniqueTexts.Add(Shop.MAXIMA, new string[] { @"maxim(a|[^u]\w+)"});
            shopUniqueTexts.Add(Shop.RIMI, new string[] { "rimi" });
            shopUniqueTexts.Add(Shop.LIDL, new string[] { @"lidl\w*" });
            shopUniqueTexts.Add(Shop.NORFA, new string[] { @"norf\w+" });

            // Helps to prevent some corner cases, e.g "maximą" => "maxima"
            string receiptText = RemoveInternationalLetters(text);

            // loop through all the shops (their names)
            foreach (KeyValuePair<Shop,string[]> shopInfo in shopUniqueTexts)  
            {
                foreach(string shopIdentifier in shopInfo.Value) {
                    // look for the name as one word
                    string shopPattern = @"\b" + shopIdentifier.ToLower() + @"\b"; 
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

        /// <summary>
        /// Get price float in text, if present
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static float ExtractPriceFloat(string text) {
            // match price-formatted float
            string pricePattern = @"(-?\d+(\.|,)\s?\d{1,2})\s?(A|N)\b"; 
            float result;
            Match priceMatch = Regex.Match(RemoveInternationalLetters(text),
                pricePattern, RegexOptions.IgnoreCase);
            try
            {
                // Format text to be easier to detect float
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

        /// <summary>
        /// Replaces everything, that is not a latin letter
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveNonLetters(string text)
        {
            string patternForPrice = @"(-?\d+(\.|,)\s?\d{1,2})\s?(A|N)\b";
            string textWithoutPrice = Regex.Replace(text, patternForPrice, "");
            textWithoutPrice = RemoveInternationalLetters(textWithoutPrice);
            string patternForLetters = @"[^a-zA-Z\s]";
            string replaced = Regex.Replace(textWithoutPrice, patternForLetters, "");
            return RemoveTrailingWhitespace(replaced);
        }

        /// <summary>
        /// Removes unnecessary whitespaces at the end of the string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveTrailingWhitespace(string text)
        {
            string whitespacePattern = @"\s+$";
            return Regex.Replace(text, whitespacePattern, "");
        }

        public static bool FindEurKg(string text)
        {
            if (text.Contains("EUR/kg"))
                return true;
            else return false;
        }

        
    }
}
