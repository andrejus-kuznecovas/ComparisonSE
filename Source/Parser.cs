using System;
using System.Text.RegularExpressions;

namespace CSE
{
    public class Parser
    {
        public static Shop GetShopName(string text) {
            foreach (string shopName in Enum.GetNames(typeof(Shop)))
            {
                if (shopName != "UNKNOWN_SHOP") {
                    string shopPattern = "\\b" + shopName.ToLower() + "\\b";

                    bool matching = Regex.IsMatch(text, shopPattern, RegexOptions.IgnoreCase);
                    if (matching)
                    {
                        return (Shop)Enum.Parse(typeof(Shop), shopName);
                    }
                }
            }
            return Shop.UNKNOWN_SHOP;
        }
    }
}
