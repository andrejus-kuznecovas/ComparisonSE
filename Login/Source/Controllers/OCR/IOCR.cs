using System.Threading.Tasks;

namespace Login.Source.Controllers.OCR
{
    interface IOCR
    {
        Task GetTextFromImage(byte[] image);
    }
}