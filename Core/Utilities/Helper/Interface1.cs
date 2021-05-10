using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helper
{
    public interface IFileHelper
    {
        IDataResult<string> Upload(IFormFile file, string path, string fileType);
        IResult Delete(string path, string file);
        IResult Move(string oldPath, string newPath);
        IDataResult<string> FileControl(IFormFile file, string[] fileExtention);
        IDataResult<string[]> FileExtensionRotates(string FileType);
    }
}
