using System;
using System.Text.RegularExpressions;

namespace CSE
{
    public class Parser
    {
        public static Shop GetShopName(string text) {
            foreach (string shopName in Enum.GetNames(typeof(Shop)))  // loop through all the shops (their names)
            {
                if (shopName != "UNKNOWN_SHOP") {
                    string shopPattern = @"\\b" + shopName.ToLower() + "\\b"; // look for the name of enum as one word

                    bool matching = Regex.IsMatch(text, shopPattern, RegexOptions.IgnoreCase);
                    if (matching)
                    {
                        return (Shop)Enum.Parse(typeof(Shop), shopName); // return enum parsed from the shop name
                    }
                }
            }
            return Shop.UNKNOWN_SHOP; // if nothing is found, return unknown shop
        }

        public static float GetPrice(string text) {
            string pricePattern = @"(\\d+(\\.|,)\\s?\\d{1,2})\\s?\u20ac?";
            float result;
            Match priceMatch = Regex.Match(text, pricePattern);
            try
            {
                string preparedMatch = priceMatch.Groups[1].Value.Replace(" ","");
                preparedMatch = preparedMatch.Replace(',', '.');
                result = float.Parse(preparedMatch);
                return result;
            }
            catch(FormatException e) {
                return -1f;
            }
        }
    }
}
