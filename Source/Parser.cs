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
            string receiptText = Parser.RemoveInternationalLetters(text);
            shopUniqueTexts.Add(Shop.IKI, new string[]{ "palink", "iki"});
            shopUniqueTexts.Add(Shop.MAXIMA, new string[] { "maxima"});
            shopUniqueTexts.Add(Shop.RIMI, new string[] { "rimi" });
            shopUniqueTexts.Add(Shop.LIDL, new string[] { "lidl" });
            shopUniqueTexts.Add(Shop.NORFA, new string[] { "norfa" });

            foreach (KeyValuePair<Shop,string[]> shopInfo in shopUniqueTexts)  // loop through all the shops (their names)
            {
                foreach(string shopIdentifier in shopInfo.Value) {
                    string shopPattern = "\\b" + shopIdentifier.ToLower() + "\\b"; // look for the name of enum as one word

                    bool matching = Regex.IsMatch(receiptText, shopPattern, RegexOptions.IgnoreCase);
                    if (matching)
                    {
                        return shopInfo.Key; // return enum parsed from the shop name
                    }
                }
            }
            return Shop.UNKNOWN_SHOP; // if nothing is found, return unknown shop
        }

        public static float ExtractPriceFloat(string text) {
            string pricePattern = "(-?\\d+(\\.|,)\\s?\\d{1,2})\\s?(A|N)\\b";
            float result;
            Match priceMatch = Regex.Match(text, pricePattern, RegexOptions.IgnoreCase);
            try
            {
                string preparedMatch = priceMatch.Groups[1].Value.Replace(" ","");
                preparedMatch = preparedMatch.Replace(',', '.');
                result = float.Parse(preparedMatch);
                return result;
            }
            catch(FormatException e) {
                return -1000f;
            }
        }

        public static string RemoveInternationalLetters(string text) {
            return String.Join("", text.Normalize(NormalizationForm.FormD)
                .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
        }
    }
}
