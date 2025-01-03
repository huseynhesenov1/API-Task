using Microsoft.AspNetCore.Http;

namespace StoreManagment.BL.Utilities;

public static class FileManager
{
    public static bool CheckSize(this IFormFile formFile, int size)
    {
        if (formFile.Length > size * 1024 * 1024)
        {
            return false;
        }
        return true;
    }

    public static bool CheckType(this IFormFile formFile)
    {
        string extension = Path.GetExtension(formFile.FileName);
        string[] AllowFormat = [".png", ".jpg", ".jpeg"];
        bool isAlllowed = false;
        foreach (var item in AllowFormat)
        {
            if (item == extension)
            {
                isAlllowed = true;
                break;
            }
        }
        return isAlllowed;
    }
}