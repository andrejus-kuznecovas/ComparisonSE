using Patagames.Ocr;
using Patagames.Ocr.Enums;

namespace CSE.Source
{
    class ImageRecogniser
    {
        public string ImageToText(string imgPath)
        {
            using (var api = OcrApi.Create())
            {
                api.Init(new Languages[] { Languages.Lithuanian, Languages.English });
                api.PageSegmentationMode = PageSegMode.PSM_SINGLE_BLOCK;
                string plainText = api.GetTextFromImage(@imgPath);
                return plainText;
            }
        }
    }
}
